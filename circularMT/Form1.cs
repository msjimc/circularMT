using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Forms;
using System.Windows.Forms.VisualStyles;
using System.Xml.Linq;
using Microsoft.VisualBasic;
using static System.Windows.Forms.AxHost;


namespace circularMT
{
    public partial class Form1 : Form
    {
        string defination = "";
        Dictionary<string, List<feature>> features = new Dictionary<string, List<feature>>();
        int sequencelength = -1;
        Dictionary<string, Brush> colours;
        Dictionary<string, Brush> coloursFont;
        bool resising = false;
        ImageScaling scaling = null;

        int newStartOffset = 0;
        public Form1()
        {
            InitializeComponent();

            scaling = new ImageScaling(96);
        }

        private void btnGenBank_Click(object sender, EventArgs e)
        {
            string filename = FileAccessClass.FileString(FileAccessClass.FileJob.Open, "Seletct the annotation file", "Genbank file (*.gb;*.genbank)|*.gb;*.genbank|Mitos file (*.mitos)|*.mitos|GTF and GFF - ver 3(*.gtf;*.gff)|*.gtf;*.gff|Seq file (*.seq)|*.seq|Bed tile (*.bed;*.txt)|*.bed;*.txt|Fasta file (*.fasta;*.fas:*.fa)|*.fasta;*.fas;*.fa");
            if (System.IO.File.Exists(filename) == false) { return; }

            string extension = filename.Substring(filename.LastIndexOf('.')).ToLower();

            bool done = true;

            switch (extension)
            {
                case ".gb":
                case ".genbank":
                    openGenBank(filename);
                    break;
                case ".fa":
                case ".fas":
                case ".fasta":
                    openFastaFile(filename);
                    break;
                case ".gff":
                    openGFFFile(filename);
                    break;
                case ".gtf":
                    openGTFFile(filename);
                    break;
                case ".mitos":
                    openMITOSFile(filename);
                    break;
                case ".seq":
                    openSEQFile(filename);
                    break;
                case ".bed":
                case ".txt":
                    openBedFile(filename);
                    break;
                default:
                    done = false;
                    break;
            }
            if (done == true)
            { 
                Text = "circularMT: " + filename.Substring(filename.LastIndexOf("\\") + 1);
                newStartOffset = 0;
            }
            else { Text = "circularMT"; }

        }

        private void openSEQFile(string filename)
        {
            defination = "";
            features = new Dictionary<string, List<feature>>();
            int newValue = getSequenceLength();
            if (newValue >-1)
            { sequencelength = newValue; }
            else { return; }

            System.IO.StreamReader fs = null;
            try
            {
                fs = new System.IO.StreamReader(filename);
                string data = fs.ReadToEnd();
                fs.Close();

                string[] lines = data.Split('\n');
                string term = "Feature";
                string[] items = lines[0].Split('\t');

                int one = lines[0].IndexOf(" ") + 1;
                defination = lines[0].Substring(one).Trim();

                items = null;
                string name = "";
                for (int index = lines.Length - 1; index > -1; index--)
                {
                    if (lines[index].StartsWith("\t\t\t") == true)
                    {
                        items = lines[index].Split('\t');
                        name = items[4].Trim();
                    }
                    else if (string.IsNullOrEmpty(name) == false && lines[index].StartsWith(">") == false)
                    {
                        string line = lines[index].Trim() + "\t" + name + "\t" + sequencelength.ToString();
                        items = line.Split('\t');
                        term = items[2];
                        feature f = new feature(items, 0, 0, term, "seq");

                        if (features.ContainsKey(f.FeatureType.Trim()) == false)
                        { features.Add(f.FeatureType, new List<feature>()); }

                        features[f.FeatureType].Add(f);
                    }
                }

                SetUpProgramsData();

                cboStart.Items.Clear();
                cboStart.Items.Add("select");
                foreach (string key in features.Keys)
                {
                    List<feature> lists = features[key];
                    lists.Sort(new featureSorter());
                    foreach (feature f in lists)
                    { cboStart.Items.Add(key + ": " + f.Name); }
                }
                cboStart.SelectedIndex = 0;
                setColours();
                drawFeatures("", scaling);

            }
            catch (Exception ex)
            { MessageBox.Show("Could not open and process the file", "Error"); }
            finally
            { if (fs != null) { fs.Close(); } }

        }

        private void openGFFFile(string filename)
        {
            defination = "";
            features = new Dictionary<string, List<feature>>();
            
            int newValue = getSequenceLength();
            if (newValue > -1)
            { sequencelength = newValue; }
            else { return; }

            System.IO.StreamReader fs = null;

            try
            {

                fs = new System.IO.StreamReader(filename);
                string data = fs.ReadToEnd();
                fs.Close();

                string[] lines = data.Split('\n');
                string term = "Feature";
                string[] items = lines[0].Split('\t');

                items = null;
                foreach (string line in lines)
                {
                    items = line.Split('\t');
                    if (items.Length == 9 && items[0].StartsWith("#") == false)
                    {
                        if (defination == "") { defination = items[0].Trim(); }
                        term = items[2].Trim();
                        feature f = new feature(items, 0, 0, term, "gff");

                        if (features.ContainsKey(f.FeatureType.Trim()) == false)
                        { features.Add(f.FeatureType, new List<feature>()); }

                        features[f.FeatureType].Add(f);
                    }
                }

                SetUpProgramsData();

                cboStart.Items.Clear();
                cboStart.Items.Add("select");
                foreach (string key in features.Keys)
                {
                    List<feature> lists = features[key];
                    lists.Sort(new featureSorter());
                    foreach (feature f in lists)
                    { cboStart.Items.Add(key + ": " + f.Name); }
                }
                cboStart.SelectedIndex = 0;
                setColours();
                drawFeatures("", scaling);

            }
            catch (Exception ex)
            { MessageBox.Show("Could not open and process the file", "Error"); }
            finally
            { if (fs != null) { fs.Close(); } }

        }

        private void SetUpProgramsData()
        {
            chlTerms.Items.Clear();
            Brush[] colourSet = { Brushes.PaleGreen, Brushes.Pink, Brushes.LightBlue, Brushes.LightGray, Brushes.Orange, Brushes.GreenYellow, Brushes.Orchid };
            colours = new Dictionary<string, Brush>();
            coloursFont = new Dictionary<string, Brush>();

            int index = 0;
            foreach (string term in features.Keys)
            {
                foreach (feature f in features[term])
                {
                    Color[] colourPair = getFeatureColour(term);
                    if (colourPair[0] == Color.DarkGoldenrod && colourPair[1] == Color.DarkGoldenrod)
                    { 
                        f.FeatureColour = colourSet[index];
                        if (colours.ContainsKey(term) == false)
                        { colours.Add(term, colourSet[index]); }
                        if (coloursFont.ContainsKey(term) == false)
                        { coloursFont.Add(term, Brushes.Black); }
                    }
                    else
                    {
                        f.FeatureColour = new SolidBrush(colourPair[0]);
                        f.FontColour = new SolidBrush(colourPair[1]);
                        if (colours.ContainsKey(term) == false)
                        { colours.Add(term, f.FeatureColour); }
                        if (coloursFont.ContainsKey(term) == false)
                        { coloursFont.Add(term, f.FontColour); }
                    }
                }
               
                chlTerms.Items.Add(term);
                index++;
                if (index >= colourSet.Length)
                { index = 0; }

            }

            for (int count = 0; count < chlTerms.Items.Count; count++)
            {
                chlTerms.SetItemChecked(count, true);
            }
        }

