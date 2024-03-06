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
        public AdjustColours(Dictionary<string, Brush> colourscheme, Dictionary<string, List<feature>> features, Form1 parent, List<string> terms)
        {
            InitializeComponent();
            this.colourscheme = colourscheme;
            this.features = features;
            this.parent = parent;

            cboTerms.Items.Add("Select");
            foreach (string term in terms)
            { cboTerms.Items.Add(term); }
            cboTerms.SelectedIndex = 0;

        }

        private void AdjustColours_Load(object sender, EventArgs e)
        {
            
        }

        private void cboTerms_SelectedIndexChanged(object sender, EventArgs e)
        {
            txtNames.Clear();
            if (cboTerms.SelectedIndex>0)
            {  txtNames.Enabled= true; }
            else
            { txtNames.Enabled= false; }
            txtNames_TextChanged(txtNames, new EventArgs());
        }

        private void txtNames_TextChanged(object sender, EventArgs e)
        {
            if (features == null || cboTerms.Text == "Select") { return; }

            string namePart = txtNames.Text.Trim().ToLower();            
            txtListOfNames.Clear();
            btnSelect.Enabled = false;
            foreach (feature f in features[cboTerms.Text])
            {
                if (f.Name.ToLower().StartsWith(namePart) == true)
                {
                    txtListOfNames.Text += f.Name + " ";
                    btnSelect.Enabled = true;
                }
            }
            
        }

        private void btnSelect_Click(object sender, EventArgs e)
        {
            string namePart = txtNames.Text.Trim().ToLower();            

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
    }
}
