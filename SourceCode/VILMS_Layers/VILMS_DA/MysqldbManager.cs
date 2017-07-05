using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SQLite;

namespace VILMS_DA
{
    public class MysqldbManager : Idbmanager
    {
        #region Constructor
        /// <summary>
        /// Initialization of class and Constructor initialization.
        /// </summary>
        public MysqldbManager()
        {
        }

        /// <summary>
        /// Initialization of class and Constructor initialization.
        /// </summary>
        /// <param name="lconstring">string</param>
        public MysqldbManager(string lconstring)
        {
            constring = "data source=" + lconstring;
        }
        #endregion

        #region Variables
        string constring = string.Empty;
        #endregion

        #region Methods
        public DataSet GetDataInDataSet(string query)
        {
            SQLiteConnection con = null;
            SQLiteCommand cmd = null;
            SQLiteDataAdapter adaptar = null;
            DataSet dsResult = new DataSet();
            try
            {
                con = new SQLiteConnection(constring);
                if (con != null && con.State == ConnectionState.Closed)
                    con.Open();
                cmd = new SQLiteCommand
                {
                    CommandText = query,
                    CommandType = System.Data.CommandType.Text,
                    Connection = con,
                    CommandTimeout = 50000
                };
                adaptar = new SQLiteDataAdapter(cmd);
                adaptar.Fill(dsResult);
                return dsResult;
            }
            catch (Exception ex)
            {
                throw;
            }
            finally
            {
                if (con != null && con.State == ConnectionState.Open)
                    con.Close();
                if (cmd != null)
                    cmd.Dispose();
            }
        }

        public object GetSingleValue(string query)
        {
            SQLiteConnection con = null;
            SQLiteCommand cmd = null;
            object value = null;
            try
            {
                con = new SQLiteConnection(constring);
                con.Open();
                {
                    cmd = new SQLiteCommand
                    {
                        CommandText = query,
                        CommandType = CommandType.Text,
                        Connection = con,
                        CommandTimeout = 50000
                    };
                    value = cmd.ExecuteScalar();
                }
                return value;
            }
            catch (Exception ex)
            {
                return value;
            }
            finally
            {
                if (con != null && con.State == ConnectionState.Open)
                {
                    con.Close();
                }
                if (cmd != null)
                    cmd.Dispose();
            }
        }

        public bool RunQuery(string query, out int noOfRowsaffected)
        {
            noOfRowsaffected = 0;
            SQLiteConnection con = null;
            SQLiteCommand cmd = null;
            try
            {
                con = new SQLiteConnection(constring);
                cmd = new SQLiteCommand();
                con.Open();
                cmd = new SQLiteCommand
                {
                    CommandText = query,
                    CommandType = CommandType.Text,
                    Connection = con,
                    CommandTimeout = 50000
                };
                noOfRowsaffected = cmd.ExecuteNonQuery();
                return true;
            }
            catch (Exception ex)
            {
                throw;
            }
            finally
            {
                if (con != null && con.State == ConnectionState.Open)
                    con.Close();
                if (cmd != null)
                    cmd.Dispose();
            }
        }

        public bool ExecuteSpForMultipleCommands(List<SQLiteCommand> commands)
        {
            int totalNoOfRowsaffected;
            return ExecuteSpForMultipleCommands(commands, out totalNoOfRowsaffected);
        }

        public bool ExecuteSpForMultipleCommands(List<SQLiteCommand> commands, out int totalNoOfRowsaffected)
        {
            totalNoOfRowsaffected = 0;
            SQLiteConnection con = null;
            SQLiteTransaction transaction = null;
            try
            {
                con = new SQLiteConnection(constring);
                con.Open();
                transaction = con.BeginTransaction();
                foreach (SQLiteCommand command in commands)
                {
                    command.Connection = con;
                    command.Transaction = transaction;
                    int rowsEffected = command.ExecuteNonQuery();
                    totalNoOfRowsaffected = totalNoOfRowsaffected + rowsEffected;
                }
                if (commands.Count == totalNoOfRowsaffected)
                {
                    transaction.Commit();
                    return true;
                }
                else
                {
                    transaction.Rollback();
                    return false;
                }

            }
            catch (Exception ex)
            {
                if (transaction != null)
                    transaction.Rollback();
                throw;
            }
            finally
            {
                if (con != null && con.State == ConnectionState.Open)
                    con.Close();
                commands.Clear();
                if (transaction != null)
                    transaction.Dispose();
            }
        }

        public bool ExecuteSp(SQLiteCommand command, out int noOfRowsaffected)
        {
            noOfRowsaffected = 0;
            SQLiteConnection con = null;
            SQLiteTransaction transaction = null;
            try
            {
                if (command != null)
                {
                    con = new SQLiteConnection(constring);
                    con.Open();
                    transaction = con.BeginTransaction();
                    command.Connection = con;
                    command.Transaction = transaction;
                    noOfRowsaffected = command.ExecuteNonQuery();
                    if (noOfRowsaffected <= 0)
                    {
                        transaction.Rollback();
                        return false;
                    }
                    else if (noOfRowsaffected > 0)
                    {
                        transaction.Commit();
                        return true;
                    }
                }

            }
            catch (Exception ex)
            {
                if (transaction != null)
                    transaction.Rollback();
                throw;
            }
            finally
            {
                if (con != null && con.State == ConnectionState.Open)
                    con.Close();
                if (command != null)
                    command.Dispose();
                if (transaction != null)
                    transaction.Dispose();
            }
            return false;
        }

        public DataSet ExecuteSpFillDataSet(SQLiteCommand command)
        {
            SQLiteConnection con = null;
            DataSet dsResult = new DataSet();
            try
            {
                con = new SQLiteConnection(constring);
                con.Open();
                command.Connection = con;
                var adaptar = new SQLiteDataAdapter(command);
                adaptar.Fill(dsResult);
                return dsResult;
            }
            catch (Exception ex)
            {
                throw;
            }
            finally
            {
                if (con != null && con.State == ConnectionState.Open)
                    con.Close();
                if (command != null)
                    command.Dispose();
            }
        }

        public DataSet GetDataInDataSet(string query, string tablename = "")
        {
            SQLiteConnection con = null;
            SQLiteCommand cmd = null;
            SQLiteDataAdapter adaptar = null;
            DataSet dsResult = new DataSet();
            try
            {
                con = new SQLiteConnection(constring);

                if (con != null && con.State == ConnectionState.Closed)
                    con.Open();
                cmd = new SQLiteCommand
                {
                    CommandText = query,
                    CommandType = System.Data.CommandType.Text,
                    Connection = con,
                    CommandTimeout = 50000
                };
                adaptar = new SQLiteDataAdapter(cmd);
                if (tablename.Length > 0)
                    adaptar.Fill(dsResult, tablename);
                else
                    adaptar.Fill(dsResult);
                return dsResult;
            }
            catch (Exception ex)
            {
                throw;
            }
            finally
            {
                if (con != null && con.State == ConnectionState.Open)
                    con.Close();
                if (cmd != null)
                    cmd.Dispose();
            }
        }
        #endregion
    }
}
