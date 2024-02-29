using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace circularMT
{
    internal class feature
    {
        private string name = "";
        private string featureType = "";
        private int from = -1;
        private int too = -1;
        private bool forward = true;

        public feature(string[] lines, int index, int endIndex, string FeatureType)
        {
            featureType = FeatureType;
            if (lines[index][21] == 'c')
            { forward = false; }

            for (int lineIndex = index+1; lineIndex < endIndex; lineIndex++) 
            {
                if (lines[lineIndex].Contains("/ID") == true)
                { setName(lines[lineIndex]); }
                else if (lines[lineIndex].Contains("/gene_id") == true)
                { setName(lines[lineIndex]); }
                else if (lines[lineIndex].Contains("/Name") == true)
                { setName(lines[lineIndex]); }
                
            }

            setcoordinates( lines[index]);

        }

        private void setName(string line)
        {
            string[] items = line.Split('"');
            if (items.Length > 0)
            {
                if (items[1].Contains('_') == true)
                {
                    name = items[1].Split('_')[1];
                }
                else
                { name = items[1]; }
            }
        }

        private void setcoordinates(string data)
        {
            int bracket = data.IndexOf("(");
            if (bracket == -1)
            { data = data.Substring(21).Trim(); }
            else 
            { 
                data = data.Substring(data.LastIndexOf("(") + 1).Trim();
                data = data.Substring(0, data.Length - 1);
            }
            
            try
            {
                string[] items = data.Split('.');
                from = Convert.ToInt32(items[0]);
                too = Convert.ToInt32(items[2]);
            }
            catch { throw new Exception("Coordinate error for " + name + " feature"); }

        }

        public float arcEndAngle(int length)
        {
            float angle = too / (float)length * 360;
            return angle;
        }

        public float arcStartAngle(int length)
        {
            float angle = from / (float)length * 360;
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

        public bool Forward
        { get { return forward; } }

        public string Name
        { get { return name; } }


        //public void CoordinatesAtEndOfSequence(int genomelength)
        //{
        //    if (too - from > genomelength)
        //    {
        //        int t = too;
        //        too = from;
        //        from = t;
        //    }
        //}

    }
}
