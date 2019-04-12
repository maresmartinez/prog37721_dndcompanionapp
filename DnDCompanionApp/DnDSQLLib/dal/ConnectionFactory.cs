using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DnDSQLLib.dal {
    /// <summary>
    /// Centralizes the database connection creation
    /// </summary>
    class ConnectionFactory {

        /// <summary>
        /// The connection string for the primary local server
        /// </summary>
        public static string server1 = @"Data Source=HAM\SQLEXPRESS;Initial Catalog=DungeonsAndDragonsDB;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False";

        /// <summary>
        /// The connection string for a backup local server
        /// </summary>
        public static string server2 = "";  // Used in the event of server1 failure

        /// <summary>
        /// Insantiates an SqlConnection with either the Azure server, or the backup localhost server
        /// </summary>
        /// <returns>A connection to the DnD database</returns>
        public static SqlConnection GetConnection() {
            try {
                return new SqlConnection(server1);
            } catch (SqlException) {
                return new SqlConnection(server2);
            }
        }
    }
}
