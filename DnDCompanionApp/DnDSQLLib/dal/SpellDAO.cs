using CharacterCreationLib;
using DnDSQLLib.dal;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DnDSQLLib
{
    public class SpellDAO
    {
        SqlConnection conn;

        public SpellDAO()
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

        public int UploadSpells(Character character)
        {
            return 0;
        }
    }
}
