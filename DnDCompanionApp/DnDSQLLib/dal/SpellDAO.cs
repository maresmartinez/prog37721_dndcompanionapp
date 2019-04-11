using CharacterCreationLib;
using DnDSQLLib.dal;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DnDSQLLib {
    /// <summary>
    /// Database access object for the spells table
    /// </summary>
    public class SpellDAO {

        /// <summary>
        /// Connection to the database
        /// </summary>
        SqlConnection conn;

        /// <summary>
        /// Constructor
        /// </summary>
        public SpellDAO() {
            conn = ConnectionFactory.GetConnection();
        }

        /// <summary>
        /// Retrieves all spells in the database
        /// </summary>
        /// <returns>Collection of spells</returns>
        public List<Spells> GetAllSpells() {
            List<Spells> spells = new List<Spells>();
            using (conn = ConnectionFactory.GetConnection()) {
                conn.Open();

                SqlCommand cmd = new SqlCommand($"select * from spells");
                cmd.Connection = conn;

                SqlDataReader reader = cmd.ExecuteReader();
                while (reader.Read()) {
                    int id = Convert.ToInt32(reader["id"]);
                    string name = Convert.ToString(reader["Name"]);
                    int castingTime = Convert.ToInt32(reader["castingTime"]);
                    int duration = Convert.ToInt32(reader["Duration"]);
                    int range = Convert.ToInt32(reader["Range"]);
                    string description = Convert.ToString(reader["Description"]);
                    Spells spell = new Spells(id, name, castingTime, duration, range, description);
                    spells.Add(spell);
                }
                reader.Close();
                return spells;
            }
        }
    }
}
