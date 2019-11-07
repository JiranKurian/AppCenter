using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Data.SqlClient;

namespace AppCenterAPI.StaticData
{
    public class SqlCon
    {
        public SqlConnection GetConnection()
        {
            SqlConnection sqlConnection = new SqlConnection(@"Data Source=(localdb)\MSSQLLocalDB;Initial Catalog=AppCenterDB;Integrated Security=True");
            return sqlConnection;
        }
    }
}
