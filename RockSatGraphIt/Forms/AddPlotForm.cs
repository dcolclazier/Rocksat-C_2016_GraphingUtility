using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Windows.Forms;
using RockSatGraphIt.Properties;

namespace RockSatGraphIt.Forms
{
 

    public partial class AddPlotForm : Form {
        private readonly NewGraphitForm _baseForm;
        private PlotInfo _plotInfo;

        //public new static int Width { get; private set; }

        public AddPlotForm(NewGraphitForm baseForm) {
            InitializeComponent();

            _baseForm = baseForm;
            Width = Size.Width;

            colorCMB.DataSource = Utilities.ColorOptions;
            colorCMB.Text = @"black";
        }

        private void addPlotBTN_Click(object sender, System.EventArgs e) {
            if (!Ready()) return;

            _plotInfo = new PlotInfo()
            {
                InputFilePath = filenameTXT.Text,
                PlotColor = colorCMB.Text,
                GraphType = graphTypeCMB.Text,
                DomainMin = int.Parse(domainMinTXT.Text),
                DomainMax = int.Parse(domainMaxTXT.Text),
                DomainHashPeriod = int.Parse(domainHashPeriodTXT.Text),
                RangeHashPeriod = int.Parse(rangeHashPeriodTXT.Text),
                RangeMin = int.Parse(rangeMinTXT.Text),
                RangeMax = int.Parse(rangeMaxTXT.Text),
                DomainDataColumnName = xDatasetCMB.Text,
                RangeDataColumnName = yDatasetCMB.Text,
                Metadata = $"Type:{graphTypeCMB.Text}-Color:{colorCMB.Text} Domain:\"{xDatasetCMB.Text}\" ({domainMinTXT.Text}->{domainMaxTXT.Text}) Period:{domainHashPeriodTXT.Text} ,Range: \"{yDatasetCMB.Text}\"({rangeMinTXT.Text}->{rangeMaxTXT.Text}) Period:{rangeHashPeriodTXT.Text}\n",
        };
            _baseForm.OnPlotCompleted(_plotInfo);
        }

        private bool Ready() {

            var ready = true;
            if (colorCMB.Text == string.Empty) colorCMB.Text = "black";
            if (graphTypeCMB.Text == string.Empty || xDatasetCMB.Text == string.Empty ||
                yDatasetCMB.Text == string.Empty) {
                MessageBox.Show("No empty fields!", "Alert", MessageBoxButtons.OK);
                ready = false;
            }
            if (domainHashPeriodTXT.Text == string.Empty || rangeHashPeriodTXT.Text == string.Empty) {
                MessageBox.Show("Make sure you define the hash period for the domain and range...", "Alert",
                    MessageBoxButtons.OK);
                ready = false;
            }
            if (domainMinTXT.Text == string.Empty || domainMaxTXT.Text == string.Empty ||
                rangeMinTXT.Text == string.Empty || rangeMaxTXT.Text == string.Empty) {
                MessageBox.Show("Make sure you define the domain and range for your dataset...", "Alert",
                    MessageBoxButtons.OK);
                ready = false;
            }
            int value;
            if (!int.TryParse(domainMinTXT.Text, out value) ||
                !int.TryParse(domainMaxTXT.Text, out value) ||
                !int.TryParse(domainHashPeriodTXT.Text, out value) ||
                !int.TryParse(rangeMinTXT.Text, out value) ||
                !int.TryParse(rangeMaxTXT.Text, out value) ||
                !int.TryParse(rangeHashPeriodTXT.Text, out value)) {
                MessageBox.Show(Resources.DomainRangeError, Resources.ErrorTitle,
                    MessageBoxButtons.OK);
                ready = false;
            }
            
            return ready;
        }

        private void loadDataFileBTN_Click(object sender, System.EventArgs e)
        {
            var fbd = new OpenFileDialog();
            if (fbd.ShowDialog() == DialogResult.OK) {
                filenameTXT.Text = fbd.FileName;
            }
            try {
                var header = File.ReadLines(fbd.FileName).First();
                var columns = header.Split(',').ToList();
                BindColumns(xDatasetCMB, new List<string>(columns));
                BindColumns(yDatasetCMB, new List<string>(columns));
            }
            catch (Exception ex) {
                MessageBox.Show($"Error loading csv: {ex}.");
            }
        }

        private void BindColumns(ComboBox box, List<string> entries) {
            box.DataSource = entries;
        }
    }

    public class PlotInfo
    {
        public string InputFilePath { get; set; }
        public string GraphType { get; set; }
        public int DomainMin { get; set; }
        public int DomainMax { get; set; }
        public string DomainDataColumnName { get; set; }
        public string RangeDataColumnName { get; set; }
        public int RangeMin { get; set; }
        public int RangeMax { get; set; }
        public int DomainHashPeriod { get; set; }
        public int RangeHashPeriod { get; set; }
        public string PlotColor { get; set; }
        public string Metadata { get; set; }
    }
}
