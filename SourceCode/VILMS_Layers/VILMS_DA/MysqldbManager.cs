using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
            constring = ConfigurationManager.AppSettings["ConString"];
        }
        #endregion

        #region Variables
        string constring = string.Empty;
        private static MysqldbManager o_instance;
        #endregion

        #region Methods
        public DataSet GetDataInDataSet(string query)
        {
            MySqlConnection con = null;
            MySqlCommand cmd = null;
            MySqlDataAdapter adaptar = null;
            DataSet dsResult = new DataSet();
            try
            {
                con = new MySqlConnection(constring);
                if (con != null && con.State == ConnectionState.Closed)
                    con.Open();
                cmd = new MySqlCommand
                {
                    CommandText = query,
                    CommandType = System.Data.CommandType.Text,
                    Connection = con,
                    CommandTimeout = 50000
                };
                adaptar = new MySqlDataAdapter(cmd);
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
            MySqlConnection con = null;
            MySqlCommand cmd = null;
            object value = null;
            try
            {
                con = new MySqlConnection(constring);
                con.Open();

                {
                    cmd = new MySqlCommand
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
            MySqlConnection con = null;
            MySqlCommand cmd = null;
            try
            {
                con = new MySqlConnection(constring);
                cmd = new MySqlCommand();
                con.Open();
                cmd = new MySqlCommand
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
        
        public bool ExecuteSpForMultipleCommands(List<MySqlCommand> commands)
        {
            int totalNoOfRowsaffected;
            return ExecuteSpForMultipleCommands(commands, out totalNoOfRowsaffected);
        }
        
        public bool ExecuteSpForMultipleCommands(List<MySqlCommand> commands, out int totalNoOfRowsaffected)
        {
            totalNoOfRowsaffected = 0;
            MySqlConnection con = null;
            MySqlTransaction transaction = null;
            try
            {
                con = new MySqlConnection(constring);
                con.Open();
                transaction = con.BeginTransaction();
                foreach (MySqlCommand command in commands)
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
        
        public bool ExecuteSp(MySqlCommand command, out int noOfRowsaffected)
        {
            noOfRowsaffected = 0;
            MySqlConnection con = null;
            MySqlTransaction transaction = null;
            try
            {
                if (command != null)
                {
                    con = new MySqlConnection(constring);
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
        
        public DataSet ExecuteSpFillDataSet(MySqlCommand command)
        {
            MySqlConnection con = null;
            DataSet dsResult = new DataSet();
            try
            {
                con = new MySqlConnection(constring);
                con.Open();
                command.Connection = con;
                var adaptar = new MySqlDataAdapter(command);
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
            MySqlConnection con = null;
            MySqlCommand cmd = null;
            MySqlDataAdapter adaptar = null;
            DataSet dsResult = new DataSet();
            try
            {
                con = new MySqlConnection(constring);

                if (con != null && con.State == ConnectionState.Closed)
                    con.Open();
                cmd = new MySqlCommand
                {
                    CommandText = query,
                    CommandType = System.Data.CommandType.Text,
                    Connection = con,
                    CommandTimeout = 50000
                };
                adaptar = new MySqlDataAdapter(cmd);
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
