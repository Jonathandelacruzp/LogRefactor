using Company.JobLogger.Logger.Core;
using Company.JobLogger.Logger;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Company.JobLogger
{
    class Program
    {
        static void Main(string[] args)
        {

            using (ILogger logger = new ConsoleLogger())
            {
                logger.LogMessage("Test console", LogMessageType.Error);
                logger.LogMessage("Test console", LogMessageType.Message);
                logger.LogMessage("Test console", LogMessageType.Warning);
            }

            using (ILogger logger = new FileLogger())
            {
                logger.LogMessage("Test", LogMessageType.Error);
                logger.LogMessage("Test", LogMessageType.Message);
                logger.LogMessage("Test", LogMessageType.Warning);

            }

            using (ILogger logger = new DataBaseLogger())
            {
                logger.LogMessage("Test database error", LogMessageType.Error);
                logger.LogMessage("Test database message", LogMessageType.Message);
                logger.LogMessage("Test database Warning", LogMessageType.Warning);
            }

            LoggerHub.Log("Test database error from hub", LogMessageType .Error, LogType.Database);
        }
    }
}
