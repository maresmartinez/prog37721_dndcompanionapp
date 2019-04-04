using CharacterCreationLib;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DnDSQLLib.dal
{
    public class RaceDAO
    {
        SqlConnection conn;
        public RaceDAO()
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

        public Race GetRace(int raceId)
        {
            Race race;
            string name = "";
            string description = "";
            List<Language> languages = new List<Language>();

            try
            {
                conn.Open();
                SqlCommand cmd = new SqlCommand($"" +
                    $"select Name, Description from race where Id = @rId");
                cmd.Parameters.AddWithValue("@rId", raceId);
                cmd.Connection = conn;

                SqlDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    name = Convert.ToString(reader["name"]);
                    description = Convert.ToString(reader["description"]);
                }
                reader.Close();

                cmd = new SqlCommand($"" +
                    $"select LanguageID from raceLanguage where RaceID = @rId");
                cmd.Parameters.AddWithValue("@rId", raceId);
                cmd.Connection = conn;

                reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    string languageId = Convert.ToString(reader["LanguageID"]);
                    languages.Add((Language)Enum.ToObject(typeof(Language), languageId));
                }
                reader.Close();

                race = new Race(name, description, languages);
                return race;
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
