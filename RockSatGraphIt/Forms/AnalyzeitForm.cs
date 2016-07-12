using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using RockSatGraphIt.Properties;
using RockSatGraphIt.Utilities;
using static System.Math;


namespace RockSatGraphIt.Forms
{
    public partial class AnalyzeitForm : Form {

        private async void runImageTestBTN_Click(object sender, EventArgs e) {

            var testToRun = chooseTestCMB.Text;
            if (testToRun == string.Empty) return;

            if (testToRun == "Demosat Analysis") {
                var demo = new DemosatAnalysis(imageDirectoryTXT.Text, chooseTestCMB.Text, imageExtensionCMB.Text);
                if (!demo.Prepare()) return;

                runImageTestBTN.Enabled = false;
                await demo.Run(this);
                runImageTestBTN.Enabled = true;
            }
            else if (testToRun == "Pixel Intensity Analysis") {
                var pixel = new PixelIntensity(imageDirectoryTXT.Text, outputImageDirectoryTXT.Text, chooseTestCMB.Text, imageExtensionCMB.Text);
                if (!pixel.Prepare()) return;

                runImageTestBTN.Enabled = false;
                await pixel.Run(this);
                runImageTestBTN.Enabled = true;
            }
        }
        private void originalPhotosBTN_Click(object sender, EventArgs e)
        {
            var fbd = new FolderBrowserDialog();
            if (fbd.ShowDialog() == DialogResult.OK) {
                if (!Directory.Exists(fbd.SelectedPath)) Directory.CreateDirectory(fbd.SelectedPath);
                imageDirectoryTXT.Text = fbd.SelectedPath;
            }
        }
        private void outputPhotosBTN_Click(object sender, EventArgs e)
        {
            var fbd = new FolderBrowserDialog();
            if (fbd.ShowDialog() == DialogResult.OK)
            {
                if (!Directory.Exists(fbd.SelectedPath)) Directory.CreateDirectory(fbd.SelectedPath);
                outputImageDirectoryTXT.Text = fbd.SelectedPath;
            }
        }
        public void OnScriptDataReceived(string data)
        {
            int test;
            if (int.TryParse(data, out test)) OnProgressUpdate(test);
            else WriteLine(data, Color.Blue);
        }
        public void OnProgressUpdate(int percentage) {

            BeginInvoke((Action)(() => {
                imagePBAR.SetProgressNoAnimation(percentage);
            }));
        }
        public void WriteLine(string s, Color color)
        {
            s += "\n";
            BeginInvoke((Action)(() => {
                consoleRTB.SelectionColor = color;
                consoleRTB.SelectedText += s;
            }));
        }
        public sealed override string Text {
            get { return base.Text; }
            set { base.Text = value; }
        }
        private void ImageAnalysisFrm_Load(object sender, EventArgs e) {
            FormClosing += ImageAnalysisFrm_FormClosing;
        }
        private void ImageAnalysisFrm_FormClosing(object sender, FormClosingEventArgs e) {
            if (MessageBox.Show(Resources.SureTasksWillCancel, Resources.AreYouSure, MessageBoxButtons.OKCancel) ==
                DialogResult.Cancel) e.Cancel = true;
        }

        public AnalyzeitForm()
        {
            InitializeComponent();
            Text = $"AnalyzeIt! A RockSat-C Rocket Data Graphing Utility v{Program.Version.Major}.{Program.Version.Minor}.{Program.Version.Revision}";
        }
    }
}
