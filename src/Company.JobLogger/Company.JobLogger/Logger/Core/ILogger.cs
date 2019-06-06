
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Company.JobLogger.Logger.Core
{
    public enum LogMessageType
    {
        Message = 1,
        Warning = 2,
        Error = 3
    }

    public interface ILogger : IDisposable
    {
        void LogMessage(string message, LogMessageType logType);
    }
}
