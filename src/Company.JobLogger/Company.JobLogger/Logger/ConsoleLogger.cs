using Company.JobLogger.Logger.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Company.JobLogger.Logger
{
    public class ConsoleLogger : ILogger
    {
        public void Dispose()
        {
            GC.SuppressFinalize(this);
        }

        public void LogMessage(string message, LogMessageType logType)
        {
            if (string.IsNullOrEmpty(message))
            {
                return;
            }
            message = message.Trim();


            switch (logType)
            {
                case LogMessageType.Message:
                    Console.ForegroundColor = ConsoleColor.Red;
                    break;
                case LogMessageType.Warning:
                    Console.ForegroundColor = ConsoleColor.Yellow;
                    break;
                case LogMessageType.Error:
                    Console.ForegroundColor = ConsoleColor.White;
                    break;
                default:
                    throw new Exception("Invallid log Type Selected");                         
            }
            Console.WriteLine(DateTime.Now.ToShortDateString() + message);
        }
    }
}
