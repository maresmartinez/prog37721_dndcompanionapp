using CharacterCreationLib;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DnDSQLLib.dal {
    /// <summary>
    /// The database access object for the skills table in the database
    /// </summary>
    public class SkillsDAO {

        /// <summary>
        /// Connection to the database
        /// </summary>
        SqlConnection conn;

        /// <summary>
        /// Constructor
        /// </summary>
        public SkillsDAO() {
            conn = ConnectionFactory.GetConnection();
        }

        /// <summary>
        /// Retrieves all skills in the database
        /// </summary>
        /// <returns>Collection of all skills</returns>
        public List<Skills> GetAllSkills() {
            List<Skills> skills = new List<Skills>();

            using (conn = ConnectionFactory.GetConnection()) {
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
            }
        }
    }
}
