using System;
using System.Globalization;
using System.IO;
using System.Net;
using System.Threading.Tasks;
using System.Windows.Forms;
using Ionic.Zip;
using RockSatGraphIt.Properties;

namespace RockSatGraphIt {
    public class FileUtilities {
        public static async Task DownloadFileAsynch(Form owner, Uri sourceUri, string path, Action<int> onProgressUpdate, Action<string> onCompleted) {
           
            var client = new WebClient();

            client.DownloadProgressChanged += (o, e) => {
                owner.BeginInvoke((MethodInvoker)delegate {
                    var bytesIn = double.Parse(e.BytesReceived.ToString());
                    var totalBytes = double.Parse(e.TotalBytesToReceive.ToString());
                    var percentage = bytesIn / totalBytes * 100;
                    onProgressUpdate(int.Parse(Math.Truncate(percentage).ToString(CultureInfo.CurrentCulture)));

                });
            };

            client.DownloadFileCompleted += (o, e) => {
                onCompleted.Invoke(path);
            };

            var dir = Path.GetDirectoryName(path);
            // ReSharper disable once AssignNullToNotNullAttribute
            if (!Directory.Exists(dir)) Directory.CreateDirectory(dir);

            client.DownloadFileAsync(sourceUri, path);
        }

        public static async Task ExtractFileAsync(Form owner, string zipToUnpack, string unpackDirectory, bool deleteWhenFinished,
            Action<int> onProgressChanged, Action onCompleted) {
            using (var zip = ZipFile.Read(zipToUnpack)) {
                var step = 100.0/zip.Count;
                double percentComplete = 0;
                onProgressChanged(0);
                foreach (var file in zip) {
                    file.Extract(unpackDirectory, ExtractExistingFileAction.OverwriteSilently);
                    percentComplete += step;
                    onProgressChanged((int) Math.Round(percentComplete));
                }
                //if(deleteWhenFinished) File.Delete(zipToUnpack);
                onProgressChanged(100);
                onCompleted.Invoke();
            }
        }

        public static async Task WriteFileAsync(Form owner, byte[] byteArray, string filePath,
            Action<int> onProgressChanged, Action onCompleted) {
            using (var stream = new FileStream(filePath, FileMode.Create))
            using (var writer = new BinaryWriter(stream)) {
                var bytesLeft = byteArray.Length; // assuming array is an array of bytes
                var bytesWritten = 0;
                while (bytesLeft > 0) {
                    var percentageComplete = bytesLeft == 0 ? 100.0 : (double) bytesWritten/byteArray.Length*100.0;

                    onProgressChanged((int) percentageComplete);

                    var chunkSize = Math.Min(262144, bytesLeft);
                    writer.Write(byteArray, bytesWritten, chunkSize);
                    bytesWritten += chunkSize;
                    bytesLeft -= chunkSize;
                }
                onProgressChanged(100);
                onCompleted.Invoke();
            }
        }

        public static bool Safe_FileWrite(string solutionFilePath, FileMode fileMode, string contents) {
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
}