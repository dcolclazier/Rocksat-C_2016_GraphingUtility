using System;
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;
using System.Threading.Tasks;
using System.Windows.Forms;
using RockSatGraphIt.Properties;
using RockSatGraphIt.Utilities;

namespace RockSatGraphIt.Forms {
    class Otsu
    {
        // function is used to compute the q values in the equation
        private static float Px(int init, int end, int[] hist)
        {
            var sum = 0;
            int i;
            for (i = init; i <= end; i++)
                sum += hist[i];

            return sum;
        }

        // function is used to compute the mean values in the equation (mu)
        private float Mx(int init, int end, int[] hist)
        {
            int sum = 0;
            int i;
            for (i = init; i <= end; i++)
                sum += i * hist[i];

            return sum;
        }

        // finds the maximum element in a vector
        private int findMax(float[] vec, int n)
        {
            float maxVec = 0;
            int idx = 0;
            int i;

            for (i = 1; i < n - 1; i++)
            {
                if (vec[i] > maxVec)
                {
                    maxVec = vec[i];
                    idx = i;
                }
            }
            return idx;
        }

        // simply computes the image histogram
        private unsafe void getHistogram(byte* p, int w, int h, int ws, int[] hist)
        {
            hist.Initialize();
            for (int i = 0; i < h; i++)
            {
                for (int j = 0; j < w * 3; j += 3)
                {
                    int index = i * ws + j;
                    hist[p[index]]++;
                }
            }
        }

        // find otsu threshold
        public int GetOtsuThreshold(Bitmap bmp)
        {
            float[] vet = new float[256];
            int[] hist = new int[256];
            vet.Initialize();

            BitmapData bmData = bmp.LockBits(new Rectangle(0, 0, bmp.Width, bmp.Height),
            ImageLockMode.ReadOnly, PixelFormat.Format24bppRgb);
            unsafe
            {
                byte* p = (byte*)bmData.Scan0.ToPointer();

                getHistogram(p, bmp.Width, bmp.Height, bmData.Stride, hist);

                // loop through all possible t values and maximize between class variance
                int k;
                for (k = 1; k != 255; k++)
                {
                    var p1 = Px(0, k, hist);
                    var p2 = Px(k + 1, 255, hist);
                    var p12 = p1 * p2;
                    if (Math.Abs(p12) < .01)
                        p12 = 1;
                    float diff = (Mx(0, k, hist) * p2) - (Mx(k + 1, 255, hist) * p1);
                    vet[k] = diff * diff / p12;
                    //vet[k] = (float)Math.Pow((Mx(0, k, hist) * p2) - (Mx(k + 1, 255, hist) * p1), 2) / p12;
                }
            }
            bmp.UnlockBits(bmData);

            var t = (byte)findMax(vet, 256);

            return t;
        }

        // simple routine to convert to gray scale
        public void Convert2GrayScaleFast(Bitmap bmp)
        {
            BitmapData bmData = bmp.LockBits(new Rectangle(0, 0, bmp.Width, bmp.Height),
                    ImageLockMode.ReadWrite, PixelFormat.Format24bppRgb);
            unsafe
            {
                byte* p = (byte*)bmData.Scan0.ToPointer();
                int stopAddress = (int)p + bmData.Stride * bmData.Height;
                while ((int)p != stopAddress)
                {
                    p[0] = (byte)(.299 * p[2] + .587 * p[1] + .114 * p[0]);
                    p[1] = p[0];
                    p[2] = p[0];
                    p += 3;
                }
            }
            bmp.UnlockBits(bmData);
        }

        // simple routine for thresholdin
        public void Threshold(Bitmap bmp, int thresh)
        {
            BitmapData bmData = bmp.LockBits(new Rectangle(0, 0, bmp.Width, bmp.Height),
            ImageLockMode.ReadOnly, PixelFormat.Format24bppRgb);
            unsafe
            {
                byte* p = (byte*)bmData.Scan0.ToPointer();
                int h = bmp.Height;
                int w = bmp.Width;
                int ws = bmData.Stride;

                for (int i = 0; i < h; i++)
                {
                    byte* row = &p[i * ws];
                    for (int j = 0; j < w * 3; j += 3)
                    {
                        row[j] = (byte)((row[j] > (byte)thresh) ? 255 : 0);
                        row[j + 1] = (byte)((row[j + 1] > (byte)thresh) ? 255 : 0);
                        row[j + 2] = (byte)((row[j + 2] > (byte)thresh) ? 255 : 0);
                    }
                }
            }
            bmp.UnlockBits(bmData);
        }
    }
    public class PixelIntensity {

