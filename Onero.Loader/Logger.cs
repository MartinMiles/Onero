using System;
using System.IO;
using System.Text;

namespace Onero.Loader
{
    public class Logger
    {
        public static void Log(string message)
        {
            File.AppendAllText("_log.txt", message);
        }
        public static void Log(Exception e)
        {
            StringBuilder logMessage = new StringBuilder();
            logMessage.AppendFormat("Exception occured: {0}{1}", e.Message, Environment.NewLine);
            logMessage.AppendFormat("Call stack: {0}{1}", e.StackTrace, Environment.NewLine);
            logMessage.AppendFormat(string.Format("--------------------------------------{0}", Environment.NewLine));
            logMessage.AppendFormat(Environment.NewLine);

            File.AppendAllText("_log.txt", logMessage.ToString());
        }
    }
}
