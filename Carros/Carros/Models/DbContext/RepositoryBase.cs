using System.Configuration;
using System.Data;
using System.Data.SqlClient;

namespace Carros.Models.DbContext
{
    public class RepositoryBase
    {
        protected SqlConnection _con;

        protected string Connection()
        {
            string stringCon = ConfigurationManager.ConnectionStrings["DbContext"].ToString();

            _con = new SqlConnection(stringCon);

            return stringCon;
        }
    }
}