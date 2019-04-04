﻿using CharacterCreationLib;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DnDSQLLib.dal
{
    public class ClassDAO
    {
        SqlConnection conn;
        public ClassDAO()
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

        public Class GetClass(int classID)
        {
            Class charClass;
            string name = "";
            string description = "";

            FeatureDAO fDAO = new FeatureDAO();
            List<Feature> features = fDAO.GetClassFeatures(classID);

            int hitDiceValue;
            Dice dice = null;

            SkillsDAO sDAO = new SkillsDAO();
            List<Skills> skills = sDAO.GetAllSkills();

            try
            {
                conn.Open();

                SqlCommand cmd = new SqlCommand($"" +
                        $"select Name, Description, hitDice from race where Id = @cId");
                cmd.Parameters.AddWithValue("@cId", classID);
                cmd.Connection = conn;

                SqlDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    name = Convert.ToString(reader["name"]);
                    description = Convert.ToString(reader["description"]);
                    hitDiceValue = Convert.ToInt32(reader["hitDice"]);
                    dice = new Dice(hitDiceValue);
                }
                reader.Close();

                charClass = new Class(name, description, features, dice, skills);

                return charClass;
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