        private Color[] getFeatureColour(string featureName)
        {
            Color[] colourPair = { Color.DarkGoldenrod, Color.DarkGoldenrod };
            featureName = featureName.ToLower();

            switch (featureName)
            {
                case "cds":
                    colourPair[0] = Properties.Settings.Default.CDS;
                    colourPair[1] = Properties.Settings.Default.CDS_font;
                    break;
                case "exon":
                    colourPair[0] = Properties.Settings.Default.exon;
                    colourPair[1] = Properties.Settings.Default.exon_font;
                    break;
                case "trna":
                    colourPair[0] = Properties.Settings.Default.tRNA;
                    colourPair[1] = Properties.Settings.Default.tRNA_font;
                    break;
                case "rrna":
                    colourPair[0] = Properties.Settings.Default.rRNA;
                    colourPair[1] = Properties.Settings.Default.rRNA_font;
                    break;
                case "mrna":
                    colourPair[0] = Properties.Settings.Default.mRNA;
                    colourPair[1] = Properties.Settings.Default.mRNA_font;
                    break;
                case "d-loop":
                    colourPair[0] = Properties.Settings.Default.D_loop;
                    colourPair[1] = Properties.Settings.Default.D_loop_font;
                    break;
                case "repeat_region":
                    colourPair[0] = Properties.Settings.Default.repeat_region;
                    colourPair[1] = Properties.Settings.Default.repeat_region_font;
                    break;
                case "misc_feature":
                    colourPair[0] = Properties.Settings.Default.misc_feature;
                    colourPair[1] = Properties.Settings.Default.misc_feature_font;
                    break;
                case "gene":
                    colourPair[0] = Properties.Settings.Default.gene;
                    colourPair[1] = Properties.Settings.Default.gene_font;
                    break;
                case "rep_origin":
                    colourPair[0] = Properties.Settings.Default.CDS;
                    colourPair[1] = Properties.Settings.Default.CDS_font;
                    break;
            }

            return colourPair;

        }

        private void openGTFFile(string filename)
        {
            defination = "";
            features = new Dictionary<string, List<feature>>();            
            int newValue = getSequenceLength();
            if (newValue > -1)
            { sequencelength = newValue; }
            else { return; }

            System.IO.StreamReader fs = null;

            try
            {

                fs = new System.IO.StreamReader(filename);
                string data = fs.ReadToEnd();
                fs.Close();

                string[] lines = data.Split('\n');
                string term = "Feature";
                string[] items = lines[0].Split('\t');

                defination = "";
                items = null;
                foreach (string line in lines)
                {
                    items = line.Split('\t');
                    if (items.Length == 9 && items[0].StartsWith("#") == false)
                    {
                        if (defination == "") { defination = items[0].Trim(); }
                        term = items[2].Trim();
                        feature f = new feature(items, 0, 0, term, "gtf");

                        if (features.ContainsKey(f.FeatureType.Trim()) == false)
                        { features.Add(f.FeatureType, new List<feature>()); }

                        features[f.FeatureType].Add(f);
                    }
                }

                SetUpProgramsData();

                cboStart.Items.Clear();
                cboStart.Items.Add("select");
                foreach (string key in features.Keys)
                {
                    List<feature> lists = features[key];
                    lists.Sort(new featureSorter());
                    foreach (feature f in lists)
                    { cboStart.Items.Add(key + ": " + f.Name); }
                }
                cboStart.SelectedIndex = 0;
                setColours();
                drawFeatures("", scaling);

            }
            catch (Exception ex)
            { MessageBox.Show("Could not open and process the file", "Error"); }
            finally
            { if (fs != null) { fs.Close(); } }
        }

        private void openBedFile(string filename)
        {
            defination = "";
            features = new Dictionary<string, List<feature>>();
            int newValue = getSequenceLength();
            if (newValue > -1)
            { sequencelength = newValue; }
            else { return; }

            System.IO.StreamReader fs = null;

            try
            {
                fs = new System.IO.StreamReader(filename);
                string data = fs.ReadToEnd();
                fs.Close();

                string[] lines = data.Split('\n');
                string term = "Feature";
                string[] items = lines[0].Split('\t');

                defination = "";
                items = null;
                foreach (string line in lines)
                {
                    items = (line.Trim() + "\t" + sequencelength.ToString()).Split('\t');
                    if (items.Length == 7)
                    {
                        if (defination == "") { defination = items[0].Trim(); }
                        feature f = new feature(items, 0, 0, term, "bed");

                        if (features.ContainsKey(f.FeatureType.Trim()) == false)
                        { features.Add(f.FeatureType, new List<feature>()); }

                        features[f.FeatureType].Add(f);
                    }
                }

                SetUpProgramsData();

                cboStart.Items.Clear();
                cboStart.Items.Add("select");
                foreach (string key in features.Keys)
                {
                    List<feature> lists = features[key];
                    lists.Sort(new featureSorter());
                    foreach (feature f in lists)
                    { cboStart.Items.Add(key + ": " + f.Name); }
                }
                cboStart.SelectedIndex = 0;
                setColours();
                drawFeatures("", scaling);

            }
            catch (Exception ex)
            { MessageBox.Show("Could not open and process the file", "Error"); }
            finally
            { if (fs != null) { fs.Close(); } }

        }

        private void openMITOSFile(string filename)
        {
            defination = "";
            features = new Dictionary<string, List<feature>>();
            int newValue = getSequenceLength();
            if (newValue > -1)
            { sequencelength = newValue; }
            else { return; }

            System.IO.StreamReader fs = null;

            try
            {
                fs = new System.IO.StreamReader(filename);
                string data = fs.ReadToEnd();
                fs.Close();

                string[] lines = data.Split('\n');
                string term = "Feature";
                string[] items = lines[0].Split('\t');

                defination = "";
                items = null;
                foreach (string line in lines)
                {
                    items = (line.Trim() + "\t" + sequencelength.ToString()).Split('\t');
                    if (items.Length == 15)
                    {
                        if (defination == "") { defination = items[0].Trim(); }
                        term = items[1].Trim();
                        
                        feature f = new feature(items, 0, 0, term, "mitos");

                        if (features.ContainsKey(f.FeatureType.Trim()) == false)
                        { features.Add(f.FeatureType, new List<feature>()); }

                        features[f.FeatureType].Add(f);
                    }
                }

                SetUpProgramsData();

                cboStart.Items.Clear();
                cboStart.Items.Add("select");
                foreach (string key in features.Keys)
                {
                    List<feature> lists = features[key];
                    lists.Sort(new featureSorter());
                    foreach (feature f in lists)
                    { cboStart.Items.Add(key + ": " + f.Name); }
                }
                cboStart.SelectedIndex = 0;
                setColours();
                drawFeatures("", scaling);

            }
            catch (Exception ex)
            { MessageBox.Show("Could not open and process the file", "Error"); }
            finally
            { if (fs != null) { fs.Close(); } }
        }

        private void openFastaFile(string filename)
        {

            defination = "";
            features = new Dictionary<string, List<feature>>();
            int newValue = getSequenceLength();
            if (newValue > -1)
            { sequencelength = newValue; }
            else { return; }

            System.IO.StreamReader fs = null;

            try
            {
                fs = new System.IO.StreamReader(filename);
                string data = fs.ReadToEnd();
                fs.Close();

                string[] lines = data.Split('\n');

                string term = "Features";
                defination = "";               

                string[] items = null;
                string dataInfo = "";
                string sequence = "";
                foreach (string line in lines)
                {
                    if (line.StartsWith(">") == true && dataInfo.Length > 0)
                    {
                        dataInfo += ";" + sequence.Length.ToString();
                        items = dataInfo.Split(';');

                        if (defination == "")
                        { defination = items[0].Trim().Replace(">",""); }

                        feature f = new feature(items, 0, 0, term, "fasta");

                        if (features.ContainsKey(term) == false)
                        { features.Add(term, new List<feature>()); }

                        features[f.FeatureType].Add(f);
                        dataInfo = line.Trim();
                        sequence = "";
                    }
                    else if (line.StartsWith(">") == true)
                    { dataInfo = line; }
                    else
                    {
                        sequence += line.Trim();
                    }
                }

                if (dataInfo.Length > 0)
                {
                    dataInfo += ";" + sequence.Length.ToString();
                    items = dataInfo.Split(';');

                    if (defination == "")
                    { defination = items[0].Trim(); }

                    feature f = new feature(items, 0, 0, term, "fasta");
                    features[f.FeatureType].Add(f);
                }


                SetUpProgramsData();

                cboStart.Items.Clear();
                cboStart.Items.Add("select");
                foreach (string key in features.Keys)
                {
                    List<feature> lists = features[key];
                    lists.Sort(new featureSorter());
                    foreach (feature f in lists)
                    { cboStart.Items.Add(key + ": " + f.Name); }
                }
                cboStart.SelectedIndex = 0;
                setColours();
                drawFeatures("", scaling);

            }
            catch (Exception ex)
            { MessageBox.Show("Could not open and process the file", "Error"); }
            finally
            { if (fs != null) { fs.Close(); } }
        }
        
