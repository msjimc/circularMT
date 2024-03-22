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
    public partial class Deletefeature : Form
    {
        private Dictionary<string, List<feature>> features = new Dictionary<string, List<feature>>();
        public Form1 parent = null;
        private List<string> terms = new List<string>();
        public Deletefeature(Dictionary<string, List<feature>> features, Form1 parent, List<string> Terms)
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

        private void btnClose_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void cboTerms_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cboTerms.SelectedIndex > 0)
            { txtNames.Enabled = true; }
            else
            { txtNames.Enabled = false; }
            txtNames.Clear();
            txtListOfNames.Clear();
            parent.ResetBoxColour(terms);
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
            btnDelete.Enabled = false;
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
            if (counter > 0) 
            { btnDelete.Enabled = true; }
            parent.ReDrawFromOutSide();
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            if (features == null || cboTerms.Text == "Select") { return; }

            string namePart = txtNames.Text.Trim();
            if (string.IsNullOrEmpty(namePart))
            {
                txtListOfNames.Clear();
                txtListOfNames.Enabled = false;
                return;
            }

            List<feature> newSet = new List<feature>();

            foreach (feature f in features[cboTerms.Text])
            {
                if (f.Name.StartsWith(namePart) == false)
                {
                    newSet.Add(f);                    
                }
            }

            features[cboTerms.Text] = newSet;
            parent.ReDrawFromOutSide();

        }
    }
}
