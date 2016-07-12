namespace RockSatGraphIt.Forms
{
    partial class AnalyzeitForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(AnalyzeitForm));
            this.imageDirectoryTXT = new System.Windows.Forms.TextBox();
            this.inputPicsLBL = new System.Windows.Forms.Label();
            this.outputImageDirectoryTXT = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.originalPhotosBTN = new System.Windows.Forms.Button();
            this.outputPhotosBTN = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.chooseTestCMB = new System.Windows.Forms.ComboBox();
            this.runImageTestBTN = new System.Windows.Forms.Button();
            this.consoleRTB = new System.Windows.Forms.RichTextBox();
            this.imagePBAR = new System.Windows.Forms.ProgressBar();
            this.label3 = new System.Windows.Forms.Label();
            this.imageExtensionCMB = new System.Windows.Forms.ComboBox();
            this.label4 = new System.Windows.Forms.Label();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.fileToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.imageComparisonToolToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.menuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // imageDirectoryTXT
            // 
            this.imageDirectoryTXT.Location = new System.Drawing.Point(103, 57);
            this.imageDirectoryTXT.Name = "imageDirectoryTXT";
            this.imageDirectoryTXT.Size = new System.Drawing.Size(505, 20);
            this.imageDirectoryTXT.TabIndex = 1;
            // 
            // inputPicsLBL
            // 
            this.inputPicsLBL.AutoSize = true;
            this.inputPicsLBL.Location = new System.Drawing.Point(19, 60);
            this.inputPicsLBL.Name = "inputPicsLBL";
            this.inputPicsLBL.Size = new System.Drawing.Size(78, 13);
            this.inputPicsLBL.TabIndex = 2;
            this.inputPicsLBL.Text = "Original Photos";
            // 
            // outputImageDirectoryTXT
            // 
            this.outputImageDirectoryTXT.Location = new System.Drawing.Point(103, 83);
            this.outputImageDirectoryTXT.Name = "outputImageDirectoryTXT";
            this.outputImageDirectoryTXT.Size = new System.Drawing.Size(505, 20);
            this.outputImageDirectoryTXT.TabIndex = 3;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(11, 86);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(86, 13);
            this.label1.TabIndex = 4;
            this.label1.Text = "Analyzed Photos";
            // 
            // originalPhotosBTN
            // 
            this.originalPhotosBTN.Location = new System.Drawing.Point(614, 57);
            this.originalPhotosBTN.Name = "originalPhotosBTN";
            this.originalPhotosBTN.Size = new System.Drawing.Size(35, 20);
            this.originalPhotosBTN.TabIndex = 45;
            this.originalPhotosBTN.Text = "...";
            this.originalPhotosBTN.UseVisualStyleBackColor = true;
            this.originalPhotosBTN.Click += new System.EventHandler(this.originalPhotosBTN_Click);
            // 
            // outputPhotosBTN
            // 
            this.outputPhotosBTN.Location = new System.Drawing.Point(614, 83);
            this.outputPhotosBTN.Name = "outputPhotosBTN";
            this.outputPhotosBTN.Size = new System.Drawing.Size(35, 20);
            this.outputPhotosBTN.TabIndex = 46;
            this.outputPhotosBTN.Text = "...";
            this.outputPhotosBTN.UseVisualStyleBackColor = true;
            this.outputPhotosBTN.Click += new System.EventHandler(this.outputPhotosBTN_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(33, 113);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(67, 13);
            this.label2.TabIndex = 47;
            this.label2.Text = "Test To Run";
            // 
            // chooseTestCMB
            // 
            this.chooseTestCMB.FormattingEnabled = true;
            this.chooseTestCMB.Items.AddRange(new object[] {
            "Demosat Analysis",
            "Pixel Intensity Analysis"});
            this.chooseTestCMB.Location = new System.Drawing.Point(104, 110);
            this.chooseTestCMB.Name = "chooseTestCMB";
            this.chooseTestCMB.Size = new System.Drawing.Size(194, 21);
            this.chooseTestCMB.TabIndex = 48;
            this.chooseTestCMB.Text = "Demosat Analysis";
            // 
            // runImageTestBTN
            // 
            this.runImageTestBTN.Location = new System.Drawing.Point(436, 111);
            this.runImageTestBTN.Name = "runImageTestBTN";
            this.runImageTestBTN.Size = new System.Drawing.Size(35, 20);
            this.runImageTestBTN.TabIndex = 49;
            this.runImageTestBTN.Text = "Run";
            this.runImageTestBTN.UseVisualStyleBackColor = true;
            this.runImageTestBTN.Click += new System.EventHandler(this.runImageTestBTN_Click);
            // 
            // consoleRTB
            // 
            this.consoleRTB.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.consoleRTB.Location = new System.Drawing.Point(12, 457);
            this.consoleRTB.Name = "consoleRTB";
            this.consoleRTB.Size = new System.Drawing.Size(656, 178);
            this.consoleRTB.TabIndex = 50;
            this.consoleRTB.Text = "";
            // 
            // imagePBAR
            // 
            this.imagePBAR.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.imagePBAR.Location = new System.Drawing.Point(12, 641);
            this.imagePBAR.Name = "imagePBAR";
            this.imagePBAR.Size = new System.Drawing.Size(654, 13);
            this.imagePBAR.TabIndex = 51;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(304, 113);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(57, 13);
            this.label3.TabIndex = 52;
            this.label3.Text = "Image Ext:";
            // 
            // imageExtensionCMB
            // 
            this.imageExtensionCMB.FormattingEnabled = true;
            this.imageExtensionCMB.Items.AddRange(new object[] {
            "JPG"});
            this.imageExtensionCMB.Location = new System.Drawing.Point(367, 110);
            this.imageExtensionCMB.Name = "imageExtensionCMB";
            this.imageExtensionCMB.Size = new System.Drawing.Size(63, 21);
            this.imageExtensionCMB.TabIndex = 53;
            this.imageExtensionCMB.Text = "JPG";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(142, 41);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(395, 13);
            this.label4.TabIndex = 54;
            this.label4.Text = "STILL UNDER CONSTRUCTION, NOT ALL FEATURES WORK AS EXPECTED.";
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.fileToolStripMenuItem,
            this.toolsToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(680, 24);
            this.menuStrip1.TabIndex = 55;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // fileToolStripMenuItem
            // 
            this.fileToolStripMenuItem.Name = "fileToolStripMenuItem";
            this.fileToolStripMenuItem.Size = new System.Drawing.Size(37, 20);
            this.fileToolStripMenuItem.Text = "File";
            // 
            // toolsToolStripMenuItem
            // 
            this.toolsToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.imageComparisonToolToolStripMenuItem});
            this.toolsToolStripMenuItem.Name = "toolsToolStripMenuItem";
            this.toolsToolStripMenuItem.Size = new System.Drawing.Size(47, 20);
            this.toolsToolStripMenuItem.Text = "Tools";
            // 
            // imageComparisonToolToolStripMenuItem
            // 
            this.imageComparisonToolToolStripMenuItem.Name = "imageComparisonToolToolStripMenuItem";
            this.imageComparisonToolToolStripMenuItem.Size = new System.Drawing.Size(201, 22);
            this.imageComparisonToolToolStripMenuItem.Text = "Image Comparison Tool";
            // 
            // AnalyzeitForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(680, 666);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.imageExtensionCMB);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.imagePBAR);
            this.Controls.Add(this.consoleRTB);
            this.Controls.Add(this.runImageTestBTN);
            this.Controls.Add(this.chooseTestCMB);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.outputPhotosBTN);
            this.Controls.Add(this.outputImageDirectoryTXT);
            this.Controls.Add(this.originalPhotosBTN);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.imageDirectoryTXT);
            this.Controls.Add(this.inputPicsLBL);
            this.Controls.Add(this.menuStrip1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "AnalyzeitForm";
            this.Text = "AnalyzeIt!    A RockSat-C RICH Detector Image Analysis Tool";
            this.Load += new System.EventHandler(this.ImageAnalysisFrm_Load);
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox imageDirectoryTXT;
        private System.Windows.Forms.Label inputPicsLBL;
        private System.Windows.Forms.TextBox outputImageDirectoryTXT;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button originalPhotosBTN;
        private System.Windows.Forms.Button outputPhotosBTN;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.ComboBox chooseTestCMB;
        private System.Windows.Forms.Button runImageTestBTN;
        private System.Windows.Forms.RichTextBox consoleRTB;
        private System.Windows.Forms.ProgressBar imagePBAR;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.ComboBox imageExtensionCMB;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem fileToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem toolsToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem imageComparisonToolToolStripMenuItem;
    }
}