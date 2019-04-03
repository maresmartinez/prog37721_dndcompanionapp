using CharacterCreationLib;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DnDSQLLib.dal
{
    public class BackgroundDAO
    {
        SqlConnection conn;

        public BackgroundDAO()
        {
            try
            {
                conn = ConnectionFactory.GetConnection();
                conn.Open();
                conn.Close();   // Just double checking to make sure that yes, we can indeed access the server
            }
            catch (SqlException)
            {
                // Figure out how to let the user know that things just aint happening
            }
        }

        public int createBackground(Background bg)
        {
            return 0;
        }
        public int removeBackground(int backgroundId)
        {
            return 0;
        }
        public int getBackground()
        {
            return 0;
        }
        public int updateBackground()
        {
            return 0;
        }
    }
}
