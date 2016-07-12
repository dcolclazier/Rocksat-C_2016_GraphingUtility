using System;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using RockSatGraphIt.Properties;
using RockSatGraphIt.Utilities;
using static System.Math;
namespace RockSatGraphIt.Forms {
    public class DemosatAnalysis {
        private readonly string _imgDirectory;
        private readonly string _chosenTest;
        private readonly string _imgExtension;
        private string _scriptDir;

        private readonly string _stepOnePath = Directory.GetCurrentDirectory() + @"\DemosatStep1.py";
        private readonly string _pyExePath = Directory.GetCurrentDirectory() + @"\Python34\Python.exe";

        private string _outputFilenameStep1 = @"Step1results.txt";
        public DemosatAnalysis(string imgDirectory, string chosenTest, string imgExtension) {
            _imgDirectory = imgDirectory;
            _chosenTest = chosenTest;
            _imgExtension = imgExtension;

        }

        public bool Prepare()
        {
            if (_imgDirectory == string.Empty || _chosenTest == string.Empty || _imgExtension == string.Empty) {
                MessageBox.Show(Resources.EmptyFieldError, Resources.ErrorTitle, MessageBoxButtons.OK);
                return false;
            }

            var directoryName = "DemoSatFiles";
            var attempt = 0;
            var pathEnding = @"\";
            var prePath = directoryName + attempt;
            while (Directory.Exists(prePath)) {
                attempt++;
                prePath = directoryName + attempt;
            }

            Directory.CreateDirectory(prePath);
            _scriptDir = prePath + pathEnding;

            if (ScriptDaemon.FixScript(Resources.DemoSatStep1, "DemosatStep1.py", FixDemosatAnalysisScript)) return true;

            MessageBox.Show(Resources.DemoSatStep1FixError, Resources.ErrorTitle, MessageBoxButtons.OK);
            return false;
        }

        private string FixDemosatAnalysisScript(string template)
        {

            var fixedContents = template;
            fixedContents = fixedContents.Replace("__imageDirectory__", _imgDirectory.Replace(@"\", "/"));
            fixedContents = fixedContents.Replace("__outputDirectory__", (Directory.GetCurrentDirectory() + @"\" + _scriptDir).Replace(@"\", "/"));
            fixedContents = fixedContents.Replace("__outputFilename__", _outputFilenameStep1);
            fixedContents = fixedContents.Replace("__imageExtension__", "." + _imgExtension);
            fixedContents = fixedContents.Replace("__totalFileCount__", Directory.GetFiles(_imgDirectory.Replace(@"\", "/"), "*.JPG", SearchOption.AllDirectories).Length.ToString());
            return fixedContents;
        }
        public async Task Run(AnalyzeitForm owningForm)
        {

            var stepOne = new ScriptStartInfo(_stepOnePath, _pyExePath, onDataReceived: owningForm.OnScriptDataReceived);
            await Task.Run(() => ScriptDaemon.ExecuteScript(owningForm, stepOne, true));

            var test = csv_calculateStandardDeviationfromColum(_scriptDir + _outputFilenameStep1, 1, true);
            var testMean = csv_calculateMeanfromColumn(_scriptDir + _outputFilenameStep1, 1, true);

            var test2 = csv_calculateStandardDeviationfromColum(_scriptDir + _outputFilenameStep1, 2, true);
            var test2Mean = csv_calculateMeanfromColumn(_scriptDir + _outputFilenameStep1, 2, true);

            owningForm.WriteLine("Standard dev - Max Pixels : " + test, Color.Blue);
            owningForm.WriteLine("Mean - Max Pixels : " + testMean, Color.Blue);
            owningForm.WriteLine("Standard dev - otsu threshold: " + test2, Color.Blue);
            owningForm.WriteLine("Mean - otsu threshold: " + test2Mean, Color.Blue);

        }

        private double csv_calculateStandardDeviationfromColum(string csvPath, int column, bool header)
        {

            var mean = csv_calculateMeanfromColumn(csvPath, column, header);
            double standardDev = 0;
            double topHalf = 0;
            try {
                var lines = File.ReadLines(csvPath).ToList();
                if (header) lines.RemoveAt(0);
                topHalf += lines.Select(line => line.Split(',')).Select(columns => Pow(Abs(double.Parse(columns[column]) - mean), 2)).Sum();
                standardDev = Sqrt(topHalf / lines.Count);
            }
            catch (Exception e) {
                MessageBox.Show("Something went wrong " + e.Message + e.InnerException?.Message, "Ugh", MessageBoxButtons.OK);
            }
            return standardDev;
        }
        private static double csv_calculateMeanfromColumn(string csvPath, int column, bool header)
        {
            double sum = 0;
            var lines = File.ReadLines(csvPath).ToList();
            try
            {

                if (header) lines.RemoveAt(0);
                foreach (var line in lines)
                {
                    var columns = line.Split(',');
                    sum += double.Parse(columns[column]);
                }

            }
            catch (Exception e)
            {
                MessageBox.Show(e.Message + e.InnerException?.Message, "column length!", MessageBoxButtons.OK);
            }
            return sum / lines.Count;
        }
    }
}