using System;
using System.Diagnostics;
using System.IO;

namespace RockSatGraphIt {
    public static class ScriptDaemon
    {
        public static bool GenerateScript(string inputTemplate, string outputFilename, Func<string, string> scriptFixer)
        {

            var scriptContents = scriptFixer(inputTemplate);
            return FileUtilities.Safe_FileWrite(outputFilename, FileMode.Create, scriptContents);
        }

        public static void ExecuteScript(string scriptPath, string executablePath, string args, Action onComplete, Action<string> onDataReceived, Action<Exception> onException)
        {
            //Create our process start info
            var editedPath = "\"" + scriptPath + "\" " + args;

            var processStartInfo = new ProcessStartInfo
            {
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
            var proc = new Process
            {
                EnableRaisingEvents = true,
                StartInfo = processStartInfo
            };

            proc.Exited += (o, e) => { onComplete.Invoke(); };
            proc.OutputDataReceived += (o, e) => { onDataReceived.Invoke(e.Data); };


            //Start the process.
            try
            {
                proc.Start();
            }
            catch (Exception ex)
            {
                onException.Invoke(ex);
            }

            proc.BeginOutputReadLine();
        }
    }
}