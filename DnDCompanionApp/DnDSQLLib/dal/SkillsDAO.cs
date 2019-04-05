using CharacterCreationLib;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DnDSQLLib.dal {
    public class SkillsDAO {
        SqlConnection conn;

        public SkillsDAO() {
            try {
                conn = ConnectionFactory.GetConnection();
                conn.Open();
                conn.Close();   // Just double checking to make sure that yes, we can indeed access the server
            } catch (SqlException) {
                // Figure out how to let the user know that things just aint happening
            }
        }

        public List<Skills> GetAllSkills() {
            List<Skills> skills = new List<Skills>();

            try {
                conn.Open();
                SqlCommand cmd = new SqlCommand($"" +
                    $"select Id from skill");
                cmd.Connection = conn;

                SqlDataReader reader = cmd.ExecuteReader();
                while (reader.Read()) {
                    skills.Add((Skills)Convert.ToInt32(reader["Id"]));
                }
                reader.Close();

                return skills;
            } catch (SqlException) {
                // **ERROR PLACE HOLDER**
                return null;
            } finally {
                conn.Close();
            }
        }
    }
}
