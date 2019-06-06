using System;
using System.Data.SqlClient;
using System.IO;
using Company.JobLogger.Logger;
using Company.JobLogger.Logger.Core;
using Company.JobLogger.Test.ConsoleMock;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;

namespace Company.JobLogger.Test
{
    [TestClass]
    public class LoggerTest
    {

        [TestMethod]
        public void TestFileLoggerNotCreateLogFileWithNullMessage()
        {

            var directoryFile = System.Configuration.ConfigurationManager.AppSettings["LogFileDirectory"];

            var logTxtFile = directoryFile + "LogFile" + DateTime.Now.ToString("yyyy-MM-dd") + ".txt";

            if (System.IO.File.Exists(logTxtFile))
            {
                System.IO.File.Delete(logTxtFile);
            }
            if (System.IO.Directory.Exists(directoryFile))
            {
                System.IO.Directory.Delete(directoryFile);
            }

            var fileLogger = new FileLogger();
            string message = null;
            fileLogger.LogMessage(message, Logger.Core.LogMessageType.Message);

            Assert.IsNull(message);
            Assert.IsFalse(System.IO.File.Exists(logTxtFile));
        }


        [TestMethod]
        public void TestFileLoggerCreateLogFile()
        {

            var directoryFile = System.Configuration.ConfigurationManager.AppSettings["LogFileDirectory"];

            var logTxtFile = directoryFile + "LogFile" + DateTime.Now.ToString("yyyy-MM-dd") + ".txt";

            var message = "Test log arcchivo";
            var fileLogger = new FileLogger();
            fileLogger.LogMessage(message, Logger.Core.LogMessageType.Message);

            Assert.IsTrue(System.IO.File.Exists(logTxtFile));
        }


        [TestMethod]
        public void TestInsertValueFromLoggerHubToDatabaseLogger()
        {
            var messsage = "Test database error from hub";

            LoggerHub.Log(messsage, LogMessageType.Error, LogType.Database);

            string queryString = "SELECT TOP(1) LogId, Message, LogType from dbo.Log ORDER BY LogId DESC";

            var messsageFronSql = string.Empty;
            using (var connection = new SqlConnection(System.Configuration.ConfigurationManager.AppSettings["ConnectionString"]))
            {
                using (var command = new SqlCommand(queryString, connection))
                {
                    connection.Open();
                    SqlDataReader reader = command.ExecuteReader();
                    while (reader.Read())
                    {
                        messsageFronSql = reader[1].ToString();
                    }
                    reader.Close();

                }
            }

            Assert.AreEqual(messsage, messsageFronSql);
        }

        [TestMethod]
        public void TestInsertNullValueFromLoggerHubToDatabaseLogger()
        {
            var messsage = string.Empty;
            LoggerHub.Log(messsage, LogMessageType.Error, LogType.Database);

            string queryString = "SELECT TOP(1) LogId, Message, LogType from dbo.Log ORDER BY LogId DESC";

            var messsageFronSql = string.Empty;
            using (var connection = new SqlConnection(System.Configuration.ConfigurationManager.AppSettings["ConnectionString"]))
            {
                using (var command = new SqlCommand(queryString, connection))
                {
                    connection.Open();
                    SqlDataReader reader = command.ExecuteReader();
                    while (reader.Read())
                    {
                        messsageFronSql = reader[1].ToString();                     
                    }
                    reader.Close();

                }
            }

            Assert.AreNotEqual(messsage, messsageFronSql);
        }

    }
}
