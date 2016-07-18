using System;
using System.Diagnostics;
using System.IO;
using System.Threading;
using System.Windows.Forms;

namespace RockSatGraphIt.Utilities {
    public class ScriptStartInfo
    {
        public string ScriptPath { get; }
        public string ExePath { get; }
        public string Args { get; set; }

        public Action<string> OnDataReceived;
        public Action OnExit;
        public Action<Exception> OnException;
        public ScriptStartInfo(string scriptPath, string exePath, string args = "", Action<string> onDataReceived = null, Action onExit = null, Action<Exception> onException = null)
        {
            Args = args;
            ScriptPath = scriptPath;
            ExePath = exePath;

            OnDataReceived = onDataReceived;
            OnExit = onExit;
            OnException = onException;
        }
    }
    public static class ScriptDaemon
    {
        public static bool FixScript(string inputTemplate, string outputFilename, Func<string, string> scriptFixer)
        {
            var scriptContents = scriptFixer(inputTemplate);
            return FileUtilities.WriteStringToFile(outputFilename, scriptContents);
        }
        
        public static void ExecuteScript(Form owner, ScriptStartInfo script, bool waitTillFinished) {
            var mre = new ManualResetEvent(false);
            
            //Create our process start info
            var editedPath = "\"" + script.ScriptPath + "\" " + script.Args;

            var processStartInfo = new ProcessStartInfo
            {
                FileName = script.ExePath,
                // ReSharper disable once AssignNullToNotNullAttribute
                WorkingDirectory = Path.GetDirectoryName(script.ExePath),
                Arguments = editedPath,
                RedirectStandardInput = false,
                RedirectStandardOutput = script.OnDataReceived != null,
                RedirectStandardError = true,
                ErrorDialog = false,
                UseShellExecute = false,
                CreateNoWindow = true
            };

            //Create our process, register process events
            var proc = new Process
            {
                EnableRaisingEvents = true,
                StartInfo = processStartInfo
            };

            //proc.Exited += (o, e) => { script.OnExit?.Invoke(); };
            proc.Exited += delegate {
                script.OnExit?.Invoke();
                if (waitTillFinished) mre.Set();
            };
            proc.OutputDataReceived += (o, e) => {
                
                script?.OnDataReceived?.Invoke(e.Data);

            };

            //Configure Exit early bugfix
            owner.Closed += delegate {
                if (!proc.HasExited) {
                    proc.Kill();
                    proc.Close();
                }
                script = null;
            };


            //Start the process.
            try
            {
                proc.Start();
            }
            catch (Exception ex)
            {
                script.OnException?.Invoke(ex);
            }

            proc.BeginOutputReadLine();
            if (waitTillFinished) mre.WaitOne();
        }
       
    }
}