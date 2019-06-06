using Company.JobLogger.Logger.Core;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Company.JobLogger.Logger
{
    public class DataBaseLogger : ILogger
    {
        private string _connectionString { get; set; } = System.Configuration.ConfigurationManager.AppSettings["ConnectionString"];

        public void Dispose()
        {
            this._connectionString = null;
            GC.SuppressFinalize(this);
        }

        public void LogMessage(string message, LogMessageType logType)
        {

            if (string.IsNullOrEmpty(message))
            {
                return;
            }
            message = message.Trim();

            using (var sqlConnection = new SqlConnection(this._connectionString))
            {
                try
                {
                    using (var sqlCommand = new SqlCommand("INSERT INTO Log VALUES(@Message, @LogTypeId)", sqlConnection))
                    {
                        sqlCommand.Parameters.AddWithValue("@Message", message);
                        sqlCommand.Parameters.AddWithValue("@LogTypeId", (int)logType);
                        sqlConnection.Open();
                        sqlCommand.ExecuteNonQuery();

                    }
                }
                catch (Exception ex)
                {
                    throw new Exception("No se pudo Conectar a la base de datos");
                }
                finally
                {
                    sqlConnection.Close();
                }
            }

        }
    }
}
