using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Drawing;

namespace circularMT
{
    public  class feature
    {
        private string name = "";
        private string gene = "";
        private string product = "";
        private string gene_synonym = "";
        private string userSet = "";
        private string featureType = "";
        private int from = -1;
        private int too = -1;
        private bool forward = true;
        private Point textPoint = new Point(-1, -1);
        Point clashData = new Point(0, 0);
        private Brush color = Brushes.Gray;
        private Point[] arrows = null;

        public feature(string[] lines, int index, int endIndex, string FeatureType, string dataType)
        {
            featureType = FeatureType;

            if (dataType == "genbank")
            { Genbank(lines, index, endIndex, featureType); }
            else if (dataType == "fasta")
            { Fasta(lines); }
            else if (dataType == "gff")
            { GFF(lines, FeatureType); }
            else if (dataType == "gtf")
            { GTF(lines, FeatureType); }
            else if (dataType == "bed")
            { BED(lines, FeatureType); }
            else if (dataType == "mitos")
            { MITOS(lines, FeatureType); }
            else if (dataType == "seq")
            { SEQ(lines, FeatureType); }
        }

        private void SEQ(string[] data, string Feature)
        {           
            name = data[3].Trim();
            gene = name;

            try
            {
                from = Convert.ToInt32(data[0]);
                too = Convert.ToInt32(data[1]);
                int seqLen = Convert.ToInt32(data[4]);
                if (Math.Abs(too-from) > seqLen / 3)
                {
                    from = too - Convert.ToInt32(data[4]);
                }

                if (from < too)
                { 
                    forward = true; 
                }
                else if (too < from)
                { 
                    forward = false;
                    int t = from;
                    from = too;
                    too = t;
                }

                if (too < from)
                { from = too - Convert.ToInt32(data[4]); }
            }
            catch (Exception ex)
            { throw new Exception("Error getting coordinates from " + name); }
        }

        private void MITOS(string[] data, string Feature)
        {
            if (data[6].Trim() == "-1")
            { forward = false; }
            name = data[2].Trim();
            gene = name;

            try
            {
                from = Convert.ToInt32(data[4]);
                too = Convert.ToInt32(data[5]);
                if (too < from)
                { from =  Convert.ToInt32(data[14])  + too; }
            }
            catch (Exception ex)
            { throw new Exception("Error getting coordinates from " + name); }
        }

        private void BED(string[] data, string Feature)
        {
            if (data[5].Trim() == "-")
            { forward = false; }
            name = data[3].Trim();
            gene = name;

            try
            {
                from = Convert.ToInt32(data[1]);
                too = Convert.ToInt32(data[2]);
                if (too < from)
                { from = Convert.ToInt32(data[6]) + too; }
            }
            catch (Exception ex)
            { throw new Exception("Error getting coordinates from " + name); }
        }
       
        private void GFF(string[] data, string FeatureType)
        {
            featureType = FeatureType;

            if (data[6].Trim() == "-")
            { forward = false; }

            if (data[2].ToLower() == "region")
            { 
                name = "Region"; 
                gene = name; 
            }
            else
            {
                int one = data[8].IndexOf("Name=") + 5;
                int two = data[8].IndexOf(";", one);

                if (one > 4 && two > one)
                { name = data[8].Substring(one, two - one); }
                else if (one > 4 && two == -1)
                { name = data[8].Substring(one).Trim(); }
                else { name = ""; }

                 one = data[8].IndexOf("gene_id=") + 8;
                 two = data[8].IndexOf(";", one);

                if (one > 5 && two > one)
                { gene = data[8].Substring(one, two - one); }
                else if (one > 5 && two == -1)
                { gene = data[8].Substring(one).Trim(); }
                else { gene = ""; }

                if (gene == "" && name != "")
                { gene = name; }

                if (gene != "" && name == "")
                { name = gene; }
            }

            try
            {
                from = Convert.ToInt32(data[3]);
                too = Convert.ToInt32(data[4]);
                if (too < from)
                { from = Convert.ToInt32(data[14]) + too; ; }
            }
            catch (Exception ex)
            { throw new Exception("Error getting coordinates from " + name); }

        }

        private void GTF(string[] data, string FeatureType)
        {
            featureType = FeatureType;

            if (data[6].Trim() == "-")
            { forward = false; }

            if (data[2].ToLower() == "region")
            {
                name = "Region";
                gene = name;
            }
            else
            {
                int one = data[8].IndexOf("gene_id ") + 8;
                int two = data[8].IndexOf(";", one);

                if (one > 4 && two > one)
                { name = data[8].Substring(one, two - one).Replace("\"",""); }
                else if (one > 4 && two == -1)
                { name = data[8].Substring(one).Trim().Replace("\"", ""); }
                else { name = ""; }

                one = data[8].IndexOf("transcript_name ") + 15;
                two = data[8].IndexOf(";", one);

                if (one > 5 && two > one)
                { gene = data[8].Substring(one, two - one).Replace("\"", ""); }
                else if (one > 5 && two == -1)
                { gene = data[8].Substring(one).Trim().Replace("\"", ""); }
                else { gene = ""; }

                if (gene == "" && name != "")
                { gene = name; }

                if (gene != "" && name == "")
                { name = gene; }


            }

            try
            {
                from = Convert.ToInt32(data[3]);
                too = Convert.ToInt32(data[4]);
                if (too < from)
                { from = Convert.ToInt32(data[14]) + too; ; }
            }
            catch (Exception ex)
            { throw new Exception("Error getting coordinates from " + name); }

        }

