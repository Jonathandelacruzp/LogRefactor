using System;
using System.IO;
using Company.JobLogger.Logger;
using Company.JobLogger.Test.ConsoleMock;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;

namespace Company.JobLogger.Test
{
    [TestClass]
    public class ConsoleLoggerTest
    {
        public static void Main(string[] args)
        {
            var message = "Test de consola";

            var fileLogger = new ConsoleLogger();
            fileLogger.LogMessage(message, Logger.Core.LogMessageType.Message);
        }

        [TestMethod]
        public void TestConsoleLoggerWillAppearOnConsole()
        {
            var message = "Test de consola";
            
            var output = new StringWriter();
            Console.SetOut(output);

            ConsoleLoggerTest.Main(new string[] { });

            Assert.AreEqual(output.ToString(), string.Format("{0}{1}{2}", DateTime.Now.ToShortDateString(), message, Environment.NewLine));
        }

    }
}
