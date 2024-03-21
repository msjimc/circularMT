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
    public partial class AddFeature : Form
    {
        private Dictionary<string, List<feature>> features = new Dictionary<string, List<feature>>();
        public Form1 parent = null;
        private int sequenceLength = -1;
        private bool nameAdd = false;
        private string name = "";
        private bool startAdd = false;
        private int startPoint = -1;
        private bool lengthAdd = false;
        private int length = -1;
        private bool strandSet = false;
        private bool strand = false;
        private int newSTartOffSet = 0;
        public AddFeature(Dictionary<string, List<feature>> features, Form1 parent, List<string> terms, int Length, int NewSTartOffSet)
        {
            InitializeComponent();

            this.parent = parent;
            this.features = features;
            this.sequenceLength = Length;
            this.newSTartOffSet = NewSTartOffSet;

            cboTerms.Items.Add("Select");
            foreach (string term in terms)
            { cboTerms.Items.Add(term); }
            cboTerms.SelectedIndex = 0;
            cboStrand.SelectedIndex = 0;
        }

            private void btnClose_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void cboTerms_SelectedIndexChanged(object sender, EventArgs e)
        {
            bool isEnabled = true;
            if (cboTerms.SelectedIndex > 0)
            { isEnabled = true; }
            else
            { isEnabled = false; }
            txtName.Enabled = isEnabled;
            txtLength.Enabled = isEnabled;
            txtStart.Enabled = isEnabled;
            txtName.Clear();            
        }

        private void TestInputs()
        {
            if (strandSet==true && startAdd==true && lengthAdd==true && nameAdd == true)
            { btnAdd.Enabled = true; }
            else { btnAdd.Enabled = false; }
        } 
        
        private void txtNames_TextChanged(object sender, EventArgs e)
        {
            if (txtName.Text.Trim().Length >0)
            { 
                nameAdd = true;
                name = txtName.Text.Trim();
            }

            TestInputs();
        }

        private void txtStart_TextChanged(object sender, EventArgs e)
        {
            try 
            { 
                string t = txtStart.Text.Trim().Replace(",","");
                startPoint = Convert.ToInt32(t);
                if (startPoint > -1 && startPoint < sequenceLength +1)
                { 
                    startAdd = true;
                    txtStart.ForeColor = ForeColor;
                }
                else 
                { 
                    startAdd = false;
                    txtStart.ForeColor = Color.Red;
                }
            }
            catch 
            { 
                txtStart.ForeColor = Color.Red;
                startAdd = false;
            }
            TestInputs();
        }

        private void txtLength_TextChanged(object sender, EventArgs e)
        {
            try
            {
                string t = txtLength.Text.Trim().Replace(",", "");
                length = Convert.ToInt32(t);
                if (length > -1 && length < (sequenceLength / 3))
                {
                    lengthAdd = true;
                    txtLength.ForeColor = ForeColor;
                }
                else
                {
                    lengthAdd = false;
                    txtLength.ForeColor = Color.Red;
                }
            }
            catch
            {
                txtLength.ForeColor = Color.Red;
                lengthAdd = false;
            }
            TestInputs();
        }

        private void cboStrand_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cboStrand.SelectedIndex > 0)
            { 
                strandSet = true; 
                if (cboStrand.SelectedIndex == 1) { strand = true; }
                else if (cboStrand.SelectedIndex == 2) { strand = false; }
            }
            else
            { strandSet= false; }

            TestInputs();
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            int newStart = startPoint - newSTartOffSet;
          
            while (newStart < 0)
            { newStart += sequenceLength; }

            feature f = new feature(name, newStart, length, strand);
            features[cboTerms.Text].Add(f);
            features[cboTerms.Text].Sort(new featureSorter());
            parent.ReDrawFromOutSide();
        }
    }
}