        private void openGenBank(string filename)
        {
            defination = "";
            features = new Dictionary<string, List<feature>>();
            
            System.IO.StreamReader fs = null;

            try
            {
                fs = new System.IO.StreamReader(filename);
                string data = fs.ReadToEnd();
                fs.Close();

                string[] lines = data.Split('\n');
                for (int line = 0; line < lines.Length; line++)
                { lines[line] = lines[line].Replace("\r", ""); }

                data = "";

                int index = 0;
                while (index < lines.Length)
                {
                    if (lines[index].StartsWith("FEATURES") == true)
                    {
                        index++;
                        break;
                    }
                    else if (lines[index].StartsWith("DEFINITION") == true)
                    { defination = lines[index].Substring(12).Trim(); }
                    else if (lines[index].StartsWith("LOCUS") == true)
                    { 
                        string t = lines[index].Substring(35);
                        int intbp = t.IndexOf("bp");
                        if (intbp > -1) { t= t.Substring(0, intbp-1).Trim();}
                        try
                        { 
                            int len = Convert.ToInt32(t);
                            if (len > 1000) 
                            { sequencelength = len; } 
                        }
                        catch(Exception ex) { }
                    }
                    index++;
                }

                int lastPlace = -1;
                List<int> startOfFeatures = new List<int>();

                while (index < lines.Length)
                {
                    if (lines[index].StartsWith("      ") == false && lines[index].StartsWith("ORIGIN") == false)
                    {
                        startOfFeatures.Add(index);
                    }
                    else if (lines[index].StartsWith("ORIGIN") == true)
                    {
                        lastPlace = index;
                        break;
                    }
                    index++;
                }

                string[] trimmedLines = new string[lastPlace];
                Array.Copy(lines, trimmedLines, trimmedLines.Length);
                lines = trimmedLines;
                trimmedLines = null;

                addListsToFeatureDictionary(lines);

                for (int place = 0; place < startOfFeatures.Count; place++)
                {
                    if (place != startOfFeatures.Count - 1)
                    {
                        if (lines[startOfFeatures[place]].Contains("..") == true)
                        {
                            feature f = new feature(lines, startOfFeatures[place], startOfFeatures[place + 1], lines[startOfFeatures[place]].Substring(0, 21).Trim(), "genbank");
                            features[f.FeatureType].Add(f);
                        }
                    }
                    else
                    {
                        if (lines[startOfFeatures[place]].Contains("..") == true)
                        {
                            feature f = new feature(lines, startOfFeatures[place], lastPlace, lines[startOfFeatures[place]].Substring(0, 21).Trim(), "genbank");
                            features[f.FeatureType].Add(f);
                        }
                    }
                }

                if (sequencelength == -1)
                {
                    int newValue = getSequenceLength();
                    if (newValue > -1)
                    { sequencelength = newValue; }
                }

                cboStart.Items.Clear();
                cboStart.Items.Add("select");
                foreach (string key in features.Keys)
                {
                    List<feature> lists = features[key];
                    lists.Sort(new featureSorter());
                    foreach (feature f in lists)
                    { cboStart.Items.Add(key + ": " + f.Name); }
                }
                cboStart.SelectedIndex = 0;
                setColours();
                drawFeatures("", scaling);

            }
            catch (Exception ex)
            { MessageBox.Show("Could not open and process the file", "Error"); }
            finally
            { if (fs != null) { fs.Close(); } }

        }

        private void addListsToFeatureDictionary(string[] lines)
        {
            if (coloursFont == null)
            { coloursFont = new Dictionary<string, Brush>(); }

            chlTerms.Items.Clear();
            features = new Dictionary<string, List<feature>>();
            Brush[] colourSet = { Brushes.PaleGreen, Brushes.Pink, Brushes.LightBlue, Brushes.LightGray, Brushes.Orange, Brushes.GreenYellow, Brushes.Orchid };
            colours = new Dictionary<string, Brush>();
            int index = 0;

            foreach (string line in lines)
            {
                if (line.StartsWith("     ") == true && line.StartsWith("      ") == false)
                {
                    string term = line.Substring(0, 21).Trim();
                    if (features.ContainsKey(term) == false)
                    {
                        features.Add(term, new List<feature>());
                        Color[] colourPair = getFeatureColour(term);
                        if (colourPair[0] == Color.DarkGoldenrod && colourPair[1] == Color.DarkGoldenrod)
                        { colours.Add(term, colourSet[index]); }
                        else 
                        {
                            if (colours.ContainsKey(term) == false)
                            { colours.Add(term, new SolidBrush(colourPair[0])); }
                            if (coloursFont.ContainsKey(term) == false)
                            { coloursFont.Add(term, new SolidBrush(colourPair[1])); }
                        }

                       
                        chlTerms.Items.Add(term);
                        index++;
                        if (index >= colourSet.Length)
                        { index = 0; }
                    }
                }
            }

            for (int count = 0; count < chlTerms.Items.Count; count++)
            {
                chlTerms.SetItemChecked(count, true);
            }
        }

        private void setColours()
        {
            foreach (string key in features.Keys)
            {
                Brush b = colours[key];
                Brush fontb = Brushes.Black;
                if (coloursFont != null && coloursFont.ContainsKey(key) == true)
                { fontb = coloursFont[key]; }

                foreach (feature f in features[key])
                {
                    f.FeatureColour = b;
                    f.FontColour = fontb;
                }
            }
        }

        public void ReDrawFromOutSide()
        { drawFeatures("", scaling); }

        private void drawFeatures(string fileName, ImageScaling scaling)
        {
            if (this.WindowState == FormWindowState.Minimized)
            { return; }

            if (chkLine.Checked == false)
            { drawCircle(fileName, scaling); }
            else
            { drawLine(fileName, scaling); }
        }

        private void drawLine(string fileName, ImageScaling scaling)
        {
            Bitmap bmp = new Bitmap(p1.Width * scaling.one, p1.Height * scaling.one, System.Drawing.Imaging.PixelFormat.Format32bppArgb);
            bmp.SetResolution(scaling.hundred, scaling.hundred);
            Graphics g = Graphics.FromImage(bmp);
            g.SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.AntiAlias;
            g.TextContrast = 0;

            Point center = new Point(bmp.Width / 2, bmp.Height / 2);
            center.Y += (int)((float)nupUPDown.Value * scaling.scale);

            ResetClash();
            ClashLineDectection(g, center, scaling.twenty, scaling);
            
            g.Clear(Color.White);
            Point title = center;
            title.Y = scaling.thirty; 
            writeDefinition(g, title,(int)(((p1.Width/2) - 40) * scaling.scale), scaling);
                       
            g.DrawLine(new Pen(Color.Black, scaling.three), scaling.twenty, center.Y, (bmp.Width - scaling.twenty), center.Y);
            if (features.Count == 0 || sequencelength < 1) 
            {
                p1.Image = bmp;
                return;
            }
            drawLineTicks(g, center, scaling.twenty, scaling);
                       

            int largerThan = 0;
            int smallerThan = sequencelength / 3;
            if (chkDrawOrder.Checked == false)
            {
                if (chlTerms.CheckedItems.Count != 0)
                {
                    for (int index = 0; index < chlTerms.CheckedItems.Count; index++)
                    {
                        string key = chlTerms.CheckedItems[index].ToString();
                        drawLineFeatures(g, key, center, scaling.twenty, largerThan, smallerThan, scaling);
                    }
                }
            }
            else
            {
                largerThan = 150;
                for (int loop = 0; loop < 2; loop++)
                {
                    if (chlTerms.CheckedItems.Count != 0)
                    {
                        for (int index = 0; index < chlTerms.CheckedItems.Count; index++)
                        {
                            string key = chlTerms.CheckedItems[index].ToString();
                            drawLineFeatures(g, key, center, scaling.twenty, largerThan, smallerThan, scaling);
                        }
                    }
                    smallerThan = 151;
                    largerThan = 0;
                }
            }

            g.FillRectangle(Brushes.White, -1, 0, scaling.seventeen, bmp.Height);
            g.FillRectangle(Brushes.White, bmp.Width - scaling.seventeen, 0, scaling.twenty, bmp.Height);


            if (string.IsNullOrWhiteSpace(fileName) == true)
            { p1.Image = bmp; }
            else
            { bmp.Save(fileName); }
        }

