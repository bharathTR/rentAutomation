using Oracle.ManagedDataAccess.Client;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Web;

namespace SampleProject
{
    
    public class GlobalConnection
    {
        public static OracleConnection conn = null;

        public OracleConnection getConnection()
        {
            OracleConnection conn = new OracleConnection(ConfigurationManager.ConnectionStrings["ConnString"].ConnectionString);

            conn.Open();

            return conn;
        }
    }
}