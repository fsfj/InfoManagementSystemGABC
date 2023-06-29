using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace InfoManagementSystem.Data
{
    public class ConnectionFactory : IConnectionFactory
    {
        public SqlConnection DatabaseConnection()
        {
            //var str = $"Server={server}; Database={dbName};Trusted_Connection=true; Integrated Security=false; User Id={userId}; Password={password};";

            return new SqlConnection(ConfigurationManager.ConnectionStrings["IMDBContext"].ToString());
        }
    }
}