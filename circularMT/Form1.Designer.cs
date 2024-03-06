namespace circularMT
{
    partial class Form1
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
            this.components = new System.ComponentModel.Container();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.p1 = new System.Windows.Forms.PictureBox();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.chkDrawOrder = new System.Windows.Forms.CheckBox();
            this.label7 = new System.Windows.Forms.Label();
            this.btnChangeColours = new System.Windows.Forms.Button();
            this.label6 = new System.Windows.Forms.Label();
            this.btnResetName = new System.Windows.Forms.Button();
            this.label5 = new System.Windows.Forms.Label();
            this.btnNewLenght = new System.Windows.Forms.Button();
            this.cboNameOptions = new System.Windows.Forms.ComboBox();
            this.label4 = new System.Windows.Forms.Label();
            this.cboStart = new System.Windows.Forms.ComboBox();
            this.label3 = new System.Windows.Forms.Label();
            this.chcReverseSequence = new System.Windows.Forms.CheckBox();
            this.label2 = new System.Windows.Forms.Label();
            this.chlTerms = new System.Windows.Forms.CheckedListBox();
            this.btnGenBank = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.label8 = new System.Windows.Forms.Label();
            this.button1 = new System.Windows.Forms.Button();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.p1)).BeginInit();
            this.groupBox2.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBox1.Controls.Add(this.p1);
            this.groupBox1.Location = new System.Drawing.Point(12, 12);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(742, 753);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Genome";
            // 
            // p1
            // 
            this.p1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.p1.Location = new System.Drawing.Point(3, 16);
            this.p1.Name = "p1";
            this.p1.Size = new System.Drawing.Size(736, 734);
            this.p1.TabIndex = 0;
            this.p1.TabStop = false;
            this.p1.MouseClick += new System.Windows.Forms.MouseEventHandler(this.p1_MouseClick);
            // 
            // groupBox2
            // 
            this.groupBox2.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBox2.Controls.Add(this.button1);
            this.groupBox2.Controls.Add(this.label8);
            this.groupBox2.Controls.Add(this.chkDrawOrder);
            this.groupBox2.Controls.Add(this.label7);
            this.groupBox2.Controls.Add(this.btnChangeColours);
            this.groupBox2.Controls.Add(this.label6);
            this.groupBox2.Controls.Add(this.btnResetName);
            this.groupBox2.Controls.Add(this.label5);
            this.groupBox2.Controls.Add(this.btnNewLenght);
            this.groupBox2.Controls.Add(this.cboNameOptions);
            this.groupBox2.Controls.Add(this.label4);
            this.groupBox2.Controls.Add(this.cboStart);
            this.groupBox2.Controls.Add(this.label3);
            this.groupBox2.Controls.Add(this.chcReverseSequence);
            this.groupBox2.Controls.Add(this.label2);
            this.groupBox2.Controls.Add(this.chlTerms);
            this.groupBox2.Controls.Add(this.btnGenBank);
            this.groupBox2.Controls.Add(this.label1);
            this.groupBox2.Location = new System.Drawing.Point(760, 12);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(217, 753);
            this.groupBox2.TabIndex = 1;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Options";
            // 
            // chkDrawOrder
            // 
            this.chkDrawOrder.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.chkDrawOrder.CheckAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.chkDrawOrder.Checked = true;
            this.chkDrawOrder.CheckState = System.Windows.Forms.CheckState.Checked;
            this.chkDrawOrder.Location = new System.Drawing.Point(6, 376);
            this.chkDrawOrder.Name = "chkDrawOrder";
            this.chkDrawOrder.Size = new System.Drawing.Size(204, 24);
            this.chkDrawOrder.TabIndex = 15;
            this.chkDrawOrder.Text = "Draw smaller features last";
            this.chkDrawOrder.UseVisualStyleBackColor = true;
            this.chkDrawOrder.CheckedChanged += new System.EventHandler(this.chkDrawOrder_CheckedChanged);
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(6, 352);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(108, 13);
            this.label7.TabIndex = 14;
            this.label7.Text = "Adjust colour scheme";
            // 
            // btnChangeColours
            // 
            this.btnChangeColours.Location = new System.Drawing.Point(136, 347);
            this.btnChangeColours.Name = "btnChangeColours";
            this.btnChangeColours.Size = new System.Drawing.Size(75, 23);
            this.btnChangeColours.TabIndex = 13;
            this.btnChangeColours.Text = "Reset";
            this.btnChangeColours.UseVisualStyleBackColor = true;
            this.btnChangeColours.Click += new System.EventHandler(this.btnChangeColours_Click);
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(6, 323);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(105, 13);
            this.label6.TabIndex = 12;
            this.label6.Text = "Reset genome name";
            // 
            // btnResetName
            // 
            this.btnResetName.Location = new System.Drawing.Point(136, 318);
            this.btnResetName.Name = "btnResetName";
            this.btnResetName.Size = new System.Drawing.Size(75, 23);
            this.btnResetName.TabIndex = 11;
            this.btnResetName.Text = "Reset";
            this.btnResetName.UseVisualStyleBackColor = true;
            this.btnResetName.Click += new System.EventHandler(this.btnResetName_Click);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(6, 294);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(108, 13);
            this.label5.TabIndex = 10;
            this.label5.Text = "Reset genome length";
            // 
            // btnNewLenght
            // 
            this.btnNewLenght.Location = new System.Drawing.Point(136, 289);
            this.btnNewLenght.Name = "btnNewLenght";
            this.btnNewLenght.Size = new System.Drawing.Size(75, 23);
            this.btnNewLenght.TabIndex = 9;
            this.btnNewLenght.Text = "Reset";
            this.btnNewLenght.UseVisualStyleBackColor = true;
            this.btnNewLenght.Click += new System.EventHandler(this.btnNewLenght_Click);
            // 
            // cboNameOptions
            // 
            this.cboNameOptions.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.cboNameOptions.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboNameOptions.FormattingEnabled = true;
            this.cboNameOptions.Items.AddRange(new object[] {
            "Gene",
            "Product",
            "Gene_synonym"});
            this.cboNameOptions.Location = new System.Drawing.Point(9, 260);
            this.cboNameOptions.Name = "cboNameOptions";
            this.cboNameOptions.Size = new System.Drawing.Size(201, 21);
            this.cboNameOptions.TabIndex = 8;
            this.cboNameOptions.SelectedIndexChanged += new System.EventHandler(this.cboNameOptions_SelectedIndexChanged);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(6, 244);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(84, 13);
            this.label4.TabIndex = 7;
            this.label4.Text = "Select name tag";
            // 
            // cboStart
            // 
            this.cboStart.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.cboStart.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboStart.FormattingEnabled = true;
            this.cboStart.Location = new System.Drawing.Point(9, 211);
            this.cboStart.Name = "cboStart";
            this.cboStart.Size = new System.Drawing.Size(201, 21);
            this.cboStart.TabIndex = 6;
            this.cboStart.SelectedIndexChanged += new System.EventHandler(this.cboStart_SelectedIndexChanged);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(6, 195);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(204, 13);
            this.label3.TabIndex = 5;
            this.label3.Text = "Step this feature as the start of sequence.";
            // 
            // chcReverseSequence
            // 
            this.chcReverseSequence.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.chcReverseSequence.CheckAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.chcReverseSequence.Location = new System.Drawing.Point(9, 164);
            this.chcReverseSequence.Margin = new System.Windows.Forms.Padding(2);
            this.chcReverseSequence.Name = "chcReverseSequence";
            this.chcReverseSequence.Size = new System.Drawing.Size(201, 17);
            this.chcReverseSequence.TabIndex = 4;
            this.chcReverseSequence.Text = "Reverse complement sequence";
            this.chcReverseSequence.UseVisualStyleBackColor = true;
            this.chcReverseSequence.CheckedChanged += new System.EventHandler(this.chcReverseSequence_CheckedChanged);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(6, 51);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(116, 13);
            this.label2.TabIndex = 3;
            this.label2.Text = "Select features to draw";
            // 
            // chlTerms
            // 
            this.chlTerms.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.chlTerms.FormattingEnabled = true;
            this.chlTerms.Location = new System.Drawing.Point(9, 67);
            this.chlTerms.Name = "chlTerms";
            this.chlTerms.Size = new System.Drawing.Size(201, 79);
            this.chlTerms.TabIndex = 2;
            this.chlTerms.MouseUp += new System.Windows.Forms.MouseEventHandler(this.chlTerms_MouseUp);
            // 
            // btnGenBank
            // 
            this.btnGenBank.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnGenBank.Location = new System.Drawing.Point(136, 11);
            this.btnGenBank.Name = "btnGenBank";
            this.btnGenBank.Size = new System.Drawing.Size(75, 23);
            this.btnGenBank.TabIndex = 1;
            this.btnGenBank.Text = "Select";
            this.btnGenBank.UseVisualStyleBackColor = true;
            this.btnGenBank.Click += new System.EventHandler(this.btnGenBank_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(6, 16);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(71, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "GenBank file:";
            // 
            // timer1
            // 
            this.timer1.Tick += new System.EventHandler(this.timer1_Tick);
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(6, 411);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(63, 13);
            this.label8.TabIndex = 16;
            this.label8.Text = "Save image";
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(135, 406);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(75, 23);
            this.button1.TabIndex = 17;
            this.button1.Text = "Save";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(989, 777);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.Name = "Form1";
            this.Text = "Circular MT";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.Resize += new System.EventHandler(this.Form1_Resize);
            this.groupBox1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.p1)).EndInit();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.PictureBox p1;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.Button btnGenBank;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.CheckedListBox chlTerms;
        private System.Windows.Forms.CheckBox chcReverseSequence;
        private System.Windows.Forms.ComboBox cboStart;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.ComboBox cboNameOptions;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Timer timer1;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Button btnNewLenght;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Button btnResetName;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Button btnChangeColours;
        private System.Windows.Forms.CheckBox chkDrawOrder;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Label label8;
    }
}

