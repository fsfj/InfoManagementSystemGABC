using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InfoManagementSystem.Data
{
    public interface IConnectionFactory
    {
        SqlConnection DatabaseConnection();
    }
}
