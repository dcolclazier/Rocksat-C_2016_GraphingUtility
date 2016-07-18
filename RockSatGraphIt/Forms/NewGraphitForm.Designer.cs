namespace RockSatGraphIt.Forms
{
    partial class NewGraphitForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(NewGraphitForm));
            this.label1 = new System.Windows.Forms.Label();
            this.createGraphBTN = new System.Windows.Forms.Button();
            this.labelSizeTXT = new System.Windows.Forms.TextBox();
            this.yAxisLabelTXT = new System.Windows.Forms.TextBox();
            this.xAxisLabelTXT = new System.Windows.Forms.TextBox();
            this.label19 = new System.Windows.Forms.Label();
            this.label18 = new System.Windows.Forms.Label();
            this.label17 = new System.Windows.Forms.Label();
            this.label16 = new System.Windows.Forms.Label();
            this.graphitToolTip = new System.Windows.Forms.ToolTip(this.components);
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.graphSubtitleTXT = new System.Windows.Forms.TextBox();
            this.graphTitleTXT = new System.Windows.Forms.TextBox();
            this.label15 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.addplotBTN = new System.Windows.Forms.Button();
            this.removePlotBTN = new System.Windows.Forms.Button();
            this.progressBar1 = new System.Windows.Forms.ProgressBar();
            this.consoleRTB = new System.Windows.Forms.RichTextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.fileToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.downloadRocksatCDatafilesToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.launchNewAnalyzeItWindowToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.launchNewGraphItWindowToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.exitToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.editToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.aboutToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.graphHeightTXT = new System.Windows.Forms.TextBox();
            this.graphLengthTXT = new System.Windows.Forms.TextBox();
            this.plotsListBox = new System.Windows.Forms.ListBox();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.colorCMB = new System.Windows.Forms.ComboBox();
            this.menuStrip1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 33);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(525, 143);
            this.label1.TabIndex = 0;
            this.label1.Text = resources.GetString("label1.Text");
            // 
            // createGraphBTN
            // 
            this.createGraphBTN.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.createGraphBTN.Location = new System.Drawing.Point(132, 326);
            this.createGraphBTN.Name = "createGraphBTN";
            this.createGraphBTN.Size = new System.Drawing.Size(56, 23);
            this.createGraphBTN.TabIndex = 29;
            this.createGraphBTN.Text = "GraphIt!";
            this.createGraphBTN.UseVisualStyleBackColor = true;
            this.createGraphBTN.Click += new System.EventHandler(this.createGraphBTN_Click);
            // 
            // labelSizeTXT
            // 
            this.labelSizeTXT.Location = new System.Drawing.Point(89, 326);
            this.labelSizeTXT.Name = "labelSizeTXT";
            this.labelSizeTXT.Size = new System.Drawing.Size(37, 20);
            this.labelSizeTXT.TabIndex = 5;
            this.labelSizeTXT.Text = "1.0";
            // 
            // yAxisLabelTXT
            // 
            this.yAxisLabelTXT.Location = new System.Drawing.Point(89, 274);
            this.yAxisLabelTXT.Name = "yAxisLabelTXT";
            this.yAxisLabelTXT.Size = new System.Drawing.Size(99, 20);
            this.yAxisLabelTXT.TabIndex = 3;
            this.yAxisLabelTXT.Text = "Y-Axis";
            // 
            // xAxisLabelTXT
            // 
            this.xAxisLabelTXT.Location = new System.Drawing.Point(89, 248);
            this.xAxisLabelTXT.Name = "xAxisLabelTXT";
            this.xAxisLabelTXT.Size = new System.Drawing.Size(99, 20);
            this.xAxisLabelTXT.TabIndex = 2;
            this.xAxisLabelTXT.Text = "X-Axis";
            // 
            // label19
            // 
            this.label19.AutoSize = true;
            this.label19.Location = new System.Drawing.Point(27, 329);
            this.label19.Name = "label19";
            this.label19.Size = new System.Drawing.Size(56, 13);
            this.label19.TabIndex = 27;
            this.label19.Text = "Label Size";
            this.graphitToolTip.SetToolTip(this.label19, "Relative to default... greater than 1.0 yields larger text, less than 1.0 yields " +
        "smaller.");
            // 
            // label18
            // 
            this.label18.AutoSize = true;
            this.label18.Location = new System.Drawing.Point(23, 303);
            this.label18.Name = "label18";
            this.label18.Size = new System.Drawing.Size(60, 13);
            this.label18.TabIndex = 25;
            this.label18.Text = "Label Color";
            this.graphitToolTip.SetToolTip(this.label18, "The font color for the x and y axis labels");
            // 
            // label17
            // 
            this.label17.AutoSize = true;
            this.label17.Location = new System.Drawing.Point(20, 277);
            this.label17.Name = "label17";
            this.label17.Size = new System.Drawing.Size(63, 13);
            this.label17.TabIndex = 23;
            this.label17.Text = "y-Axis Label";
            this.graphitToolTip.SetToolTip(this.label17, "Label to appear on the Y-Axis of the final graph");
            // 
            // label16
            // 
            this.label16.AutoSize = true;
            this.label16.Location = new System.Drawing.Point(20, 251);
            this.label16.Name = "label16";
            this.label16.Size = new System.Drawing.Size(63, 13);
            this.label16.TabIndex = 21;
            this.label16.Text = "x-Axis Label";
            this.graphitToolTip.SetToolTip(this.label16, "Label to appear on the X-Axis of the final graph");
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(193, 200);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(18, 13);
            this.label3.TabIndex = 53;
            this.label3.Text = "W";
            this.graphitToolTip.SetToolTip(this.label3, "Relative to default... greater than 1.0 yields larger text, less than 1.0 yields " +
        "smaller.");
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(239, 199);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(15, 13);
            this.label4.TabIndex = 54;
            this.label4.Text = "H";
            this.graphitToolTip.SetToolTip(this.label4, "Relative to default... greater than 1.0 yields larger text, less than 1.0 yields " +
        "smaller.");
            // 
            // graphSubtitleTXT
            // 
            this.graphSubtitleTXT.Location = new System.Drawing.Point(89, 222);
            this.graphSubtitleTXT.Name = "graphSubtitleTXT";
            this.graphSubtitleTXT.Size = new System.Drawing.Size(99, 20);
            this.graphSubtitleTXT.TabIndex = 1;
            this.graphSubtitleTXT.Text = "Example subtitle";
            // 
            // graphTitleTXT
            // 
            this.graphTitleTXT.Location = new System.Drawing.Point(89, 196);
            this.graphTitleTXT.Name = "graphTitleTXT";
            this.graphTitleTXT.Size = new System.Drawing.Size(99, 20);
            this.graphTitleTXT.TabIndex = 0;
            this.graphTitleTXT.Text = "Example Title";
            // 
            // label15
            // 
            this.label15.AutoSize = true;
            this.label15.Location = new System.Drawing.Point(41, 225);
            this.label15.Name = "label15";
            this.label15.Size = new System.Drawing.Size(42, 13);
            this.label15.TabIndex = 34;
            this.label15.Text = "Subtitle";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(24, 199);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(59, 13);
            this.label8.TabIndex = 31;
            this.label8.Text = "Graph Title";
            // 
            // addplotBTN
            // 
            this.addplotBTN.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.addplotBTN.Location = new System.Drawing.Point(649, 192);
            this.addplotBTN.Name = "addplotBTN";
            this.addplotBTN.Size = new System.Drawing.Size(30, 24);
            this.addplotBTN.TabIndex = 8;
            this.addplotBTN.Text = "+";
            this.addplotBTN.UseVisualStyleBackColor = true;
            this.addplotBTN.Click += new System.EventHandler(this.addplotBTN_Click);
            // 
            // removePlotBTN
            // 
            this.removePlotBTN.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.removePlotBTN.Location = new System.Drawing.Point(681, 192);
            this.removePlotBTN.Name = "removePlotBTN";
            this.removePlotBTN.Size = new System.Drawing.Size(31, 24);
            this.removePlotBTN.TabIndex = 9;
            this.removePlotBTN.Text = "-";
            this.removePlotBTN.UseVisualStyleBackColor = true;
            this.removePlotBTN.Click += new System.EventHandler(this.removePlotBTN_Click);
            // 
            // progressBar1
            // 
            this.progressBar1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.progressBar1.Location = new System.Drawing.Point(15, 528);
            this.progressBar1.Name = "progressBar1";
            this.progressBar1.Size = new System.Drawing.Size(698, 11);
            this.progressBar1.TabIndex = 46;
            // 
            // consoleRTB
            // 
            this.consoleRTB.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.consoleRTB.Location = new System.Drawing.Point(15, 355);
            this.consoleRTB.Name = "consoleRTB";
            this.consoleRTB.Size = new System.Drawing.Size(698, 167);
            this.consoleRTB.TabIndex = 45;
            this.consoleRTB.Text = "";
            // 
            // label2
            // 
            this.label2.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(554, 201);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(92, 13);
            this.label2.TabIndex = 49;
            this.label2.Text = "Add/Remove Plot";
            // 
            // menuStrip1
            // 
            this.menuStrip1.BackColor = System.Drawing.SystemColors.MenuBar;
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.fileToolStripMenuItem,
            this.editToolStripMenuItem});
            this.menuStrip1.LayoutStyle = System.Windows.Forms.ToolStripLayoutStyle.HorizontalStackWithOverflow;
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.RenderMode = System.Windows.Forms.ToolStripRenderMode.System;
            this.menuStrip1.Size = new System.Drawing.Size(722, 24);
            this.menuStrip1.TabIndex = 4;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // fileToolStripMenuItem
            // 
            this.fileToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.downloadRocksatCDatafilesToolStripMenuItem,
            this.launchNewAnalyzeItWindowToolStripMenuItem,
            this.launchNewGraphItWindowToolStripMenuItem,
            this.exitToolStripMenuItem});
            this.fileToolStripMenuItem.Name = "fileToolStripMenuItem";
            this.fileToolStripMenuItem.Size = new System.Drawing.Size(37, 20);
            this.fileToolStripMenuItem.Text = "File";
            // 
            // downloadRocksatCDatafilesToolStripMenuItem
            // 
            this.downloadRocksatCDatafilesToolStripMenuItem.Name = "downloadRocksatCDatafilesToolStripMenuItem";
            this.downloadRocksatCDatafilesToolStripMenuItem.Size = new System.Drawing.Size(241, 22);
            this.downloadRocksatCDatafilesToolStripMenuItem.Text = "Download Rocksat-C datafiles...";
            this.downloadRocksatCDatafilesToolStripMenuItem.Click += new System.EventHandler(this.downloadRocksatCDatafilesToolStripMenuItem_Click);
            // 
            // launchNewAnalyzeItWindowToolStripMenuItem
            // 
            this.launchNewAnalyzeItWindowToolStripMenuItem.Name = "launchNewAnalyzeItWindowToolStripMenuItem";
            this.launchNewAnalyzeItWindowToolStripMenuItem.Size = new System.Drawing.Size(241, 22);
            this.launchNewAnalyzeItWindowToolStripMenuItem.Text = "Launch New AnalyzeIt! Window";
            this.launchNewAnalyzeItWindowToolStripMenuItem.Click += new System.EventHandler(this.launchNewAnalyzeItWindowToolStripMenuItem_Click);
            // 
            // launchNewGraphItWindowToolStripMenuItem
            // 
            this.launchNewGraphItWindowToolStripMenuItem.Name = "launchNewGraphItWindowToolStripMenuItem";
            this.launchNewGraphItWindowToolStripMenuItem.Size = new System.Drawing.Size(241, 22);
            this.launchNewGraphItWindowToolStripMenuItem.Text = "Launch New GraphIt! Window";
            this.launchNewGraphItWindowToolStripMenuItem.Click += new System.EventHandler(this.launchNewGraphItWindowToolStripMenuItem_Click);
            // 
            // exitToolStripMenuItem
            // 
            this.exitToolStripMenuItem.Name = "exitToolStripMenuItem";
            this.exitToolStripMenuItem.Size = new System.Drawing.Size(241, 22);
            this.exitToolStripMenuItem.Text = "Exit";
            this.exitToolStripMenuItem.Click += new System.EventHandler(this.exitToolStripMenuItem_Click);
            // 
            // editToolStripMenuItem
            // 
            this.editToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.aboutToolStripMenuItem});
            this.editToolStripMenuItem.Name = "editToolStripMenuItem";
            this.editToolStripMenuItem.Size = new System.Drawing.Size(44, 20);
            this.editToolStripMenuItem.Text = "Help";
            // 
            // aboutToolStripMenuItem
            // 
            this.aboutToolStripMenuItem.Name = "aboutToolStripMenuItem";
            this.aboutToolStripMenuItem.Size = new System.Drawing.Size(116, 22);
            this.aboutToolStripMenuItem.Text = "About...";
            this.aboutToolStripMenuItem.Click += new System.EventHandler(this.aboutToolStripMenuItem_Click);
            // 
            // graphHeightTXT
            // 
            this.graphHeightTXT.Location = new System.Drawing.Point(258, 196);
            this.graphHeightTXT.Name = "graphHeightTXT";
            this.graphHeightTXT.Size = new System.Drawing.Size(26, 20);
            this.graphHeightTXT.TabIndex = 7;
            this.graphHeightTXT.Text = "4";
            // 
            // graphLengthTXT
            // 
            this.graphLengthTXT.Location = new System.Drawing.Point(211, 196);
            this.graphLengthTXT.Name = "graphLengthTXT";
            this.graphLengthTXT.Size = new System.Drawing.Size(26, 20);
            this.graphLengthTXT.TabIndex = 6;
            this.graphLengthTXT.Text = "20";
            // 
            // plotsListBox
            // 
            this.plotsListBox.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.plotsListBox.FormattingEnabled = true;
            this.plotsListBox.Location = new System.Drawing.Point(195, 222);
            this.plotsListBox.Name = "plotsListBox";
            this.plotsListBox.Size = new System.Drawing.Size(518, 121);
            this.plotsListBox.TabIndex = 55;
            // 
            // pictureBox1
            // 
            this.pictureBox1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.pictureBox1.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox1.Image")));
            this.pictureBox1.InitialImage = global::RockSatGraphIt.Properties.Resources.MissionPatch;
            this.pictureBox1.Location = new System.Drawing.Point(534, 12);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(179, 179);
            this.pictureBox1.TabIndex = 56;
            this.pictureBox1.TabStop = false;
            // 
            // colorCMB
            // 
            this.colorCMB.FormattingEnabled = true;
            this.colorCMB.Location = new System.Drawing.Point(89, 301);
            this.colorCMB.Name = "colorCMB";
            this.colorCMB.Size = new System.Drawing.Size(99, 21);
            this.colorCMB.TabIndex = 57;
            this.colorCMB.Text = "black";
            // 
            // NewGraphitForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(722, 551);
            this.Controls.Add(this.colorCMB);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.plotsListBox);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.graphLengthTXT);
            this.Controls.Add(this.graphHeightTXT);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.progressBar1);
            this.Controls.Add(this.consoleRTB);
            this.Controls.Add(this.removePlotBTN);
            this.Controls.Add(this.addplotBTN);
            this.Controls.Add(this.graphSubtitleTXT);
            this.Controls.Add(this.graphTitleTXT);
            this.Controls.Add(this.label15);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.createGraphBTN);
            this.Controls.Add(this.labelSizeTXT);
            this.Controls.Add(this.yAxisLabelTXT);
            this.Controls.Add(this.xAxisLabelTXT);
            this.Controls.Add(this.label19);
            this.Controls.Add(this.label18);
            this.Controls.Add(this.label17);
            this.Controls.Add(this.label16);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.menuStrip1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "NewGraphitForm";
            this.Text = "GraphIt! A Data Graphing Utility";
            this.Load += new System.EventHandler(this.NewGraphitForm_Load);
            this.Shown += new System.EventHandler(this.NewGraphitForm_Shown);
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button createGraphBTN;
        private System.Windows.Forms.TextBox labelSizeTXT;
        private System.Windows.Forms.TextBox yAxisLabelTXT;
        private System.Windows.Forms.TextBox xAxisLabelTXT;
        private System.Windows.Forms.Label label19;
        private System.Windows.Forms.ToolTip graphitToolTip;
        private System.Windows.Forms.Label label18;
        private System.Windows.Forms.Label label17;
        private System.Windows.Forms.Label label16;
        private System.Windows.Forms.TextBox graphSubtitleTXT;
        private System.Windows.Forms.TextBox graphTitleTXT;
        private System.Windows.Forms.Label label15;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Button addplotBTN;
        private System.Windows.Forms.Button removePlotBTN;
        private System.Windows.Forms.ProgressBar progressBar1;
        private System.Windows.Forms.RichTextBox consoleRTB;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem fileToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem editToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem downloadRocksatCDatafilesToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem launchNewAnalyzeItWindowToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem launchNewGraphItWindowToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem exitToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem aboutToolStripMenuItem;
        private System.Windows.Forms.TextBox graphHeightTXT;
        private System.Windows.Forms.TextBox graphLengthTXT;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.ListBox plotsListBox;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.ComboBox colorCMB;
    }
}