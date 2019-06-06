using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Company.JobLogger.Test.ConsoleMock
{
    class DataWithConsole
    {
        public DataWithConsole(IConsoleMethods consoleMethods) { this.console = consoleMethods; }

        public IConsoleMethods console;
        private string _name;

        public void GetData()
        {
            console.WriteLine("Please Enter your Name(only Alphabet)");
            _name = console.ReadLine();
            console.WriteLine(_name);
        }
    }
}
