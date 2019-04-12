using CharacterCreationLib;
using System;
using System.Collections.Generic;
using System.Data;
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
            conn = ConnectionFactory.GetConnection();
        }
        
        /// <summary>
        /// Retrieves all classes from database
        /// </summary>
        /// <returns>Collection of classes</returns>
        public List<Class> GetAllClasses() {
            List<Class> classes = new List<Class>();

            SkillsDAO sDAO = new SkillsDAO();
            List<Skills> skills = sDAO.GetAllSkills();

            SqlDataAdapter classAdapter = new SqlDataAdapter("SELECT id, name, description, hitdice FROM class;",
                ConnectionFactory.GetConnection());
            SqlCommandBuilder commandBuilder = new SqlCommandBuilder(classAdapter);

            DataTable classTable = new DataTable();
            classAdapter.Fill(classTable);

            // Retrieve features for all rows
            foreach (DataRow row in classTable.Rows) {
                int classID = Convert.ToInt32(row.Field<int>(0));
                string name = Convert.ToString(row.Field<string>(1));
                string description = Convert.ToString(row.Field<string>(2));
                int hitDiceValue = Convert.ToInt32(row.Field<int>(3));
                Dice dice = new Dice(hitDiceValue);

                FeatureDAO fDAO = new FeatureDAO();
                List<Feature> features = fDAO.GetClassFeatures(row.Field<int>(0)); // Retrieve features for specific class id

                classes.Add(new Class(classID, name, description, features, dice, skills));
            }

            classes.Sort();
            return classes;
        }

        /// <summary>
        /// Retrieves the class of a character
        /// </summary>
        /// <param name="characterId">The character id</param>
        /// <returns>The class of the character, or null if character does not exist</returns>
        public Class GetCharacterClass(int characterId) {
            int classId = 0;

            using (conn = ConnectionFactory.GetConnection()) {
                conn.Open();

                SqlCommand cmd = new SqlCommand("SELECT classid FROM character WHERE id=@ID;");
                cmd.Parameters.AddWithValue("@ID", characterId);
                cmd.Connection = conn;

                SqlDataReader reader = cmd.ExecuteReader();
                if (reader.Read()) {
                    classId = Convert.ToInt32(reader["classId"]);
                }
            }

            Class charClass = GetClass(classId);
            return charClass;
        }

        /// <summary>
        /// Get a Class from the database
        /// </summary>
        /// <param name="classID">The ID of the class record</param>
        /// <returns>The class record</returns>
        public Class GetClass(int classID) {
            Class charClass;
            int classId = 0;
            string name = "";
            string description = "";

            FeatureDAO fDAO = new FeatureDAO();
            List<Feature> features = fDAO.GetClassFeatures(classID);

            int hitDiceValue;
            Dice dice = null;

            SkillsDAO sDAO = new SkillsDAO();
            List<Skills> skills = sDAO.GetAllSkills();

            using (conn = ConnectionFactory.GetConnection()) {
                conn.Open();

                SqlCommand cmd = new SqlCommand($"" +
                        $"select Id, Name, Description, hitDice from class where Id = @cId;");
                cmd.Parameters.AddWithValue("@cId", classID);
                cmd.Connection = conn;

                SqlDataReader reader = cmd.ExecuteReader();
                while (reader.Read()) {
                    classId = Convert.ToInt32(reader["id"]);
                    name = Convert.ToString(reader["name"]);
                    description = Convert.ToString(reader["description"]);
                    hitDiceValue = Convert.ToInt32(reader["hitDice"]);
                    dice = new Dice(hitDiceValue);
                }
                reader.Close();

                charClass = new Class(classId, name, description, features, dice, skills);

                return charClass;
            }
        }
    }
}
