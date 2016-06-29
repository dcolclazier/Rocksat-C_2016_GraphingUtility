using System;
using System.ComponentModel;
using System.Drawing;
using System.Threading.Tasks;
using System.Windows.Forms;
using RockSatGraphIt.Properties;

namespace RockSatGraphIt
{
    partial class MainForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private IContainer components = null;

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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainForm));
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.label10 = new System.Windows.Forms.Label();
            this.label11 = new System.Windows.Forms.Label();
            this.label12 = new System.Windows.Forms.Label();
            this.label13 = new System.Windows.Forms.Label();
            this.label14 = new System.Windows.Forms.Label();
            this.label15 = new System.Windows.Forms.Label();
            this.label16 = new System.Windows.Forms.Label();
            this.label17 = new System.Windows.Forms.Label();
            this.label18 = new System.Windows.Forms.Label();
            this.label19 = new System.Windows.Forms.Label();
            this.fileNameTXT = new System.Windows.Forms.TextBox();
            this.outputDirectoryTXT = new System.Windows.Forms.TextBox();
            this.timeStartTXT = new System.Windows.Forms.TextBox();
            this.fileTypeCMB = new System.Windows.Forms.ComboBox();
            this.timeStopTXT = new System.Windows.Forms.TextBox();
            this.xAxisTicksTXT = new System.Windows.Forms.TextBox();
            this.graphTitleTXT = new System.Windows.Forms.TextBox();
            this.yMinTXT = new System.Windows.Forms.TextBox();
            this.yMaxTXT = new System.Windows.Forms.TextBox();
            this.label20 = new System.Windows.Forms.Label();
            this.graphTypeCMB = new System.Windows.Forms.ComboBox();
            this.graphWidthTXT = new System.Windows.Forms.TextBox();
            this.graphHeightTXT = new System.Windows.Forms.TextBox();
            this.graphSubtitleTXT = new System.Windows.Forms.TextBox();
            this.plotColorTXT = new System.Windows.Forms.TextBox();
            this.xAxisLabelTXT = new System.Windows.Forms.TextBox();
            this.yAxisLabelTXT = new System.Windows.Forms.TextBox();
            this.labelColorTXT = new System.Windows.Forms.TextBox();
            this.labelSizeTXT = new System.Windows.Forms.TextBox();
            this.loadDataFileBTN = new System.Windows.Forms.Button();
            this.outputDirectoryBTN = new System.Windows.Forms.Button();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.createGraphBTN = new System.Windows.Forms.Button();
            this.consoleRTB = new System.Windows.Forms.RichTextBox();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.fileToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.saveSettingsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.loadSettingsFilegsfToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.downloadDatafilesToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.exitToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.helpToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.howToToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.aboutToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.progressBar1 = new System.Windows.Forms.ProgressBar();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.menuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 32);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(105, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Input Data File (.csv)";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(33, 58);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(84, 13);
            this.label2.TabIndex = 1;
            this.label2.Text = "Output Directory";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(12, 89);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(164, 17);
            this.label3.TabIndex = 2;
            this.label3.Text = "GRAPH DATA OPTIONS";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(29, 146);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(88, 13);
            this.label4.TabIndex = 3;
            this.label4.Text = "Tiem Start (in ms)";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(29, 196);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(88, 13);
            this.label5.TabIndex = 4;
            this.label5.Text = "x-Axis  # ms/tick ";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(163, 222);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(27, 13);
            this.label6.TabIndex = 5;
            this.label6.Text = "Max";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(20, 301);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(101, 13);
            this.label7.TabIndex = 6;
            this.label7.Text = "Size (in inches)    W";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(58, 327);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(59, 13);
            this.label8.TabIndex = 7;
            this.label8.Text = "Graph Title";
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(65, 379);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(52, 13);
            this.label9.TabIndex = 8;
            this.label9.Text = "Plot Color";
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(32, 122);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(85, 13);
            this.label10.TabIndex = 9;
            this.label10.Text = "Output File Type";
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Location = new System.Drawing.Point(29, 170);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(88, 13);
            this.label11.TabIndex = 10;
            this.label11.Text = "Time Stop (in ms)";
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Location = new System.Drawing.Point(29, 222);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(98, 13);
            this.label12.TabIndex = 11;
            this.label12.Text = "y-Axis Range:   Min";
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.Location = new System.Drawing.Point(54, 274);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(63, 13);
            this.label13.TabIndex = 12;
            this.label13.Text = "Graph Type";
            // 
            // label14
            // 
            this.label14.AutoSize = true;
            this.label14.Location = new System.Drawing.Point(167, 301);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(15, 13);
            this.label14.TabIndex = 13;
            this.label14.Text = "H";
            // 
            // label15
            // 
            this.label15.AutoSize = true;
            this.label15.Location = new System.Drawing.Point(43, 353);
            this.label15.Name = "label15";
            this.label15.Size = new System.Drawing.Size(74, 13);
            this.label15.TabIndex = 14;
            this.label15.Text = "Graph Subtitle";
            // 
            // label16
            // 
            this.label16.AutoSize = true;
            this.label16.Location = new System.Drawing.Point(54, 405);
            this.label16.Name = "label16";
            this.label16.Size = new System.Drawing.Size(63, 13);
            this.label16.TabIndex = 15;
            this.label16.Text = "x-Axis Label";
            // 
            // label17
            // 
            this.label17.AutoSize = true;
            this.label17.Location = new System.Drawing.Point(54, 431);
            this.label17.Name = "label17";
            this.label17.Size = new System.Drawing.Size(63, 13);
            this.label17.TabIndex = 16;
            this.label17.Text = "y-Axis Label";
            // 
            // label18
            // 
            this.label18.AutoSize = true;
            this.label18.Location = new System.Drawing.Point(57, 457);
            this.label18.Name = "label18";
            this.label18.Size = new System.Drawing.Size(60, 13);
            this.label18.TabIndex = 17;
            this.label18.Text = "Label Color";
            // 
            // label19
            // 
            this.label19.AutoSize = true;
            this.label19.Location = new System.Drawing.Point(61, 483);
            this.label19.Name = "label19";
            this.label19.Size = new System.Drawing.Size(56, 13);
            this.label19.TabIndex = 18;
            this.label19.Text = "Label Size";
            // 
            // fileNameTXT
            // 
            this.fileNameTXT.Location = new System.Drawing.Point(123, 29);
            this.fileNameTXT.Name = "fileNameTXT";
            this.fileNameTXT.Size = new System.Drawing.Size(505, 20);
            this.fileNameTXT.TabIndex = 0;
            // 
            // outputDirectoryTXT
            // 
            this.outputDirectoryTXT.Location = new System.Drawing.Point(123, 55);
            this.outputDirectoryTXT.Name = "outputDirectoryTXT";
            this.outputDirectoryTXT.Size = new System.Drawing.Size(505, 20);
            this.outputDirectoryTXT.TabIndex = 1;
            // 
            // timeStartTXT
            // 
            this.timeStartTXT.Location = new System.Drawing.Point(123, 141);
            this.timeStartTXT.Name = "timeStartTXT";
            this.timeStartTXT.Size = new System.Drawing.Size(99, 20);
            this.timeStartTXT.TabIndex = 5;
            // 
            // fileTypeCMB
            // 
            this.fileTypeCMB.FormattingEnabled = true;
            this.fileTypeCMB.Items.AddRange(new object[] {
            "pdf",
            "png",
            "jpeg"});
            this.fileTypeCMB.Location = new System.Drawing.Point(123, 114);
            this.fileTypeCMB.Name = "fileTypeCMB";
            this.fileTypeCMB.Size = new System.Drawing.Size(99, 21);
            this.fileTypeCMB.TabIndex = 4;
            // 
            // timeStopTXT
            // 
            this.timeStopTXT.Location = new System.Drawing.Point(123, 167);
            this.timeStopTXT.Name = "timeStopTXT";
            this.timeStopTXT.Size = new System.Drawing.Size(99, 20);
            this.timeStopTXT.TabIndex = 6;
            // 
            // xAxisTicksTXT
            // 
            this.xAxisTicksTXT.Location = new System.Drawing.Point(123, 193);
            this.xAxisTicksTXT.Name = "xAxisTicksTXT";
            this.xAxisTicksTXT.Size = new System.Drawing.Size(99, 20);
            this.xAxisTicksTXT.TabIndex = 7;
            // 
            // graphTitleTXT
            // 
            this.graphTitleTXT.Location = new System.Drawing.Point(123, 324);
            this.graphTitleTXT.Name = "graphTitleTXT";
            this.graphTitleTXT.Size = new System.Drawing.Size(99, 20);
            this.graphTitleTXT.TabIndex = 13;
            // 
            // yMinTXT
            // 
            this.yMinTXT.Location = new System.Drawing.Point(127, 219);
            this.yMinTXT.Name = "yMinTXT";
            this.yMinTXT.Size = new System.Drawing.Size(33, 20);
            this.yMinTXT.TabIndex = 8;
            // 
            // yMaxTXT
            // 
            this.yMaxTXT.Location = new System.Drawing.Point(188, 219);
            this.yMaxTXT.Name = "yMaxTXT";
            this.yMaxTXT.Size = new System.Drawing.Size(34, 20);
            this.yMaxTXT.TabIndex = 9;
            // 
            // label20
            // 
            this.label20.AutoSize = true;
            this.label20.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label20.Location = new System.Drawing.Point(12, 251);
            this.label20.Name = "label20";
            this.label20.Size = new System.Drawing.Size(185, 17);
            this.label20.TabIndex = 28;
            this.label20.Text = "GRAPH FORMAT OPTIONS";
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
            this.graphTypeCMB.Location = new System.Drawing.Point(123, 271);
            this.graphTypeCMB.Name = "graphTypeCMB";
            this.graphTypeCMB.Size = new System.Drawing.Size(99, 21);
            this.graphTypeCMB.TabIndex = 10;
            // 
            // graphWidthTXT
            // 
            this.graphWidthTXT.Location = new System.Drawing.Point(127, 298);
            this.graphWidthTXT.Name = "graphWidthTXT";
            this.graphWidthTXT.Size = new System.Drawing.Size(33, 20);
            this.graphWidthTXT.TabIndex = 11;
            // 
            // graphHeightTXT
            // 
            this.graphHeightTXT.Location = new System.Drawing.Point(188, 298);
            this.graphHeightTXT.Name = "graphHeightTXT";
            this.graphHeightTXT.Size = new System.Drawing.Size(33, 20);
            this.graphHeightTXT.TabIndex = 12;
            // 
            // graphSubtitleTXT
            // 
            this.graphSubtitleTXT.Location = new System.Drawing.Point(123, 350);
            this.graphSubtitleTXT.Name = "graphSubtitleTXT";
            this.graphSubtitleTXT.Size = new System.Drawing.Size(99, 20);
            this.graphSubtitleTXT.TabIndex = 14;
            // 
            // plotColorTXT
            // 
            this.plotColorTXT.Location = new System.Drawing.Point(123, 376);
            this.plotColorTXT.Name = "plotColorTXT";
            this.plotColorTXT.Size = new System.Drawing.Size(99, 20);
            this.plotColorTXT.TabIndex = 15;
            // 
            // xAxisLabelTXT
            // 
            this.xAxisLabelTXT.Location = new System.Drawing.Point(123, 402);
            this.xAxisLabelTXT.Name = "xAxisLabelTXT";
            this.xAxisLabelTXT.Size = new System.Drawing.Size(99, 20);
            this.xAxisLabelTXT.TabIndex = 16;
            // 
            // yAxisLabelTXT
            // 
            this.yAxisLabelTXT.Location = new System.Drawing.Point(123, 428);
            this.yAxisLabelTXT.Name = "yAxisLabelTXT";
            this.yAxisLabelTXT.Size = new System.Drawing.Size(99, 20);
            this.yAxisLabelTXT.TabIndex = 17;
            // 
            // labelColorTXT
            // 
            this.labelColorTXT.Location = new System.Drawing.Point(123, 454);
            this.labelColorTXT.Name = "labelColorTXT";
            this.labelColorTXT.Size = new System.Drawing.Size(99, 20);
            this.labelColorTXT.TabIndex = 18;
            // 
            // labelSizeTXT
            // 
            this.labelSizeTXT.Location = new System.Drawing.Point(123, 480);
            this.labelSizeTXT.Name = "labelSizeTXT";
            this.labelSizeTXT.Size = new System.Drawing.Size(37, 20);
            this.labelSizeTXT.TabIndex = 19;
            // 
            // loadDataFileBTN
            // 
            this.loadDataFileBTN.Location = new System.Drawing.Point(634, 29);
            this.loadDataFileBTN.Name = "loadDataFileBTN";
            this.loadDataFileBTN.Size = new System.Drawing.Size(35, 20);
            this.loadDataFileBTN.TabIndex = 2;
            this.loadDataFileBTN.Text = "...";
            this.loadDataFileBTN.UseVisualStyleBackColor = true;
            this.loadDataFileBTN.Click += new System.EventHandler(this.loadDataFileBTN_Click);
            // 
            // outputDirectoryBTN
            // 
            this.outputDirectoryBTN.Location = new System.Drawing.Point(634, 55);
            this.outputDirectoryBTN.Name = "outputDirectoryBTN";
            this.outputDirectoryBTN.Size = new System.Drawing.Size(35, 20);
            this.outputDirectoryBTN.TabIndex = 3;
            this.outputDirectoryBTN.Text = "...";
            this.outputDirectoryBTN.UseVisualStyleBackColor = true;
            this.outputDirectoryBTN.Click += new System.EventHandler(this.outputDirectoryBTN_Click);
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = global::RockSatGraphIt.Properties.Resources.MissionPatch;
            this.pictureBox1.Location = new System.Drawing.Point(257, 91);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(407, 395);
            this.pictureBox1.TabIndex = 40;
            this.pictureBox1.TabStop = false;
            // 
            // createGraphBTN
            // 
            this.createGraphBTN.Location = new System.Drawing.Point(166, 477);
            this.createGraphBTN.Name = "createGraphBTN";
            this.createGraphBTN.Size = new System.Drawing.Size(56, 25);
            this.createGraphBTN.TabIndex = 20;
            this.createGraphBTN.Text = "GraphIt!";
            this.createGraphBTN.UseVisualStyleBackColor = true;
            this.createGraphBTN.Click += new System.EventHandler(this.createGraphBTN_Click);
            // 
            // consoleRTB
            // 
            this.consoleRTB.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.consoleRTB.Location = new System.Drawing.Point(15, 509);
            this.consoleRTB.Name = "consoleRTB";
            this.consoleRTB.Size = new System.Drawing.Size(654, 127);
            this.consoleRTB.TabIndex = 42;
            this.consoleRTB.Text = "";
            // 
            // menuStrip1
            // 
            this.menuStrip1.BackColor = System.Drawing.SystemColors.MenuBar;
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.fileToolStripMenuItem,
            this.helpToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(685, 24);
            this.menuStrip1.TabIndex = 43;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // fileToolStripMenuItem
            // 
            this.fileToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.saveSettingsToolStripMenuItem,
            this.loadSettingsFilegsfToolStripMenuItem,
            this.downloadDatafilesToolStripMenuItem,
            this.exitToolStripMenuItem});
            this.fileToolStripMenuItem.Name = "fileToolStripMenuItem";
            this.fileToolStripMenuItem.Size = new System.Drawing.Size(37, 20);
            this.fileToolStripMenuItem.Text = "File";
            // 
            // saveSettingsToolStripMenuItem
            // 
            this.saveSettingsToolStripMenuItem.Name = "saveSettingsToolStripMenuItem";
            this.saveSettingsToolStripMenuItem.Size = new System.Drawing.Size(193, 22);
            this.saveSettingsToolStripMenuItem.Text = "Save settings...";
            // 
            // loadSettingsFilegsfToolStripMenuItem
            // 
            this.loadSettingsFilegsfToolStripMenuItem.Name = "loadSettingsFilegsfToolStripMenuItem";
            this.loadSettingsFilegsfToolStripMenuItem.Size = new System.Drawing.Size(193, 22);
            this.loadSettingsFilegsfToolStripMenuItem.Text = "Load settings file (.gsf)";
            // 
            // downloadDatafilesToolStripMenuItem
            // 
            this.downloadDatafilesToolStripMenuItem.Name = "downloadDatafilesToolStripMenuItem";
            this.downloadDatafilesToolStripMenuItem.Size = new System.Drawing.Size(193, 22);
            this.downloadDatafilesToolStripMenuItem.Text = "Download datafiles...";
            this.downloadDatafilesToolStripMenuItem.Click += new System.EventHandler(this.downloadDatafilesMenuItem_Click);
            // 
            // exitToolStripMenuItem
            // 
            this.exitToolStripMenuItem.Name = "exitToolStripMenuItem";
            this.exitToolStripMenuItem.Size = new System.Drawing.Size(193, 22);
            this.exitToolStripMenuItem.Text = "Exit";
            this.exitToolStripMenuItem.Click += new System.EventHandler(this.exitMenuItem_Click);
            // 
            // helpToolStripMenuItem
            // 
            this.helpToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.howToToolStripMenuItem,
            this.aboutToolStripMenuItem});
            this.helpToolStripMenuItem.Name = "helpToolStripMenuItem";
            this.helpToolStripMenuItem.Size = new System.Drawing.Size(44, 20);
            this.helpToolStripMenuItem.Text = "Help";
            // 
            // howToToolStripMenuItem
            // 
            this.howToToolStripMenuItem.Name = "howToToolStripMenuItem";
            this.howToToolStripMenuItem.Size = new System.Drawing.Size(122, 22);
            this.howToToolStripMenuItem.Text = "How to...";
            // 
            // aboutToolStripMenuItem
            // 
            this.aboutToolStripMenuItem.Name = "aboutToolStripMenuItem";
            this.aboutToolStripMenuItem.Size = new System.Drawing.Size(122, 22);
            this.aboutToolStripMenuItem.Text = "About";
            this.aboutToolStripMenuItem.Click += new System.EventHandler(this.aboutMenuItem_Click);
            // 
            // progressBar1
            // 
            this.progressBar1.Location = new System.Drawing.Point(15, 642);
            this.progressBar1.Name = "progressBar1";
            this.progressBar1.Size = new System.Drawing.Size(654, 11);
            this.progressBar1.TabIndex = 44;
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(685, 665);
            this.Controls.Add(this.progressBar1);
            this.Controls.Add(this.consoleRTB);
            this.Controls.Add(this.createGraphBTN);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.outputDirectoryBTN);
            this.Controls.Add(this.loadDataFileBTN);
            this.Controls.Add(this.labelSizeTXT);
            this.Controls.Add(this.labelColorTXT);
            this.Controls.Add(this.yAxisLabelTXT);
            this.Controls.Add(this.xAxisLabelTXT);
            this.Controls.Add(this.plotColorTXT);
            this.Controls.Add(this.graphSubtitleTXT);
            this.Controls.Add(this.graphHeightTXT);
            this.Controls.Add(this.graphWidthTXT);
            this.Controls.Add(this.graphTypeCMB);
            this.Controls.Add(this.label20);
            this.Controls.Add(this.yMaxTXT);
            this.Controls.Add(this.yMinTXT);
            this.Controls.Add(this.graphTitleTXT);
            this.Controls.Add(this.xAxisTicksTXT);
            this.Controls.Add(this.timeStopTXT);
            this.Controls.Add(this.fileTypeCMB);
            this.Controls.Add(this.timeStartTXT);
            this.Controls.Add(this.outputDirectoryTXT);
            this.Controls.Add(this.fileNameTXT);
            this.Controls.Add(this.label19);
            this.Controls.Add(this.label18);
            this.Controls.Add(this.label17);
            this.Controls.Add(this.label16);
            this.Controls.Add(this.label15);
            this.Controls.Add(this.label14);
            this.Controls.Add(this.label13);
            this.Controls.Add(this.label12);
            this.Controls.Add(this.label11);
            this.Controls.Add(this.label10);
            this.Controls.Add(this.label9);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.menuStrip1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximumSize = new System.Drawing.Size(701, 1000);
            this.MinimumSize = new System.Drawing.Size(701, 680);
            this.Name = "MainForm";
            this.Text = "Graphit! A RockSat-C CC-CO Graphing Tool v1.1";
            this.Load += new System.EventHandler(this.MainForm_Load);
            this.Shown += new System.EventHandler(this.MainForm_Shown);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private Label label1;
        private Label label2;
        private Label label3;
        private Label label4;
        private Label label5;
        private Label label6;
        private Label label7;
        private Label label8;
        private Label label9;
        private Label label10;
        private Label label11;
        private Label label12;
        private Label label13;
        private Label label14;
        private Label label15;
        private Label label16;
        private Label label17;
        private Label label18;
        private Label label19;
        private TextBox fileNameTXT;
        private TextBox outputDirectoryTXT;
        private TextBox timeStartTXT;
        private ComboBox fileTypeCMB;
        private TextBox timeStopTXT;
        private TextBox xAxisTicksTXT;
        private TextBox graphTitleTXT;
        private TextBox yMinTXT;
        private TextBox yMaxTXT;
        private Label label20;
        private ComboBox graphTypeCMB;
        private TextBox graphWidthTXT;
        private TextBox graphHeightTXT;
        private TextBox graphSubtitleTXT;
        private TextBox plotColorTXT;
        private TextBox xAxisLabelTXT;
        private TextBox yAxisLabelTXT;
        private TextBox labelColorTXT;
        private TextBox labelSizeTXT;
        private Button loadDataFileBTN;
        private Button outputDirectoryBTN;
        private PictureBox pictureBox1;
        private Button createGraphBTN;
        private RichTextBox consoleRTB;
        private MenuStrip menuStrip1;
        private ToolStripMenuItem fileToolStripMenuItem;
        private ToolStripMenuItem loadSettingsFilegsfToolStripMenuItem;
        private ToolStripMenuItem saveSettingsToolStripMenuItem;
        private ToolStripMenuItem exitToolStripMenuItem;
        private ToolStripMenuItem helpToolStripMenuItem;
        private ToolStripMenuItem howToToolStripMenuItem;
        private ToolStripMenuItem aboutToolStripMenuItem;
        private ToolStripMenuItem downloadDatafilesToolStripMenuItem;
        private ProgressBar progressBar1;
    }
}