        private void drawLineFeatures(Graphics g, string featureSet, Point center, int edge, int largerThan, int smallerThan, ImageScaling scaling)
        {
            int y = (int)(center.Y );
            List<feature> endSet = new List<feature>();
            List<feature> startSet = new List<feature>();


            foreach (feature f in features[featureSet])
            {
                if (f.EndPoint - f.StartPoint > largerThan && f.EndPoint - f.StartPoint < smallerThan && f.EndPoint - f.StartPoint < sequencelength / 3)
                {
                    if (f.Forward == true)
                    {
                        g.FillPolygon(f.FeatureColour, f.Arrows);
                        g.DrawPolygon(f.BoxColour, f.Arrows);
                        writeLineText(g, f, center, edge, scaling);                        
                    }
                    else
                    {
                        g.FillPolygon(f.FeatureColour, f.Arrows);
                        g.DrawPolygon(f.BoxColour, f.Arrows);
                        writeLineText(g, f, center, edge, scaling);
                    }

                    if (f.Arrows[0].X < scaling.twenty)
                    { startSet.Add(f); }
                    else if (f.Arrows[3].X > p1.Width * scaling.scale - scaling.twenty)
                    { endSet.Add(f); }
                }
            } 
            
            if (startSet.Count > 0 || endSet.Count > 0)
            {
                DrawEnds(g, startSet, endSet, featureSet, center, edge, largerThan, smallerThan, scaling);
            }
        }

        private void DrawEnds(Graphics g, List<feature> startSet, List<feature> endSet, string featureSet, Point center, int edge, int largerThan, int smallerThan, ImageScaling scaling)
        {

            if (startSet.Count > 0)
            {
                foreach (feature f in startSet)
                {
                    feature fClone = new feature(f.Name, f.StartPoint + sequencelength, f.EndPoint - f.StartPoint, f.Forward);
                    fClone.FontColour = f.FontColour;
                    fClone.FeatureColour = f.FeatureColour;
                    fClone.Arrows = getLineArrow(fClone, center, fClone.Forward, edge, scaling);
                    fClone.clash = f.clash;
                    fClone.ClashData = f.ClashData;
                    fClone.VerticalOffset = f.VerticalOffset;
                    g.FillPolygon(fClone.FeatureColour, fClone.Arrows);
                    g.DrawPolygon(f.BoxColour, fClone.Arrows);
                    writeLineText(g, fClone, center, edge, scaling);
                }
            }
            if (endSet.Count > 0)
            {
                foreach (feature f in endSet)
                {
                    feature fClone = new feature(f.Name, f.StartPoint - sequencelength, f.EndPoint - f.StartPoint, f.Forward);
                    fClone.FontColour = f.FontColour;
                    fClone.FeatureColour = f.FeatureColour;
                    fClone.Arrows = getLineArrow(fClone, center, fClone.Forward, edge, scaling);
                    fClone.clash = f.clash;
                    fClone.ClashData = f.ClashData; g.FillPolygon(fClone.FeatureColour, fClone.Arrows);
                    g.FillPolygon(fClone.FeatureColour, fClone.Arrows);
                    g.DrawPolygon(f.BoxColour, fClone.Arrows);
                    writeLineText(g, fClone, center, edge, scaling);
                }
            }

        }
        private void writeLineText(Graphics g, feature f, Point center, int edge, ImageScaling scaling)
        {
            float fontsize = 20.0f;
            Font font = new Font(FontFamily.GenericSansSerif, fontsize, FontStyle.Bold);
            SizeF length = g.MeasureString(f.Name, font);

            float scale = (float)((p1.Width * scaling.one) - scaling.fourty) / sequencelength;
            
            f.Arrows = getLineArrow(f, center, f.Forward, edge, scaling);
            Point[] points = f.Arrows;           
            int featurelength = points[1].X - points[0].X;

            while (length.Width > featurelength && fontsize > 9.0f)
            {
                fontsize -= 0.5f;
                font = new Font(FontFamily.GenericSansSerif, fontsize, FontStyle.Bold);
                length = g.MeasureString(f.Name, font);
            }

            if (fontsize > 9.5f)
            {
                if (f.Forward == true)
                {
                    float y = points[0].Y + (scaling.scale * 25) - (length.Height / 2);
                    float x = points[0].X + ((featurelength - length.Width) / 2);
                    g.DrawString(f.Name, font, f.FontColour, x, y);
                }
                else
                {
                    float y = points[0].Y - (scaling.scale * 25) - (length.Height / 2);
                    float x = points[0].X + ((featurelength - length.Width) / 2);
                    g.DrawString(f.Name, font, f.FontColour, x, y);
                }
            }
            else
            { writePerpendicularText(g, f, scaling); }
        }

        private void writePerpendicularText(Graphics g, feature f, ImageScaling scaling)
        {
            float scale = (float)((p1.Width * scaling.one) - scaling.fourty) / sequencelength;
            Font font = new Font(FontFamily.GenericSansSerif, 10, FontStyle.Bold);
            SizeF length = g.MeasureString(f.Name, font);
                        
            float dx = 0;

            if (f.Clash == true)
            {
                float middle = (float)f.ClashData.Y / 2;
                dx = scaling.five * ((float)f.ClashData.X - middle);
            }

            float upDown = (float)f.VerticalOffset * scaling.scale;
            float backForward = (float)f.HorizontalOffset * scaling.scale;

            if (f.Forward == true)
            {
                float x = ((f.Arrows[0].X + f.Arrows[1].X)/2) + (length.Height / 2) + dx - upDown;
                float y = f.Arrows[0].Y - scaling.ten - length.Width;
                g.TranslateTransform(x, y);
                g.RotateTransform(90.0f);
                g.DrawString(f.Name, font, Brushes.Black, 0,0);
                g.ResetTransform();
                f.TextPoint = new Point((int)x, (int)y);
            }
            else
            {
                float x = ((f.Arrows[0].X + f.Arrows[1].X) / 2) - (length.Height / 2) + dx - upDown;
                float y = f.Arrows[1].Y + scaling.ten + length.Width;
                g.TranslateTransform(x, y);
                g.RotateTransform(-90.0f);
                g.DrawString(f.Name, font, Brushes.Black, 0, 0);
                g.ResetTransform();
                f.TextPoint = new Point((int)x, (int)y);
            }
        }

        private Point[] getLineArrow(feature f, Point center, bool strand, int edge, ImageScaling scaling )
        {
            float scale = (float)((p1.Width * scaling.one) - scaling.fourty) / sequencelength;

            Point[] points = new Point[5];
            if (strand == true)
            {
                int top = (center.Y - scaling.sixty);
                int bottum = (center.Y - scaling.ten);
                int middle = (center.Y - scaling.thirtyFive);
                int startPoint = (int)(f.StartPoint * scale) + edge;
                int OffsetPoint = (int)(f.EndPoint * scale) - scaling.four + edge;
                if (OffsetPoint < startPoint) { OffsetPoint = startPoint; }
                int EndPoint = (int)(f.EndPoint * scale) + edge;
                points[0] = new Point(startPoint, top);
                points[1] = new Point(OffsetPoint, top);
                points[2] = new Point(EndPoint, middle);
                points[3] = new Point(OffsetPoint, bottum);
                points[4] = new Point(startPoint, bottum);
            }
            else
            {
                int top = (center.Y + scaling.sixty);
                int bottum = (center.Y + scaling.ten);
                int middle = (center.Y + scaling.thirtyFive); ;
                int startPoint = (int)(f.StartPoint * scale) + edge;
                int OffsetPoint = (int)(f.StartPoint * scale) + scaling.four + edge;
                int EndPoint = (int)(f.EndPoint * scale) + edge;
                if (OffsetPoint > EndPoint) {OffsetPoint = EndPoint; }
                points[0] = new Point(OffsetPoint, top);
                points[1] = new Point(EndPoint, top);
                points[2] = new Point(EndPoint, bottum);
                points[3] = new Point(OffsetPoint, bottum);
                points[4] = new Point(startPoint, middle);
            }
            return points;
        }

        private void ClashLineDectection(Graphics g, Point center, int edge, ImageScaling scaling)
        {
            setTextPoints(g, center, edge, scaling);
            ClashDetection(scaling);
        }

