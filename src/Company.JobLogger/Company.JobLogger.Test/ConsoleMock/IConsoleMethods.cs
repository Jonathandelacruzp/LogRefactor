using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Company.JobLogger.Test.ConsoleMock
{
    public interface IConsoleMethods
    {
        void WriteLine(string message);
        string ReadLine();
    }
}
