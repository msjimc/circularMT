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
    public partial class AdjustTextLocation : Form
    {
        private Dictionary<string, List<feature>> features = new Dictionary<string, List<feature>>();
        public Form1 parent = null;
        private bool oneSelected = false;
        private feature selectedFeature = null;

        public AdjustTextLocation(Dictionary<string, List<feature>> features, Form1 parent, List<string> terms)
        {
            InitializeComponent();

            this.parent = parent;
            this.features = features;

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
        }

        private void txtNames_TextChanged(object sender, EventArgs e)
        {
            if (features == null || cboTerms.Text == "Select") { return; }

            string namePart = txtNames.Text.Trim();
            if (string.IsNullOrEmpty(namePart))
            {
                txtListOfNames.Clear();
                txtListOfNames.Enabled = false;
                return;
            }

            txtListOfNames.Clear();
            int counter = 0;
            foreach (feature f in features[cboTerms.Text])
            {
                if (f.Name.StartsWith(namePart) == true)
                {
                    txtListOfNames.Text += f.Name + " ";
                    counter += 1;
                    selectedFeature = f;
                }
            }

            if (counter == 1)
            { 
                oneSelected = true;
                nupRotate.Value = 0;
                nupUpDown.Value = 0;
                nupbackAndForth.Value = 0;
            }
            else
            {
                oneSelected = false;
                selectedFeature = null;
            }

            if (counter > 1)
            { btnNumber.Enabled = true; }
            else { btnNumber.Enabled = false; }

            nupbackAndForth.Enabled = oneSelected;
            nupUpDown.Enabled = oneSelected;
            nupRotate.Enabled = oneSelected;
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
            if (count > 0)
            { parent.ReDrawFromOutSide(); }
        }

        private void nupbackAndForth_ValueChanged(object sender, EventArgs e)
        {
            if (selectedFeature != null)
            {
                selectedFeature.HorizontalOffset = -(int)nupbackAndForth.Value;
                parent.ReDrawFromOutSide();
            }
        }

        private void nupUpDown_ValueChanged(object sender, EventArgs e)
        {
            if (selectedFeature != null)
            {
                selectedFeature.VerticalOffset = (int)nupUpDown.Value;
                parent.ReDrawFromOutSide();
            }
        }

        private void nupRotate_ValueChanged(object sender, EventArgs e)
        {
            if (selectedFeature != null)
            {
                selectedFeature.Rotate = (int)nupRotate.Value;
                parent.ReDrawFromOutSide();
            }
        }
    }
}
