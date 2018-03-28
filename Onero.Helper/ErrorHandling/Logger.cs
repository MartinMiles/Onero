using System;
using System.IO;
using System.Text;

namespace Onero.Helper.ErrorHandling
{
    public class Logger
    {
        private readonly string _logDirectory; 

        public Logger(string logDirectory)
        {
            _logDirectory = logDirectory;

            VerifyDirectoryExists(_logDirectory);
        }

        private string LogFilename => _logDirectory.TrimEnd('\\') + "\\" + GlobalSettings.LogFileName;

        // TODO: Ensure logs well in Release mode 
        public void Log(string message)
        {
            File.AppendAllText(LogFilename, message);
        }
        public void Log(Exception e)
        {
            StringBuilder logMessage = new StringBuilder();
            logMessage.AppendFormat("Exception occured: {0}{1}", e.Message, Environment.NewLine);
            logMessage.AppendFormat("Call stack: {0}{1}", e.StackTrace, Environment.NewLine);
            logMessage.AppendFormat("--------------------------------------{0}", Environment.NewLine);
            logMessage.AppendFormat(Environment.NewLine);

            File.AppendAllText(LogFilename, logMessage.ToString());
        }

        private void VerifyDirectoryExists(string logDirectory)
        {
            if (!Directory.Exists(logDirectory))
            {
                Directory.CreateDirectory(logDirectory);
            }
        }
    }
}
