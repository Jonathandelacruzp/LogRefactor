using Company.JobLogger.Logger.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Company.JobLogger.Logger
{

    public enum LogType
    {
        Console,
        Database,
        File
    }


    public static class LoggerHub
    {
        public static void Log(string message, LogMessageType logMessageType, LogType logType = LogType.Console)
        {

            if (string.IsNullOrEmpty(message) || string.IsNullOrWhiteSpace(message))
            {
                return;
            }
            message = message.Trim();

            ILogger logger;
            switch (logType)
            {
                case LogType.Database:
                    logger = new DataBaseLogger();
                    break;
                case LogType.File:
                    logger = new FileLogger();
                    break;
                default:
                    logger = new ConsoleLogger();
                    break;
            }
            logger.LogMessage(message, logMessageType);
            logger.Dispose();
        }
    }
}
