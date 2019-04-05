using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DnDSQLLib.dal
{
    class ConnectionFactory
    {
        // TODO: remove MARS from production build
        public static string server1 = @"Data Source=mark-laptop\sqlexpress;Initial Catalog=dnd;Integrated Security=True;MultipleActiveResultSets=true";
        public static string server2 = "";  // Used in the event of redundancy
        public static SqlConnection GetConnection()
        {
            try
            {
                return new SqlConnection(server1);
            }
            catch (SqlException)
            {
                return new SqlConnection(server2);  // Flips over to the redundant server is things go horribly wrong with the Azure instance
            }
        }
    }
}
