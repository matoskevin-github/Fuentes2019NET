using System.Configuration;
using System.Data.SqlClient;
using System.Text;

namespace WcfEscuelaCRUDADO.Net.DataSource
{
    public class DBSQLServerUtils
    {
        public static SqlConnection GetDBConnection(string datasource, string database, string username, string password)
        {
            StringBuilder sbCadena = new StringBuilder();
            sbCadena.Append(ConfigurationManager.ConnectionStrings["DBConnectionString"].ConnectionString);
            sbCadena.Replace("@Servidor", datasource);
            sbCadena.Replace("@BaseDatos", database);
            sbCadena.Replace("@Usuario", username);
            sbCadena.Replace("@Password", password);

            SqlConnection conn = new SqlConnection(sbCadena.ToString());

            return conn;
        }
    }
}