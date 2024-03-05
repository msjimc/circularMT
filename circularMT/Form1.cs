using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml.Linq;
using Microsoft.VisualBasic;


namespace circularMT
{
    public partial class Form1 : Form
    {
        string defination = "";
        Dictionary<string, List<feature>> features = new Dictionary<string, List<feature>>();
        int sequencelength = -1;
        Dictionary<string, Brush> colours;
        public Form1()
        {
            InitializeComponent();
        }

        private void btnGenBank_Click(object sender, EventArgs e)
        {
            string filename = FileAccessClass.FileString(FileAccessClass.FileJob.Open, "Seletct the annotation file", "*.*;|*.*");
            if (System.IO.File.Exists(filename) == false) { return; }

            string extension = filename.Substring(filename.LastIndexOf('.')).ToLower();

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

                    break;
                case ".seq":

                    break;
                case ".bed": 
                    openBedFile(filename);
                    break;
                case ".txt":
                    
                    break;
            }

        }

        private void openGFFFile(string filename)
        {
            sequencelength = -1;
            string input = Interaction.InputBox("Enter the genome length", "Genome length");
            try
            { sequencelength = Convert.ToInt32(input.Trim().Replace(",", "")); }
            catch (Exception ex)
            {
                MessageBox.Show("Could not convert value to a whole number", "Error");
                return;
            }

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
                        feature f = new feature(items, 0, 0, term, "gff");
                       
                        if (features.ContainsKey(f.FeatureType.Trim()) == false )
                        { features.Add(f.FeatureType, new List<feature>()); }

                        features[f.FeatureType].Add(f);
                    }                    
                }

                SetUpProgramStata();

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

                drawFeatures();

            }
            catch (Exception ex)
            { MessageBox.Show("Could not open and process the file", "Error"); }
            finally
            { if (fs != null) { fs.Close(); } }

        }        

        private void SetUpProgramStata()
        {
            chlTerms.Items.Clear();
            Brush[] colourSet = { Brushes.PaleGreen, Brushes.Pink, Brushes.LightBlue, Brushes.LightGray, Brushes.Orange, Brushes.GreenYellow, Brushes.Orchid };
            colours = new Dictionary<string, Brush>();
            
            int index = 0;
                        foreach (string term in features.Keys)
            {

                colours.Add(term, colourSet[index]);
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


        private void openGTFFile(string filename)
        {

        }
        private void openBedFile(string filename)
        {

        }


        private void openFastaFile(string filename)
        {

            System.IO.StreamReader fs = null;

            try
            {
                string input = Interaction.InputBox("Enter the genome length", "Genome length");
                try
                { sequencelength = Convert.ToInt32(input.Trim().Replace(",","")); }
                catch
                {
                    MessageBox.Show("Could not convert value to a whole number", "Error");
                        return; 
                }


                fs = new System.IO.StreamReader(filename);
                string data = fs.ReadToEnd();
                fs.Close();

                string[] lines = data.Split('\n');

                string term = "Features";
                defination = "";
                AddSingleFeatureListAndSortState();

                string[] items = null;
                string dataInfo = "";
                string sequence = "";
                foreach (string line in lines) 
                {
                    if (line.StartsWith(">") == true && dataInfo.Length>0)
                    {
                        dataInfo += ";" + sequence.Length.ToString();
                        items = dataInfo.Split(';');

                        if (defination =="")
                        { defination = items[0].Trim(); }
                        
                        feature f = new feature(items, 0, 0, term, "fasta");
                        features[f.FeatureType].Add(f);
                        dataInfo = line;
                        sequence = "";
                    }
                    else if (line.StartsWith(">") == true)
                    { dataInfo = line; }
                    else
                    {
                        sequence += line.Trim();
                    }
                }

                if (dataInfo.Length >0) 
                {
                    dataInfo += ";" + sequence.Length.ToString();
                    items = dataInfo.Split(';');

                    if (defination == "")
                    { defination = items[0].Trim(); }

                    feature f = new feature(items, 0, 0, term, "fasta");
                    features[f.FeatureType].Add(f);
                    

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

                drawFeatures();

            }
            catch (Exception ex)
            { MessageBox.Show("Could not open and process the file", "Error"); }
            finally
            { if (fs != null) { fs.Close(); } }
        }

        private void AddSingleFeatureListAndSortState()
        {
            chlTerms.Items.Clear();
            features = new Dictionary<string, List<feature>>();
            Brush[] colourSet = { Brushes.PaleGreen, Brushes.Pink, Brushes.LightBlue, Brushes.LightGray, Brushes.Orange, Brushes.GreenYellow, Brushes.Orchid };
            colours = new Dictionary<string, Brush>();
            string term = "Features";

            features.Add(term, new List<feature>());
            colours.Add(term, colourSet[0]);
            chlTerms.Items.Add(term);
            chlTerms.SetItemChecked(0, true);

        }

        private void openGenBank(string filename)
        { 
            System.IO.StreamReader fs = null;

            try 
            {
                fs= new System.IO.StreamReader(filename);
                string data = fs.ReadToEnd();
                fs.Close();

                string[] lines = data.Split('\n');
                for (int line = 0;line < lines.Length;line++)
                { lines[line] = lines[line].Replace("\r",""); }

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
                    index++;
                }

                int lastPlace = -1;
                List<int> startOfFeatures=new List<int>();

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
                trimmedLines= null;

                addListsToFeatureDictionary(lines);

                for(int place =0; place < startOfFeatures.Count;place++)
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

                sequencelength = getlength();

                cboStart.Items.Clear();
                cboStart.Items.Add("select");
                foreach(string key in features.Keys)                
                { 
                    List<feature> lists = features[key];
                    lists.Sort(new featureSorter());
                    foreach (feature f in lists)
                    { cboStart.Items.Add(key + ": " + f.Name); }
                }
                cboStart.SelectedIndex = 0;

                drawFeatures();

            }
            catch (Exception ex)
            { MessageBox.Show("Could not open and process the file", "Error"); }
            finally
            { if (fs != null) { fs.Close(); } }

        }

        private void addListsToFeatureDictionary(string[] lines)
        {            
            chlTerms.Items.Clear();
            features = new Dictionary<string, List<feature>>();
            Brush[] colourSet = {Brushes.PaleGreen, Brushes.Pink, Brushes.LightBlue, Brushes.LightGray,Brushes.Orange, Brushes.GreenYellow, Brushes.Orchid};
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
                        colours.Add(term, colourSet[index]);
                        chlTerms.Items.Add(term);                        
                        index++;
                        if (index>= colourSet.Length)
                        { index = 0; }
                    }
                }
            }

            for (int count = 0; count < chlTerms.Items.Count; count++)
            {
                chlTerms.SetItemChecked(count, true);
            }
        }

        private void drawFeatures()
        {
            Bitmap bmp = new Bitmap(p1.Width, p1.Height, System.Drawing.Imaging.PixelFormat.Format32bppArgb);
            Graphics g = Graphics.FromImage(bmp);            
            g.SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.AntiAlias;

            Point center = new Point(bmp.Width / 2, bmp.Height / 2);
            int radius = -1;
            if (bmp.Width > bmp.Height)
            { radius = center.Y - 40; }
            else
            { radius = center.X - 40; }
            
            int step = 50;
            int stepTwo = 100;

            ResetClash();
            int overhang = GetOverhang(g, center, radius);
            if (overhang < 10) { radius += (overhang - 10); }

            ClashDetection();

            g.Clear(Color.White);
            writeDefinition(g, center,radius);                                  

            Rectangle area = new Rectangle(center.X - radius + 30, center.Y - radius + 30, (radius - 30) * 2, (radius - 30) * 2);
            g.DrawEllipse(new Pen(Color.Black, 3), area);

            drawTicks(g, center, radius - 30);

            if (chlTerms.CheckedItems.Count != 0)
            {
                for (int index = 0; index < chlTerms.CheckedItems.Count; index++)
                {
                    if (area.Height < step || area.Width < step) { break; }
                    string key = chlTerms.CheckedItems[index].ToString();
                    drawFeatures(g, key, center, radius);
                    area = new Rectangle(area.X + step, area.Y + step, area.Width - stepTwo, area.Height - stepTwo);
                }
            }

            p1.Image = bmp;
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

        private void ClashDetection()
        {
            List<feature> all = new List<feature>();
            if (chlTerms.CheckedItems.Count > 0)
            {
                foreach (string key in chlTerms.CheckedItems)
                {
                    List<feature> list = features[key];

                    if (list.Count > 1)
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
                    for (int index = 0; index < all.Count; index++)
                    {
                        if (index + 1 < all.Count)
                        {
                            int diff = Distance(all[index].TextPoint, all[index + 1].TextPoint);
                            if (Math.Abs(diff) <= 25 && diff > 0)
                            {
                                all[index].Clash = true;
                                all[index + 1].Clash = true;
                            }
                        }
                        else if (index + 1 == all.Count)
                        {
                            int diff = Distance(all[index].TextPoint, all[0].TextPoint);
                            if (Math.Abs(diff) <= 25 && diff > 0)
                            {
                                all[index].Clash = true;
                                all[0].Clash = true;
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
                        else if (index == all.Count && all[0].Clash== true)
                        {
                            count++;
                            Point p = all[0].ClashData;
                            p.X = count;
                            all[0].ClashData = p;
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

        private void writeDefinition(Graphics g, Point center, int radius)
        {
            if (string.IsNullOrEmpty(defination) == true) { return; }
            radius -= 160;
            int fontSize = 20;
            Font f = new Font(FontFamily.GenericSansSerif, fontSize, FontStyle.Bold);
            SizeF s = g.MeasureString(defination, f);
            
            int gap = (radius * 2) ;

            while (s.Width  > gap)
            {
                f = new Font(FontFamily.GenericSansSerif, fontSize, FontStyle.Bold);
                s = g.MeasureString(defination, f);
                fontSize--;
            }

            int x = (int)s.Width / 2;
            g.DrawString(defination,f,Brushes.Black,center.X-x,center.Y - (fontSize));
            s = g.MeasureString(sequencelength.ToString("N0") + " bp", f);
            x = (int)s.Width / 2;
            g.DrawString(sequencelength.ToString("N0") + " bp", f, Brushes.Black, center.X - x, center.Y + (fontSize * 0.5f));

        }

        private void drawTicks(Graphics g, Point center, int radius)
        {
            Pen black =new Pen(Color.Black, 2);
            for (int index = 0; index < sequencelength; index += 1000)
            {
                float angle = (float)index * 360.0f / sequencelength;
                double radion = ((angle - 90) * 2 * Math.PI) / 360;
                float x1 = (int)(Math.Cos(radion) * (radius + 6)) + center.X;
                float y1 = (int)(Math.Sin(radion) * (radius + 6)) + center.Y;
                float x2 = (int)(Math.Cos(radion) * (radius - 5)) + center.X;
                float y2 = (int)(Math.Sin(radion) * (radius - 5)) + center.Y;
                g.DrawLine(black, x1, y1, x2, y2);             
            }
        }

        private void drawFeatures(Graphics g, string featureSet, Point center, int radius)
        {        
            Brush colour = colours[featureSet];

            foreach (feature f in features[featureSet])
            {
                if (f.EndPoint - f.StartPoint < sequencelength / 3)
                {
                    if (f.Forward == true)
                    {
                        Point[] p = getArrow(f.arcStartAngle(sequencelength), f.arcEndAngle(sequencelength), radius, center, true);
                        g.FillPolygon(colour, p);
                        g.DrawPolygon(Pens.Black, p);
                    }
                    else
                    {
                        Point[] p = getArrow( f.arcStartAngle(sequencelength), f.arcEndAngle(sequencelength), radius - 60, center, false);
                        g.FillPolygon(colour, p);
                        g.DrawPolygon(Pens.Black, p);
                     }                   
                }                
            }
            foreach (feature f in features[featureSet])
            {
                if (f.EndPoint - f.StartPoint < sequencelength / 3)
                {
                    if (f.Forward == true)
                    { writeName(g, f,  center, radius); }
                    else
                    { writeName(g, f, center, radius - 60); }
                }
            }


        }

        private Point[] getArrow(float startPoint, float endPoint, int radius, Point center, bool start)
        {
            List<Point> places = new List<Point>();

            double radion;

            if (endPoint - startPoint < 1.1)
            {
                if (start == true)
                {
                    radion = (startPoint * 2 * Math.PI) / 360;
                    Point p = new Point((int)(Math.Cos(radion) * (radius + 22)) + center.X, (int)(Math.Sin(radion) * (radius + 22)) + center.Y);
                    places.Add(p);
                    radion = (startPoint * 2 * Math.PI) / 360;
                    p = new Point((int)(Math.Cos(radion) * (radius - 22)) + center.X, (int)(Math.Sin(radion) * (radius - 22)) + center.Y);
                    places.Add(p);
                    radion = ((endPoint + 1.0f) * 2 * Math.PI) / 360;
                     p = new Point((int)(Math.Cos(radion) * radius) + center.X, (int)(Math.Sin(radion) * radius) + center.Y);
                    places.Add(p);
                }
                else
                {
                    radion = (endPoint * 2 * Math.PI) / 360;
                    Point p = new Point((int)(Math.Cos(radion) * (radius + 22)) + center.X, (int)(Math.Sin(radion) * (radius + 22)) + center.Y);
                    places.Add(p);
                    radion = (endPoint * 2 * Math.PI) / 360;
                    p = new Point((int)(Math.Cos(radion) * (radius - 22)) + center.X, (int)(Math.Sin(radion) * (radius - 22)) + center.Y);
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
                    Point p = new Point((int)(Math.Cos(radion) * (radius + 22)) + center.X, (int)(Math.Sin(radion) * (radius + 22)) + center.Y);
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
                    Point p = new Point((int)(Math.Cos(radion) * (radius - 22)) + center.X, (int)(Math.Sin(radion) * (radius - 22)) + center.Y);
                    places.Add(p);
                }
            }

            return places.ToArray();
        }

        private Point[] writeName(Graphics g,feature f, Point center, int radius)
        {
            Point[] answer = { new Point(0, 0), new Point(0, 0) }; 
            string name = f.Name;
            
            float startPoint = f.arcStartAngle(sequencelength);
            float endPoint = f.arcEndAngle(sequencelength);
            
            Font font = new Font(FontFamily.GenericSansSerif, 20, FontStyle.Bold);
            SizeF lenght = g.MeasureString(name, font);
            float circumference = (float)(2 * radius * Math.PI);

            float arcLength = circumference * (endPoint - startPoint) / 360;
            int fontSize = 19;
            float fontRadiusOffset = 0;
            while (lenght.Width > arcLength && fontSize > 10)
            {
                fontRadiusOffset++;
                font = new Font(FontFamily.GenericSansSerif, fontSize, FontStyle.Bold);
                 lenght = g.MeasureString(name, font);
                 circumference = (float)(2 * radius * Math.PI);

                 arcLength = circumference * (endPoint - startPoint) / 360;
                fontSize--;
            }


            if (lenght.Width < arcLength)
            {
                float diff = (arcLength - lenght.Width) / 2.0f;
                float offset = diff * 360 / circumference;
                float angle = startPoint + offset;

                if (angle < 0 || angle > 180)
                {
                    radius += 28;
                    diff = (arcLength - lenght.Width) / 2.0f;
                    offset = diff * 360 / circumference;

                    angle = startPoint + offset;

                    for (int index = 0; index < name.Length; index++)
                    {
                        SizeF s = g.MeasureString(new string(name[index], 1), font);
                        double radion = (angle * 2 * Math.PI) / 360;
                        float x = (int)(Math.Cos(radion) * (radius - fontRadiusOffset - 13)) + center.X;
                        float y = (int)(Math.Sin(radion) * (radius - fontRadiusOffset - 13)) + center.Y;
                        g.TranslateTransform(x, y);
                        g.RotateTransform((float)angle + 90.0f);
                        g.DrawString(new string(name[index], 1), font, Brushes.Black, 0, 0);
                        g.ResetTransform();
                        angle += (float)(s.Width * 270 / circumference);
                    }
                }
                else
                {
                    radius -= 10;
                    diff = (arcLength - (lenght.Width * (name.Length - 2) / name.Length)) / 2.0f;
                    offset = diff * 360 / circumference;

                    angle = startPoint + offset;
                    for (int index = 0; index < name.Length; index++)
                    {
                        string letter = new string(name[name.Length - (1 + index)], 1);

                        double radion = (angle * 2 * Math.PI) / 360;
                        float x = (int)(Math.Cos(radion) * (radius + fontRadiusOffset - 3)) + center.X;
                        float y = (int)(Math.Sin(radion) * (radius + fontRadiusOffset - 3)) + center.Y;
                        g.TranslateTransform(x, y);
                        g.RotateTransform((float)angle + 270.0f);
                        g.DrawString(letter, font, Brushes.Black, 0, 0);

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
                Point answerSingle = writeRadially(g, f, center, radius);
                if (answerSingle.X < answer[0].X) { answer[0].X = answerSingle.X; }
                if (answerSingle.Y < answer[0].Y) { answer[0].Y = answerSingle.Y; }
                if (answerSingle.X > answer[1].X) { answer[1].X = answerSingle.X; }
                if (answerSingle.Y > answer[1].Y) { answer[1].Y = answerSingle.Y; }
            }
            return answer;
        }

        private Point writeRadially(Graphics g, feature f, Point center, int radius)
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
            float x = (int)(Math.Cos(radion) * (radius - 10)) + center.X;
            float y = (int)(Math.Sin(radion) * (radius - 10)) + center.Y;

            g.TranslateTransform(x, y);

            if (f.Clash == true)
            {
                Point cd = f.ClashData;
                int half = (cd.Y / 2) ;
                int cX = cd.X;
                
                if (f.Forward != false)//chcReverseSequence.Checked)
                {
                    int wiggle =  (5 * (half + 1 - cX));
                    middle -= wiggle; 
                }
                else 
                {
                    int wiggle = (8 * (half + 1 - cX));
                    middle += wiggle; 
                }
            }

            g.RotateTransform(middle - spin);

            SizeF s = g.MeasureString(name, font);
            if (spin == 180)
            {
                if (f.Forward == true)
                { g.DrawString(name, font, Brushes.Black, -38 - s.Width, -6); }
                else
                { g.DrawString(name, font, Brushes.Black, 20, -10); }
            }
            else
            {
                if (f.Forward == true)
                { g.DrawString(name, font, Brushes.Black, 38, -10); }
                else
                { g.DrawString(name, font, Brushes.Black, -16 - s.Width, -6); }
            }
            
            g.ResetTransform();

            if (f.Forward == true)
            {
                if (spin == 180)
                {
                    float dX = (int)(Math.Cos(-radion) * -(38 + s.Width));
                    float dY = (int)(Math.Sin(-radion) * +(38 + s.Width));
                    answer = new Point((int)(x - dX), (int)(y - dY));
                    f.TextPoint = new Point((int)(x - dX), (int)(y - dY));
                }
                else
                {
                    float dX = (int)(Math.Cos(-radion) * -(38 + s.Width));
                    float dY = (int)(Math.Sin(-radion) * +(38 + s.Width));
                    answer = new Point((int)(x - dX), (int)(y - dY));
                    f.TextPoint = new Point((int)(x - dX), (int)(y - dY));
                }
            }
            else 
            { 
                if (spin  == 180)
                {
                    float dX = (int)(Math.Cos(-radion) * 20);
                    float dY = (int)(Math.Sin(-radion) * -20);
                    f.TextPoint  = new Point((int)(x - dX), (int)(y - dY));
                }
                else
                {
                    float dX = (int)(Math.Cos(-radion) * -(16 ));
                    float dY = (int)(Math.Sin(-radion) * (16 ));                    
                    f.TextPoint = new Point((int)(x + dX), (int)(y + dY));
                }
            }


            return answer;
        }

        public int Distance(Point one, Point two)
        {
            double square = Math.Pow((one.X - two.X), 2) + Math.Pow((one.Y - two.Y), 2);
            int answer =  (int)Math.Sqrt(square);
            return  answer;
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
            drawFeatures();
        }

        private void p1_MouseClick(object sender, MouseEventArgs e)
        {
            drawFeatures();
        }

        private int GetOverhang(Graphics g, Point center, int radius)
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
                        Point[] answerP = writeName(g, f, center, radius);
                        if (answer > answerP[0].X)
                        { answer = answerP[0].X; }

                        if (answer > answerP[0].Y)
                        { answer = answerP[0].Y; }

                        if (answer > p1.Width - answerP[1].X)
                        { answer = (p1.Width - answerP[1].X); }

                        if (answer > p1.Height - answerP[1].Y)
                        { answer = (p1.Height - answerP[1].Y); }
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
            drawFeatures();
        }

        private void cboStart_SelectedIndexChanged(object sender, EventArgs e)
        {
            int start = 0;
            if (cboStart.SelectedIndex == 0)
            { }
            else
            {
                string keys = cboStart.Text;
                string featureType = keys.Substring(0, keys.IndexOf(": "));
                string featureName = keys.Substring(keys.IndexOf(": ") + 2);
                List<feature> list = features[featureType];
                foreach (feature f in list)
                {
                    if (f.Name == featureName)
                    {
                        start = f.StartPoint;
                        break;
                    }
                }

                foreach(List<feature> listF in features.Values)
                {
                    foreach (feature f in listF)
                    {
                        f.ResetStart(sequencelength, start);
                    }
                }
            }
            drawFeatures();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            cboNameOptions.SelectedIndex = 0;
        }

        private void cboNameOptions_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (features == null) { return; }
            foreach (List<feature> list in features.Values)
            { 
                foreach (feature f in list)
                {
                    f.SetDisplayName(cboNameOptions.Text);
                }
            }
            drawFeatures();
        }
    }
}
