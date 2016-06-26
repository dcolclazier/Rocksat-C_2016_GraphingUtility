using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.IO.Compression;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using RockSatGraphIt.Properties;

namespace RockSatGraphIt
{
    public partial class MainForm : Form
    {

        public MainForm()
        {
            InitializeComponent();
        }

        private void MainForm_Load(object sender, EventArgs e)
        {

            if (!Directory.Exists(@"R\"))
            {
                MessageBox.Show(
                    @"Performing first time setup... This could take a few minutes.",
                    Resources.AlertTitle, MessageBoxButtons.OK);
                CreateDependencies();
                MessageBox.Show(@"Setup complete.", Resources.AlertTitle, MessageBoxButtons.OK);
            }
            LoadSettings();
        }
        private void loadDataFileBTN_Click(object sender, EventArgs e)
        {
            var fbd = new OpenFileDialog();
            if (fbd.ShowDialog() == DialogResult.OK)
            {
                fileNameTXT.Text = fbd.FileName;
            }
        }
        private void outputDirectoryBTN_Click(object sender, EventArgs e)
        {
            var fbd = new FolderBrowserDialog();
            if (fbd.ShowDialog() == DialogResult.OK)
            {
                outputDirectoryTXT.Text = fbd.SelectedPath;
            }
        }
        private void createGraphBTN_Click(object sender, EventArgs e)
        {
            if (!Ready(true)) return;

            if (!GenerateRScript(Resources.RScript))
            {
                MessageBox.Show(Resources.ScriptGenerationError, Resources.AlertTitle,
                    MessageBoxButtons.OK);
                return;
            };

            var rCodeFilePath = Directory.GetCurrentDirectory() + @"\Rscript.r";

            var rScriptExecutablePath = Environment.Is64BitOperatingSystem
                ? Directory.GetCurrentDirectory() + @"\R\R-3.3.1\bin\x64\RScript.exe"
                : Directory.GetCurrentDirectory() + @"\R\R-3.3.1\bin\x86\RScript.exe";

            ExecuteScript(rCodeFilePath, rScriptExecutablePath, "--verbose");

        }

        private void LoadSettings()
        {
            fileNameTXT.Text = (string)Settings.Default["fileNameTXT"];
            timeStartTXT.Text = (string)Settings.Default["timeStartTXT"];
            timeStopTXT.Text = (string)Settings.Default["timeStopTXT"];
            xAxisTicksTXT.Text = (string)Settings.Default["xAxisTicksTXT"];
            yMinTXT.Text = (string)Settings.Default["yMinTXT"];
            yMaxTXT.Text = (string)Settings.Default["yMaxTXT"];
            fileTypeCMB.Text = (string)Settings.Default["fileTypeCMB"];
            xAxisLabelTXT.Text = (string)Settings.Default["xAxisLabelTXT"];
            yAxisLabelTXT.Text = (string)Settings.Default["yAxisLabelTXT"];
            graphTitleTXT.Text = (string)Settings.Default["graphTitleTXT"];
            graphSubtitleTXT.Text = (string)Settings.Default["graphSubtitleTXT"];
            graphTypeCMB.Text = (string)Settings.Default["graphTypeCMB"];
            graphWidthTXT.Text = (string)Settings.Default["graphWidthTXT"];
            graphHeightTXT.Text = (string)Settings.Default["graphHeightTXT"];
            plotColorTXT.Text = (string)Settings.Default["plotColorTXT"];
            labelColorTXT.Text = (string)Settings.Default["labelColorTXT"];
            labelSizeTXT.Text = (string)Settings.Default["labelSizeTXT"];
            outputDirectoryTXT.Text = (string)Settings.Default["outputDirectoryTXT"];

            if (labelSizeTXT.Text == string.Empty) labelSizeTXT.Text = @"1.0";
        }
        private void SaveSettings()
        {

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
        private void CreateDependencies()
        {
            File.WriteAllBytes(@"R.zip", Resources.R);
            ZipFile.ExtractToDirectory(@"R.zip", Directory.GetCurrentDirectory());
            File.Delete("R.zip");

        }

        private bool Ready(bool verbose)
        {

            if (fileNameTXT.Text == string.Empty || timeStartTXT.Text == string.Empty || timeStopTXT.Text == string.Empty ||
                xAxisTicksTXT.Text == string.Empty || yMinTXT.Text == string.Empty || yMaxTXT.Text == string.Empty ||
                fileTypeCMB.Text == string.Empty || xAxisLabelTXT.Text == string.Empty || yAxisLabelTXT.Text == string.Empty ||
                graphTitleTXT.Text == string.Empty || graphTypeCMB.Text == string.Empty ||
                graphWidthTXT.Text == string.Empty || graphHeightTXT.Text == string.Empty || plotColorTXT.Text == string.Empty ||
                plotColorTXT.Text == string.Empty || labelSizeTXT.Text == string.Empty || outputDirectoryTXT.Text == string.Empty)
            {

                if (verbose) MessageBox.Show(Resources.EmptyFieldsError, Resources.AlertTitle, MessageBoxButtons.OK);
                return false;
            }

            if (!System.IO.Directory.Exists(outputDirectoryTXT.Text))
            {
                if (verbose)
                {
                    var response = MessageBox.Show(Resources.DirectoryDoesntExist, Resources.AlertTitle,
                        MessageBoxButtons.YesNo);
                    switch (response)
                    {
                        case DialogResult.No:
                            return false;
                        case DialogResult.Yes:
                            Directory.CreateDirectory(outputDirectoryTXT.Text);
                            if (outputDirectoryTXT.Text.GetLast(1) != @"\") outputDirectoryTXT.Text = outputDirectoryTXT.Text + @"\";
                            break;
                    }
                }
                else
                {
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
                !double.TryParse(xAxisTicksTXT.Text, out result))
            {
                if (verbose) MessageBox.Show(Resources.InvalidNumber, Resources.AlertTitle, MessageBoxButtons.OK);
                return false;
            }
            if (double.Parse(timeStartTXT.Text) > double.Parse(timeStopTXT.Text))
            {
                if (verbose) MessageBox.Show(Resources.NumericalBoundsError, Resources.AlertTitle, MessageBoxButtons.OK);
                return false;
            }
            if (double.Parse(yMinTXT.Text) > double.Parse(yMaxTXT.Text))
            {
                if (verbose) MessageBox.Show(Resources.NumericalBoundsError, Resources.AlertTitle, MessageBoxButtons.OK);
                return false;
            }
            if (double.Parse(timeStartTXT.Text) < 0)
            {
                if (verbose) MessageBox.Show(Resources.InvalidStartTime, Resources.AlertTitle, MessageBoxButtons.OK);
                timeStartTXT.Text = @"0";
                return false;
            }
            if (Path.GetFileName(fileNameTXT.Text).GetLast(4) != ".csv")
            {
                if (verbose) MessageBox.Show(Resources.InvalidFileExtension, Resources.AlertTitle, MessageBoxButtons.OK);
                return false;
            }
            if (!fileTypeCMB.Items.Contains(fileTypeCMB.Text))
            {
                if (verbose) MessageBox.Show(Resources.InvalidOutputType, Resources.AlertTitle, MessageBoxButtons.OK);
                return false;
            }
            if (!graphTypeCMB.Items.Contains(graphTypeCMB.Text))
            {
                if (verbose) MessageBox.Show(Resources.InvalidGraphType, Resources.AlertTitle, MessageBoxButtons.OK);
                return false;
            }


            SaveSettings();
            return true;
        }
        private bool GenerateRScript(string template)
        {

            var readyScript = FixRScript(template);
            return Safe_FileWrite("RScript.r", FileMode.Create, readyScript);
        }
        private string FixRScript(string contents)
        {

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
        private string FixNonRPath(string path)
        {
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

        private void ExecuteScript(string scriptPath, string executablePath, string args)
        {
            var result = string.Empty;
            try
            {
                var info = new ProcessStartInfo
                {
                    FileName = executablePath,
                    // ReSharper disable once AssignNullToNotNullAttribute
                    WorkingDirectory = Path.GetDirectoryName(executablePath),
                    Arguments = scriptPath + " " + args,
                    RedirectStandardInput = false,
                    RedirectStandardOutput = false,
                    ErrorDialog = false,
                    UseShellExecute = false,
                    CreateNoWindow = false
                };

                using (var proc = new Process())
                {
                    proc.StartInfo = info;
                    proc.Start();
                }
            }
            catch (Exception ex)
            {
                throw new Exception("R Script failed: " + result, ex);
            }

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
    }

    public static class StringExtension {
        public static string GetLast(this string source, int tailLength) {
            return tailLength >= source.Length ? source : source.Substring(source.Length - tailLength);
        }
    }
}
