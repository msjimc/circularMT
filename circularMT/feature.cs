﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Drawing;

namespace circularMT
{
    internal class feature
    {
        private string name = "";
        private string gene = "";
        private string product = "";
        private string gene_synonym = "";
        private string featureType = "";
        private int from = -1;
        private int too = -1;
        private bool forward = true;

        public feature(string[] lines, int index, int endIndex, string FeatureType)
        {
            featureType = FeatureType;
            if (lines[index][21] == 'c')
            { forward = false; }

            gene = FeatureType;
            name = gene;

            for (int lineIndex = index+1; lineIndex < endIndex; lineIndex++) 
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

            setcoordinates( lines[index]);
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

        public bool Forward
        { get { return forward; } }

        public string Name
        { get { return name; } }
              
        Point textPoint = new Point(-1,-1);
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

        Point clashData = new Point(0,0);
        public Point ClashData
        {
            get { return clashData; }
            set { clashData = value; }
        }
    }
}
