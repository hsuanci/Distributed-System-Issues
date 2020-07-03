using Oracle.ManagedDataAccess.Client;
using System.Configuration;
using System.Data;

namespace ServerA.Helplers
{
    public class DBHelpers
    {
        public static OracleConnection GetConnection()
        {
            var conn = new OracleConnection(ConfigurationManager.AppSettings["DB"]);

            if (conn.State == ConnectionState.Closed)
            {
                conn.Open();
            }
            return conn;
        }

        public static void CloseConnection(OracleConnection conn)
        {
            if (conn.State == ConnectionState.Open || conn.State == ConnectionState.Broken)
            {
                conn.Close();
            }
        }
    }
}