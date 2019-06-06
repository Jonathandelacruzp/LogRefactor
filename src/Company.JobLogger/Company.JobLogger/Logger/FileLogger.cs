using Company.JobLogger.Logger.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Company.JobLogger.Logger
{
    public class FileLogger : ILogger
    {
        private string _fileDirectory { get; set; } = System.Configuration.ConfigurationManager.AppSettings["LogFileDirectory"];
        
        public void Dispose()
        {
            this._fileDirectory = null;
            GC.SuppressFinalize(this);
        }

        public void LogMessage(string message, LogMessageType logType)
        {
            if (string.IsNullOrEmpty(message))
            {
                return;
            }
            message = message.Trim();

            var logTxtFile = this._fileDirectory + "LogFile" + DateTime.Now.ToString("yyyy-MM-dd")+ ".txt";
            if (!System.IO.Directory.Exists(_fileDirectory))
            {
                System.IO.Directory.CreateDirectory(_fileDirectory);
            }

            var logText = string.Empty;
            if (System.IO.File.Exists(logTxtFile))
            {
                logText = System.IO.File.ReadAllText(logTxtFile);
            }

            var strBuilderLogTextContent = new StringBuilder(logText);
            strBuilderLogTextContent.Append(DateTime.Now.ToShortDateString()).Append(" ");
            strBuilderLogTextContent.Append(message);
            strBuilderLogTextContent.AppendLine();

            System.IO.File.WriteAllText(logTxtFile, strBuilderLogTextContent.ToString());
        }
    }
}
