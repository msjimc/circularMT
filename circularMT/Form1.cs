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
                    if (area.Height < step || area.Width < step) { break; }
                    string key = chlTerms.CheckedItems[index].ToString();
                    drawFeatures(g, key, area, 20, center, radius);
                    area = new Rectangle(area.X + step, area.Y + step, area.Width - stepTwo, area.Height - stepTwo);
                    
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
                        Point[] p = getArrow(f.arcEndAngle(sequencelength), f.arcStartAngle(sequencelength), f.arcEndAngle(sequencelength), radius, center, true);
                        g.FillPolygon(Brushes.PaleGreen, p);
                        g.DrawPolygon(Pens.Black, p);
                        writeName(g, f.Name, f.arcStartAngle(sequencelength), f.arcEndAngle(sequencelength), center, radius);
                    }
                    else
                    {
                        Point[] p = getArrow(f.arcEndAngle(sequencelength), f.arcStartAngle(sequencelength), f.arcEndAngle(sequencelength), radius, center, false);
                        g.FillPolygon(Brushes.Pink, p);
                        g.DrawPolygon(Pens.Black, p);
                        writeName(g, f.Name, f.arcStartAngle(sequencelength), f.arcEndAngle(sequencelength), center, radius);
                    }                   
                }                
            }
        
        }

        private Point[] getArrow(float degrees, float startPoint, float endPoint, int radius, Point center, bool start)
        {           
            List<Point> places = new List<Point>();

            double radion;

            if (start == true)
            { endPoint -= 1.0f; }
            else
            {
                radion = (startPoint * 2 * Math.PI) / 360;
                Point p = new Point((int)(Math.Cos(radion) * radius)  + center.X, (int)(Math.Sin(radion) * radius) + center.Y);
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


            return places.ToArray();
        }

        private void writeName(Graphics g, string name, float startPoint, float endPoint, Point center, int radius)
        {
            radius += 30;
            Font f = new Font(FontFamily.GenericSansSerif, 20);
            SizeF lenght = g.MeasureString(name, f);
            float circumference = (float)(2 * radius * Math.PI);
            float angle = startPoint;
            for (int index = 0; index < name.Length; index++)
            {
                SizeF s = g.MeasureString(new string(name[index], 1), f);                
                double radion = (angle * 2 * Math.PI) / 360;
                float x = (int)(Math.Cos(radion) * (radius - 10)) + center.X;
                float y = (int)(Math.Sin(radion) * (radius - 10)) + center.Y;
                //g.DrawString(new string(name[index], 1), f, Brushes.Black, x, y);
                //g.DrawEllipse(Pens.Black, x-2, y-2 , 4, 4);
                g.TranslateTransform(x, y);
                g.RotateTransform((float)angle + 90.0f);
                g.DrawString(new string(name[index], 1), f, Brushes.Black, 0, 0);
                g.DrawEllipse(Pens.Black, -2, -2, 4, 4);
                g.ResetTransform();
                angle += (float)(s.Width * 270 / circumference);
            }
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
