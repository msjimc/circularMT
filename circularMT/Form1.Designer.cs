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
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.p1 = new System.Windows.Forms.PictureBox();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.cboStart = new System.Windows.Forms.ComboBox();
            this.label3 = new System.Windows.Forms.Label();
            this.chcReverseSequence = new System.Windows.Forms.CheckBox();
            this.label2 = new System.Windows.Forms.Label();
            this.chlTerms = new System.Windows.Forms.CheckedListBox();
            this.btnGenBank = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
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
            this.groupBox1.Size = new System.Drawing.Size(570, 426);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Genome";
            // 
            // p1
            // 
            this.p1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.p1.Location = new System.Drawing.Point(3, 16);
            this.p1.Name = "p1";
            this.p1.Size = new System.Drawing.Size(564, 407);
            this.p1.TabIndex = 0;
            this.p1.TabStop = false;
            this.p1.MouseClick += new System.Windows.Forms.MouseEventHandler(this.p1_MouseClick);
            // 
            // groupBox2
            // 
            this.groupBox2.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBox2.Controls.Add(this.cboStart);
            this.groupBox2.Controls.Add(this.label3);
            this.groupBox2.Controls.Add(this.chcReverseSequence);
            this.groupBox2.Controls.Add(this.label2);
            this.groupBox2.Controls.Add(this.chlTerms);
            this.groupBox2.Controls.Add(this.btnGenBank);
            this.groupBox2.Controls.Add(this.label1);
            this.groupBox2.Location = new System.Drawing.Point(588, 12);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(200, 426);
            this.groupBox2.TabIndex = 1;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Options";
            // 
            // cboStart
            // 
            this.cboStart.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboStart.FormattingEnabled = true;
            this.cboStart.Location = new System.Drawing.Point(9, 211);
            this.cboStart.Name = "cboStart";
            this.cboStart.Size = new System.Drawing.Size(185, 21);
            this.cboStart.TabIndex = 6;
            this.cboStart.SelectedIndexChanged += new System.EventHandler(this.cboStart_SelectedIndexChanged);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(6, 195);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(139, 13);
            this.label3.TabIndex = 5;
            this.label3.Text = "Step this feature as the start";
            // 
            // chcReverseSequence
            // 
            this.chcReverseSequence.AutoSize = true;
            this.chcReverseSequence.Location = new System.Drawing.Point(9, 164);
            this.chcReverseSequence.Margin = new System.Windows.Forms.Padding(2);
            this.chcReverseSequence.Name = "chcReverseSequence";
            this.chcReverseSequence.Size = new System.Drawing.Size(176, 17);
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
            this.chlTerms.FormattingEnabled = true;
            this.chlTerms.Location = new System.Drawing.Point(9, 67);
            this.chlTerms.Name = "chlTerms";
            this.chlTerms.Size = new System.Drawing.Size(185, 79);
            this.chlTerms.TabIndex = 2;
            this.chlTerms.MouseUp += new System.Windows.Forms.MouseEventHandler(this.chlTerms_MouseUp);
            // 
            // btnGenBank
            // 
            this.btnGenBank.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnGenBank.Location = new System.Drawing.Point(119, 11);
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
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.Name = "Form1";
            this.Text = "Circular MT";
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
    }
}

