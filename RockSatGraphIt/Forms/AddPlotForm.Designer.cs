namespace RockSatGraphIt.Forms
{
    partial class AddPlotForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(AddPlotForm));
            this.filenameTXT = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.loadDataFileBTN = new System.Windows.Forms.Button();
            this.xDatasetCMB = new System.Windows.Forms.ComboBox();
            this.label10 = new System.Windows.Forms.Label();
            this.yDatasetCMB = new System.Windows.Forms.ComboBox();
            this.label4 = new System.Windows.Forms.Label();
            this.domainMinTXT = new System.Windows.Forms.TextBox();
            this.label12 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.domainHashPeriodTXT = new System.Windows.Forms.TextBox();
            this.label8 = new System.Windows.Forms.Label();
            this.rangeHashPeriodTXT = new System.Windows.Forms.TextBox();
            this.label9 = new System.Windows.Forms.Label();
            this.label11 = new System.Windows.Forms.Label();
            this.graphTypeCMB = new System.Windows.Forms.ComboBox();
            this.label13 = new System.Windows.Forms.Label();
            this.domainMaxTXT = new System.Windows.Forms.TextBox();
            this.rangeMinTXT = new System.Windows.Forms.TextBox();
            this.rangeMaxTXT = new System.Windows.Forms.TextBox();
            this.addPlotBTN = new System.Windows.Forms.Button();
            this.colorCMB = new System.Windows.Forms.ComboBox();
            this.SuspendLayout();
            // 
            // filenameTXT
            // 
            this.filenameTXT.Location = new System.Drawing.Point(90, 12);
            this.filenameTXT.Name = "filenameTXT";
            this.filenameTXT.Size = new System.Drawing.Size(382, 20);
            this.filenameTXT.TabIndex = 0;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(23, 15);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(61, 13);
            this.label2.TabIndex = 3;
            this.label2.Text = "Select CSV";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Underline, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(153, 66);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(36, 13);
            this.label1.TabIndex = 4;
            this.label1.Text = "X Axis";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Underline, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(397, 66);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(36, 13);
            this.label3.TabIndex = 5;
            this.label3.Text = "Y-Axis";
            // 
            // loadDataFileBTN
            // 
            this.loadDataFileBTN.Location = new System.Drawing.Point(478, 12);
            this.loadDataFileBTN.Name = "loadDataFileBTN";
            this.loadDataFileBTN.Size = new System.Drawing.Size(27, 20);
            this.loadDataFileBTN.TabIndex = 0;
            this.loadDataFileBTN.Text = "...";
            this.loadDataFileBTN.UseVisualStyleBackColor = true;
            this.loadDataFileBTN.Click += new System.EventHandler(this.loadDataFileBTN_Click);
            // 
            // xDatasetCMB
            // 
            this.xDatasetCMB.FormattingEnabled = true;
            this.xDatasetCMB.Items.AddRange(new object[] {
            "pdf",
            "png",
            "jpeg"});
            this.xDatasetCMB.Location = new System.Drawing.Point(90, 87);
            this.xDatasetCMB.Name = "xDatasetCMB";
            this.xDatasetCMB.Size = new System.Drawing.Size(167, 21);
            this.xDatasetCMB.TabIndex = 3;
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(42, 90);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(45, 13);
            this.label10.TabIndex = 11;
            this.label10.Text = "Column:";
            // 
            // yDatasetCMB
            // 
            this.yDatasetCMB.FormattingEnabled = true;
            this.yDatasetCMB.Items.AddRange(new object[] {
            "pdf",
            "png",
            "jpeg"});
            this.yDatasetCMB.Location = new System.Drawing.Point(334, 87);
            this.yDatasetCMB.Name = "yDatasetCMB";
            this.yDatasetCMB.Size = new System.Drawing.Size(171, 21);
            this.yDatasetCMB.TabIndex = 7;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(286, 90);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(45, 13);
            this.label4.TabIndex = 13;
            this.label4.Text = "Column:";
            // 
            // domainMinTXT
            // 
            this.domainMinTXT.Location = new System.Drawing.Point(90, 117);
            this.domainMinTXT.Name = "domainMinTXT";
            this.domainMinTXT.Size = new System.Drawing.Size(66, 20);
            this.domainMinTXT.TabIndex = 4;
            this.domainMinTXT.Text = "0";
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Location = new System.Drawing.Point(15, 120);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(72, 13);
            this.label12.TabIndex = 17;
            this.label12.Text = "Domain:   Min";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(162, 120);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(27, 13);
            this.label6.TabIndex = 14;
            this.label6.Text = "Max";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(263, 120);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(68, 13);
            this.label5.TabIndex = 21;
            this.label5.Text = "Range:   Min";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(406, 120);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(27, 13);
            this.label7.TabIndex = 18;
            this.label7.Text = "Max";
            // 
            // domainHashPeriodTXT
            // 
            this.domainHashPeriodTXT.Location = new System.Drawing.Point(90, 149);
            this.domainHashPeriodTXT.Name = "domainHashPeriodTXT";
            this.domainHashPeriodTXT.Size = new System.Drawing.Size(167, 20);
            this.domainHashPeriodTXT.TabIndex = 6;
            this.domainHashPeriodTXT.Text = "10";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(19, 152);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(65, 13);
            this.label8.TabIndex = 22;
            this.label8.Text = "Hash Period";
            // 
            // rangeHashPeriodTXT
            // 
            this.rangeHashPeriodTXT.Location = new System.Drawing.Point(334, 146);
            this.rangeHashPeriodTXT.Name = "rangeHashPeriodTXT";
            this.rangeHashPeriodTXT.Size = new System.Drawing.Size(171, 20);
            this.rangeHashPeriodTXT.TabIndex = 10;
            this.rangeHashPeriodTXT.Text = "10";
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(263, 149);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(65, 13);
            this.label9.TabIndex = 24;
            this.label9.Text = "Hash Period";
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Location = new System.Drawing.Point(32, 41);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(52, 13);
            this.label11.TabIndex = 26;
            this.label11.Text = "Plot Color";
            // 
            // graphTypeCMB
            // 
            this.graphTypeCMB.FormattingEnabled = true;
            this.graphTypeCMB.Items.AddRange(new object[] {
            "Points",
            "Line",
            "Both Points + Line",
            "Overplotted",
            "Histogram",
            "Stair Steps"});
            this.graphTypeCMB.Location = new System.Drawing.Point(337, 38);
            this.graphTypeCMB.Name = "graphTypeCMB";
            this.graphTypeCMB.Size = new System.Drawing.Size(168, 21);
            this.graphTypeCMB.TabIndex = 2;
            this.graphTypeCMB.Text = "Line";
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.Location = new System.Drawing.Point(268, 41);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(63, 13);
            this.label13.TabIndex = 29;
            this.label13.Text = "Graph Type";
            // 
            // domainMaxTXT
            // 
            this.domainMaxTXT.Location = new System.Drawing.Point(191, 117);
            this.domainMaxTXT.Name = "domainMaxTXT";
            this.domainMaxTXT.Size = new System.Drawing.Size(66, 20);
            this.domainMaxTXT.TabIndex = 5;
            this.domainMaxTXT.Text = "1000";
            // 
            // rangeMinTXT
            // 
            this.rangeMinTXT.Location = new System.Drawing.Point(334, 117);
            this.rangeMinTXT.Name = "rangeMinTXT";
            this.rangeMinTXT.Size = new System.Drawing.Size(66, 20);
            this.rangeMinTXT.TabIndex = 8;
            this.rangeMinTXT.Text = "0";
            // 
            // rangeMaxTXT
            // 
            this.rangeMaxTXT.Location = new System.Drawing.Point(439, 117);
            this.rangeMaxTXT.Name = "rangeMaxTXT";
            this.rangeMaxTXT.Size = new System.Drawing.Size(66, 20);
            this.rangeMaxTXT.TabIndex = 9;
            this.rangeMaxTXT.Text = "1000";
            // 
            // addPlotBTN
            // 
            this.addPlotBTN.Location = new System.Drawing.Point(205, 180);
            this.addPlotBTN.Name = "addPlotBTN";
            this.addPlotBTN.Size = new System.Drawing.Size(105, 20);
            this.addPlotBTN.TabIndex = 11;
            this.addPlotBTN.Text = "Add Plot";
            this.addPlotBTN.UseVisualStyleBackColor = true;
            this.addPlotBTN.Click += new System.EventHandler(this.addPlotBTN_Click);
            // 
            // colorCMB
            // 
            this.colorCMB.FormattingEnabled = true;
            this.colorCMB.Location = new System.Drawing.Point(90, 38);
            this.colorCMB.Name = "colorCMB";
            this.colorCMB.Size = new System.Drawing.Size(167, 21);
            this.colorCMB.TabIndex = 58;
            this.colorCMB.Text = "black";
            // 
            // AddPlotForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(516, 212);
            this.Controls.Add(this.colorCMB);
            this.Controls.Add(this.addPlotBTN);
            this.Controls.Add(this.rangeMaxTXT);
            this.Controls.Add(this.rangeMinTXT);
            this.Controls.Add(this.domainMaxTXT);
            this.Controls.Add(this.graphTypeCMB);
            this.Controls.Add(this.label13);
            this.Controls.Add(this.label11);
            this.Controls.Add(this.rangeHashPeriodTXT);
            this.Controls.Add(this.label9);
            this.Controls.Add(this.domainHashPeriodTXT);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.domainMinTXT);
            this.Controls.Add(this.label12);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.yDatasetCMB);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.xDatasetCMB);
            this.Controls.Add(this.label10);
            this.Controls.Add(this.loadDataFileBTN);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.filenameTXT);
            this.Controls.Add(this.label2);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "AddPlotForm";
            this.Text = "Add plot...";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox filenameTXT;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Button loadDataFileBTN;
        private System.Windows.Forms.ComboBox xDatasetCMB;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.ComboBox yDatasetCMB;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox domainMinTXT;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.TextBox domainHashPeriodTXT;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.TextBox rangeHashPeriodTXT;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.ComboBox graphTypeCMB;
        private System.Windows.Forms.Label label13;
        private System.Windows.Forms.TextBox domainMaxTXT;
        private System.Windows.Forms.TextBox rangeMinTXT;
        private System.Windows.Forms.TextBox rangeMaxTXT;
        private System.Windows.Forms.Button addPlotBTN;
        private System.Windows.Forms.ComboBox colorCMB;
    }
}