using System;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;
using Ionic.Zip;
using RockSatGraphIt.Properties;

namespace RockSatGraphIt.Utilities {
    public class FileUtilities {
        public static void IntegralCsvSort(string csvPath, int columnToSortBy, bool header)
        {
            var lines = File.ReadAllLines(csvPath);
            var data = header ? lines.Skip(1) : lines;
            var sorted = data.Select(line => new {
                SortKey = Regex.Match(line.Split(',')[columnToSortBy], @"\d+").Value,
                Line = line
            })
                .OrderBy(x => x.SortKey)
                .Select(x => x.Line);
            File.WriteAllLines(csvPath, header ? lines.Take(1).Concat(sorted) : lines.Take(0).Concat(sorted));
        }
        public static async Task DownloadFileAsync(Uri sourceUri, string destinationPath, Action<int> onProgressUpdate = null) {
           
            //var mre = new ManualResetEvent(false);

            var client = new WebClient();

            client.DownloadProgressChanged += (o, e) => {
                var bytesIn = double.Parse(e.BytesReceived.ToString());
                var totalBytes = double.Parse(e.TotalBytesToReceive.ToString());
                var percentage = bytesIn / totalBytes * 100;
                onProgressUpdate?.Invoke(int.Parse(Math.Truncate(percentage).ToString(CultureInfo.CurrentCulture)));
               
            };
            //client.DownloadFileCompleted += (o1, e1) => {
            //    mre.Set();
            //};
            var possible = Path.GetDirectoryName(destinationPath);
            if (possible == null) {
                MessageBox.Show(Resources.NullDownloadDest);
                return;
            }
            var dir = possible;
            if (!Directory.Exists(dir))
                Directory.CreateDirectory(dir);

            await client.DownloadFileTaskAsync(sourceUri, destinationPath);
            //mre.WaitOne();

        }
        
        public static void ExtractArchive(string zipToUnpack, string unpackDirectory, Action<int> onProgressChanged = null) {
            
            try {
                using (var zip = ZipFile.Read(zipToUnpack)) {
                    var step = 100.0/zip.Count;
                    double percentComplete = 0;
                    onProgressChanged?.Invoke(0);
                    foreach (var file in zip) {
                        file.Extract(unpackDirectory, ExtractExistingFileAction.OverwriteSilently);
                        percentComplete += step;
                        onProgressChanged((int) Math.Round(percentComplete));
                    }
                    onProgressChanged?.Invoke(100);
                }
            }
            catch (Exception e) {
                MessageBox.Show(Resources.ArchiveExtractError + e.Message + e.InnerException?.Message, Resources.AlertTitle, MessageBoxButtons.OK);
            }
        }
        public static int WriteBytesToFile(byte[] byteArray, string destinationPath, Action<int> onProgressChanged = null) {

            FileStream fs = null;
            try {
                fs = new FileStream(destinationPath, FileMode.Create);
                using (var bw = new BinaryWriter(fs)) {
                    fs = null;
                    var bytesLeft = byteArray.Length; // assuming array is an array of bytes
                    var bytesWritten = 0;
                    while (bytesLeft > 0) {
                        var percentageComplete = bytesLeft == 0 ? 100.0 : (double) bytesWritten/byteArray.Length*100.0;

                        onProgressChanged?.Invoke((int) percentageComplete);

                        var chunkSize = Math.Min(262144, bytesLeft);
                        bw.Write(byteArray, bytesWritten, chunkSize);
                        bytesWritten += chunkSize;
                        bytesLeft -= chunkSize;
                    }
                    onProgressChanged?.Invoke(100);
                }
            }
            catch (Exception e) {
                MessageBox.Show(e.Message + e.InnerException?.Message, Resources.AlertTitle, MessageBoxButtons.OK);
            }
            finally {
                fs?.Dispose();
            }
            return 1;
        }
        public static bool WriteStringToFile(string solutionFilePath, string contents) {

            FileStream fs = null;
            try {
                fs = new FileStream(solutionFilePath, FileMode.Create, FileAccess.ReadWrite, FileShare.ReadWrite);
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
        public static bool InsertLineInFile
            (string filePath, FileMode fileMode, string contents, string lineToFollow) {

            var sb = new StringBuilder();
            using (var sr = new StreamReader(filePath)) {
                string line;
                do {
                    line = sr.ReadLine();
                    sb.AppendLine(line);

                } while (line != null && !line.Contains(lineToFollow));
                sb.Append(contents);
                sb.Append(sr.ReadToEnd());
            }
            
            FileStream fs = null;
            try {
                fs = new FileStream(filePath, fileMode, 
                    FileAccess.ReadWrite, FileShare.ReadWrite);
                using (TextWriter tw = new StreamWriter(fs)) {
                    fs = null;
                    tw.Write(sb.ToString());
                    tw.Close();
                }
            }
            catch (Exception e) {
                MessageBox.Show(e.Message + e.InnerException?.Message, 
                    Resources.AlertTitle, MessageBoxButtons.OK);
                return false;
            }
            finally {
                fs?.Dispose();
            }
            return true;
        }
    }
}