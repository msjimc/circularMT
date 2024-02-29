using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace circularMT
{
    public partial class Form1 : Form
    {
        Dictionary<string, List<feature>> features = new Dictionary<string, List<feature>>();
        int sequencelength = -1;
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void btnGenBank_Click(object sender, EventArgs e)
        {
            string filename = FileAccessClass.FileString(FileAccessClass.FileJob.Open, "Seletct the genbank mitochondrial genome file", "*.gnk;*.genbank|*.gnk;*.genbank");
            if (System.IO.File.Exists(filename) == false) { return; }

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
                        feature f = new feature(lines, startOfFeatures[place], startOfFeatures[place + 1], lines[startOfFeatures[place]].Substring(0, 21).Trim());
                        features[f.FeatureType].Add(f);
                    }
                    else 
                    {
                        feature f = new feature(lines, startOfFeatures[place], lastPlace, lines[startOfFeatures[place]].Substring(0, 21).Trim());
                        features[f.FeatureType].Add(f);
                    }
                }

                sequencelength = getlength();
    

                drawfeatures();

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

            foreach (string line in lines)
            {
                if (line.StartsWith("     ") == true && line.StartsWith("      ") == false)
                {
                    string term = line.Substring(0, 21).Trim();
                    if (features.ContainsKey(term) == false)
                    {
                        features.Add(term, new List<feature>());
                        chlTerms.Items.Add(term);
                    }
                }
            }

            for (int count = 0; count < chlTerms.Items.Count; count++)
            {
                chlTerms.SetItemChecked(count, true);
            }
        }

        private void drawfeatures()
        {
            Bitmap bmp = new Bitmap(p1.Width, p1.Height, System.Drawing.Imaging.PixelFormat.Format32bppArgb);
            Graphics g = Graphics.FromImage(bmp);
            g.SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.HighQuality;
            g.Clear(Color.White);

            Point center = new Point(bmp.Width/2, bmp.Height/2);
            int radius = -1;          
            if (bmp.Width > bmp.Height)
            { radius = center.Y - 40; }
            else
            { radius = center.X - 40; }

            int step = 50;
            int stepTwo = 100;

            Rectangle area = new Rectangle(center.X - radius, center.Y - radius, radius * 2,radius*2) ;
            if (chlTerms.CheckedItems.Count != 0)
            {
                for (int index = 0; index < chlTerms.CheckedItems.Count; index++)
                {
                    string key = chlTerms.CheckedItems[index].ToString();
                    drawFeatures(g, key, area, 20, center, radius);
                    area = new Rectangle(area.X + step, area.Y + step, area.Width - stepTwo, area.Height - stepTwo);
                    if (area.Height < 20 || area.Width < 20) { break; }
                    radius -= step;
                }
            }



            p1.Image = bmp;
        }

        private void drawFeatures(Graphics g, string featureSet, Rectangle area, int increment, Point center, int radius)
        {
            int step = increment;
            int stepTwo = increment * 2;

            Rectangle outer = new Rectangle(area.X - step, area.Y - step, area.Width + stepTwo, area.Height + stepTwo);
            Rectangle inner = new Rectangle(area.X + step, area.Y + step, area.Width - stepTwo, area.Height - stepTwo);

            g.DrawEllipse(Pens.Black, area);


            foreach (feature f in features[featureSet])
            {
                if (f.EndPoint - f.StartPoint < sequencelength / 3)
                {
                    if (f.Forward == true)
                    {
                        g.FillPie(Brushes.PaleGreen, outer, f.arcStartAngle(sequencelength), f.arcLengthAngle(sequencelength) - 1);
                        g.FillPolygon(Brushes.PaleGreen, getArrow(f.arcEndAngle(sequencelength), radius, center, true));
                    }
                    else
                    {
                        g.FillPie(Brushes.Pink, outer, f.arcStartAngle(sequencelength) + 1, f.arcLengthAngle(sequencelength) -1);
                        g.FillPolygon(Brushes.Pink, getArrow(f.arcStartAngle(sequencelength), radius, center, false));
                    }
                    g.DrawPie(Pens.Black, outer, f.arcStartAngle(sequencelength), f.arcLengthAngle(sequencelength));
                    g.DrawPie(Pens.Black, inner, f.arcStartAngle(sequencelength), f.arcLengthAngle(sequencelength));
                   
                }
                
            }
           g.FillEllipse(Brushes.White, inner.X + 1, inner.Y + 1, inner.Width - 2, inner.Height - 2);


        }

        private Point[] getArrow(float degrees, int radius, Point center, bool start)
        {
            Point[] points = new Point[3];
            int difference = 1;
            if (start == true) { difference = -1; }
            double radion = ((degrees + difference) * 2 * Math.PI) / 360;
            points[0] = new Point((int)(Math.Cos(radion) * (radius + 22)) + center.X, (int)(Math.Sin(radion) * (radius + 22)) + center.Y);
            points[1] = new Point((int)(Math.Cos(radion) * (radius - 22)) + center.X, (int)(Math.Sin(radion) * (radius - 22)) + center.Y);
            radion = ((degrees) * 2 * Math.PI) / 360;
            points[2] = new Point((int)(Math.Cos(radion) * (radius)) + center.X, (int)(Math.Sin(radion) * (radius)) + center.Y);
            return points;
        }

        private int getlength()
        {
            int length = -1;
            foreach (feature f in features["region"])
            {
                if (length < f.EndPoint) { length = f.EndPoint; }
            }
            return length;
        }

        private void chlTerms_MouseUp(object sender, MouseEventArgs e)
        {
            drawfeatures();
        }
    }
}
