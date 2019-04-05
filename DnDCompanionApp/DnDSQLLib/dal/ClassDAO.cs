using CharacterCreationLib;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DnDSQLLib.dal {

    /// <summary>
    /// Data Access Object for Class
    /// </summary>
    public class ClassDAO {

        /// <summary>
        /// Database connection
        /// </summary>
        SqlConnection conn;

        /// <summary>
        /// Constructor
        /// </summary>
        public ClassDAO() {
            try {
                conn = ConnectionFactory.GetConnection();
                conn.Open();
                conn.Close();   // Just double checking to make sure that yes, we can indeed access the server
            } catch (SqlException) {
                // Figure out how to let the user know that things just aint happening
            }
        }

        /// <summary>
        /// Retrieves all classes from database
        /// </summary>
        /// <returns>Collection of classes</returns>
        public List<Class> GetAllClasses() {
            List<Class> classes = new List<Class>();

            SkillsDAO sDAO = new SkillsDAO();
            List<Skills> skills = sDAO.GetAllSkills();

            // TODO: refactor code so that we don't need multiple connections
            using (conn) {
                conn.Open();

                SqlCommand cmd = new SqlCommand("SELECT id, name, description, hitdice FROM class;");
                cmd.Connection = conn;

                SqlDataReader reader = cmd.ExecuteReader();
                while (reader.Read()) {
                    int classID = Convert.ToInt32(reader["id"]);
                    string name = Convert.ToString(reader["name"]);
                    string description = Convert.ToString(reader["description"]);
                    int hitDiceValue = Convert.ToInt32(reader["hitDice"]);
                    Dice dice = new Dice(hitDiceValue);

                    FeatureDAO fDAO = new FeatureDAO();
                    List<Feature> features = fDAO.GetClassFeatures(classID);

                    classes.Add(new Class(name, description, features, dice, skills));
                }
            }

            return classes;
        }

        /// <summary>
        /// Get a Class from the database
        /// </summary>
        /// <param name="classID">The ID of the class record</param>
        /// <returns>The class record</returns>
        public Class GetClass(int classID) {
            Class charClass;
            string name = "";
            string description = "";

            FeatureDAO fDAO = new FeatureDAO();
            List<Feature> features = fDAO.GetClassFeatures(classID);

            int hitDiceValue;
            Dice dice = null;

            SkillsDAO sDAO = new SkillsDAO();
            List<Skills> skills = sDAO.GetAllSkills();

            try {
                conn.Open();

                SqlCommand cmd = new SqlCommand($"" +
                        $"select Name, Description, hitDice from class where Id = @cId");
                cmd.Parameters.AddWithValue("@cId", classID);
                cmd.Connection = conn;

                SqlDataReader reader = cmd.ExecuteReader();
                while (reader.Read()) {
                    name = Convert.ToString(reader["name"]);
                    description = Convert.ToString(reader["description"]);
                    hitDiceValue = Convert.ToInt32(reader["hitDice"]);
                    dice = new Dice(hitDiceValue);
                }
                reader.Close();

                charClass = new Class(name, description, features, dice, skills);

                return charClass;
            } finally {
                conn.Close();
            }
        }
    }
}
