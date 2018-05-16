using Oracle.DataAccess.Client;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuanLyDatHangTraSua.DAO
{
    public class DataProvider
    {
        private static DataProvider instance;

        public static DataProvider Instance
        {
            get { if (instance == null) instance = new DataProvider(); return DataProvider.instance; }
            private set { DataProvider.instance = value; }
        }

        private DataProvider() { }

        private string connectionSTR = null;
        public void setConnectionSTR(string host,string service, string username,string password)
        {
            connectionSTR = string.Format(@"Data Source = " +
                "(DESCRIPTION =(ADDRESS = (PROTOCOL = TCP)(HOST = {0})(PORT = 1521))" +
                "(CONNECT_DATA =(SERVER = DEDICATED)(SERVICE_NAME = {1})));User ID = {2}; Password={3};",host,service,username,password);
        }
        
        public int ExecuteProcedure(string query,ref string error, object[] parameter = null)
        {
            int data = 0;

            using (OracleConnection connection = new OracleConnection(connectionSTR))
            {
                connection.Open();
                OracleCommand command = new OracleCommand();
                command.CommandType = CommandType.StoredProcedure;

                if (parameter != null)
                {
                    string[] listPara = query.Split(' ');
                    query = listPara[0];
                    int i = 0;
                    foreach (string item in listPara)
                    {
                        if (item.Contains('$'))
                        {
                            command.Parameters.Add(item, parameter[i]);
                            i++;
                        }
                    }
                }
                command.CommandText = query;
                command.Connection = connection;
                try
                {
                    data = command.ExecuteNonQuery();
                }
                catch(Exception ex)
                {
                    error = ex.Message;
                }
                command.Parameters.Clear();
                connection.Close();
            }

            return data;
        }

        public DataTable ExecuteQuery(string query)
        {
            DataTable data = null;
            OracleDataAdapter adapter = null;
            using (OracleConnection connection = new OracleConnection(connectionSTR))
            {
                try
                {
                    connection.Open();
                    OracleCommand command = new OracleCommand(query, connection);
                    adapter = new OracleDataAdapter(command);
                    data = new DataTable();
                    adapter.Fill(data);
                    connection.Close();
                }
                catch (Exception e)
                {
                    return data;
                }
            }
            return data;
        }

        public DataSet ExecuteQueryDS(string query)
        {
            DataSet data = null;
            OracleDataAdapter adapter = null;
            using (OracleConnection connection = new OracleConnection(connectionSTR))
            {
                try
                {
                    connection.Open();
                    OracleCommand command = new OracleCommand(query, connection);
                    adapter = new OracleDataAdapter(command);
                    data = new DataSet();
                    adapter.Fill(data);
                    connection.Close();
                }
                catch (Exception e)
                {
                    return data;
                }
            }
            return data;
        }

        public int ExecuteNonQuery(string query, ref string error)
        {
            int data = 0;

            using (OracleConnection connection = new OracleConnection(connectionSTR))
            {
                connection.Open();

                OracleCommand command = new OracleCommand(query, connection);
                try
                {
                    data = command.ExecuteNonQuery();
                }
                catch (Exception ex)
                {
                    error = ex.Message;
                }
                finally
                {
                    connection.Close();
                }
            }

            return data;
        }

        public int ExecuteNonQuery(string query, object[] parameter = null)
        {
            int data = 0;

            using (OracleConnection connection = new OracleConnection(connectionSTR))
            {
                connection.Open();

                OracleCommand command = new OracleCommand(query, connection);

                if (parameter != null)
                {
                    string[] listPara = query.Split(' ');
                    int i = 0;
                    foreach (string item in listPara)
                    {
                        if (item.Contains('@'))
                        {
                            command.Parameters.Add(item, parameter[i]);
                            i++;
                        }
                    }
                }

                data = command.ExecuteNonQuery();

                connection.Close();
            }

            return data;
        }

        public object ExecuteScalar(string query, object[] parameter = null)
        {
            object data = new DataTable();

            using (OracleConnection connection = new OracleConnection(connectionSTR))
            {
                connection.Open();

                OracleCommand command = new OracleCommand(query, connection);

                if (parameter != null)
                {
                    string[] listPara = query.Split(' ');
                    int i = 0;
                    foreach (string item in listPara)
                    {
                        if (item.Contains('@'))
                        {
                            command.Parameters.Add(item, parameter[i]);
                            i++;
                        }
                    }
                }

                data = command.ExecuteScalar();

                connection.Close();
            }

            return data;
        }
        
        private string checkString(string s)
        {
            s = s.Replace("'", "");
            s = s.Replace("or", "");
            s = s.Replace('=', ' ');
            s = s.Replace('-', ' ');
            s = s.Replace('#', ' ');
            s = s.Replace("/*", "");
            s = s.Replace('"', ' ');
            s = s.Replace(')', ' ');

            return s;
        }
    }
}
