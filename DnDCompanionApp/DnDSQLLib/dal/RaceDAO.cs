using CharacterCreationLib;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DnDSQLLib.dal {
    public class RaceDAO {

        /// <summary>
        /// Connection to the database
        /// </summary>
        SqlConnection conn;

        /// <summary>
        /// Constructor
        /// </summary>
        public RaceDAO() {
            conn = ConnectionFactory.GetConnection();
        }

        /// <summary>
        /// Retrieves all races in the database
        /// </summary>
        /// <returns>Collection of all races in the database</returns>
        public List<Race> GetAllRaces() {
            List<Race> races = new List<Race>();

            SqlDataAdapter raceAdapter = new SqlDataAdapter("SELECT id, name, description from race;",
                ConnectionFactory.GetConnection());
            DataTable raceTable = new DataTable();
            raceAdapter.Fill(raceTable);

            foreach (DataRow row in raceTable.Rows) {
                int id = row.Field<int>(0);
                string name = row.Field<string>(1);
                string description = row.Field<string>(2);

                SqlDataAdapter languageAdapter = new SqlDataAdapter("SELECT languageID from raceLanguage WHERE raceID=" + id + ";",
                    ConnectionFactory.GetConnection());
                DataTable languageTable = new DataTable();
                languageAdapter.Fill(languageTable);
                List<Language> languages = new List<Language>();
                foreach (DataRow langaugeRow in languageTable.Rows) {
                    languages.Add((Language)langaugeRow.Field <int>(0));
                }
                races.Add(new Race(id, name, description, languages));
            }
           
            races.Sort();
            return races;
        }

        /// <summary>
        /// Retrieves a character's race
        /// </summary>
        /// <param name="characterId">Character id</param>
        /// <returns>The race of the character, or null if character does not exist</returns>
        public Race GetCharacterRace(int characterId) {
            int raceId = 0;

            using (conn = ConnectionFactory.GetConnection()) {
                conn.Open();

                SqlCommand cmd = new SqlCommand("SELECT raceid FROM character WHERE id=@ID;");
                cmd.Parameters.AddWithValue("@ID", characterId);
                cmd.Connection = conn;

                SqlDataReader reader = cmd.ExecuteReader();
                if (reader.Read()) {
                    raceId = Convert.ToInt32(reader["raceid"]);
                }
            } // DB Connection automatically disposed, must reinitialize since this method calls another method in the class

            conn = ConnectionFactory.GetConnection();

            Race race = GetRace(raceId);
            return race;
        }

        /// <summary>
        /// Retrieves a race record from the database
        /// </summary>
        /// <param name="raceId">ID of the race to retrieve</param>
        /// <returns>The race object</returns>
        public Race GetRace(int raceId) {
            Race race;
            string name = "";
            string description = "";
            List<Language> languages = new List<Language>();

            using (conn = ConnectionFactory.GetConnection()) {
                conn.Open();
                SqlCommand cmd = new SqlCommand($"" +
                    $"select Name, Description from race where Id = @rId");
                cmd.Parameters.AddWithValue("@rId", raceId);
                cmd.Connection = conn;

                SqlDataReader reader = cmd.ExecuteReader();
                while (reader.Read()) {
                    name = Convert.ToString(reader["name"]);
                    description = Convert.ToString(reader["description"]);
                }
                reader.Close();

                cmd = new SqlCommand($"" +
                    $"select LanguageID from raceLanguage where RaceID = @rId");
                cmd.Parameters.AddWithValue("@rId", raceId);
                cmd.Connection = conn;

                reader = cmd.ExecuteReader();
                while (reader.Read()) {
                    int languageId = Convert.ToInt32(reader["LanguageID"]);
                    languages.Add((Language)languageId);
                }
                reader.Close();

                race = new Race(name, description, languages);
                return race;
            }
        }
    }
}
