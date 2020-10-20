using System;
using System.Data;
using Npgsql;

namespace Entities.SQLConnect
{
    public class SqlConnect
    {
        private NpgsqlConnection _conn;
        private static SqlConnect _newConnect = null;

        public SqlConnect(NpgsqlConnection conn)
        {
            _conn = conn;
        }

        public bool GetConnect { get { return _conn.State == ConnectionState.Closed;} }

        public SqlConnect GetNewSqlConn()
        {
            return (_newConnect = new SqlConnect(_conn));
        }


        public NpgsqlConnection GetConn => _conn;

        public void OpenConn()
        {
            try
            {
                _conn.Open();
            }
            catch (Exception)
            {
                
            }
        }
        public void CloseConn()
        {
            try
            {
                _conn.Close();
               
            }
            catch (Exception)
            {
               
            }
        }
    }
}
