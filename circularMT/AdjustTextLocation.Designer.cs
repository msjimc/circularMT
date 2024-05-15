namespace circularMT
{
    partial class AdjustTextLocation
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
            this.btnClose = new System.Windows.Forms.Button();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.nupRotate = new System.Windows.Forms.NumericUpDown();
            this.label6 = new System.Windows.Forms.Label();
            this.nupUpDown = new System.Windows.Forms.NumericUpDown();
            this.label4 = new System.Windows.Forms.Label();
            this.nupbackAndForth = new System.Windows.Forms.NumericUpDown();
            this.label3 = new System.Windows.Forms.Label();
            this.btnNumber = new System.Windows.Forms.Button();
            this.label5 = new System.Windows.Forms.Label();
            this.txtListOfNames = new System.Windows.Forms.TextBox();
            this.txtNames = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.cboTerms = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nupRotate)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.nupUpDown)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.nupbackAndForth)).BeginInit();
            this.SuspendLayout();
            // 
            // btnClose
            // 
            this.btnClose.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btnClose.Location = new System.Drawing.Point(25, 231);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(75, 23);
            this.btnClose.TabIndex = 9;
            this.btnClose.Text = "Close";
            this.btnClose.UseVisualStyleBackColor = true;
            this.btnClose.Click += new System.EventHandler(this.btnClose_Click);
            // 
            // groupBox1
            // 
            this.groupBox1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBox1.Controls.Add(this.nupRotate);
            this.groupBox1.Controls.Add(this.label6);
            this.groupBox1.Controls.Add(this.nupUpDown);
            this.groupBox1.Controls.Add(this.label4);
            this.groupBox1.Controls.Add(this.nupbackAndForth);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.btnNumber);
            this.groupBox1.Controls.Add(this.label5);
            this.groupBox1.Controls.Add(this.txtListOfNames);
            this.groupBox1.Controls.Add(this.txtNames);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.cboTerms);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Location = new System.Drawing.Point(16, 15);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(512, 210);
            this.groupBox1.TabIndex = 8;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Adjust text location";
            // 
            // nupRotate
            // 
            this.nupRotate.Location = new System.Drawing.Point(431, 184);
            this.nupRotate.Maximum = new decimal(new int[] {
            20,
            0,
            0,
            0});
            this.nupRotate.Minimum = new decimal(new int[] {
            20,
            0,
            0,
            -2147483648});
            this.nupRotate.Name = "nupRotate";
            this.nupRotate.Size = new System.Drawing.Size(75, 20);
            this.nupRotate.TabIndex = 16;
            this.nupRotate.ValueChanged += new System.EventHandler(this.nupRotate_ValueChanged);
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(6, 186);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(59, 13);
            this.label6.TabIndex = 15;
            this.label6.Text = "Rotate text";
            // 
            // nupUpDown
            // 
            this.nupUpDown.Location = new System.Drawing.Point(431, 153);
            this.nupUpDown.Maximum = new decimal(new int[] {
            10,
            0,
            0,
            0});
            this.nupUpDown.Minimum = new decimal(new int[] {
            10,
            0,
            0,
            -2147483648});
            this.nupUpDown.Name = "nupUpDown";
            this.nupUpDown.Size = new System.Drawing.Size(75, 20);
            this.nupUpDown.TabIndex = 14;
            this.nupUpDown.ValueChanged += new System.EventHandler(this.nupUpDown_ValueChanged);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(6, 155);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(119, 13);
            this.label4.TabIndex = 13;
            this.label4.Text = "Move text up and down";
            // 
            // nupbackAndForth
            // 
            this.nupbackAndForth.Location = new System.Drawing.Point(431, 123);
            this.nupbackAndForth.Maximum = new decimal(new int[] {
            15,
            0,
            0,
            0});
            this.nupbackAndForth.Minimum = new decimal(new int[] {
            15,
            0,
            0,
            -2147483648});
            this.nupbackAndForth.Name = "nupbackAndForth";
            this.nupbackAndForth.Size = new System.Drawing.Size(75, 20);
            this.nupbackAndForth.TabIndex = 12;
            this.nupbackAndForth.ValueChanged += new System.EventHandler(this.nupbackAndForth_ValueChanged);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(6, 125);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(145, 13);
            this.label3.TabIndex = 11;
            this.label3.Text = "Move text back and forwards";
            // 
            // btnNumber
            // 
            this.btnNumber.Location = new System.Drawing.Point(431, 66);
            this.btnNumber.Name = "btnNumber";
            this.btnNumber.Size = new System.Drawing.Size(75, 23);
            this.btnNumber.TabIndex = 3;
            this.btnNumber.Text = "Number";
            this.btnNumber.UseVisualStyleBackColor = true;
            this.btnNumber.Click += new System.EventHandler(this.btnNumber_Click);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(6, 71);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(179, 13);
            this.label5.TabIndex = 10;
            this.label5.Text = "Number features with selected name";
            // 
            // txtListOfNames
            // 
            this.txtListOfNames.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtListOfNames.Enabled = false;
            this.txtListOfNames.Location = new System.Drawing.Point(9, 95);
            this.txtListOfNames.Name = "txtListOfNames";
            this.txtListOfNames.Size = new System.Drawing.Size(497, 20);
            this.txtListOfNames.TabIndex = 4;
            // 
            // txtNames
            // 
            this.txtNames.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtNames.Enabled = false;
            this.txtNames.Location = new System.Drawing.Point(275, 40);
            this.txtNames.Name = "txtNames";
            this.txtNames.Size = new System.Drawing.Size(231, 20);
            this.txtNames.TabIndex = 2;
            this.txtNames.TextChanged += new System.EventHandler(this.txtNames_TextChanged);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(6, 43);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(263, 13);
            this.label2.TabIndex = 3;
            this.label2.Text = "Enter name of feature to be edited: this case sensitive.";
            // 
            // cboTerms
            // 
            this.cboTerms.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.cboTerms.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboTerms.FormattingEnabled = true;
            this.cboTerms.Location = new System.Drawing.Point(275, 13);
            this.cboTerms.Name = "cboTerms";
            this.cboTerms.Size = new System.Drawing.Size(231, 21);
            this.cboTerms.TabIndex = 1;
            this.cboTerms.SelectedIndexChanged += new System.EventHandler(this.cboTerms_SelectedIndexChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(6, 16);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(207, 13);
            this.label1.TabIndex = 1;
            this.label1.Text = "Select the type of feature you want to edit ";
            // 
            // AdjustTextLocation
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(544, 270);
            this.Controls.Add(this.btnClose);
            this.Controls.Add(this.groupBox1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Fixed3D;
            this.Name = "AdjustTextLocation";
            this.Text = "Adjust text location";
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nupRotate)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.nupUpDown)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.nupbackAndForth)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button btnClose;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.NumericUpDown nupRotate;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.NumericUpDown nupUpDown;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.NumericUpDown nupbackAndForth;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Button btnNumber;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox txtListOfNames;
        private System.Windows.Forms.TextBox txtNames;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.ComboBox cboTerms;
        private System.Windows.Forms.Label label1;
    }
}