        private string _inputPath;
        private string _outputPath;
        private readonly string _chosenTest;
        private readonly string _imgFlag;
        private readonly double _imgThreshold;
        private string _logPath;
        private readonly Otsu _otsu = new Otsu();


        public PixelIntensity(string inputPath, string outputPath, string chosenTest, string imgFlag) {
            _inputPath = inputPath;
            _outputPath = outputPath;
            _chosenTest = chosenTest;
            _imgFlag = "*." + imgFlag;
            _imgThreshold = 6.5;
        }

        public async Task Run(AnalyzeitForm owningForm) {
            await Task.Run(() => {
                if (_outputPath.GetLast(1) != @"\") _outputPath += @"\";
                if (_inputPath.GetLast(1) != @"\") _inputPath += @"\";
                _logPath = _outputPath + "pixelIntensity.csv";

                owningForm.WriteLine("Beginning Pixel Intensity test...", Color.Blue);
                owningForm.WriteLine($"     Threshold intensity: {_imgThreshold}...", Color.Blue);
                owningForm.WriteLine($"     Original images: {_inputPath}...", Color.Blue);
                owningForm.WriteLine($"     Modified images: {_outputPath}...", Color.Blue);
                owningForm.WriteLine($"     Data Path: {_logPath}...", Color.Blue);

                //create necessary directories and object initialization
                Directory.CreateDirectory(_outputPath);

                //Add headers to our data file.
                using (var file = new StreamWriter(_logPath, false))
                {
                    file.WriteLine("Image, Otsu I, Thr I, Avg. I > Thr, Max I, > Otsu I, > Thr I, > 10% I, > 20% I, > 30% I, > 40% I, >50% I, >60% I");
                }

                owningForm.WriteLine(" Test prep complete. Starting...", Color.Blue);
            });

            //stuff for progress bar
            double totalProgress = 0;
            double progressStep = 100.0 / Directory.GetFiles(_inputPath, _imgFlag, SearchOption.AllDirectories).Length;
            int lastPercentComplete = -1;
            int percentComplete;

            //Create a parallel task - 8 maximum threads, goes through all images and analyzes the grayscale intensity of each pixel,
            //  Also applies a manual threshold of OurThreshold to each image - any pixel above threshold gets flipped to RGB(255,255,255)
            await Task.Run(() => Parallel.ForEach(Directory.GetFiles(_inputPath, _imgFlag, SearchOption.AllDirectories),
                new ParallelOptions { MaxDegreeOfParallelism = 8 }, inputImage => {
                    try
                    {
                        using (var inputBitmap = new Bitmap(inputImage))
                        {
                            Console.WriteLine($"Processing  {Path.GetFileName(inputImage)}...");
                            var currentOtsuIntensity =
                                double.Parse(GetGrayScaleIntensity(_otsu.GetOtsuThreshold(inputBitmap)).ToString("F2"));

                            var pixelsOverOtsu = 0;
                            var pixelsOverThreshold = 0;
                            var pixelsOver10Percent = 0;
                            var pixelsOver20Percent = 0;
                            var pixelsOver30Percent = 0;
                            var pixelsOver40Percent = 0;
                            var pixelsOver50Percent = 0;
                            var pixelsOver60Percent = 0;
                            double mostIntensePixelIntensity = 0;

                            using (var outputBitmap = new Bitmap(inputImage))
                            {

                                var inData = inputBitmap.LockBits(new Rectangle(0, 0, inputBitmap.Width, inputBitmap.Height),
                                    ImageLockMode.ReadOnly, inputBitmap.PixelFormat);

                                var outData = outputBitmap.LockBits(new Rectangle(0, 0, inputBitmap.Width, inputBitmap.Height),
                                    ImageLockMode.WriteOnly, inputBitmap.PixelFormat);

                                var bitsPerPixel = Image.GetPixelFormatSize(inputBitmap.PixelFormat);

                                var overThresholdCount = 0;
                                double overThresholdSum = 0;

                                unsafe
                                {
                                    var inScan0 = (byte*)inData.Scan0.ToPointer();
                                    var outScan0 = (byte*)outData.Scan0.ToPointer();

                                    for (var y = 0; y < inData.Height; ++y)
                                    {
                                        for (var x = 0; x < inData.Width; ++x)
                                        {
                                            var incoming = inScan0 + y * inData.Stride + x * bitsPerPixel / 8;
                                            var outgoing = outScan0 + y * inData.Stride + x * bitsPerPixel / 8;

                                            var currentPixelIntensity = GetGrayScaleIntensity(incoming[0], incoming[1], incoming[2]);

                                            if (currentPixelIntensity > mostIntensePixelIntensity)
                                                mostIntensePixelIntensity = double.Parse(currentPixelIntensity.ToString("F2"));

                                            if (currentPixelIntensity > 60) pixelsOver60Percent++;
                                            else if (currentPixelIntensity > 50) pixelsOver50Percent++;
                                            else if (currentPixelIntensity > 40) pixelsOver40Percent++;
                                            else if (currentPixelIntensity > 30) pixelsOver30Percent++;
                                            else if (currentPixelIntensity > 20) pixelsOver20Percent++;
                                            else if (currentPixelIntensity > 10) pixelsOver10Percent++;
                                            else if (currentPixelIntensity > _imgThreshold) pixelsOverThreshold++;
                                            else if (currentPixelIntensity > currentOtsuIntensity) pixelsOverOtsu++;

                                            outgoing[0] = currentPixelIntensity > _imgThreshold ? (byte)255 : incoming[0];
                                            outgoing[1] = currentPixelIntensity > _imgThreshold ? (byte)255 : incoming[1];
                                            outgoing[2] = currentPixelIntensity > _imgThreshold ? (byte)255 : incoming[2];

                                            if (!(currentPixelIntensity > _imgThreshold)) continue;

                                            overThresholdSum += currentPixelIntensity;
                                            overThresholdCount++;
                                        }
                                    }
                                }

                                inputBitmap.UnlockBits(inData);
                                outputBitmap.UnlockBits(outData);

                                var averageIntensityOverThreshold =
                                    double.Parse((overThresholdSum / overThresholdCount).ToString("F2"));

                                //Save the output image
                                var outputFile = _outputPath + Path.GetFileName(inputImage);
                                outputBitmap.Save(outputFile);

                                //Add data for current image to log
                                lock (Locker)
                                {
                                    using (var file = new StreamWriter(_logPath, true))
                                    {
                                        file.WriteLine(
                                            $"{Path.GetFileName(inputImage)}, {currentOtsuIntensity},{_imgThreshold},{averageIntensityOverThreshold}, " +
                                            $"{mostIntensePixelIntensity},{pixelsOverOtsu}, {pixelsOverThreshold}, {pixelsOver10Percent}, {pixelsOver20Percent}, " +
                                            $"{pixelsOver30Percent}, {pixelsOver40Percent}, {pixelsOver50Percent}, {pixelsOver60Percent}");
                                    }
                                    totalProgress += progressStep;
                                    percentComplete = (int)Math.Floor(totalProgress);
                                    if (lastPercentComplete != percentComplete) {
                                        owningForm.OnProgressUpdate(percentComplete);
                                    }
                                    lastPercentComplete = percentComplete;

                                }
                            }
                        }
                    }
                    catch (Exception e) {
                        owningForm.WriteLine($"Error.. File: {inputImage}. More info: {e.Message}... {e.InnerException?.Message}.", Color.Red);
                    }
                }));

            FileUtilities.IntegralCsvSort(_logPath, 0, true);
            owningForm.WriteLine("Pixel Intensity analysis complete.", Color.Blue);

        }

        private static double GetGrayScaleIntensity(byte red, byte green, byte blue) => GetGrayScaleIntensity(red + green + blue);
        private static double GetGrayScaleIntensity(double otsuThresholdValue) => (otsuThresholdValue / 3.0 / 255 * 100);

        private static readonly object Locker = new object();

        public bool Prepare() {

            if (_inputPath == string.Empty || _outputPath == string.Empty ||
                _chosenTest == string.Empty || _imgFlag == string.Empty)
            {
                MessageBox.Show(Resources.EmptyFieldError, Resources.ErrorTitle, MessageBoxButtons.OK);
                return false;
            }

            var directoryName = "IntensityFiles";
            var attempt = 0;
            var prePath = directoryName + attempt;
            while (Directory.Exists(prePath))
            {
                attempt++;
                prePath = directoryName + attempt;
            }
            Directory.CreateDirectory(prePath);

            return true;
        }
    }
}