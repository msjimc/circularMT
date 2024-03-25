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
    public partial class EditNames : Form
    {
        private Dictionary<string, List<feature>> features = new Dictionary<string, List<feature>>();
        public Form1 parent = null;
        private List<string> terms = new List<string>();
        private bool oneSelected = false;
        
        public EditNames(Dictionary<string, List<feature>> features, Form1 parent, List<string> Terms)
        {
            InitializeComponent();

            this.parent = parent;
            this.features = features;
            this.terms = Terms;

            cboTerms.Items.Add("Select");
            foreach (string term in terms)
            { cboTerms.Items.Add(term); }
            cboTerms.SelectedIndex = 0;
        }

        private void cboTerms_SelectedIndexChanged(object sender, EventArgs e)
        {
            
            if (cboTerms.SelectedIndex > 0)
            { txtNames.Enabled = true; }
            else
            { txtNames.Enabled = false; }
            txtNames.Clear();
            txtListOfNames.Clear();
            parent.ResetBoxColour(terms, 1);
        }

        private void txtNames_TextChanged(object sender, EventArgs e)
        {
            if (features == null || cboTerms.Text == "Select") { return; }

            Pen selected = new Pen(Color.Red, 2);
            string namePart = txtNames.Text.Trim();
            if (string.IsNullOrEmpty(namePart)) 
            {
                txtListOfNames.Clear();
                txtListOfNames.Enabled = false;
                return; 
            }            

            txtListOfNames.Clear();
            btnSelect.Enabled = false;
            int counter = 0;
            foreach (feature f in features[cboTerms.Text])
            {
                if (f.Name.StartsWith(namePart) == true)
                {
                    txtListOfNames.Text += f.Name + " ";
                    counter += 1;
                    f.BoxColour = selected;
                }
                else
                { f.BoxColour = Pens.Black; }
            }

            if (counter == 1)
            {  oneSelected = true; }
            else { oneSelected = false; }
            
            if (counter > 1)
            { btnNumber.Enabled = true;}
            else { btnNumber.Enabled = false; }

            txtNew.Enabled = oneSelected;

            parent.ReDrawFromOutSide();

        }

        private void btnNumber_Click(object sender, EventArgs e)
        {
            
            if (features == null || cboTerms.Text == "Select") { return; }

            int count = 1;
            string namePart = txtNames.Text.Trim();
            foreach (feature f in features[cboTerms.Text])
            {
                if (f.Name.StartsWith(namePart) == true)
                {
                    f.Name += " - " + count.ToString();
                    count += 1;
                }
            }
            if (count>0)
            { parent.ReDrawFromOutSide(); }
        }

        private void txtNew_TextChanged(object sender, EventArgs e)
        {
            if (txtNew.Text.Trim().Length > 0 && oneSelected == true)
            { btnSelect.Enabled = true; }
            else { btnSelect.Enabled = false; }
        }

        private void btnSelect_Click(object sender, EventArgs e)
        {
            string namePart = txtNames.Text.Trim();


            bool changed = false;
            foreach (feature f in features[cboTerms.Text])
            {
                if (f.Name.StartsWith(namePart) == true)
                {
                    f.Name = txtNew.Text.Trim();
                    changed = true;
                }
            }
            if (changed == true)
            { parent.ReDrawFromOutSide(); }

            txtNew.Clear();
        }   
        
        private void btnClose_Click(object sender, EventArgs e)
        {
            Close();
        }
  
    }
}
