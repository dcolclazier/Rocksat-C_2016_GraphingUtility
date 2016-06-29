using System;
using System.Drawing;
using System.IO;
using System.Threading.Tasks;
using System.Windows.Forms;
using RockSatGraphIt.Properties;

#pragma warning disable 1998

namespace RockSatGraphIt {

    
    public partial class MainForm : Form {


        #region Form Event Handlers

        public MainForm() {
            InitializeComponent();
            this.Text = $"GraphIt!   A RockSat-C Rocket Data Graphing Utility v{Program.Version.Major}.{Program.Version.Minor}.{Program.Version.Revision}"
            ;
        }

        private void MainForm_Load(object sender, EventArgs e) {
            LoadSettings();
            FormClosing += MainForm_FormClosing;
        }

        private void MainForm_Shown(object sender, EventArgs e) {
            if (Directory.Exists(@"R\")) return;

            StartInitialSetup();
        }

        private void MainForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (MessageBox.Show(Resources.ExitMessage, Resources.ExitTitle, MessageBoxButtons.OKCancel) ==
                DialogResult.Cancel) e.Cancel = true;
        }

        private void StartInitialSetup() {
            createGraphBTN.Enabled = false;
            WriteOutput("Performing initial setup... Extracting necessary files from embedded resources..",
                Color.Blue);
            new Task(
                async () => {
                    await
                        FileUtilities.WriteFileAsync(this, Resources.R, @"R.zip", UpdateProgressBar,
                            OnIntialSetupComplete);
                }).Start();
        }

        public async void OnIntialSetupComplete()
        {
            Invoke((MethodInvoker)(() => {
                createGraphBTN.Enabled = false;

                WriteOutput("Extraction complete", Color.Blue);
                WriteOutput("Unzipping necessary files for graph creation...", Color.Blue);
            }));

            var task = new Task(async () => {
                await FileUtilities.ExtractFileAsync(this, @"R.zip", Directory.GetCurrentDirectory(), false, UpdateProgressBar,
                    () => {
                        WriteOutput("Initial Setup complete. Ready for some graphing!!", Color.Blue);
                        Invoke((Action) (() => {
                            createGraphBTN.Enabled = true;
                        }));
                        
                    });
            });
            task.Start();
        }

        private void loadDataFileBTN_Click(object sender, EventArgs e) {
            var fbd = new OpenFileDialog();
            if (fbd.ShowDialog() == DialogResult.OK) {
                fileNameTXT.Text = fbd.FileName;
            }
        }

        private void outputDirectoryBTN_Click(object sender, EventArgs e) {
            var fbd = new FolderBrowserDialog();
            if (fbd.ShowDialog() == DialogResult.OK) {
                outputDirectoryTXT.Text = fbd.SelectedPath;
            }
        }

        private void createGraphBTN_Click(object sender, EventArgs e) {
            if (!Ready(true)) return;

            createGraphBTN.Enabled = false;
            if (!ScriptDaemon.GenerateScript(Resources.RScript, "RScript.r", FixRScript)) {
                MessageBox.Show(Resources.ScriptGenerationError, Resources.AlertTitle,
                    MessageBoxButtons.OK);
                return;
            }

            var rCodeFilePath = Directory.GetCurrentDirectory() + @"\Rscript.r";

            var rScriptExecutablePath = Environment.Is64BitOperatingSystem
                ? Directory.GetCurrentDirectory() + @"\R\R-3.3.1\bin\x64\RScript.exe"
                : Directory.GetCurrentDirectory() + @"\R\R-3.3.1\bin\x86\RScript.exe";

            ScriptDaemon.ExecuteScript(rCodeFilePath, rScriptExecutablePath, "--verbose",
                onComplete: delegate { Invoke((Action) (() => {
                    WriteOutput("Graph generation complete.", Color.Blue);
                    createGraphBTN.Enabled = true;
                })); },
                onDataReceived: (data) => { WriteOutput(data, Color.Blue); },
                onException: (exception) => { WriteOutput(exception.Message + exception.InnerException?.Message, Color.Red);}
                );
        }

        private void exitMenuItem_Click(object sender, EventArgs e) {
            Application.Exit();
        }

        private void aboutMenuItem_Click(object sender, EventArgs e)
        {
            var aboutBox = new AboutBoxFRM();
            aboutBox.Show();
        }

        private void downloadDatafilesMenuItem_Click(object sender, EventArgs e)
        {
            string url = "http://apps.jdc.tech/graphit/data/data.zip";

            var fbd = new FolderBrowserDialog
            {
                Description = Resources.DataDirectorySelectMessage,
                RootFolder = Environment.SpecialFolder.MyDocuments,
                ShowNewFolderButton = true,
                SelectedPath = Environment.SpecialFolder.MyDocuments + @"\Rocksat-C Launch Data\"
            };
            if (fbd.ShowDialog() != DialogResult.OK) return;

            createGraphBTN.Enabled = false;
            WriteOutput("Beginning download of data files from " + url, Color.Blue);
            new Task(async () => {
                await
                    FileUtilities.DownloadFileAsynch(this, new Uri(url),
                        fbd.SelectedPath + @"\Rocksat-C Launch Data\data.zip", UpdateProgressBar, OnDataDownloadComplete);

            }).Start();
        }

        private async void OnDataDownloadComplete(string downloadPath)
        {

            Invoke((MethodInvoker)(() => {

                WriteOutput("Download complete.", Color.Blue);
                WriteOutput("Unzipping files...", Color.Blue);
            }));

            var task = new Task(async () => {
                var directory = Path.GetDirectoryName(downloadPath);
                await FileUtilities.ExtractFileAsync(this, downloadPath, directory, true, UpdateProgressBar,
                    () => {
                        WriteOutput("Data files unzipped succesfully to " + directory, Color.Blue);
                        BeginInvoke((Action)(() => {
                            createGraphBTN.Enabled = true;
                        }));
                    });
            });
            task.Start();
        }

        public void UpdateProgressBar(int percentage)
        {
            BeginInvoke((Action)(() => {
                progressBar1.Enabled = true;

                progressBar1.SetProgressNoAnimation(percentage);
            }));
        }
        #endregion


        #region Form Behaviour
        private void LoadSettings() {
            fileNameTXT.Text = (string) Settings.Default["fileNameTXT"];
            timeStartTXT.Text = (string) Settings.Default["timeStartTXT"];
            timeStopTXT.Text = (string) Settings.Default["timeStopTXT"];
            xAxisTicksTXT.Text = (string) Settings.Default["xAxisTicksTXT"];
            yMinTXT.Text = (string) Settings.Default["yMinTXT"];
            yMaxTXT.Text = (string) Settings.Default["yMaxTXT"];
            fileTypeCMB.Text = (string) Settings.Default["fileTypeCMB"];
            xAxisLabelTXT.Text = (string) Settings.Default["xAxisLabelTXT"];
            yAxisLabelTXT.Text = (string) Settings.Default["yAxisLabelTXT"];
            graphTitleTXT.Text = (string) Settings.Default["graphTitleTXT"];
            graphSubtitleTXT.Text = (string) Settings.Default["graphSubtitleTXT"];
            graphTypeCMB.Text = (string) Settings.Default["graphTypeCMB"];
            graphWidthTXT.Text = (string) Settings.Default["graphWidthTXT"];
            graphHeightTXT.Text = (string) Settings.Default["graphHeightTXT"];
            plotColorTXT.Text = (string) Settings.Default["plotColorTXT"];
            labelColorTXT.Text = (string) Settings.Default["labelColorTXT"];
            labelSizeTXT.Text = (string) Settings.Default["labelSizeTXT"];
            outputDirectoryTXT.Text = (string) Settings.Default["outputDirectoryTXT"];
            consoleRTB.ReadOnly = true;

            if (labelSizeTXT.Text == string.Empty) labelSizeTXT.Text = @"1.0";
        }

        private void SaveSettings() {
            Settings.Default["fileNameTXT"] = fileNameTXT.Text;
            Settings.Default["timeStartTXT"] = timeStartTXT.Text;
            Settings.Default["timeStopTXT"] = timeStopTXT.Text;
            Settings.Default["xAxisTicksTXT"] = xAxisTicksTXT.Text;
            Settings.Default["yMinTXT"] = yMinTXT.Text;
            Settings.Default["yMaxTXT"] = yMaxTXT.Text;
            Settings.Default["fileTypeCMB"] = fileTypeCMB.Text;
            Settings.Default["xAxisLabelTXT"] = xAxisLabelTXT.Text;
            Settings.Default["yAxisLabelTXT"] = yAxisLabelTXT.Text;
            Settings.Default["graphTitleTXT"] = graphTitleTXT.Text;
            Settings.Default["graphSubtitleTXT"] = graphSubtitleTXT.Text;
            Settings.Default["graphTypeCMB"] = graphTypeCMB.Text;
            Settings.Default["graphWidthTXT"] = graphWidthTXT.Text;
            Settings.Default["graphHeightTXT"] = graphHeightTXT.Text;
            Settings.Default["plotColorTXT"] = plotColorTXT.Text;
            Settings.Default["labelColorTXT"] = labelColorTXT.Text;
            Settings.Default["labelSizeTXT"] = labelSizeTXT.Text;
            Settings.Default["outputDirectoryTXT"] = outputDirectoryTXT.Text;
            Settings.Default.Save();
        }

        private void WriteOutput(string s, Color color) {
            s += "\n";
            BeginInvoke((Action) (() => {
                consoleRTB.SelectionColor = color;
                consoleRTB.SelectedText += s;
            }));
        }

        private bool Ready(bool verbose) {
            if (fileNameTXT.Text == string.Empty || timeStartTXT.Text == string.Empty ||
                timeStopTXT.Text == string.Empty ||
                xAxisTicksTXT.Text == string.Empty || yMinTXT.Text == string.Empty || yMaxTXT.Text == string.Empty ||
                fileTypeCMB.Text == string.Empty || xAxisLabelTXT.Text == string.Empty ||
                yAxisLabelTXT.Text == string.Empty ||
                graphTitleTXT.Text == string.Empty || graphTypeCMB.Text == string.Empty ||
                graphWidthTXT.Text == string.Empty ||
                graphHeightTXT.Text == string.Empty || plotColorTXT.Text == string.Empty ||
                plotColorTXT.Text == string.Empty ||
                labelSizeTXT.Text == string.Empty || outputDirectoryTXT.Text == string.Empty) {
                if (verbose) MessageBox.Show(Resources.EmptyFieldsError, Resources.AlertTitle, MessageBoxButtons.OK);
                return false;
            }

            if (!Directory.Exists(outputDirectoryTXT.Text)) {
                if (verbose) {
                    var response = MessageBox.Show(Resources.DirectoryDoesntExist, Resources.AlertTitle,
                        MessageBoxButtons.YesNo);
                    switch (response) {
                        case DialogResult.No:
                            return false;
                        case DialogResult.Yes:
                            Directory.CreateDirectory(outputDirectoryTXT.Text);
                            if (outputDirectoryTXT.Text.GetLast(1) != @"\")
                                outputDirectoryTXT.Text = outputDirectoryTXT.Text + @"\";
                            break;
                    }
                }
                else {
                    Directory.CreateDirectory(outputDirectoryTXT.Text);
                }
            }

            if (outputDirectoryTXT.Text.GetLast(1) != @"\") outputDirectoryTXT.Text += @"\";

            double result;
            if (!double.TryParse(yMinTXT.Text, out result) ||
                !double.TryParse(yMaxTXT.Text, out result) ||
                !double.TryParse(graphWidthTXT.Text, out result) ||
                !double.TryParse(graphHeightTXT.Text, out result) ||
                !double.TryParse(labelSizeTXT.Text, out result) ||
                !double.TryParse(xAxisTicksTXT.Text, out result)) {
                if (verbose) MessageBox.Show(Resources.InvalidNumber, Resources.AlertTitle, MessageBoxButtons.OK);
                return false;
            }
            if (double.Parse(timeStartTXT.Text) > double.Parse(timeStopTXT.Text)) {
                if (verbose)
                    MessageBox.Show(Resources.NumericalBoundsError, Resources.AlertTitle, MessageBoxButtons.OK);
                return false;
            }
            if (double.Parse(yMinTXT.Text) > double.Parse(yMaxTXT.Text)) {
                if (verbose)
                    MessageBox.Show(Resources.NumericalBoundsError, Resources.AlertTitle, MessageBoxButtons.OK);
                return false;
            }
            if (double.Parse(timeStartTXT.Text) < 0) {
                if (verbose) MessageBox.Show(Resources.InvalidStartTime, Resources.AlertTitle, MessageBoxButtons.OK);
                timeStartTXT.Text = @"0";
                return false;
            }
            if (Path.GetFileName(fileNameTXT.Text).GetLast(4) != ".csv") {
                if (verbose)
                    MessageBox.Show(Resources.InvalidFileExtension, Resources.AlertTitle, MessageBoxButtons.OK);
                return false;
            }
            if (!fileTypeCMB.Items.Contains(fileTypeCMB.Text)) {
                if (verbose) MessageBox.Show(Resources.InvalidOutputType, Resources.AlertTitle, MessageBoxButtons.OK);
                return false;
            }
            if (!graphTypeCMB.Items.Contains(graphTypeCMB.Text)) {
                if (verbose) MessageBox.Show(Resources.InvalidGraphType, Resources.AlertTitle, MessageBoxButtons.OK);
                return false;
            }

            SaveSettings();
            return true;
        }
        


        private string FixRScript(string template)
        {

            var fixedContents = template;
            fixedContents = fixedContents.Replace("__Filename__", Path.GetFileName(fileNameTXT.Text));
            fixedContents = fixedContents.Replace("__FullFilename__", fileNameTXT.Text.Replace(@"\", "/"));
            fixedContents = fixedContents.Replace("__TimeStart__", timeStartTXT.Text);
            fixedContents = fixedContents.Replace("__TimeStop__", timeStopTXT.Text);
            fixedContents = fixedContents.Replace("__TickPeriod__", xAxisTicksTXT.Text);
            fixedContents = fixedContents.Replace("__yMinimum__", yMinTXT.Text);
            fixedContents = fixedContents.Replace("__yMaximum__", yMaxTXT.Text);
            fixedContents = fixedContents.Replace("__OutputFileType__", fileTypeCMB.Text);
            fixedContents = fixedContents.Replace("__xLabel__", xAxisLabelTXT.Text);
            fixedContents = fixedContents.Replace("__yLabel__", yAxisLabelTXT.Text);
            fixedContents = fixedContents.Replace("__Title__", graphTitleTXT.Text);
            fixedContents = fixedContents.Replace("__Subtitle__", graphSubtitleTXT.Text);
            fixedContents = fixedContents.Replace("__GraphType__", graphTypeCMB.Text.Substring(0, 1).ToLower());
            fixedContents = fixedContents.Replace("__GraphWidth__", graphWidthTXT.Text);
            fixedContents = fixedContents.Replace("__GraphHeight__", graphHeightTXT.Text);
            fixedContents = fixedContents.Replace("__PlotColor__", plotColorTXT.Text);
            fixedContents = fixedContents.Replace("__LabelColor__", labelColorTXT.Text);
            fixedContents = fixedContents.Replace("__LabelSize__", labelSizeTXT.Text);
            fixedContents = fixedContents.Replace("__OutputDirectory__", outputDirectoryTXT.Text.Replace(@"\", "/"));
            return fixedContents;
        }

        #endregion
    }
}