        private void setTextPoints(Graphics g, Point center, int edge, ImageScaling scaling)
        {
            if (chlTerms.CheckedItems.Count != 0)
            {
                for (int index = 0; index < chlTerms.CheckedItems.Count; index++)
                {
                    string key = chlTerms.CheckedItems[index].ToString();
                    foreach (feature f in features[key])
                    {
                        string name = f.Name;
                        
                        writeLineText(g, f, center, edge, scaling);
                        Point answerP = f.TextPoint;
                    }
                }
            }            
        }

        private void drawLineTicks(Graphics g, Point center, int edge, ImageScaling scaling)
        {           
            float linelenght = ((p1.Width * scaling.one) - scaling.fourty);
            float interval = linelenght * 1000 / sequencelength;
            float point = 0;
            Pen p = new Pen(Brushes.Black, scaling.three);
            while (point < linelenght)
            {
                g.DrawLine(p, scaling.twenty + point, (center.Y - scaling.six), scaling.twenty + point, (center.Y + scaling.six));
                point += interval;
            }
        }

        private void drawCircle(string fileName, ImageScaling scaling)
        { 
            if (WindowState == FormWindowState.Minimized) { return; }

            
            Bitmap bmp = new Bitmap(p1.Width * scaling.one, p1.Height * scaling.one, System.Drawing.Imaging.PixelFormat.Format32bppArgb);
            bmp.SetResolution(scaling.hundred, scaling.hundred);
            Graphics g = Graphics.FromImage(bmp);
            g.SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.AntiAlias;
            g.TextContrast = 0;
           
            Point center = new Point(bmp.Width / 2, bmp.Height / 2);
            center.X += (int)((float)nupLeftRight.Value * scaling.scale);
            center.Y += (int)((float)nupUPDown.Value * scaling.scale);

            int radius = -1;
            if (bmp.Width > bmp.Height)
            { radius = center.Y - scaling.fourty; }
            else
            { radius = center.X - scaling.fourty; }

            ResetClash();
            int overhang = GetOverhang(g, center, radius, scaling);
            if (overhang < scaling.ten) { radius += (overhang - scaling.ten); }
            if (radius < 150 * scaling.one)
            { radius = 150 * scaling.one; }

            ClashDetection(scaling);

            g.Clear(Color.White);
            writeDefinition(g, center, radius, scaling);

            Rectangle area = new Rectangle(center.X - radius + scaling.thirty, center.Y - radius + scaling.thirty, (radius - scaling.thirty) * 2, (radius - scaling.thirty) * 2);
            g.DrawEllipse(new Pen(Color.Black, scaling.three), area);

            drawTicks(g, center, radius - scaling.thirty, scaling);

            int largerThan = 0;
            int smallerThan = sequencelength / 3;
            if (chkDrawOrder.Checked == false)
            {
                if (chlTerms.CheckedItems.Count != 0)
                {
                    for (int index = 0; index < chlTerms.CheckedItems.Count; index++)
                    {
                        string key = chlTerms.CheckedItems[index].ToString();
                        drawFeatures(g, key, center, radius, largerThan, smallerThan, scaling);
                    }
                }
            }
            else
            {
                largerThan = 150;
                for (int loop = 0; loop < 2; loop++)
                {
                    if (chlTerms.CheckedItems.Count != 0)
                    {
                        for (int index = 0; index < chlTerms.CheckedItems.Count; index++)
                        {
                            string key = chlTerms.CheckedItems[index].ToString();
                            drawFeatures(g, key, center, radius, largerThan, smallerThan, scaling);
                        }
                    }
                    smallerThan = 151;
                    largerThan = 0;
                }
            }

           if (string.IsNullOrWhiteSpace(fileName) == true)
            { p1.Image = bmp; }
            else
            { bmp.Save(fileName); }
        }

        private void ResetClash()
        {
            if (chlTerms.CheckedItems.Count > 0)
            {
                foreach (string key in chlTerms.CheckedItems)
                {
                    List<feature> list = features[key];
                    foreach (feature f in list)
                    { f.ResetClash(); }
                }
            }
        }

        private void ClashDetection(ImageScaling scaling)
        {
            int clashDistance = (int)((float)nupCluster.Value * scaling.scale);

            List<feature> all = new List<feature>();
            if (chlTerms.CheckedItems.Count > 0)
            {
                foreach (string key in chlTerms.CheckedItems)
                {
                    List<feature> list = features[key];

                    if (list.Count > 0)
                    {
                        for (int index = 0; index < list.Count; index++)
                        {
                            all.Add(list[index]);
                        }
                    }
                }
                all.Sort(new featureSorter());

                if (all.Count > 1)
                {
                    for (int index = 0; index < all.Count - 1; index++)
                    {
                        if (index + 1 < all.Count)
                        {
                            int diff = Distance(all[index].TextPoint, all[index + 1].TextPoint);
                            if (Math.Abs(diff) <= (clashDistance * scaling.scale) && diff > 0)
                            {
                                all[index].Clash = true;
                                all[index + 1].Clash = true;
                            }
                        }                        
                    }

                    int count = 0;
                    for (int index = 0; index < all.Count + 1; index++)
                    {
                        if (index < all.Count && all[index].Clash == true)
                        {
                            count++;
                            Point p = all[index].ClashData;
                            p.X = count;
                            all[index].ClashData = p;
                        }                        
                        else { count = 0; }
                    }
                    count = 0;
                    for (int index = all.Count - 1; index >= 0; index--)
                    {
                        if (all[index].ClashData.X > count)
                        {
                            count = all[index].ClashData.X;
                            Point p = all[index].ClashData;
                            p.Y = count;
                            all[index].ClashData = p;
                        }
                        else if (all[index].ClashData.X > 0)
                        {
                            Point p = all[index].ClashData;
                            p.Y = count;
                            all[index].ClashData = p;
                        }
                        else { count = 0; }
                    }
                }
            }
        }

        private void writeDefinition(Graphics g, Point center, int radius, ImageScaling scaling)
        {
            if (string.IsNullOrEmpty(defination) == true) { return; }
            radius -= scaling.sixty;
            float fontSize = 20;
            Font f = new Font(FontFamily.GenericSansSerif, fontSize, FontStyle.Bold);

            string[] lines = null;
            
            if (defination.Contains(";") == true)
            {
                lines = (defination + ";" + sequencelength.ToString("N0") + " bp").Split(';');
            }
            else
            {
                string[] one = { defination, sequencelength.ToString("N0") + " bp" };
                lines = one;
            }

            SizeF s = new SizeF(0, 0);
            string longestLine = "";

            foreach (string l in lines)
            {
                SizeF sL = g.MeasureString(l.Trim(), f);
                if (sL.Width > s.Width)
                {
                    s = sL;
                    longestLine = l.Trim();
                }
            }

            int gap = (radius * 2) - (int)(140 * scaling.scale);

            while (s.Width > gap)
            {
                if (fontSize < 2) { return; }
                f = new Font(FontFamily.GenericSansSerif, fontSize, FontStyle.Bold);
                s = g.MeasureString(longestLine, f);
                fontSize -= 0.5f;
            }

            float middle = 1.5f + ((float)lines.Length / 2);
            float startH = center.Y - ((scaling.scale * fontSize) * middle);

            foreach (string l in lines)
            {
                s = g.MeasureString(l, f);
                int x = (int)s.Width / 2;
                g.DrawString(l.Trim(), f, Brushes.Black, center.X - x, startH);
                startH += s.Height;
            }
        }

        private void drawTicks(Graphics g, Point center, int radius, ImageScaling scaling)
        {
            Pen black = new Pen(Color.Black, scaling.two);
            for (int index = 0; index < sequencelength; index += 1000)
            {
                float angle = (float)index * 360.0f / sequencelength;
                double radion = ((angle - 90) * 2 * Math.PI) / 360;
                float x1 = (int)(Math.Cos(radion) * (radius + scaling.six)) + center.X;
                float y1 = (int)(Math.Sin(radion) * (radius + scaling.six)) + center.Y;
                float x2 = (int)(Math.Cos(radion) * (radius - scaling.five)) + center.X;
                float y2 = (int)(Math.Sin(radion) * (radius - scaling.five)) + center.Y;
                g.DrawLine(black, x1, y1, x2, y2);
            }
        }

