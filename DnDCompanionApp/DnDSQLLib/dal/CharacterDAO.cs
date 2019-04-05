using CharacterCreationLib;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DnDSQLLib.dal {
    public class CharacterDAO {
        SqlConnection conn;

        public CharacterDAO() {
            try {
                conn = ConnectionFactory.GetConnection();
                conn.Open();
                conn.Close();   // Just double checking to make sure that yes, we can indeed access the server
            } catch (SqlException) {
                // Figure out how to let the user know that things just aint happening
            }
        }

        public int UploadCharacter(Character character) {
            int characterId;

            try {
                conn.Open();

                SqlCommand cmd = new SqlCommand($"" +
                    $"Insert into character (Name, Notes, StatsID, RaceID, ClassID, BackgroundID, AppearaneID)" +
                    $"Values (@name,@notes,@sid,@rid,@bid,@aid)");
                cmd.Parameters.AddWithValue("@name", character.Name);
                cmd.Parameters.AddWithValue("@notes", character.AdditionalNotes);
                cmd.Parameters.AddWithValue("@sid", character.StatID);
                cmd.Parameters.AddWithValue("@rid", character.RaceID);
                cmd.Parameters.AddWithValue("@bid", character.BackgroundID);
                cmd.Parameters.AddWithValue("@aid", character.AppearanceID);
                cmd.Connection = conn;

                characterId = Convert.ToInt32(cmd.ExecuteScalar());
                character.DbID = characterId;
                return characterId;
            } catch (SqlException) {
                // **ERROR PLACE HOLDER**
                characterId = -1;
                return characterId;
            } finally {
                conn.Close();
            }

        }
        public int DeleteCharacter(int characterId) {
            int count = 0;
            try {
                conn.Open();

                SqlCommand cmd = new SqlCommand($"" +
                    $"delete from character where Id = @cId");
                cmd.Parameters.AddWithValue("@cId", characterId);

                count = cmd.ExecuteNonQuery();
                return count;
            } catch (SqlException) {
                // **ERROR PLACE HOLDER**
                count = -1;
                return count;
            } finally {
                conn.Close();
            }
        }
        public Character GetCharacter(int characterId) {
            Background background;
            BackgroundDAO bDAO = new BackgroundDAO();

            AppearanceDAO aDAO = new AppearanceDAO();

            StatsDAO sDAO = new StatsDAO();

            RaceDAO rDAO = new RaceDAO();

            FeatureDAO fDAO = new FeatureDAO();

            Character character;
            ClassDAO cDAO = new ClassDAO();

            string name = "";
            string notes = "";
            int statsId = 0;
            int raceId = 0;
            int classId = 0;
            int backgroundId = 0;
            int appearanceId = 0;

            try {
                SqlCommand cmd = new SqlCommand($"" +
                    $"Select * from character where characterId = @cId");
                cmd.Parameters.AddWithValue("@cId", characterId);
                cmd.Connection = conn;

                SqlDataReader reader = cmd.ExecuteReader();
                while (reader.Read()) {
                    name = Convert.ToString(reader["Name"]);
                    notes = Convert.ToString(reader["Notes"]);
                    statsId = Convert.ToInt32(reader["statsID"]);
                    raceId = Convert.ToInt32(reader["RaceID"]);
                    classId = Convert.ToInt32(reader["ClassID"]);
                    backgroundId = Convert.ToInt32(reader["BackgroundID"]);
                    appearanceId = Convert.ToInt32(reader["AppearanceID"]);
                }
                List<int> stats = sDAO.GetStats(statsId);
                background = bDAO.GetBackground(backgroundId);
                List<string> appearance = aDAO.GetAppearance(appearanceId);
                List<Feature> features = fDAO.GetClassFeatures(classId);
                Race race = rDAO.GetRace(raceId);
                Class charClass = cDAO.GetClass(classId);


                character = new Character(
                    name, stats[0], stats[1], stats[2], stats[3], stats[4], stats[5], stats[6],
                    stats[7], stats[8], stats[9], stats[10], stats[11], features, background, appearance[0], appearance[1],
                    appearance[2], notes, race, charClass);
                character.DbID = characterId;
            } catch (SqlException) {
                // **ERROR PLACE HOLDER**
                character = null;
            }

            return character;
        }
    }
}
