using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using CharacterCreationLib;

namespace DnDSQLLib.dal
{
    public class CharacterDAO
    {
        SqlConnection conn;

        public CharacterDAO()
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

        public int addCharacter(Character character)
        {
            BackgroundDAO bgDAO = new BackgroundDAO();
            try
            {
                conn.Open();
                bgDAO.UploadBackground(character.CharacterBackground);
            }
            catch (SqlException)
            {
                // Figure out a good way to get an error message across
            }
            finally
            {
                conn.Close();
            }

            return 0;
        }

        public int deleteCharacter(int characterID)
        {
            int count = 0;
            try
            {
                conn.Open();
                SqlCommand cmd = new SqlCommand($"" +
                    $"delete from character where Id = @chId");
                cmd.Parameters.AddWithValue("@chId", characterID);
                cmd.Connection = conn;

                count = cmd.ExecuteNonQuery();
            }
            catch (SqlException)
            {
                // Figure out how to deliver a good error message;
            }
            finally
            {
                conn.Close();
            }
            return count;
        }

        public Character getCharacter(int characterID)
        {
            BackgroundDAO bgDAO = new BackgroundDAO();
            Character character;
            int charID = 0;
            string name = "";
            int str = 0;
            int dex = 0;
            int con = 0;
            int intel = 0;
            int wis = 0;
            int chr = 0;
            int strMod = 0;
            int dexMod = 0;
            int conMod = 0;
            int intMod = 0;
            int wisMod = 0;
            int chrMod = 0;
            string hair = "";
            string eyes = "";
            string skin = "";
            string notes = "";
            Background bg = null;
            int backgroundId = 0;
            int raceID = 1;     // Setting up defaults in the event these vars are not properly initialized
            string raceName = "";
            string raceDesc = "";
            Race race;
            int classID = 1;    // Setting up defaults in the event these vars are not properly initialized
            Class charClass = new Class();
            List<Skills> skills = new List<Skills>();
            List<Feature> features = new List<Feature>();
            List<Language> languages = new List<Language>();
            try
            {
                conn.Open();
                SqlCommand cmd = new SqlCommand($"select * from character where Id = @id");
                cmd.Parameters.AddWithValue("@id", characterID);
                cmd.Connection = conn;

                SqlDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    charID = Convert.ToInt32(reader["Id"]);
                    name = Convert.ToString(reader["Name"]);
                    str = Convert.ToInt32(reader["Strength"]);
                    dex = Convert.ToInt32(reader["Dexterity"]);
                    con = Convert.ToInt32(reader["Constitution"]);
                    intel = Convert.ToInt32(reader["Intelligence"]);
                    wis = Convert.ToInt32(reader["Wisdom"]);
                    chr = Convert.ToInt32(reader["Charisma"]);
                    strMod = Convert.ToInt32(reader["strMod"]);
                    dexMod = Convert.ToInt32(reader["dexMod"]);
                    conMod = Convert.ToInt32(reader["conMod"]);
                    intMod = Convert.ToInt32(reader["intMod"]);
                    wisMod = Convert.ToInt32(reader["wisMod"]);
                    chrMod = Convert.ToInt32(reader["chrMod"]);
                    hair = Convert.ToString(reader["Hair"]);
                    eyes = Convert.ToString(reader["Eyes"]);
                    skin = Convert.ToString(reader["Skin"]);
                    notes = Convert.ToString(reader["Notes"]);
                    raceID = Convert.ToInt32(reader["RaceID"]);
                    classID = Convert.ToInt32(reader["ClassID"]);
                }
                reader.Close();

                // Getting Class Object
                cmd = new SqlCommand($"" +
                    $"select Name, Description, hitDice from class where Id = @cId");
                cmd.Parameters.AddWithValue("@cId", classID);
                cmd.Connection = conn;

                reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    charClass.Name = Convert.ToString(reader["Name"]);
                    charClass.Description = Convert.ToString(reader["Description"]);
                    charClass.HitDice = new Dice(Convert.ToInt32(reader["hitDice"]));
                }
                reader.Close();

                // Getting Skills
                cmd = new SqlCommand($"" +
                    $"select skillId from classSkills where classId = @cId");
                cmd.Parameters.AddWithValue("@cId", classID);
                cmd.Connection = conn;

                reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    int skillid = Convert.ToInt32(reader["skillId"]);
                    skills.Add((Skills)skillid);
                }
                reader.Close();

                // Get Features
                cmd = new SqlCommand($"" +
                    $"select f.Name, f.Description from features f" +
                    $"join classFeatures cf on cf.FeatureId = f.Id" +
                    $"join class c on cf.ClassId = c.Id" +
                    $"where c.Id = @cId");
                cmd.Parameters.AddWithValue("@cId", classID);
                cmd.Connection = conn;

                reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    features.Add(new Feature(Convert.ToString(reader["Name"]), Convert.ToString(reader["Description"])));
                }
                reader.Close();

                // Get Race
                cmd = new SqlCommand($"" +
                    $"select Name, Description from race where Id = @rId");
                cmd.Parameters.AddWithValue("@rId", raceID);
                cmd.Connection = conn;

                reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    raceName = Convert.ToString(reader["Name"]);
                    raceDesc = Convert.ToString(reader["Description"]);
                }
                reader.Close();

                // Languages
                cmd = new SqlCommand($"" +
                    $"select LanguageId from raceLanguage where raceId = @rId");
                cmd.Parameters.AddWithValue("@rId", raceID);
                cmd.Connection = conn;

                reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    int languageid = Convert.ToInt32(reader["LanguageID"]);
                    languages.Add((Language)languageid);
                }
                reader.Close();

                race = new Race(raceName, raceDesc, languages);

                // Getting Background
                cmd = new SqlCommand($"" +
                    $"select BackgroundId from character where Id = @chId");
                cmd.Parameters.AddWithValue("@chId", characterID);
                cmd.Connection = conn;

                reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    backgroundId = Convert.ToInt32(reader["BackgroundId"]);
                }
                bg = bgDAO.GetBackground(backgroundId);

                character = new Character(name, str, dex, con, intel, wis, chr, strMod, dexMod, conMod, intMod, wisMod, chrMod, features, bg, hair, eyes, skin, notes, race, charClass);
            }
            catch (SqlException)
            {
                // Figure out a good way to notify the users
                character = null;
            }
            finally
            {
                conn.Close();
            }
            return character;
        }
    }
}