        private void drawFeatures(Graphics g, string featureSet, Point center, int radius, int largerThan, int smallerThan, ImageScaling scaling)
        {           
            foreach (feature f in features[featureSet])
            {
                if (f.EndPoint - f.StartPoint > largerThan && f.EndPoint - f.StartPoint < smallerThan && f.EndPoint - f.StartPoint < sequencelength / 3 )
                {
                    if (f.Forward == true)
                    {
                        f.Arrows = getArrow(f.arcStartAngle(sequencelength), f.arcEndAngle(sequencelength), radius, center, true, scaling);
                        g.FillPolygon(f.FeatureColour, f.Arrows);
                        g.DrawPolygon(f.BoxColour, f.Arrows);
                    }
                    else
                    {
                        f.Arrows = getArrow(f.arcStartAngle(sequencelength), f.arcEndAngle(sequencelength), radius - scaling.sixty, center, false, scaling);
                        g.FillPolygon(f.FeatureColour, f.Arrows);
                        g.DrawPolygon(f.BoxColour, f.Arrows);
                    }
                }
            }

            foreach (feature f in features[featureSet])
            {
                if (f.EndPoint - f.StartPoint > largerThan && f.EndPoint - f.StartPoint < smallerThan && f.EndPoint - f.StartPoint < sequencelength / 3)
                {
                    if (f.Forward == true)
                    { writeName(g, f, center, radius, scaling); }
                    else
                    { writeName(g, f, center, radius - scaling.sixty, scaling); }
                }
            }
        }

        private Point[] getArrow(float startPoint, float endPoint, int radius, Point center, bool start, ImageScaling scaling)
        {
            List<Point> places = new List<Point>();

            double radion;

            if (endPoint - startPoint < 1.1)
            {
                if (start == true)
                {
                    radion = (startPoint * 2 * Math.PI) / 360;
                    Point p = new Point((int)(Math.Cos(radion) * (radius + scaling.twentyTwo)) + center.X, (int)(Math.Sin(radion) * (radius + scaling.twentyTwo)) + center.Y);
                    places.Add(p);
                    radion = (startPoint * 2 * Math.PI) / 360;
                    p = new Point((int)(Math.Cos(radion) * (radius - scaling.twentyTwo)) + center.X, (int)(Math.Sin(radion) * (radius - scaling.twentyTwo)) + center.Y);
                    places.Add(p);
                    radion = ((endPoint + 1.0f) * 2 * Math.PI) / 360;
                    p = new Point((int)(Math.Cos(radion) * radius) + center.X, (int)(Math.Sin(radion) * radius) + center.Y);
                    places.Add(p);
                }
                else
                {
                    radion = (endPoint * 2 * Math.PI) / 360;
                    Point p = new Point((int)(Math.Cos(radion) * (radius + scaling.twentyTwo)) + center.X, (int)(Math.Sin(radion) * (radius + scaling.twentyTwo)) + center.Y);
                    places.Add(p);
                    radion = (endPoint * 2 * Math.PI) / 360;
                    p = new Point((int)(Math.Cos(radion) * (radius - scaling.twentyTwo)) + center.X, (int)(Math.Sin(radion) * (radius - scaling.twentyTwo)) + center.Y);
                    places.Add(p);
                    radion = ((startPoint + 1.0f) * 2 * Math.PI) / 360;
                    p = new Point((int)(Math.Cos(radion) * radius) + center.X, (int)(Math.Sin(radion) * radius) + center.Y);
                    places.Add(p);
                }
            }
            else
            {
                if (start == true)
                { endPoint -= 1.0f; }
                else
                {
                    radion = (startPoint * 2 * Math.PI) / 360;
                    Point p = new Point((int)(Math.Cos(radion) * radius) + center.X, (int)(Math.Sin(radion) * radius) + center.Y);
                    places.Add(p);
                    startPoint += 1.0f;
                }


                for (float place = startPoint; place < endPoint + 0.1f; place += 0.1f)
                {
                    radion = (place * 2 * Math.PI) / 360;
                    Point p = new Point((int)(Math.Cos(radion) * (radius + scaling.twentyTwo)) + center.X, (int)(Math.Sin(radion) * (radius + scaling.twentyTwo)) + center.Y);
                    places.Add(p);
                }


                if (start == true)
                {
                    radion = ((endPoint + 1.0f) * 2 * Math.PI) / 360;
                    Point p = new Point((int)(Math.Cos(radion) * radius) + center.X, (int)(Math.Sin(radion) * radius) + center.Y);
                    places.Add(p);
                }

                for (float place = endPoint; place > startPoint - 0.1f; place -= 0.1f)
                {
                    radion = (place * 2 * Math.PI) / 360;
                    Point p = new Point((int)(Math.Cos(radion) * (radius - scaling.twentyTwo)) + center.X, (int)(Math.Sin(radion) * (radius - scaling.twentyTwo)) + center.Y);
                    places.Add(p);
                }
            }

            return places.ToArray();
        }

        private Point[] writeName(Graphics g, feature f, Point center, int radius, ImageScaling scaling)
        {
            
            Point[] answer = { new Point(0, 0), new Point(0, 0) };
            string name = f.Name;
            

            float startPoint = f.arcStartAngle(sequencelength);
            float endPoint = f.arcEndAngle(sequencelength);

            Font font = new Font(FontFamily.GenericSansSerif, 20, FontStyle.Bold);
            SizeF lenght = g.MeasureString(name, font);
            float circumference = (float)(2 * radius * Math.PI);

            float arcLength = circumference * (endPoint - (startPoint + 1)) / 360;
            int fontSize = 19;
            float fontRadiusOffset = 0;
            while (lenght.Width > arcLength - scaling.ten && fontSize > 10)
            {
                fontRadiusOffset++;
                font = new Font(FontFamily.GenericSansSerif, fontSize, FontStyle.Bold);
                lenght = g.MeasureString(name, font);
                circumference = (float)(2 * radius * Math.PI);

                arcLength = circumference * (endPoint- startPoint) / 360;
                fontSize--;
            }

            if (lenght.Width < arcLength - scaling.ten)
            {
                float diff = (arcLength - lenght.Width) / 2.0f;
                float offset = diff * 360 / circumference;
                float angle = startPoint + offset;

                if (angle < 0 || angle > 180)
                {
                    radius += scaling.twentyEight;
                    diff = (arcLength - lenght.Width) / 2.0f;
                    offset = diff * 360 / circumference;

                    angle = startPoint + offset - 0.5f;

                    for (int index = 0; index < name.Length; index++)
                    {
                        SizeF s = g.MeasureString(new string(name[index], 1), font);
                        double radion = (angle * 2 * Math.PI) / 360;
                        float x = (int)(Math.Cos(radion) * (radius - (fontRadiusOffset * scaling.scale) - scaling.thirteen)) + center.X;
                        float y = (int)(Math.Sin(radion) * (radius - (fontRadiusOffset *scaling.scale) - scaling.thirteen)) + center.Y;
                        g.TranslateTransform(x, y);
                        g.RotateTransform((float)angle + 90.0f);
                        g.DrawString(new string(name[index], 1), font, f.FontColour, 0, 0);
                        g.ResetTransform();
                        angle += (float)(s.Width * 270 / circumference);
                    }
                }
                else
                {
                    radius -= scaling.ten;
                    diff = (arcLength - (lenght.Width * (name.Length - 2) / name.Length)) / 2.0f;
                    offset = diff * 360 / circumference;

                    angle = startPoint + offset;
                    for (int index = 0; index < name.Length; index++)
                    {
                        string letter = new string(name[name.Length - (1 + index)], 1);

                        double radion = (angle * 2 * Math.PI) / 360;
                        float x = (int)(Math.Cos(radion) * (radius + (fontRadiusOffset * scaling.scale) - scaling.eight)) + center.X;
                        float y = (int)(Math.Sin(radion) * (radius + (fontRadiusOffset * scaling.scale) - scaling.eight)) + center.Y;
                        g.TranslateTransform(x, y);
                        g.RotateTransform((float)angle + 270.0f);
                        g.DrawString(letter, font, f.FontColour, 0, 0);

                        g.ResetTransform();
                        int place = name.Length - (1 + index);
                        if (place > 0)
                        {
                            letter = name[place - 1].ToString();
                            SizeF s = g.MeasureString(letter, font);
                            angle += (float)(s.Width * 270 / circumference);
                        }
                    }
                }
            }
            else
            {
                Point answerSingle = writeRadially(g, f, center, radius, scaling);
                if (answerSingle.X < answer[0].X) { answer[0].X = answerSingle.X; }
                if (answerSingle.Y < answer[0].Y) { answer[0].Y = answerSingle.Y; }
                if (answerSingle.X > answer[1].X) { answer[1].X = answerSingle.X; }
                if (answerSingle.Y > answer[1].Y) { answer[1].Y = answerSingle.Y; }
            }
            return answer;
        }

