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
    public partial class AdvancedNameSelection : Form
    {
        private Dictionary<string, List<feature>> features = new Dictionary<string, List<feature>>();
        public Form1 parent = null;
        private List<string> terms = new List<string>();        

        public AdvancedNameSelection(Dictionary<string, List<feature>> features, Form1 parent, List<string> Terms)
        {
            InitializeComponent();

            this.parent = parent;
            this.features = features;
            this.terms = Terms;

            cboTerms.Items.Add("Select");
            foreach (string term in terms)
            { cboTerms.Items.Add(term); }
            cboTerms.SelectedIndex = 0;

            cboNameOptions.SelectedIndex = 0;
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void btnSelect_Click(object sender, EventArgs e)
        {
            if (cboNameOptions.SelectedIndex > 0 && cboTerms.SelectedIndex > 0)
            {
                foreach (feature f in features[cboTerms.Text])
                {
                    f.SetDisplayName(cboNameOptions.Text);
                }
            }
            parent.ReDrawFromOutSide();
        }

        private void cboTerms_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cboNameOptions.SelectedIndex > 0 && cboTerms.SelectedIndex > 0)
            { btnSelect.Enabled = true; }
            else { btnSelect.Enabled = false; }
        }

        private void cboNameOptions_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cboNameOptions.SelectedIndex > 0 && cboTerms.SelectedIndex > 0)
            { btnSelect.Enabled = true; }
            else { btnSelect.Enabled = false; }
        }
    }
}