        private void Fasta(string[] data)
        {
            if (data[2].Trim() == "-")
            { forward = false; }
            name = data[3].Trim().Replace(">","");
            gene = name;
           
            string[] items = data[1].Trim().Split('-');

            try
            {
                from = Convert.ToInt32(items[0]);
                too = Convert.ToInt32(items[1]);
                if (too < from)
                { from = Convert.ToInt32(data[4]) + too; ; }

            }
            catch (Exception ex)
            { throw new Exception("Error getting coordinates from " + name); }

        }

        private void Genbank(string[] lines, int index, int endIndex, string FeatureType)
        {
            featureType = FeatureType; 
            if (lines[index][21] == 'c')
            { forward = false; }

            gene = FeatureType;
            name = gene;

            for (int lineIndex = index + 1; lineIndex < endIndex; lineIndex++)
            {
                if (lines[lineIndex].ToLower().Contains("/ID") == true)
                { setName(lines[lineIndex]); }
                else if (lines[lineIndex].ToLower().Contains("/gene_id") == true)
                { setName(lines[lineIndex]); }
                else if (lines[lineIndex].ToLower().Contains("/Name") == true)
                { setName(lines[lineIndex]); }
                else if (lines[lineIndex].ToLower().Contains("/gene") == true)
                { setName(lines[lineIndex]); }
                else if (lines[lineIndex].ToLower().Contains("/product") == true)
                { setName(lines[lineIndex]); }
                else if (lines[lineIndex].ToLower().Contains("/gene_synonym") == true)
                { setName(lines[lineIndex]); }

            }

            setcoordinates(lines[index]);
        }

        private void setName(string line)
        {
            string[] items = line.Split('"');
            if (items.Length > 0)
            {
                if (items[0].ToLower().Contains("/product"))
                {  product = items[1]; }
                else if (items[0].ToLower().Contains("/gene_synonym"))
                { gene_synonym = items[1]; }
                else
                {
                    if (items[1].Contains('_') == true)
                    {  gene = items[1].Split('_')[1]; }
                    else
                    { gene = items[1]; }
                }
                name = gene;
            }
        }

        public void SetDisplayName(string option)
        {
            if (option == "Gene" && string.IsNullOrEmpty(gene) == false)
            { name = gene; }
            else if (option == "Product" && string.IsNullOrEmpty(product) == false)
            { name = product; }
            else if (option == "Gene synonym" && string.IsNullOrEmpty(gene_synonym) == false)
            { name = gene_synonym; }
            else if (option == "User set" && string.IsNullOrEmpty(userSet) == false)
            { name = userSet; }
            else { name = gene; }
        }

        private void setcoordinates(string line)
        {

            int bracket = line.LastIndexOf("(");
            string data = "";
            if (bracket == -1)
            { data = line.Substring(21).Trim(); }
            else
            {
                data = line.Substring(line.LastIndexOf("(") + 1).Trim();
                data = data.Substring(0, data.IndexOf(")"));
            }

            if (line.Contains("(join(") == false)
            {
                try
                {
                    string[] items = data.Split('.');
                    from = Convert.ToInt32(items[0]);
                    too = Convert.ToInt32(items[2]);
                }
                catch { throw new Exception("Coordinate error for " + name + " feature"); }
            }
            else
            {
                string[] joins = data.Split(',');
                string[] items1 = joins[0].Split('.');
                int t1 = Convert.ToInt32(items1[0]);
                int t2 = Convert.ToInt32(items1[2]);
               
                string[] items2 = joins[1].Split('.');
                int t3 = Convert.ToInt32(items2[0]);
                int t4 = Convert.ToInt32(items2[2]);

                if (t3==1)
                {
                    from = -(t2 - t1);
                    too = t4;
                }
                else 
                {
                    MessageBox.Show("File has a 'join' associated with " + name + " that doesn't span the end of the sequence:\nExpected join(16024..16569,1..576), but got:\n" + data, "error");
                }

            }

        }

        public void ReverseComplementSequence(int sequencelength)
        {
            forward = !forward;
            int t = sequencelength - too;
            too= sequencelength - from;
            from = t;
        }

        public void ResetStart(int sequencelength, int newStart)
        {
            from -= newStart;
            too -= newStart;
            if (too < 0)
            {
                from += sequencelength;
                too += sequencelength;
            }
        }

        public void ResetCoordinatesOfFeatureSpanningContigEnds(int sequencelength) 
        {
            int diff = from - sequencelength;
            from = diff;
        }

        public float arcEndAngle(int length)
        {
            float angle = too / (float)length * 360;
            angle = angle - 90.0f;
            return angle;
        }

        public float arcStartAngle(int length)
        {
            float angle = from / (float)length * 360;
            angle = angle - 90.0f;
            return angle;
        }

        public float arcLengthAngle(int length)
        {
            float angle = (too - from) / (float)length * 360;
          
            return angle;
        }

        public string FeatureType
        { get { return featureType; } }

        public int StartPoint
        { get { return from; } }

        public int EndPoint
        { get { return too; } }

        public void ReSetEndPoint(int currentLength, int newLength)
        {
            int t = too - currentLength;
            too = newLength + too;
        }

        public bool Forward
        { get { return forward; } }

        public string Name
        { get { return (name + new string(' ', 18)).Substring(0,17).Trim(); } }
                    
        public Point TextPoint
        {
            get { return textPoint; }
            set { textPoint = value; }
        }

        public void ResetClash()
        {
            clash = false;
            textPoint = new Point(-1, -1);
            clashData = new Point(0, 0);
        }

        public bool clash = false;
        public bool Clash
        {
            get { return clash; }
            set { clash = value; }
        }

        public Point ClashData
        {
            get { return clashData; }
            set { clashData = value; }
        }

        public Brush FeatureColour
        {
            get { return color; }
            set { color = value; }
        }

        public Point[] Arrows
        {
            get { return arrows; }
            set { arrows = value; }
        }

    }
}