        private Point writeRadially(Graphics g, feature f, Point center, int radius, ImageScaling scaling)
        {
            Point answer = new Point(0, 0);

            string name = f.Name;

            float startPoint = f.arcStartAngle(sequencelength);
            float endPoint = f.arcEndAngle(sequencelength);

            Font font;
            if (f.Forward == true)
            { font = new Font(FontFamily.GenericSansSerif, 11, FontStyle.Bold); }
            else { font = new Font(FontFamily.GenericSansSerif, 10, FontStyle.Bold); }

            float middle = ((float)(startPoint + endPoint) / 2.0f);
            float spin = 0.0f;
            if (middle < 270 && middle > 90) { spin = 180; }

            double radion = (middle * 2 * Math.PI) / 360;
            int extra = 0;
            if (f.Forward == false && name.Length > 15) 
            { extra = scaling.sixty; }
            float x = (int)(Math.Cos(radion) * (radius + extra - scaling.ten)) + center.X;
            float y = (int)(Math.Sin(radion) * (radius + extra - scaling.ten)) + center.Y;
                        
            g.TranslateTransform(x, y);

            if (f.Clash == true)
            {
                Point cd = f.ClashData;
                int half = (cd.Y / 2);
                int cX = cd.X;

                if (f.Forward != false)
                {
                    int wiggle = (5 * (half + 1 - cX));
                    middle -= wiggle;
                }
                else
                {
                    int wiggle = (8 * (half + 1 - cX));
                    middle += wiggle;
                }
            }

            g.RotateTransform(middle - spin - f.Rotate);

            float upDown = (float)f.VerticalOffset * scaling.scale;
            float backForward = (float)f.HorizontalOffset * scaling.scale;
 
            SizeF s = g.MeasureString(name, font);
            int fHeigth = (int)s.Height / 2;
            Pen blackLinePen  = new Pen(Color.Black, scaling.two);
            
            if (spin == 180)
            {
                if (f.Forward == true || name.Length > 15)
                {                    
                    g.DrawString(name, font, Brushes.Black, -scaling.thirtyEight - s.Width - backForward, -scaling.six - upDown);
                    if (backForward > (font.Size / 2))
                    { g.DrawLine(blackLinePen, -scaling.thirtyEight - backForward, -scaling.six - upDown + fHeigth, -scaling.thirtyEight, -scaling.six  + fHeigth); }
                }
                else
                {                    
                    g.DrawString(name, font, Brushes.Black, scaling.twenty + backForward, -scaling.ten - upDown);
                    if (backForward  > (font.Size / 2))
                    { g.DrawLine(blackLinePen, scaling.twenty + backForward, -scaling.ten - upDown + fHeigth, scaling.twenty, -scaling.ten  + fHeigth); }
                }               
            }
            else
            {                
                if (f.Forward == true || name.Length > 15)
                {
                    g.DrawString(name, font, Brushes.Black, scaling.thirtyEight + backForward, -scaling.ten - upDown);
                    if (backForward > (font.Size / 2))
                    { g.DrawLine(blackLinePen, scaling.thirtyEight + backForward, -scaling.ten - upDown + fHeigth, scaling.thirtyEight, -scaling.ten  + fHeigth); }
                }
                else
                {
                    g.DrawString(name, font, Brushes.Black, -scaling.sixteen - s.Width - backForward, -scaling.six - upDown);
                    if (backForward > (font.Size / 2))
                    {  g.DrawLine(blackLinePen, -scaling.sixteen - backForward, -scaling.six - upDown + fHeigth, -scaling.sixteen, -scaling.six  + fHeigth); }
                }
                
            }

            g.ResetTransform();
            
            if (f.Forward == true || name.Length > 15)
            {
                if (spin == 180)
                {                    
                    float dX = (int)(Math.Cos(-radion) * -(scaling.thirtyEight + s.Width + backForward));
                    float dY = (int)(Math.Sin(-radion) * +(scaling.thirtyEight + s.Width + backForward));
                    answer = new Point((int)(x - dX), (int)(y - dY));
                    dX = (int)(Math.Cos(-radion) * -(scaling.thirtyEight ));
                    dY = (int)(Math.Sin(-radion) * +(scaling.thirtyEight ));
                    f.TextPoint = new Point((int)(x - dX), (int)(y - dY));                    
                }
                else
                {
                    float dX = (int)(Math.Cos(-radion) * -(scaling.thirtyEight + s.Width - backForward));
                    float dY = (int)(Math.Sin(-radion) * +(scaling.thirtyEight + s.Width - backForward));
                    answer = new Point((int)(x - dX), (int)(y - dY));
                    dX = (int)(Math.Cos(-radion) * -(scaling.thirtyEight));
                    dY = (int)(Math.Sin(-radion) * +(scaling.thirtyEight));
                    f.TextPoint = new Point((int)(x - dX), (int)(y - dY));
                }
            }
            else
            {
                if (spin == 180)
                {
                    float dX = (int)(Math.Cos(-radion) * (scaling.twenty));
                    float dY = (int)(Math.Sin(-radion) * -(scaling.twenty));
                    f.TextPoint = new Point((int)(x - dX), (int)(y - dY));                    
                }
                else
                {
                    float dX = (int)(Math.Cos(-radion) * -(scaling.sixteen));
                    float dY = (int)(Math.Sin(-radion) * (scaling.sixteen));
                    f.TextPoint = new Point((int)(x + dX), (int)(y + dY));
                }
            }
            
            return answer;
        }

        public int Distance(Point one, Point two)
        {
            double square = Math.Pow((one.X - two.X), 2) + Math.Pow((one.Y - two.Y), 2);
            int answer = (int)Math.Sqrt(square);
            return answer;
        }

        private int getlength()
        {
            int length = -1;
            foreach (string key in features.Keys)
            {
                foreach (feature f in features[key])
                {
                    if (length < f.EndPoint) { length = f.EndPoint; }
                }
            }

            return length;
        }

        private void chlTerms_MouseUp(object sender, MouseEventArgs e)
        {
            populate_cboStart();
        }

        private void populate_cboStart()
        {
            cboStart.Items.Clear();
            cboStart.Items.Add("select");
            if (chlTerms.CheckedItems.Count != 0)
            {
                for (int index = 0; index < chlTerms.CheckedItems.Count; index++)
                {
                    string key = chlTerms.CheckedItems[index].ToString();
                    List<feature> lists = features[key];

                    foreach (feature f in lists)
                    { cboStart.Items.Add(key + ": " + f.Name); }
                }
            }
            cboStart.SelectedIndex = 0;
         }

        private void p1_MouseClick(object sender, MouseEventArgs e)
        {
           drawFeatures("", scaling);// this is just for debuging
        }

        private int GetOverhang(Graphics g, Point center, int radius, ImageScaling scaling)
        {
            int answer = 0;
            if (chlTerms.CheckedItems.Count != 0)
            {
                for (int index = 0; index < chlTerms.CheckedItems.Count; index++)
                {
                    string key = chlTerms.CheckedItems[index].ToString();
                    foreach (feature f in features[key])
                    {
                        string name = f.Name;
                        Point[] answerP = writeName(g, f, center, radius, scaling);
                        if (answer > answerP[0].X)
                        { answer = answerP[0].X; }

                        if (answer > answerP[0].Y)
                        { answer = answerP[0].Y; }

                        if (answer > (p1.Width * scaling.scale) - answerP[1].X)
                        { answer = ((int)(p1.Width * scaling.scale) - answerP[1].X); }

                        if (answer > (p1.Height * scaling.scale) - answerP[1].Y)
                        { answer = ((int)(p1.Height * scaling.scale) - answerP[1].Y); }
                    }
                }
            }
            return answer;
        }

        private void chcReverseSequence_CheckedChanged(object sender, EventArgs e)
        {
            foreach (List<feature> list in features.Values)
            {
                foreach (feature f in list)
                {
                    f.ReverseComplementSequence(sequencelength);
                }
            }
            drawFeatures("", scaling);
        }

