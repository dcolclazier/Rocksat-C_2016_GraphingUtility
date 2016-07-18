using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using RockSatGraphIt.Properties;
using RockSatGraphIt.Utilities;

namespace RockSatGraphIt.Forms
{
    public partial class NewGraphitForm : Form {
        private string _saveFilePath;
        private List<PlotInfo> AllPlots { get; } = new List<PlotInfo>();
        private readonly List<string> _plotsList = new List<string>();
        private readonly string _settingsDirectory = Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData) + @"\DavidColclazier\GraphIt\";
        

        public NewGraphitForm()
        {
            InitializeComponent();
            if (!Directory.Exists(_settingsDirectory)) Directory.CreateDirectory(_settingsDirectory);
            colorCMB.DataSource = Utilities.ColorOptions;
            colorCMB.Text = @"black";

            Text = $"GraphIt!   A RockSat-C Rocket Data Graphing Utility v{Program.Version.Major}.{Program.Version.Minor}.{Program.Version.Revision}";
            PlotCompleted += AddPlotToGraph;
        }
        public sealed override string Text
        {
            get { return base.Text; }
            set { base.Text = value; }
        }
        private bool Ready(bool verbose)
        {
            if (xAxisLabelTXT.Text == string.Empty ||
                yAxisLabelTXT.Text == string.Empty || graphTitleTXT.Text == string.Empty || 
                graphLengthTXT.Text == string.Empty ||
                graphHeightTXT.Text == string.Empty || labelSizeTXT.Text == string.Empty) {
                if (verbose) MessageBox.Show(Resources.EmptyFieldsError, Resources.AlertTitle, MessageBoxButtons.OK);
                return false;
            }
            
            double result;
            if (!double.TryParse(graphHeightTXT.Text, out result) ||
                !double.TryParse(labelSizeTXT.Text, out result)) {
                if (verbose) MessageBox.Show(Resources.InvalidNumber, Resources.AlertTitle, MessageBoxButtons.OK);
                return false;
            }
            if (AllPlots.Count == 0) {
                MessageBox.Show("You must include at least one plot... Click on the '+' to add a plot.",
                    Resources.AlertTitle, MessageBoxButtons.OK);
                return false;
            }
            if (!ScriptDaemon.FixScript(Resources.RScriptTemplate, _settingsDirectory + @"\RScript.r", FixRScript)) {
                MessageBox.Show(Resources.ScriptGenerationError, Resources.AlertTitle, MessageBoxButtons.OK);
                return false;
            }

            //SaveSettings();

            return true;
        }
        private string FixRScript(string template)
        {
            var fixedContents = template;
            fixedContents = fixedContents.Replace("__xLabel__", xAxisLabelTXT.Text);
            fixedContents = fixedContents.Replace("__yLabel__", yAxisLabelTXT.Text);
            fixedContents = fixedContents.Replace("__Title__", graphTitleTXT.Text);
            fixedContents = fixedContents.Replace("__Subtitle__", graphSubtitleTXT.Text);
            fixedContents = fixedContents.Replace("__GraphWidth__", graphLengthTXT.Text);
            fixedContents = fixedContents.Replace("__GraphHeight__", graphHeightTXT.Text);
            fixedContents = fixedContents.Replace("__LabelColor__", colorCMB.Text);
            fixedContents = fixedContents.Replace("__LabelSize__", labelSizeTXT.Text);

            //fix the first plot settings...
            var firstPlot = AllPlots.First();
            fixedContents = fixedContents.Replace("__FirstPlotPath__", firstPlot.InputFilePath.Replace(@"\", "/"));
            fixedContents = fixedContents.Replace("__FirstPlotGraphType__", firstPlot.GraphType.Substring(0,1).ToLower());
            fixedContents = fixedContents.Replace("__FirstPlotColor__", firstPlot.PlotColor);
            fixedContents = fixedContents.Replace("__FirstPlotDomainDataColumnName__", firstPlot.DomainDataColumnName.Replace(@"(",".").Replace(@")", "."));
            fixedContents = fixedContents.Replace("__FirstPlotDomainMin__", firstPlot.DomainMin.ToString());
            fixedContents = fixedContents.Replace("__FirstPlotDomainMax__", firstPlot.DomainMax.ToString());
            fixedContents = fixedContents.Replace("__FirstPlotDomainHashPeriod__", firstPlot.DomainHashPeriod.ToString());
            fixedContents = fixedContents.Replace("__FirstPlotRangeDataColumnName__", firstPlot.RangeDataColumnName.Replace(@"(", ".").Replace(@")", "."));
            fixedContents = fixedContents.Replace("__FirstPlotRangeMin__", firstPlot.RangeMin.ToString());
            fixedContents = fixedContents.Replace("__FirstPlotRangeMax__", firstPlot.RangeMax.ToString());
            fixedContents = fixedContents.Replace("__FirstPlotRangeHashPeriod__", firstPlot.RangeHashPeriod.ToString());

            //get a filename from the user...
            fixedContents = fixedContents.Replace("__OutputFilePath__", GetSavedGraphPath().Replace(@"\","/"));
            fixedContents = fixedContents.Replace("__OutputExtension__", Path.GetExtension(_saveFilePath));

            //add additional plot commands to graphing script
            fixedContents = fixedContents.Replace("##PLOT ADDITIONS##", GenerateAdditionalPlots());


            return fixedContents;
        }

        private string GenerateAdditionalPlots() {

            if (AllPlots.Count <= 1) return ""; //no additional plots to add.

            var sb = new StringBuilder();
            foreach (var plot in AllPlots.Skip(1)) { 
                sb.Append($"data <- read.table(\"{plot.InputFilePath.Replace(@"\","/")}\", header=T, sep=\",\");\n");
                sb.Append($"lines(data${plot.DomainDataColumnName.Replace(@"(", ".").Replace(@")", ".")}, data${plot.RangeDataColumnName.Replace(@"(", ".").Replace(@")", ".")}, xlim = c({plot.DomainMin}, {plot.DomainMax}), ylim = c({plot.RangeMin},{plot.RangeMax}),type = \"{plot.GraphType.Substring(0, 1).ToLower()}\", col = \"{plot.PlotColor}\");\n");
            }
            return sb.ToString();
        }

        private string GetSavedGraphPath() {
            var sfd = new SaveFileDialog() {
                FileName = "Graph.pdf",
                DefaultExt = ".pdf",
                //Filter = "Images (*.pdf, *.jpg, *.png)|*.pdf;*.jpg;*.png"
                Filter = @"Adobe PDF(*.pdf) | *.pdf; | JPEG (*.jpg) | *.jpg; | Portable Network Graphic (*.png) | *.png;"
            };

            if (sfd.ShowDialog() != DialogResult.OK) return GetSavedGraphPath();

            _saveFilePath = sfd.FileName;
            return _saveFilePath;
        }

        

        private void WriteOutput(string s, Color color) {
            if (s == string.Empty) return;
            s += "\n";
            BeginInvoke((Action)(() => {
                consoleRTB.SelectionColor = color;
                consoleRTB.SelectedText += s;
            }));
        }
        public void UpdateProgressBar(int percentage)
        {
            BeginInvoke((Action)(() => {
                progressBar1.Enabled = true;
                progressBar1.SetProgressNoAnimation(percentage);
            }));
        }

        private void addplotBTN_Click(object sender, EventArgs e) {

            ShowPlotForm();
        }
        private void removePlotBTN_Click(object sender, EventArgs e)
        {
            var selected = plotsListBox.SelectedIndex;
            AllPlots.RemoveAt(selected);
            _plotsList.RemoveAt(selected);
            plotsListBox.DataSource = null;
            plotsListBox.DataSource = _plotsList;
        }
        private void ShowPlotForm() {
            var frm = new AddPlotForm(this) {
                StartPosition = FormStartPosition.Manual,
            };
            frm.Location = new Point(Location.X + (Width - frm.Width) / 2, Location.Y + 25);
            frm.Show();
        }


        public event Action<PlotInfo> PlotCompleted;
        protected internal virtual void OnPlotCompleted(PlotInfo obj) {
            PlotCompleted?.Invoke(obj);
        }
        private void AddPlotToGraph(PlotInfo plot)
        {
            AllPlots.Add(plot);
            _plotsList.Add(plot.Metadata);

            plotsListBox.DataSource = null;
            plotsListBox.DataSource = _plotsList;
        }

        private async void downloadRocksatCDatafilesToolStripMenuItem_Click(object sender, EventArgs e)
        {
            const string url = "http://apps.jdc.tech/graphit/data/data.zip";

            var fbd = new FolderBrowserDialog
            {
                Description = Resources.DataDirectorySelectMessage,
                RootFolder = Environment.SpecialFolder.MyDocuments,
                ShowNewFolderButton = true,
                SelectedPath = Environment.SpecialFolder.MyDocuments + @"\Rocksat-C Launch Data\"
            };
            if (fbd.ShowDialog() != DialogResult.OK) return;

            var downloadPath = fbd.SelectedPath + @"\Rocksat-C Launch Data\data.zip";
            var directory = Path.GetDirectoryName(downloadPath);

            createGraphBTN.Enabled = false;

            WriteOutput("Beginning download of data files from " + url, Color.Blue);
            WriteOutput("Files will be downloaded to " + directory, Color.Blue);

            await FileUtilities.DownloadFileAsync(new Uri(url), downloadPath, UpdateProgressBar);

            WriteOutput("Download complete..", Color.Blue);
            WriteOutput("Unzipping files..", Color.Blue);

            await Task.Run(() => FileUtilities.ExtractArchive(downloadPath,Path.GetDirectoryName(downloadPath), UpdateProgressBar));

            WriteOutput("Files unzipped successfuly.", Color.Blue);

            createGraphBTN.Enabled = true;
        }
        private void aboutToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var aboutBox = new AboutForm();
            aboutBox.Show();
        }
        private void exitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void createGraphBTN_Click(object sender, EventArgs e)
        {
            if (!Ready(true)) return;

            createGraphBTN.Enabled = false;
            
            var rScriptPath = _settingsDirectory + @"Rscript.r";
            var rScriptExePath = Environment.Is64BitOperatingSystem
                ? _settingsDirectory + @"R\R-3.3.1\bin\x64\RScript.exe"
                : _settingsDirectory + @"R\R-3.3.1\bin\i386\RScript.exe";

            var scriptSchema = new ScriptStartInfo(rScriptPath, rScriptExePath)
            {
                Args = "--verbose",
                OnDataReceived = data => {
                    var color = Color.Blue;
                    if (data != null && data.StartsWith("%")) {
                        color = getColor(data.Substring(1, 1));
                        data = data.Substring(2);
                    }
                    WriteOutput(data, color);
                },
                OnException = exception => { WriteOutput(exception.Message + exception.InnerException?.Message + rScriptPath + rScriptExePath, Color.Red); },
                OnExit = delegate {
                    Invoke((Action)(() => {
                        WriteOutput("Graph generation complete.", Color.Blue);
                        createGraphBTN.Enabled = true;
                    }));
                }
            };

            ScriptDaemon.ExecuteScript(this, scriptSchema, false);
        }

        private Color getColor(string substring) {
            switch (substring) {
                case "b":return Color.Blue;
                case "r":
                    return Color.Red;
                case "g":
                    return Color.Green;
            }
            return Color.Black;
        }

        private void launchNewAnalyzeItWindowToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var frm = new AnalyzeitForm
            {
                StartPosition = FormStartPosition.Manual,
                Width = Width,
                Height = Height,
                Location = new Point(Location.X + Width - 13, Location.Y)
            };
            frm.Show();
        }
        private void launchNewGraphItWindowToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var frm = new NewGraphitForm()
            {
                StartPosition = FormStartPosition.Manual,
                Width = Width,
                Height = Height,
                Location = new Point(Location.X + Width - 13, Location.Y)
            };
            frm.Show();
        }

        private void NewGraphitForm_Load(object sender, EventArgs e) {
            
        }
        private async void NewGraphitForm_Shown(object sender, EventArgs e) {
            if (!VerifyFolderStructure()) {
                if (Directory.Exists(_settingsDirectory + @"Python34\"))
                    Directory.Delete(_settingsDirectory + @"Python34\", true);
                if (Directory.Exists(_settingsDirectory + @"R\"))
                    Directory.Delete(_settingsDirectory + @"R\", true);
                await InitialSetupAsync();
            }
        }

        private bool VerifyFolderStructure()
        {
            var py34test = 6603;
            var rTest = 3699;

            var pyDir = _settingsDirectory + @"Python34\";
            var rDir = _settingsDirectory + @"R\";

            if (!Directory.Exists(rDir) || !Directory.Exists(pyDir)) return false;
            if (Directory.GetFiles(rDir, "*", SearchOption.AllDirectories).Length != rTest) return false;
            if (Directory.GetFiles(pyDir, "*", SearchOption.AllDirectories).Length != py34test) return false;

            WriteOutput("Ready to do some graphing!", Color.Blue);
            return true;
        }
        private async Task InitialSetupAsync()
        {
            //NEW WAY
            createGraphBTN.Enabled = false;
            WriteOutput("Performing initial setup...", Color.Blue);
            var outputPathR = _settingsDirectory +  @"R.zip";
            var outputPathPy = _settingsDirectory + @"Python34.zip";

            WriteOutput("Extracting necessary R files from embedded resources...", Color.Blue);
            await Task.Run(() => FileUtilities.WriteBytesToFile(Resources.R, outputPathR, UpdateProgressBar));

            WriteOutput("Extracting necessary Py files from embedded resources...", Color.Blue);
            await Task.Run(() => FileUtilities.WriteBytesToFile(Resources.Python34, outputPathPy, UpdateProgressBar));

            WriteOutput("Extraction complete... unzipping R files...", Color.Blue);
            await Task.Run(() => FileUtilities.ExtractArchive(outputPathR, _settingsDirectory, UpdateProgressBar));

            WriteOutput("Extraction complete... unzipping Py files...", Color.Blue);
            await Task.Run(() => FileUtilities.ExtractArchive(outputPathPy, _settingsDirectory, UpdateProgressBar));

            WriteOutput("Setup complete... Let's do some graphing!", Color.Blue);
            createGraphBTN.Enabled = true;
        }
    }

    public class Utilities {
        public static List<string> ColorOptions = new List<string> {
            "antiquewhite",
            "aquamarine",
            "azure",
            "bisque",
            "black",
            "blue",
            "blueviolet",
            "brown",
            "cadetblue",
            "chartreuse",
            "coral",
            "cyan",
            "darkblue",
            "darkgreen",
            "gold",
            "gray",
            "green",
            "khaki",
            "lightgreen",
            "magenta",
            "orange",
            "orchid",
            "purple",
            "sienna",
            "tan",
            "violet",
        };
    }
}
