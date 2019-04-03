﻿using System;
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
            conn.Open();
            SqlCommand cmd = new SqlCommand($"select * from character where Id = @id");
            cmd.Parameters.AddWithValue("@id", characterID);
            cmd.Connection = conn;

            SqlDataReader reader = cmd.ExecuteReader();
            while (reader.Read())
            {
                int charID = Convert.ToInt32(reader["Id"]);
                string name = Convert.ToString(reader["Name"]);
                int str = Convert.ToInt32(reader["Strength"]);
                int dex = Convert.ToInt32(reader["Dexterity"]);
                int con = Convert.ToInt32(reader["Constitution"]);
                int intel = Convert.ToInt32(reader["Intelligence"]);
                int wis = Convert.ToInt32(reader["Wisdom"]);
                int chr = Convert.ToInt32(reader["Charisma"]);
                int strMod = Convert.ToInt32(reader["strMod"]);
                int dexMod = Convert.ToInt32(reader["dexMod"]);
                int conMod = Convert.ToInt32(reader["conMod"]);
                int intMod = Convert.ToInt32(reader["intMod"]);
                int wisMod = Convert.ToInt32(reader["wisMod"]);
                int chrMod = Convert.ToInt32(reader["chrMod"]);
                string hair = Convert.ToString(reader["Hair"]);
                string eyes = Convert.ToString(reader["Eyes"]);
                string skin = Convert.ToString(reader["Skin"]);
                string notes = Convert.ToString(reader["Notes"]);
                int raceID = Convert.ToInt32(reader["RaceID"]);
                int classID = Convert.ToInt32(reader["ClassID"]);
            }
            return null;
        }

        public int updateCharacter(int characterID)
        {
            return 0;
        }
    }
}
