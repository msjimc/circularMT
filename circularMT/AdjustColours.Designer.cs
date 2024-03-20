namespace circularMT
{
    partial class AdjustColours
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.label5 = new System.Windows.Forms.Label();
            this.rboBlack = new System.Windows.Forms.RadioButton();
            this.rboWhite = new System.Windows.Forms.RadioButton();
            this.btnCopy = new System.Windows.Forms.Button();
            this.btnSelect = new System.Windows.Forms.Button();
            this.cboCopy = new System.Windows.Forms.ComboBox();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.txtListOfNames = new System.Windows.Forms.TextBox();
            this.txtNames = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.cboTerms = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.btnClose = new System.Windows.Forms.Button();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBox1.Controls.Add(this.label5);
            this.groupBox1.Controls.Add(this.rboBlack);
            this.groupBox1.Controls.Add(this.cboCopy);
            this.groupBox1.Controls.Add(this.rboWhite);
            this.groupBox1.Controls.Add(this.btnCopy);
            this.groupBox1.Controls.Add(this.btnSelect);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.label4);
            this.groupBox1.Controls.Add(this.txtListOfNames);
            this.groupBox1.Controls.Add(this.txtNames);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.cboTerms);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Location = new System.Drawing.Point(12, 12);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(512, 227);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Set colour scheme";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(6, 173);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(250, 13);
            this.label5.TabIndex = 10;
            this.label5.Text = "Select the colour of the font for text drawn in arrows";
            // 
            // rboBlack
            // 
            this.rboBlack.AutoSize = true;
            this.rboBlack.Checked = true;
            this.rboBlack.Location = new System.Drawing.Point(431, 169);
            this.rboBlack.Name = "rboBlack";
            this.rboBlack.Size = new System.Drawing.Size(52, 17);
            this.rboBlack.TabIndex = 9;
            this.rboBlack.TabStop = true;
            this.rboBlack.Text = "Black";
            this.rboBlack.UseVisualStyleBackColor = true;
            this.rboBlack.CheckedChanged += new System.EventHandler(this.rboBlack_CheckedChanged);
            // 
            // rboWhite
            // 
            this.rboWhite.AutoSize = true;
            this.rboWhite.Location = new System.Drawing.Point(346, 169);
            this.rboWhite.Name = "rboWhite";
            this.rboWhite.Size = new System.Drawing.Size(53, 17);
            this.rboWhite.TabIndex = 8;
            this.rboWhite.Text = "White";
            this.rboWhite.UseVisualStyleBackColor = true;
            this.rboWhite.CheckedChanged += new System.EventHandler(this.rboWhite_CheckedChanged);
            // 
            // btnCopy
            // 
            this.btnCopy.Enabled = false;
            this.btnCopy.Location = new System.Drawing.Point(431, 196);
            this.btnCopy.Name = "btnCopy";
            this.btnCopy.Size = new System.Drawing.Size(75, 23);
            this.btnCopy.TabIndex = 5;
            this.btnCopy.Text = "Copy";
            this.btnCopy.UseVisualStyleBackColor = true;
            this.btnCopy.Click += new System.EventHandler(this.btnCopy_Click);
            // 
            // btnSelect
            // 
            this.btnSelect.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnSelect.Enabled = false;
            this.btnSelect.Location = new System.Drawing.Point(431, 137);
            this.btnSelect.Name = "btnSelect";
            this.btnSelect.Size = new System.Drawing.Size(75, 23);
            this.btnSelect.TabIndex = 6;
            this.btnSelect.Text = "Select";
            this.btnSelect.UseVisualStyleBackColor = true;
            this.btnSelect.Click += new System.EventHandler(this.btnSelect_Click);
            // 
            // cboCopy
            // 
            this.cboCopy.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboCopy.Enabled = false;
            this.cboCopy.FormattingEnabled = true;
            this.cboCopy.Location = new System.Drawing.Point(229, 196);
            this.cboCopy.Name = "cboCopy";
            this.cboCopy.Size = new System.Drawing.Size(196, 21);
            this.cboCopy.TabIndex = 4;
            this.cboCopy.SelectedIndexChanged += new System.EventHandler(this.cboCopy_SelectedIndexChanged);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(6, 142);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(201, 13);
            this.label3.TabIndex = 6;
            this.label3.Text = "Press the Select button to set the colours";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(6, 199);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(125, 13);
            this.label4.TabIndex = 7;
            this.label4.Text = "Copy this feature\'s colour";
            // 
            // txtListOfNames
            // 
            this.txtListOfNames.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtListOfNames.Enabled = false;
            this.txtListOfNames.Location = new System.Drawing.Point(9, 86);
            this.txtListOfNames.Multiline = true;
            this.txtListOfNames.Name = "txtListOfNames";
            this.txtListOfNames.Size = new System.Drawing.Size(497, 45);
            this.txtListOfNames.TabIndex = 3;
            // 
            // txtNames
            // 
            this.txtNames.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtNames.Enabled = false;
            this.txtNames.Location = new System.Drawing.Point(9, 59);
            this.txtNames.Name = "txtNames";
            this.txtNames.Size = new System.Drawing.Size(497, 20);
            this.txtNames.TabIndex = 2;
            this.txtNames.TextChanged += new System.EventHandler(this.txtNames_TextChanged);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(6, 43);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(342, 13);
            this.label2.TabIndex = 3;
            this.label2.Text = "Enter name of the feature(s) to change, any matches will appear below.";
            // 
            // cboTerms
            // 
            this.cboTerms.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.cboTerms.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboTerms.FormattingEnabled = true;
            this.cboTerms.Location = new System.Drawing.Point(229, 13);
            this.cboTerms.Name = "cboTerms";
            this.cboTerms.Size = new System.Drawing.Size(277, 21);
            this.cboTerms.TabIndex = 1;
            this.cboTerms.SelectedIndexChanged += new System.EventHandler(this.cboTerms_SelectedIndexChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(6, 16);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(226, 13);
            this.label1.TabIndex = 1;
            this.label1.Text = "Select the type of feature you want to change ";
            // 
            // btnClose
            // 
            this.btnClose.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btnClose.Location = new System.Drawing.Point(21, 245);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(75, 23);
            this.btnClose.TabIndex = 7;
            this.btnClose.Text = "Close";
            this.btnClose.UseVisualStyleBackColor = true;
            this.btnClose.Click += new System.EventHandler(this.btnClose_Click);
            // 
            // AdjustColours
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(536, 279);
            this.Controls.Add(this.btnClose);
            this.Controls.Add(this.groupBox1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Fixed3D;
            this.MinimizeBox = false;
            this.Name = "AdjustColours";
            this.Text = "Adjust feature colours";
            this.Load += new System.EventHandler(this.AdjustColours_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Button btnSelect;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox txtListOfNames;
        private System.Windows.Forms.TextBox txtNames;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.ComboBox cboTerms;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button btnClose;
        private System.Windows.Forms.Button btnCopy;
        private System.Windows.Forms.ComboBox cboCopy;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.RadioButton rboBlack;
        private System.Windows.Forms.RadioButton rboWhite;
        private System.Windows.Forms.Label label5;
    }
}