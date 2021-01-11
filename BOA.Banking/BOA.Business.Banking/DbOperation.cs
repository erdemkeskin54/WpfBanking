using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace BOA.Business.Banking
{
    public class DbOperation
    {
        private string connectionString = @"Server=DARKSPOILER\SQLEXPRESS;Database=BOA;Trusted_Connection=True;";
        private readonly SqlConnection conn;
        public DbOperation()
        {
            if (conn == null)
                conn = new SqlConnection(connectionString);
        }
        public void CloseConnection()
        {
            if (conn != null)
            {
                conn.Close();
            }
        }
        public object SpExecuteScalar(string spName, SqlParameter[] parameters)
        {
            SqlCommand cmd = new SqlCommand
            {
                Connection = conn,
                CommandType = CommandType.StoredProcedure,
                CommandText = spName
            };
            if (parameters.Length > 0)
            {
                cmd.Parameters.AddRange(parameters);
            }
            try
            {
                conn.Open();
                object result = cmd.ExecuteScalar();
                conn.Close();
                return result;
            }


            catch (Exception e)
            {
                conn.Close();
                return false;
            }


        }
        public bool SpExecute(string spName, SqlParameter[] parameters)
        {
            SqlCommand cmd = new SqlCommand
            {
                Connection = conn,
                CommandType = CommandType.StoredProcedure,
                CommandText = spName
            };
            if (parameters.Length > 0)
            {
                cmd.Parameters.AddRange(parameters);
            }
            try
            {
                conn.Open();
                cmd.ExecuteNonQuery();
                conn.Close();
                return true;
            }
            catch (Exception e)
            {
                conn.Close();
                return false;
            }
        }
        public SqlDataReader SpGetData(string spName, SqlParameter[] parameters)
        {
            SqlCommand cmd = new SqlCommand
            {
                Connection = conn,
                CommandType = CommandType.StoredProcedure,
                CommandText = spName
            };
            if (parameters.Length > 0 || parameters!=null)
            {
                cmd.Parameters.AddRange(parameters);
            }
            conn.Open();
            try
            {
                
                return cmd.ExecuteReader();
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                throw;
            }
        }
        public SqlDataReader GetData(string query, SqlParameter[] parameters)
        {
            SqlCommand cmd = new SqlCommand
            {
                Connection = conn,
                CommandType = CommandType.Text,
                CommandText = query
            };
            if (parameters.Length > 0 )
            {
                cmd.Parameters.AddRange(parameters);
            }
            
            try
            {
                conn.Open();
                return cmd.ExecuteReader();
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                throw;
            }
        }
        public bool Execute(string query, SqlParameter[] parameters)
        {

            SqlCommand cmd = new SqlCommand
            {
                Connection = conn,
                CommandType = CommandType.Text,
                CommandText = query
            };

            if (parameters.Length > 0)
            {
                cmd.Parameters.AddRange(parameters);
            }

            try
            {
                conn.Open();
                cmd.ExecuteNonQuery();
                conn.Close();
                return true;
            }
            catch (Exception e)
            {
                conn.Close();
                return false;
            }
        }
        public int SpLogin(string spName, SqlParameter[] parameters)
        {
            SqlCommand cmd = new SqlCommand
            {
                Connection = conn,
                CommandType = CommandType.StoredProcedure,
                CommandText = spName
            };
            if (parameters.Length > 0)
            {
                cmd.Parameters.AddRange(parameters);
            }
            conn.Open();
            try
            {
                return (Int32)cmd.ExecuteScalar();
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                throw;
            }
        }

    }
}