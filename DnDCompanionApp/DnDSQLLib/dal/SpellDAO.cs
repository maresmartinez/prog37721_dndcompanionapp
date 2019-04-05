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

        public List<Spells> GetAllSpells()
        {
            List<Spells> spells = new List<Spells>();
            try
            {
                conn.Open();

                SqlCommand cmd = new SqlCommand($"" +
                    $"select * from spells");
                cmd.Connection = conn;

                SqlDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    string name = Convert.ToString(reader["Name"]);
                    int castingTime = Convert.ToInt32(reader["castingTime"]);
                    int duration = Convert.ToInt32(reader["Duration"]);
                    int range = Convert.ToInt32(reader["Range"]);
                    string description = Convert.ToString(reader["Description"]);
                    Spells spell = new Spells(name, castingTime, duration, description);
                    spells.Add(spell);
                }
                reader.Close();
                return spells;
            }
            catch (SqlException)
            {
                // **ERROR PLACE HOLDER**
                return null;
            }
            finally
            {
                conn.Close();
            }
        }
    }
}
