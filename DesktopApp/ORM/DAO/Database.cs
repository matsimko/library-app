using System;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;

namespace DesktopApp.ORM.DAO
{
    /// <summary>
    /// Represents a MS SQL Database
    /// </summary>
    public class Database
    {
        private SqlConnection Connection { get; set; }
        private SqlTransaction SqlTransaction { get; set; }
        public string Language { get; set; }

        public Database()
        {
            Connection = new SqlConnection();
            Language = "en";
        }
        
        /// <summary>
        /// Connect
        /// </summary>
        public bool Connect(string conString)
        {
            if (Connection.State != System.Data.ConnectionState.Open)
            {
                Connection.ConnectionString = conString;
                Connection.Open();
            }
            return true;

        }
       
        /// <summary>
        /// Connect
        /// </summary>
        public bool Connect()
        {
            bool ret = true;
            if (Connection.State != System.Data.ConnectionState.Open)
            {
                // connection string is stored in file App.config or Web.config
                ret = Connect(ConfigurationManager.ConnectionStrings["MSSQL"].ConnectionString);
            }
            return ret;
        }
        
        /// <summary>
        /// Close
        /// </summary>
        public void Close()
        {
            Connection.Close();
        }

        /// <summary>
        /// Begin a transaction.
        /// </summary>
        public void BeginTransaction()
        {
            SqlTransaction = Connection.BeginTransaction(IsolationLevel.Serializable);
        }

        /// <summary>
        /// End a transaction.
        /// </summary>
        public void EndTransaction()
        {
            SqlTransaction.Commit();
            Close();
        }

        /// <summary>
        /// If a transaction is failed call it.
        /// </summary>
        public void Rollback()
        {
            SqlTransaction.Rollback();
        }

        /// <summary>
        /// Insert a record encapulated in the command.
        /// </summary>
        public int ExecuteNonQuery(SqlCommand command)
        {
            int rowNumber = 0;
            try
            {
                rowNumber = command.ExecuteNonQuery();
            }
            catch (Exception e)
            {
                throw e;
            }
            return rowNumber;
        }

        /// <summary>
        /// Create command
        /// </summary>
        public SqlCommand CreateCommand(string strCommand)
        {
            if (strCommand == null)
            {
                throw new NotSupportedException("The command is not supported.");
            }

            SqlCommand command = new SqlCommand(strCommand, Connection);

            if (SqlTransaction != null)
            {
                command.Transaction = SqlTransaction;
            }
            return command;
        }

        /// <summary>
        /// Select encapulated in the command.
        /// </summary>
        public SqlDataReader Select(SqlCommand command)
        {
            SqlDataReader sqlReader = command.ExecuteReader();
            return sqlReader;
        }


        public int ExecuteStoredProcedure(SqlCommand command)
        {
            command.CommandType = CommandType.StoredProcedure;
            return ExecuteNonQuery(command);
        }

        public SqlDataReader ExecuteStoredProcedure_Reader(SqlCommand command)
        {
            command.CommandType = CommandType.StoredProcedure;
            return Select(command);
        }


        public int ExecuteScalar(SqlCommand command)
        {
            return Convert.ToInt32(command.ExecuteScalar());
        }

        public int ExecuteStoredProcedure_Scalar(SqlCommand command)
        {
            command.CommandType = CommandType.StoredProcedure;
            return ExecuteScalar(command);
        }
    }
}

