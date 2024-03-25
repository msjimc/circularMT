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
    public partial class AdjustColours : Form
    {
        private Dictionary<string, Brush> colourscheme = null;
        private Dictionary<string, List<feature>> features = new Dictionary<string, List<feature>>();
        public Form1 parent = null;
        private List<string> terms = new List<string>();

        public AdjustColours(Dictionary<string, Brush> colourscheme, Dictionary<string, List<feature>> features, Form1 parent, List<string> Terms)
        {
            InitializeComponent();
            this.colourscheme = colourscheme;
            this.features = features;
            this.parent = parent;
            this.terms = Terms;

            cboTerms.Items.Add("Select");
            cboCopy.Items.Add("Select");
            foreach (string term in terms)
            { 
                cboTerms.Items.Add(term); 
                foreach (feature f in features[term])
                { cboCopy.Items.Add(term + ": " + f.Name); }
            }
            cboTerms.SelectedIndex = 0;
            cboCopy.SelectedIndex = 0;



        }

        private void AdjustColours_Load(object sender, EventArgs e)
        {
            
        }

        private void cboTerms_SelectedIndexChanged(object sender, EventArgs e)
        {
            txtNames.Clear();
            if (cboTerms.SelectedIndex > 0)
            {
                txtNames.Enabled = true;
                //cboCopy.Items.Clear();
                //cboCopy.Items.Add("Select");
                //foreach (feature f in features[cboTerms.Text])
                //{ cboCopy.Items.Add(f.Name); }
                //cboCopy.SelectedIndex = 0;
                cboCopy.Enabled = true;
            }
            else
            {
                txtNames.Enabled = false;
                cboCopy.Enabled = false;
                //if (cboCopy.Items.Count > 0)
                //{ cboCopy.SelectedIndex = 0; }
            }
            parent.ResetBoxColour(terms, 1);
            txtNames_TextChanged(txtNames, new EventArgs());
            
        }

        private void txtNames_TextChanged(object sender, EventArgs e)
        {
            if (features == null || cboTerms.Text == "Select") { return; }

            Pen selected = new Pen(Color.Red, 2);
            string namePart = txtNames.Text.Trim().ToLower();            
            txtListOfNames.Clear();
            btnSelect.Enabled = false;
            foreach (feature f in features[cboTerms.Text])
            {
                if (f.Name.ToLower().StartsWith(namePart) == true)
                {
                    txtListOfNames.Text += f.Name + " ";
                    btnSelect.Enabled = true;
                    f.BoxColour = selected;
                }
                else { f.BoxColour = Pens.Black; }
            }
            parent.ReDrawFromOutSide();
        }

        private void btnSelect_Click(object sender, EventArgs e)
        {
            string namePart = txtNames.Text.Trim().ToLower();            
            Brush fontBrush = null;
            if (rboBlack.Checked == true)
            { fontBrush = Brushes.Black; }
            else
            { fontBrush = Brushes.White; }


            ColorDialog scheme = new ColorDialog();
            scheme.FullOpen = true;
            if (scheme.ShowDialog() == DialogResult.OK)
            {
                bool changed = false;
                foreach (feature f in features[cboTerms.Text])
                {
                    if (f.Name.ToLower().StartsWith(namePart) == true)
                    {
                        SolidBrush sb = new SolidBrush(scheme.Color);
                        f.FeatureColour = sb;
                        f.FontColour = fontBrush;
                        changed = true;
                    }
                }
                if (changed==true)
                { parent.ReDrawFromOutSide(); }
            }
        } 
        
        private void btnClose_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void cboCopy_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cboCopy.SelectedIndex == 0 || cboCopy.Enabled == false)
            { btnCopy.Enabled = false; }
            else if (btnSelect.Enabled == true)
            { btnCopy.Enabled = true; }
            else { btnCopy.Enabled = false; }
        }

        private void btnCopy_Click(object sender, EventArgs e)
        {
            try
            {
                string item = cboCopy.Text;
                string typeName = item.Substring(0, item.IndexOf(":"));
                string featureName = item.Replace(typeName + ": ", "");

                feature fFrom = null;

                int counter = 0;
                for (int index = 1; index< cboCopy.Items.Count; index++)
                {
                    if (cboCopy.Items[index].ToString().StartsWith(typeName) == true)
                    {
                        if (index == cboCopy.SelectedIndex)
                        {
                            fFrom = features[typeName][counter];
                            break;
                        }
                        counter++;
                    }
                }

                string namePart = txtNames.Text.Trim().ToLower();

                bool changed = false;
                foreach (feature f in features[typeName])
                {
                    if (f.Name.ToLower().StartsWith(namePart) == true)
                    {
                        f.FeatureColour = fFrom.FeatureColour;
                        f.FontColour = fFrom.FontColour;
                        changed = true;
                    }
                }
                if (changed == true)
                { parent.ReDrawFromOutSide(); }

            }
            catch { }
        }

        private void rboWhite_CheckedChanged(object sender, EventArgs e)
        {
            setFontColour();
        }

        private void rboBlack_CheckedChanged(object sender, EventArgs e)
        {
            setFontColour();
        }

        private void setFontColour()
        {
            try
            {
                Brush fontBrush = null;
                if (rboBlack.Checked == true)
                { fontBrush = Brushes.Black; }
                else
                { fontBrush = Brushes.White; }

                string namePart = txtNames.Text.Trim().ToLower();

                bool changed = false;
                foreach (feature f in features[cboTerms.Text])
                {
                    if (f.Name.ToLower().StartsWith(namePart) == true)
                    {
                        f.FontColour = fontBrush;
                        changed = true;
                    }
                }
                if (changed == true)
                { parent.ReDrawFromOutSide(); }

            }
            catch { }
        }

    }
}