        private void chkSwitchStrands_CheckedChanged(object sender, EventArgs e)
        {
            foreach (List<feature> list in features.Values)
            {
                foreach (feature f in list)
                {
                    f.SwitchStrands();
                }
            }
            drawFeatures("", scaling);
        }
        private void cboStart_SelectedIndexChanged(object sender, EventArgs e)
        {
            int start = 0;
            if (cboStart.SelectedIndex == 0)
            { }
            else
            {
                string keys = cboStart.Text;
                int number = 0;
                for (int count = 1; count < cboStart.SelectedIndex; count++ )
                {
                    string te = cboStart.Items[count].ToString();
                    if (cboStart.Items[count].ToString() == keys)
                    { number++; }
                }

                
                string featureType = keys.Substring(0, keys.IndexOf(": "));
                string featureName = keys.Substring(keys.IndexOf(": ") + 2);
                List<feature> list = features[featureType];
                foreach (feature f in list)
                {
                    if (f.Name == featureName && number ==0)
                    {
                        start = f.StartPoint;
                        newStartOffset += start;
                        break;
                    }
                    else if (f.Name == featureName)
                    { number--; }
                }

                foreach (List<feature> listF in features.Values)
                {
                    foreach (feature f in listF)
                    {
                        f.ResetStart(sequencelength, start);
                    }
                }
            }
            drawFeatures("", scaling);
        }

        private void Form1_Load(object sender, EventArgs e)
        {
           
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            if (resising == true)
            { resising = false; }
            else
            {
                timer1.Enabled = false;
                drawFeatures("", scaling);
            }

        }

        private void Form1_Resize(object sender, EventArgs e)
        {
            resising = true;
            timer1.Enabled = true;
        }

        private void btnNewLenght_Click(object sender, EventArgs e)
        {
            int newValue = getSequenceLength();
            if (newValue > -1 && newValue != sequencelength)
            {
                foreach (List<feature> list in features.Values)
                {
                    foreach(feature f in list)
                    {
                        if (f.EndPoint > sequencelength)
                        { }
                    }
                }
            }

            sequencelength= newValue;
            drawFeatures("", scaling);           
        }

        private int getSequenceLength()
        {
            int newValue = -1;
            string input;
            if (sequencelength == -1)
            { input = Interaction.InputBox("Enter the genome length", "Genome length"); }
            else
            { input = Interaction.InputBox("Enter the genome length", "Genome length", sequencelength.ToString("N0")); }

            if (string.IsNullOrEmpty(input) == true) { return sequencelength; }
            try
            { newValue = Convert.ToInt32(input.Trim().Replace(",", "")); }
            catch (Exception ex)
            {
                MessageBox.Show("Could not convert value to a whole number", "Error");
                return sequencelength;
            }
            return newValue;
        }

        private void btnResetName_Click(object sender, EventArgs e)
        {

            string input = Interaction.InputBox("Enter the genome name", "Genome name", defination);
            if (string.IsNullOrEmpty(input) == true) { return ; }
            defination = input;
            drawFeatures("", scaling);
        }

        private void btnChangeColours_Click(object sender, EventArgs e)
        {
            if (chlTerms.CheckedItems.Count == 0) { return ; }
            List<string> terms= new List<string>();

            for (int index = 0; index < chlTerms.CheckedItems.Count; index++)
            {
                terms.Add( chlTerms.CheckedItems[index].ToString());               
            }

            AdjustColours ac = new AdjustColours(colours, features, this, terms);
            ac.ShowDialog();

            ResetBoxColour(terms, scaling.scale);
        }

        private void chkDrawOrder_CheckedChanged(object sender, EventArgs e)
        {
            drawFeatures("", scaling);
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            string fileName = FileAccessClass.FileString(FileAccessClass.FileJob.SaveAs, "Save image as", "TIFF Image file (*.tif)|*.tif|Bitmap image file (*.bmp)|*.bmp|JPEG image file (*.jpg)|*.jpg|PNG image file (*.png)|*.png");
            if (fileName == "Cancel") { return; }

            List<string> terms = new List<string>();

            try
            {
                ImageScaling saveAs = new ImageScaling(300.0f);
                if (chlTerms.CheckedItems.Count == 0) { return; }                

                for (int index = 0; index < chlTerms.CheckedItems.Count; index++)
                { terms.Add(chlTerms.CheckedItems[index].ToString()); }
                ResetBoxColour(terms, saveAs.scale);

                drawFeatures(fileName, saveAs);
            }
            finally
            { ResetBoxColour(terms, scaling.scale); }

        }

        private void btnEdit_Click(object sender, EventArgs e)
        {
            if (chlTerms.CheckedItems.Count == 0) { return; }
            List<string> terms = new List<string>();

            for (int index = 0; index < chlTerms.CheckedItems.Count; index++)
            {
                terms.Add(chlTerms.CheckedItems[index].ToString());
            }

            EditNames en = new EditNames(features, this, terms);
            en.ShowDialog();

            ResetBoxColour(terms, scaling.scale);
            ResetcboStart();

        }

        private void ResetcboStart()
        {
            cboStart.Items.Clear();
            cboStart.Items.Add("select");
            foreach (string key in features.Keys)
            {
                List<feature> lists = features[key];
                lists.Sort(new featureSorter());
                foreach (feature f in lists)
                { cboStart.Items.Add(key + ": " + f.Name); }
            }
            cboStart.SelectedIndex = 0;
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            if (chlTerms.CheckedItems.Count == 0) { return; }
            List<string> terms = new List<string>();

            for (int index = 0; index < chlTerms.CheckedItems.Count; index++)
            {
                terms.Add(chlTerms.CheckedItems[index].ToString());
            }

            AddFeature af = new AddFeature(features, this, terms, sequencelength, newStartOffset);
            af.ShowDialog();
            ResetcboStart();
        }
        private void btnRemove_Click(object sender, EventArgs e)
        {
            if (chlTerms.CheckedItems.Count == 0) { return; }
            List<string> terms = new List<string>();

            for (int index = 0; index < chlTerms.CheckedItems.Count; index++)
            {
                terms.Add(chlTerms.CheckedItems[index].ToString());
            }

            Deletefeature df = new Deletefeature(features, this, terms);
            df.ShowDialog();

            ResetBoxColour(terms, scaling.scale);
            ResetcboStart();
        }

        private void nupLeftRight_ValueChanged(object sender, EventArgs e)
        {
            drawFeatures("", scaling);
        }

        private void nupUPDown_ValueChanged(object sender, EventArgs e)
        {
            drawFeatures("", scaling);
        }

        private void nupCluster_ValueChanged(object sender, EventArgs e)
        {
            drawFeatures("", scaling);
        }

        private void btnAdjustTextLocation_Click(object sender, EventArgs e)
        {
            if (chlTerms.CheckedItems.Count == 0) { return; }
            List<string> terms = new List<string>();

            for (int index = 0; index < chlTerms.CheckedItems.Count; index++)
            {
                terms.Add(chlTerms.CheckedItems[index].ToString());
            }

            AdjustTextLocation atl = new AdjustTextLocation(features, this, terms, chkLine.Checked);
            atl.ShowDialog();

            ResetBoxColour(terms, scaling.scale);
        }

        private void chkLine_CheckedChanged(object sender, EventArgs e)
        {
            drawFeatures("", scaling);
            nupLeftRight.Enabled = !chkLine.Checked;
        }

        public void ResetBoxColour(List<string> keys, float scale)
        {
            Pen black = new Pen(Color.Black, scale);
            foreach (string key in keys)
            {
                List<feature> list = features[key];
                foreach(feature f in list)
                { f.BoxColour = black; }
            }
            drawFeatures("", scaling);
        }

        private void btnSelect_Click(object sender, EventArgs e)
        {
            if (chlTerms.CheckedItems.Count == 0) { return; }
            List<string> terms = new List<string>();

            for (int index = 0; index < chlTerms.CheckedItems.Count; index++)
            {
                terms.Add(chlTerms.CheckedItems[index].ToString());
            }

            AdvancedNameSelection ads = new AdvancedNameSelection(features, this, terms);
            ads.ShowDialog();
            populate_cboStart();
        }
         
    }
}
