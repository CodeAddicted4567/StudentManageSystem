using Microsoft.Ajax.Utilities;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace StudentMng.DAL.Utils
{
    public class DbConnectionFactory
    {
        public string _connectionString { get; }
        public DbConnectionFactory()
        {
            _connectionString = ConfigurationManager.ConnectionStrings["Stud"].ConnectionString;
        }
        public SqlConnection GetConnect()
        {
            return new SqlConnection(_connectionString);
        }
    }
}