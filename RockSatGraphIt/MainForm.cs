using System;
using System.ComponentModel;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Net;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Windows.Forms.VisualStyles;
using Ionic.Zip;
using RockSatGraphIt.Properties;

namespace RockSatGraphIt {
    public partial class MainForm : Form {
        private string _dataDir;
        private string _zipPath;
        private string _dataDumpFolderName = @"/RockSat-C 2016 CCCO Launch Data";

        public MainForm() {
            InitializeComponent();
        }

        private void MainForm_Load(object sender, EventArgs e) {
            if (!Directory.Exists(@"R\")) {
                MessageBox.Show(
                    @"Performing first time setup... This could take a few minutes.",
                    Resources.AlertTitle, MessageBoxButtons.OK);
                CreateDependencies();
                MessageBox.Show(@"Setup complete.", Resources.AlertTitle, MessageBoxButtons.OK);
            }
            LoadSettings();
            FormClosing += MainForm_FormClosing;
            consoleRTB.ReadOnly = true;
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

            if (!GenerateRScript(Resources.RScript)) {
                MessageBox.Show(Resources.ScriptGenerationError, Resources.AlertTitle,
                    MessageBoxButtons.OK);
                return;
            }

            var rCodeFilePath = Directory.GetCurrentDirectory() + @"\Rscript.r";

            var rScriptExecutablePath = Environment.Is64BitOperatingSystem
                ? Directory.GetCurrentDirectory() + @"\R\R-3.3.1\bin\x64\RScript.exe"
                : Directory.GetCurrentDirectory() + @"\R\R-3.3.1\bin\x86\RScript.exe";

            ExecuteScript(rCodeFilePath, rScriptExecutablePath, "--verbose");
        }

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

        

        private bool Ready(bool verbose) {
            if (fileNameTXT.Text == string.Empty || timeStartTXT.Text == string.Empty ||
                timeStopTXT.Text == string.Empty ||
                xAxisTicksTXT.Text == string.Empty || yMinTXT.Text == string.Empty || yMaxTXT.Text == string.Empty ||
                fileTypeCMB.Text == string.Empty || xAxisLabelTXT.Text == string.Empty ||
                yAxisLabelTXT.Text == string.Empty ||
                graphTitleTXT.Text == string.Empty || graphTypeCMB.Text == string.Empty ||
                graphWidthTXT.Text == string.Empty || graphHeightTXT.Text == string.Empty ||
                plotColorTXT.Text == string.Empty ||
                plotColorTXT.Text == string.Empty || labelSizeTXT.Text == string.Empty ||
                outputDirectoryTXT.Text == string.Empty) {
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

        private bool GenerateRScript(string template) {
            var readyScript = FixRScript(template);
            return Safe_FileWrite("RScript.r", FileMode.Create, readyScript);
        }

        private string FixRScript(string contents) {
            var fixedContents = contents;
            fixedContents = fixedContents.Replace("__Filename__", Path.GetFileName(fileNameTXT.Text));
            fixedContents = fixedContents.Replace("__FullFilename__", FixNonRPath(fileNameTXT.Text));
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
            fixedContents = fixedContents.Replace("__GraphType__", GetGraphType(graphTypeCMB.Text));
            fixedContents = fixedContents.Replace("__GraphWidth__", graphWidthTXT.Text);
            fixedContents = fixedContents.Replace("__GraphHeight__", graphHeightTXT.Text);
            fixedContents = fixedContents.Replace("__PlotColor__", plotColorTXT.Text);
            fixedContents = fixedContents.Replace("__LabelColor__", labelColorTXT.Text);
            fixedContents = fixedContents.Replace("__LabelSize__", labelSizeTXT.Text);
            fixedContents = fixedContents.Replace("__OutputDirectory__", FixNonRPath(outputDirectoryTXT.Text));
            return fixedContents;
        }

        private string FixNonRPath(string path) {
            return path.Replace(@"\", "/");
        }

        private string GetGraphType(string selectedGraphType) {
            if (selectedGraphType == "Points") return "p";
            if (selectedGraphType == "Line") return "l";
            if (selectedGraphType == "Points + Line") return "b";
            if (selectedGraphType == "Overplotted") return "o";
            if (selectedGraphType == "Histogram") return "h";
            return selectedGraphType == "Stair Steps" ? "s" : "n";
        }

        private void ExecuteScript(string scriptPath, string executablePath, string args) {
            //Create our process start info
            var editedPath = "\"" + scriptPath + "\" " + args;

            var processStartInfo = new ProcessStartInfo {
                FileName = executablePath,
                // ReSharper disable once AssignNullToNotNullAttribute
                WorkingDirectory = Path.GetDirectoryName(executablePath),
                Arguments = editedPath,
                RedirectStandardInput = false,
                RedirectStandardOutput = true,
                RedirectStandardError = true,
                ErrorDialog = false,
                UseShellExecute = false,
                CreateNoWindow = true
            };

            //Create our process, register process events
            var proc = new Process {
                EnableRaisingEvents = true,
                StartInfo = processStartInfo
            };

            proc.Exited += ExecutionFinished;
            proc.OutputDataReceived += LogOutputData;

            

            //Disable Create graph button so we can't do this more than once at a time
            createGraphBTN.Enabled = false;

            //Start the process.
            try {
                proc.Start();
            }
            catch (Exception ex) {
                WriteOutput("Failed: " + ex + Environment.NewLine, Color.LawnGreen);
            }
            proc.BeginOutputReadLine();
            //string error = proc.StandardError.ReadLine();
            //proc.WaitForExit();
            //LogErrorData(error);


        }

        private void LogErrorData(string errorMessage) {

            WriteOutput(errorMessage, Color.DarkRed);
        }

        private void LogOutputData(object sender, DataReceivedEventArgs e) {
            WriteOutput(e.Data, Color.DarkBlue);
        }

        private void WriteOutput(string s, Color color) {
            s += "\n";
            Invoke((Action) (() => {
                consoleRTB.SelectionColor = color;
                consoleRTB.SelectedText += s;
            }));
        }

        private void ExecutionFinished(object sender, EventArgs e) {
            Invoke((Action) (() => { createGraphBTN.Enabled = true; }));
        }

        private bool Safe_FileWrite(string solutionFilePath, FileMode fileMode, string contents) {
            FileStream fs = null;
            try {
                fs = new FileStream(solutionFilePath, fileMode, FileAccess.ReadWrite, FileShare.ReadWrite);
                using (TextWriter tw = new StreamWriter(fs)) {
                    fs = null;
                    tw.Write(contents);
                    tw.Close();
                }
            }
            catch (Exception e) {
                MessageBox.Show(e.Message + e.InnerException?.Message, Resources.AlertTitle, MessageBoxButtons.OK);
                return false;
            }
            finally {
                fs?.Dispose();
            }
            return true;
        }

        private void exitToolStripMenuItem_Click(object sender, EventArgs e) {
            Application.Exit();
        }

        private void MainForm_FormClosing(object sender, FormClosingEventArgs e) {
            if (MessageBox.Show("Are you sure you wish to exit?", "...sniff sniff...", MessageBoxButtons.OKCancel) ==
                DialogResult.Cancel) e.Cancel = true;
        }

        private void downloadDatafilesToolStripMenuItem_Click(object sender, EventArgs e)
        {
            
            var fbd = new FolderBrowserDialog {
                Description = "Please select the folder to download the data files to.",
                RootFolder = Environment.SpecialFolder.MyDocuments,
                ShowNewFolderButton = true,
                SelectedPath = Environment.SpecialFolder.MyDocuments.ToString() + @"\RockSat-C 2016 Datafiles\"
            };
            if (fbd.ShowDialog() == DialogResult.OK) {
                _zipPath = fbd.SelectedPath;
                startDownload(_zipPath);
            }
        }

        private void CreateDependencies()
        {
            File.WriteAllBytes(@"R.zip", Resources.R);

            //ZipFile.ExtractToDirectory(@"R.zip", Directory.GetCurrentDirectory());
            ExtractFileAsync(@"R.zip",Directory.GetCurrentDirectory(),progressBarLBL,progressBar1,createGraphBTN);

            //File.Delete("R.zip");
        }

        private void startDownload(string path) {
            BeginInvoke((Action) (() => {
                createGraphBTN.Enabled = false;
            }));
            var thread = new Thread(() => {
                var client = new WebClient();
                client.DownloadProgressChanged += client_DownloadProgressChanged;
                client.DownloadFileCompleted += client_DownloadFileCompleted;
                var dumpDir = path + _dataDumpFolderName;
                if (!Directory.Exists(dumpDir)) Directory.CreateDirectory(dumpDir);
                _dataDir = dumpDir;
                client.DownloadFileAsync(new Uri("http://apps.jdc.tech/graphit/data/data.zip"), dumpDir + @"/data.zip");
                
            });
            thread.Start();
        }
        
        public void ExtractFileAsync(string zipToUnpack, string unpackDirectory, Label progressBarLabel, ProgressBar progressBar, Button buttonToDisable = null)
        {
            BeginInvoke((Action)(() => {
                progressBar1.Visible = true;
                if (buttonToDisable != null) buttonToDisable.Enabled = false;
            }));

            var worker = new BackgroundWorker {WorkerReportsProgress = true};

            worker.ProgressChanged += (o, e) => {
                progressBarLabel.Enabled = true;
                progressBar.Value = e.ProgressPercentage;

                progressBarLabel.BackColor = Color.Transparent;
                progressBarLBL.Text = "Unzipping...";
            };

            worker.RunWorkerCompleted += delegate {
                File.Delete(zipToUnpack);
                progressBarLabel.BackColor = Color.Transparent;
                progressBarLabel.Text = "Complete!";
                if (buttonToDisable != null) buttonToDisable.Enabled = true;
            };

            worker.DoWork += delegate {
                using (ZipFile zip = ZipFile.Read(zipToUnpack)) {
                    int step = (int) 100.0/zip.Count;
                    int percentComplete = 0;
                    foreach (ZipEntry file in zip) {
                        file.Extract(unpackDirectory, ExtractExistingFileAction.OverwriteSilently);
                        percentComplete += step;
                        worker.ReportProgress(percentComplete);
                    }
                }
            };
            worker.RunWorkerAsync();
            
        }
       
        void client_DownloadProgressChanged(object sender, DownloadProgressChangedEventArgs e) {
            
            BeginInvoke((MethodInvoker)delegate {
                progressBar1.Visible = true;
                var bytesIn = double.Parse(e.BytesReceived.ToString());
                var totalBytes = double.Parse(e.TotalBytesToReceive.ToString());
                var percentage = bytesIn / totalBytes * 100;

                progressBarLBL.BackColor = Color.Transparent;
                progressBarLBL.Text = "Downloading to " + _zipPath.Replace("/",@"\") + _dataDumpFolderName.Replace("/",@"\");
                progressBar1.Value = int.Parse(Math.Truncate(percentage).ToString());
            });
        }

        
        void client_DownloadFileCompleted(object sender, AsyncCompletedEventArgs e)
        {
            this.BeginInvoke((MethodInvoker)delegate {
                createGraphBTN.Enabled = true;
                progressBarLBL.BackColor = Color.Transparent;
                progressBarLBL.Text = "Complete!";
                //ZipFile.ExtractToDirectory(_dataDir + @"\data.zip",_dataDir);
                ExtractFileAsync(_dataDir + @"\data.zip",_dataDir,progressBarLBL,progressBar1,createGraphBTN);
            });
            
        }
        private void aboutToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var aboutBox = new AboutBOX();
            aboutBox.Show();
        }
    }

    public static class StringExtension {
        public static string GetLast(this string source, int tailLength) {
            return tailLength >= source.Length ? source : source.Substring(source.Length - tailLength);
        }
    }
}