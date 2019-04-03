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
            conn.Open();

            return 0;
        }

        public int deleteCharacter(int characterID)
        {
            return 0;
        }

        public Character getCharacter(int characterID)
        {
            int charID;
            string name;
            int str;
            int dex;
            int con;
            int intel;
            int wis;
            int chr;
            int strMod;
            int dexMod;
            int conMod;
            int intMod;
            int wisMod;
            int chrMod;
            string hair;
            string eyes;
            string skin;
            string notes;
            int raceID;
            int classID;

            conn.Open();
            SqlCommand cmd = new SqlCommand($"select * from character where Id = @id");
            cmd.Parameters.AddWithValue("@id", characterID);
            cmd.Connection = conn;

            SqlDataReader reader = cmd.ExecuteReader();
            while (reader.Read())
            {
                charID  = Convert.ToInt32(reader["Id"]);
                name = Convert.ToString(reader["Name"]);
                str     = Convert.ToInt32(reader["Strength"]);
                dex     = Convert.ToInt32(reader["Dexterity"]);
                con     = Convert.ToInt32(reader["Constitution"]);
                intel   = Convert.ToInt32(reader["Intelligence"]);
                wis     = Convert.ToInt32(reader["Wisdom"]);
                chr     = Convert.ToInt32(reader["Charisma"]);
                strMod  = Convert.ToInt32(reader["strMod"]);
                dexMod  = Convert.ToInt32(reader["dexMod"]);
                conMod  = Convert.ToInt32(reader["conMod"]);
                intMod  = Convert.ToInt32(reader["intMod"]);
                wisMod  = Convert.ToInt32(reader["wisMod"]);
                chrMod  = Convert.ToInt32(reader["chrMod"]);
                hair = Convert.ToString(reader["Hair"]);
                eyes = Convert.ToString(reader["Eyes"]);
                skin = Convert.ToString(reader["Skin"]);
                notes = Convert.ToString(reader["Notes"]);
                raceID  = Convert.ToInt32(reader["RaceID"]);
                classID = Convert.ToInt32(reader["ClassID"]);
            }
            
            return null;
        }
    }
}
