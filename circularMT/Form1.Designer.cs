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
            this.label13 = new System.Windows.Forms.Label();
            this.label12 = new System.Windows.Forms.Label();
            this.nupLeftRight = new System.Windows.Forms.NumericUpDown();
            this.nupUPDown = new System.Windows.Forms.NumericUpDown();
            this.button1 = new System.Windows.Forms.Button();
            this.label11 = new System.Windows.Forms.Label();
            this.Quit = new System.Windows.Forms.Button();
            this.btnRemove = new System.Windows.Forms.Button();
            this.label10 = new System.Windows.Forms.Label();
            this.chkSwitchStrands = new System.Windows.Forms.CheckBox();
            this.label9 = new System.Windows.Forms.Label();
            this.btnEdit = new System.Windows.Forms.Button();
            this.btnSave = new System.Windows.Forms.Button();
            this.label8 = new System.Windows.Forms.Label();
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
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.p1)).BeginInit();
            this.groupBox2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nupLeftRight)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.nupUPDown)).BeginInit();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBox1.Controls.Add(this.p1);
            this.groupBox1.Location = new System.Drawing.Point(24, 23);
            this.groupBox1.Margin = new System.Windows.Forms.Padding(6, 6, 6, 6);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Padding = new System.Windows.Forms.Padding(6, 6, 6, 6);
            this.groupBox1.Size = new System.Drawing.Size(1484, 1448);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Genome";
            // 
            // p1
            // 
            this.p1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.p1.Location = new System.Drawing.Point(6, 30);
            this.p1.Margin = new System.Windows.Forms.Padding(6, 6, 6, 6);
            this.p1.Name = "p1";
            this.p1.Size = new System.Drawing.Size(1472, 1412);
            this.p1.TabIndex = 0;
            this.p1.TabStop = false;
            this.p1.MouseClick += new System.Windows.Forms.MouseEventHandler(this.p1_MouseClick);
            // 
            // groupBox2
            // 
            this.groupBox2.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBox2.Controls.Add(this.label13);
            this.groupBox2.Controls.Add(this.label12);
            this.groupBox2.Controls.Add(this.nupLeftRight);
            this.groupBox2.Controls.Add(this.nupUPDown);
            this.groupBox2.Controls.Add(this.button1);
            this.groupBox2.Controls.Add(this.label11);
            this.groupBox2.Controls.Add(this.Quit);
            this.groupBox2.Controls.Add(this.btnRemove);
            this.groupBox2.Controls.Add(this.label10);
            this.groupBox2.Controls.Add(this.chkSwitchStrands);
            this.groupBox2.Controls.Add(this.label9);
            this.groupBox2.Controls.Add(this.btnEdit);
            this.groupBox2.Controls.Add(this.btnSave);
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
            this.groupBox2.Location = new System.Drawing.Point(1520, 23);
            this.groupBox2.Margin = new System.Windows.Forms.Padding(6, 6, 6, 6);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Padding = new System.Windows.Forms.Padding(6, 6, 6, 6);
            this.groupBox2.Size = new System.Drawing.Size(434, 1448);
            this.groupBox2.TabIndex = 1;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Options";
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.Location = new System.Drawing.Point(14, 992);
            this.label13.Margin = new System.Windows.Forms.Padding(6, 0, 6, 0);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(298, 50);
            this.label13.TabIndex = 27;
            this.label13.Text = "More up-down";
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Location = new System.Drawing.Point(14, 942);
            this.label12.Margin = new System.Windows.Forms.Padding(6, 0, 6, 0);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(145, 25);
            this.label12.TabIndex = 26;
            this.label12.Text = "More left-right";
            // 
            // nupLeftRight
            // 
            this.nupLeftRight.Increment = new decimal(new int[] {
            5,
            0,
            0,
            0});
            this.nupLeftRight.Location = new System.Drawing.Point(272, 938);
            this.nupLeftRight.Margin = new System.Windows.Forms.Padding(6, 6, 6, 6);
            this.nupLeftRight.Minimum = new decimal(new int[] {
            100,
            0,
            0,
            -2147483648});
            this.nupLeftRight.Name = "nupLeftRight";
            this.nupLeftRight.Size = new System.Drawing.Size(150, 31);
            this.nupLeftRight.TabIndex = 14;
            this.nupLeftRight.ValueChanged += new System.EventHandler(this.nupLeftRight_ValueChanged);
            // 
            // nupUPDown
            // 
            this.nupUPDown.Increment = new decimal(new int[] {
            5,
            0,
            0,
            0});
            this.nupUPDown.Location = new System.Drawing.Point(272, 988);
            this.nupUPDown.Margin = new System.Windows.Forms.Padding(6, 6, 6, 6);
            this.nupUPDown.Minimum = new decimal(new int[] {
            100,
            0,
            0,
            -2147483648});
            this.nupUPDown.Name = "nupUPDown";
            this.nupUPDown.Size = new System.Drawing.Size(150, 31);
            this.nupUPDown.TabIndex = 15;
            this.nupUPDown.ValueChanged += new System.EventHandler(this.nupUPDown_ValueChanged);
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(272, 827);
            this.button1.Margin = new System.Windows.Forms.Padding(6, 6, 6, 6);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(150, 44);
            this.button1.TabIndex = 12;
            this.button1.Text = "Add";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.btnAdd_Click);
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Location = new System.Drawing.Point(12, 837);
            this.label11.Margin = new System.Windows.Forms.Padding(6, 0, 6, 0);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(141, 25);
            this.label11.TabIndex = 23;
            this.label11.Text = "Add a feature";
            // 
            // Quit
            // 
            this.Quit.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.Quit.Location = new System.Drawing.Point(272, 1392);
            this.Quit.Margin = new System.Windows.Forms.Padding(6, 6, 6, 6);
            this.Quit.Name = "Quit";
            this.Quit.Size = new System.Drawing.Size(150, 44);
            this.Quit.TabIndex = 17;
            this.Quit.Text = "Quit";
            this.Quit.UseVisualStyleBackColor = true;
            // 
            // btnRemove
            // 
            this.btnRemove.Location = new System.Drawing.Point(272, 883);
            this.btnRemove.Margin = new System.Windows.Forms.Padding(6, 6, 6, 6);
            this.btnRemove.Name = "btnRemove";
            this.btnRemove.Size = new System.Drawing.Size(150, 44);
            this.btnRemove.TabIndex = 13;
            this.btnRemove.Text = "Remove";
            this.btnRemove.UseVisualStyleBackColor = true;
            this.btnRemove.Click += new System.EventHandler(this.btnRemove_Click);
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(12, 892);
            this.label10.Margin = new System.Windows.Forms.Padding(6, 0, 6, 0);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(182, 25);
            this.label10.TabIndex = 21;
            this.label10.Text = "Remove a feature";
            // 
            // chkSwitchStrands
            // 
            this.chkSwitchStrands.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.chkSwitchStrands.CheckAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.chkSwitchStrands.Location = new System.Drawing.Point(18, 331);
            this.chkSwitchStrands.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.chkSwitchStrands.Name = "chkSwitchStrands";
            this.chkSwitchStrands.Size = new System.Drawing.Size(402, 33);
            this.chkSwitchStrands.TabIndex = 4;
            this.chkSwitchStrands.Text = "Switch strand";
            this.chkSwitchStrands.UseVisualStyleBackColor = true;
            this.chkSwitchStrands.CheckedChanged += new System.EventHandler(this.chkSwitchStrands_CheckedChanged);
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(12, 781);
            this.label9.Margin = new System.Windows.Forms.Padding(6, 0, 6, 0);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(119, 25);
            this.label9.TabIndex = 19;
            this.label9.Text = "Edit names";
            // 
            // btnEdit
            // 
            this.btnEdit.Location = new System.Drawing.Point(272, 771);
            this.btnEdit.Margin = new System.Windows.Forms.Padding(6, 6, 6, 6);
            this.btnEdit.Name = "btnEdit";
            this.btnEdit.Size = new System.Drawing.Size(150, 44);
            this.btnEdit.TabIndex = 11;
            this.btnEdit.Text = "Edit";
            this.btnEdit.UseVisualStyleBackColor = true;
            this.btnEdit.Click += new System.EventHandler(this.btnEdit_Click);
            // 
            // btnSave
            // 
            this.btnSave.Location = new System.Drawing.Point(272, 1038);
            this.btnSave.Margin = new System.Windows.Forms.Padding(6, 6, 6, 6);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(150, 44);
            this.btnSave.TabIndex = 16;
            this.btnSave.Text = "Save";
            this.btnSave.UseVisualStyleBackColor = true;
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(14, 1048);
            this.label8.Margin = new System.Windows.Forms.Padding(6, 0, 6, 0);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(125, 25);
            this.label8.TabIndex = 16;
            this.label8.Text = "Save image";
            // 
            // chkDrawOrder
            // 
            this.chkDrawOrder.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.chkDrawOrder.CheckAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.chkDrawOrder.Checked = true;
            this.chkDrawOrder.CheckState = System.Windows.Forms.CheckState.Checked;
            this.chkDrawOrder.Location = new System.Drawing.Point(12, 723);
            this.chkDrawOrder.Margin = new System.Windows.Forms.Padding(6, 6, 6, 6);
            this.chkDrawOrder.Name = "chkDrawOrder";
            this.chkDrawOrder.Size = new System.Drawing.Size(408, 46);
            this.chkDrawOrder.TabIndex = 10;
            this.chkDrawOrder.Text = "Draw smaller features last";
            this.chkDrawOrder.UseVisualStyleBackColor = true;
            this.chkDrawOrder.CheckedChanged += new System.EventHandler(this.chkDrawOrder_CheckedChanged);
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(12, 677);
            this.label7.Margin = new System.Windows.Forms.Padding(6, 0, 6, 0);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(218, 25);
            this.label7.TabIndex = 14;
            this.label7.Text = "Adjust colour scheme";
            // 
            // btnChangeColours
            // 
            this.btnChangeColours.Location = new System.Drawing.Point(272, 667);
            this.btnChangeColours.Margin = new System.Windows.Forms.Padding(6, 6, 6, 6);
            this.btnChangeColours.Name = "btnChangeColours";
            this.btnChangeColours.Size = new System.Drawing.Size(150, 44);
            this.btnChangeColours.TabIndex = 9;
            this.btnChangeColours.Text = "Adjust";
            this.btnChangeColours.UseVisualStyleBackColor = true;
            this.btnChangeColours.Click += new System.EventHandler(this.btnChangeColours_Click);
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(12, 621);
            this.label6.Margin = new System.Windows.Forms.Padding(6, 0, 6, 0);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(191, 25);
            this.label6.TabIndex = 12;
            this.label6.Text = "Edit genome name";
            // 
            // btnResetName
            // 
            this.btnResetName.Location = new System.Drawing.Point(272, 612);
            this.btnResetName.Margin = new System.Windows.Forms.Padding(6, 6, 6, 6);
            this.btnResetName.Name = "btnResetName";
            this.btnResetName.Size = new System.Drawing.Size(150, 44);
            this.btnResetName.TabIndex = 8;
            this.btnResetName.Text = "Edit";
            this.btnResetName.UseVisualStyleBackColor = true;
            this.btnResetName.Click += new System.EventHandler(this.btnResetName_Click);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(12, 565);
            this.label5.Margin = new System.Windows.Forms.Padding(6, 0, 6, 0);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(216, 25);
            this.label5.TabIndex = 10;
            this.label5.Text = "Reset genome length";
            // 
            // btnNewLenght
            // 
            this.btnNewLenght.Location = new System.Drawing.Point(272, 556);
            this.btnNewLenght.Margin = new System.Windows.Forms.Padding(6, 6, 6, 6);
            this.btnNewLenght.Name = "btnNewLenght";
            this.btnNewLenght.Size = new System.Drawing.Size(150, 44);
            this.btnNewLenght.TabIndex = 7;
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
            this.cboNameOptions.Location = new System.Drawing.Point(18, 500);
            this.cboNameOptions.Margin = new System.Windows.Forms.Padding(6, 6, 6, 6);
            this.cboNameOptions.Name = "cboNameOptions";
            this.cboNameOptions.Size = new System.Drawing.Size(398, 33);
            this.cboNameOptions.TabIndex = 6;
            this.cboNameOptions.SelectedIndexChanged += new System.EventHandler(this.cboNameOptions_SelectedIndexChanged);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(12, 469);
            this.label4.Margin = new System.Windows.Forms.Padding(6, 0, 6, 0);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(167, 25);
            this.label4.TabIndex = 7;
            this.label4.Text = "Select name tag";
            // 
            // cboStart
            // 
            this.cboStart.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.cboStart.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboStart.FormattingEnabled = true;
            this.cboStart.Location = new System.Drawing.Point(18, 406);
            this.cboStart.Margin = new System.Windows.Forms.Padding(6, 6, 6, 6);
            this.cboStart.Name = "cboStart";
            this.cboStart.Size = new System.Drawing.Size(398, 33);
            this.cboStart.TabIndex = 5;
            this.cboStart.SelectedIndexChanged += new System.EventHandler(this.cboStart_SelectedIndexChanged);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(12, 375);
            this.label3.Margin = new System.Windows.Forms.Padding(6, 0, 6, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(412, 25);
            this.label3.TabIndex = 5;
            this.label3.Text = "Step this feature as the start of sequence.";
            // 
            // chcReverseSequence
            // 
            this.chcReverseSequence.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.chcReverseSequence.CheckAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.chcReverseSequence.Location = new System.Drawing.Point(18, 290);
            this.chcReverseSequence.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.chcReverseSequence.Name = "chcReverseSequence";
            this.chcReverseSequence.Size = new System.Drawing.Size(402, 33);
            this.chcReverseSequence.TabIndex = 3;
            this.chcReverseSequence.Text = "Reverse complement sequence";
            this.chcReverseSequence.UseVisualStyleBackColor = true;
            this.chcReverseSequence.CheckedChanged += new System.EventHandler(this.chcReverseSequence_CheckedChanged);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(12, 98);
            this.label2.Margin = new System.Windows.Forms.Padding(6, 0, 6, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(232, 25);
            this.label2.TabIndex = 3;
            this.label2.Text = "Select features to draw";
            // 
            // chlTerms
            // 
            this.chlTerms.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.chlTerms.FormattingEnabled = true;
            this.chlTerms.Location = new System.Drawing.Point(18, 129);
            this.chlTerms.Margin = new System.Windows.Forms.Padding(6, 6, 6, 6);
            this.chlTerms.Name = "chlTerms";
            this.chlTerms.Size = new System.Drawing.Size(398, 144);
            this.chlTerms.TabIndex = 2;
            this.chlTerms.MouseUp += new System.Windows.Forms.MouseEventHandler(this.chlTerms_MouseUp);
            // 
            // btnGenBank
            // 
            this.btnGenBank.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnGenBank.Location = new System.Drawing.Point(272, 21);
            this.btnGenBank.Margin = new System.Windows.Forms.Padding(6, 6, 6, 6);
            this.btnGenBank.Name = "btnGenBank";
            this.btnGenBank.Size = new System.Drawing.Size(150, 44);
            this.btnGenBank.TabIndex = 1;
            this.btnGenBank.Text = "Select";
            this.btnGenBank.UseVisualStyleBackColor = true;
            this.btnGenBank.Click += new System.EventHandler(this.btnGenBank_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 31);
            this.label1.Margin = new System.Windows.Forms.Padding(6, 0, 6, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(141, 25);
            this.label1.TabIndex = 0;
            this.label1.Text = "GenBank file:";
            // 
            // timer1
            // 
            this.timer1.Tick += new System.EventHandler(this.timer1_Tick);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(12F, 25F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1978, 1494);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.Margin = new System.Windows.Forms.Padding(6, 6, 6, 6);
            this.MinimumSize = new System.Drawing.Size(1984, 1504);
            this.Name = "Form1";
            this.Text = "circularMT";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.Resize += new System.EventHandler(this.Form1_Resize);
            this.groupBox1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.p1)).EndInit();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nupLeftRight)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.nupUPDown)).EndInit();
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
        private System.Windows.Forms.Button btnSave;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Button btnEdit;
        private System.Windows.Forms.CheckBox chkSwitchStrands;
        private System.Windows.Forms.Button btnRemove;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.Button Quit;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.Label label13;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.NumericUpDown nupLeftRight;
        private System.Windows.Forms.NumericUpDown nupUPDown;
    }
}

