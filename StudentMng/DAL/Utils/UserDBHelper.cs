using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Configuration;
using System.Data.SqlClient;

namespace StudentMng.DAL.Utils
{
    public class UserDBHelper
    {
        public string _connectionString { get; }
        public UserDBHelper()
        {
            _connectionString = ConfigurationManager.ConnectionStrings["Usr"].ConnectionString;
        }
        public SqlConnection GetConnect()
        {
            return new SqlConnection(_connectionString);
        }
    }
}