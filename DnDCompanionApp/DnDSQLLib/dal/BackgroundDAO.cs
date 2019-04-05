﻿using CharacterCreationLib;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DnDSQLLib.dal {
    public class BackgroundDAO {

        /// <summary>
        /// Connection to database
        /// </summary>
        SqlConnection conn;

        /// <summary>
        /// Constructor
        /// </summary>
        public BackgroundDAO() {
            try {
                conn = ConnectionFactory.GetConnection();
                conn.Open();
                conn.Close();   // Just double checking to make sure that yes, we can indeed access the server
            } catch (SqlException) {
                // Figure out how to let the user know that things just aint happening
            }
        }

        /// <summary>
        /// Adds character background to the database
        /// </summary>
        /// <param name="character">Character whose background is being added</param>
        /// <returns>Number of records that were added to the database</returns>
        public int UploadBackground(Character character) {
            int backgroundId;
            List<string> personality = character.CharacterBackground.Personality;
            List<string> ideal = character.CharacterBackground.Ideals;
            List<string> bond = character.CharacterBackground.Bonds;
            List<string> flaw = character.CharacterBackground.Flaws;

            List<int> personalityId = new List<int>();
            List<int> idealId = new List<int>();
            List<int> bondId = new List<int>();
            List<int> flawId = new List<int>();

            try {
                conn.Open();


                // Getting the IDs of each of the background stuff
                // Personality IDs
                for (int i = 0; i < 2; i++) {
                    SqlCommand cmd1 = new SqlCommand($"" +
                    $"Select Id from personality WHERE Description = @Desc");
                    cmd1.Parameters.AddWithValue("@Desc", personality[i]);
                    cmd1.Connection = conn;

                    SqlDataReader reader1 = cmd1.ExecuteReader();
                    while (reader1.Read())
                        personalityId.Add(Convert.ToInt32(reader1["0"]));
                    reader1.Close();
                }

                // Ideal ID
                SqlCommand cmd = new SqlCommand($"" +
                    $"Select Id from ideal WHERE Description = @Desc");
                cmd.Parameters.AddWithValue("@Desc", ideal[0]);
                cmd.Connection = conn;

                SqlDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                    idealId.Add(Convert.ToInt32(reader["0"]));
                reader.Close();

                // Bond ID
                cmd = new SqlCommand($"" +
                    $"Select Id from bond WHERE Description = @Desc");
                cmd.Parameters.AddWithValue("@Desc", bond[0]);
                cmd.Connection = conn;

                reader = cmd.ExecuteReader();
                while (reader.Read())
                    bondId.Add(Convert.ToInt32(reader["0"]));
                reader.Close();

                // Flaw ID
                cmd = new SqlCommand($"" +
                    $"Select Id from flawId WHERE Description = @Desc");
                cmd.Parameters.AddWithValue("@Desc", flaw[0]);
                cmd.Connection = conn;

                reader = cmd.ExecuteReader();
                while (reader.Read())
                    flawId.Add(Convert.ToInt32(reader["0"]));
                reader.Close();

                // Inserting the Record
                cmd = new SqlCommand($"" +
                    $"Insert into background (PersonalityID1, PersonalityID2, IdealID, BondID, FlawID)" +
                    $"Values (@pid1, @pid2, @iid, @bid, @fid");
                cmd.Parameters.AddWithValue("@pid1", personalityId[0]);
                cmd.Parameters.AddWithValue("@pid2", personalityId[1]);
                cmd.Parameters.AddWithValue("@iid", idealId[0]);
                cmd.Parameters.AddWithValue("@bid", bondId[0]);
                cmd.Parameters.AddWithValue("@fid", flawId[0]);
                cmd.Connection = conn;

                backgroundId = Convert.ToInt32(cmd.ExecuteScalar());
                character.BackgroundID = backgroundId;
                return backgroundId;
            } catch (SqlException) {
                // **ERROR PLACE HOLDER**
                backgroundId = -1;
                return backgroundId;
            } finally {
                conn.Close();
            }
        }

        /// <summary>
        /// Deletes a background from the database
        /// </summary>
        /// <param name="backgroundId">ID of the background to be deleted</param>
        /// <returns>The number of records that were affected</returns>
        public int DeleteBackground(int backgroundId) {
            int count = 0;
            try {
                conn.Open();

                SqlCommand command = new SqlCommand($"" +
                    $"delete from background where Id = @bId");
                command.Parameters.AddWithValue("@bId", backgroundId);
                command.Connection = conn;

                count = command.ExecuteNonQuery();
                return count;
            } catch (SqlException) {
                // Figure out how to deliver a good error message for the user
                count = -1;
                return count;
            } finally {
                conn.Close();
            }
        }

        public List<BackgroundType> GetAllBgTypes()
        {
            List<BackgroundType> bgTypes = new List<BackgroundType>();
            int dbId = 0;
            string name = "";
            string desc = "";

            try
            {
                conn.Open();

                SqlCommand cmd = new SqlCommand($"Select * from backgroundType");
                cmd.Connection = conn;

                SqlDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    bgTypes.Add(new BackgroundType(Convert.ToInt32(reader["Id"]), Convert.ToString(reader["Name"]), Convert.ToString(reader["Description"])));
                }
                return bgTypes;
            }
            catch (SqlException)
            {
                // Figure out what to give with the exception
                return null;
            }
            finally
            {
                conn.Close();
            }
        }

        public BackgroundType GetBgType(int bgTypeId)
        {
            BackgroundType bgType = null;

            try
            {
                conn.Open();

                SqlCommand cmd = new SqlCommand($"select t.Name, t.Description from backgroundType t where Id = @bId");
                cmd.Connection = conn;

                SqlDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    bgType = new BackgroundType(bgTypeId, Convert.ToString(reader["Name"]), Convert.ToString(reader["Description"]));  
                }
                reader.Close();
                return bgType;
            }
            catch (SqlException)
            {
                // Figure out what to give with the exception
                return null;
            }
            finally
            {
                conn.Close();
            }
        }

        public List<string> GetPossibleTraits(int bgTypeId, string traitType)
        {
            List<string> traits = new List<string>();

            try
            {
                conn.Open();
                SqlCommand cmd = null;
                switch (traitType)
                {
                    case "personality":
                        cmd = new SqlCommand($"" +
                            $"select p.Description from personality p" +
                            $"join bgTypePersonality bg on bg.PersonalityId = p.Id" +
                            $"WHERE bg.TypeId = @bId");
                        break;
                    case "ideal":
                        cmd = new SqlCommand($"" +
                            $"select i.Description from ideal i" +
                            $"join bgTypeIdeal bg on bg.IdealId = i.Id" +
                            $"WHERE bg.TypeId = @bId");
                        break;
                    case "bond":
                        cmd = new SqlCommand($"" +
                            $"select b.Description from bond b" +
                            $"join bgTypeBond bg on bg.BondId = b.Id" +
                            $"WHERE bg.TypeId = @bId");
                        break;
                    case "flaw":
                        cmd = new SqlCommand($"" +
                            $"select f.Description from flaw f" +
                            $"join bgTypeFlaw bg on bg.FlawId = f.Id" +
                            $"WHERE bg.TypeId = @bId");
                        break;
                    default:
                        return null;
                }
                cmd.Parameters.AddWithValue("@bId", bgTypeId);
                cmd.Connection = conn;

                SqlDataReader reader = cmd.ExecuteReader();
                while(reader.Read())
                {
                    traits.Add(Convert.ToString(reader["Description"]));
                }
                reader.Close();

                return traits;
            }
            catch (SqlException)
            {
                // Error message placeholder
                return null;
            }
            finally
            {
                conn.Close();
            }
        }

        public Background GetBackground(int backgroundId, BackgroundType bgType) {
            Background background;
            List<string> personality = new List<string>();
            List<string> ideal = new List<string>();
            List<string> bond = new List<string>();
            List<string> flaw = new List<string>();

            try {
                conn.Open();

                // Personality
                SqlCommand cmd = new SqlCommand($"" +
                    $"Select" +
                    $"p.Description AS 'P1', p2.Description AS 'P2'" +
                    $"FROM background bg" +
                    $"INNER JOIN personality p on p.Id = bg.PersonalityID1" +
                    $"INNER JOIN personality p2 on p2.Id = bg.PersonalityID2" +
                    $"where bg.Id = @bId");

                cmd.Parameters.AddWithValue("@bId", backgroundId);
                cmd.Connection = conn;

                SqlDataReader reader = cmd.ExecuteReader();
                while(reader.Read())
                {
                    personality.Add(Convert.ToString(reader["P1"]));
                    personality.Add(Convert.ToString(reader["P2"]));
                }
                reader.Close();

                // Ideal
                cmd = new SqlCommand($"" +
                    $"Select" +
                    $"i.Description AS 'I1', i2.Description AS 'I2'" +
                    $"FROM background bg" +
                    $"INNER JOIN ideal i on i.Id = bg.IdealID1" +
                    $"INNER JOIN ideal i2 on i2.Id = bg.IdealID2" +
                    $"where bg.Id = @bId");

                cmd.Parameters.AddWithValue("@bId", backgroundId);
                cmd.Connection = conn;

                reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    ideal.Add(Convert.ToString(reader["I1"]));
                    ideal.Add(Convert.ToString(reader["I2"]));
                }
                reader.Close();

                // Bond
                cmd = new SqlCommand($"" +
                    $"Select" +
                    $"b.Description AS 'B1', b2.Description AS 'B2'" +
                    $"FROM background bg" +
                    $"INNER JOIN bond b on b.Id = bg.BondID1" +
                    $"INNER JOIN bond b2 on b2.Id = bg.BondID2" +
                    $"where bg.Id = @bId");

                cmd.Parameters.AddWithValue("@bId", backgroundId);
                cmd.Connection = conn;

                reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    bond.Add(Convert.ToString(reader["B1"]));
                    bond.Add(Convert.ToString(reader["B2"]));
                }
                reader.Close();

                // Flaw
                cmd = new SqlCommand($"" +
                    $"Select" +
                    $"f.Description AS 'F1', f2.Description AS 'F2'" +
                    $"FROM background bg" +
                    $"INNER JOIN flaw f on f.Id = bg.FlawID1" +
                    $"INNER JOIN flaw f2 on f2.Id = bg.FlawID2" +
                    $"where bg.Id = @bId");

                cmd.Parameters.AddWithValue("@bId", backgroundId);
                cmd.Connection = conn;

                reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    flaw.Add(Convert.ToString(reader["F1"]));
                    flaw.Add(Convert.ToString(reader["F2"]));
                }
                reader.Close();



                //SqlCommand cmd = new SqlCommand($"" +
                //    $"select" +
                //    $"p.Description AS 'Personality1', p2.Description AS 'Personality2'," +
                //    $"i.Description AS 'Ideal', b.Description AS 'Bond', f.Description AS 'Flaw'" +
                //    $"FROM background bg " +
                //    $"INNER JOIN personality p on p.Id = bg.PersonalityID1" +
                //    $"INNER JOIN personality p2 on p2.Id = bg.PersonalityID2" +
                //    $"INNER JOIN ideal i on i.Id = bg.IdealID" +
                //    $"INNER JOIN bond b on b.Id = bg.BondID" +
                //    $"INNER JOIN flaw f on f.Id = bg.FlawID" +
                //    $"WHERE bg.Id = @Id");
                //cmd.Parameters.AddWithValue("@Id", backgroundId);
                //cmd.Connection = conn;

                //SqlDataReader reader = cmd.ExecuteReader();
                //while (reader.Read())
                //{
                //    personality.Add(Convert.ToString(reader["Personality1"]));
                //    personality.Add(Convert.ToString(reader["Personality2"]));
                //    ideal.Add(Convert.ToString(reader["Ideal1"]));
                //    ideal.Add(Convert.ToString(reader["Ideal2"]));
                //    bond.Add(Convert.ToString(reader["Bond1"]));
                //    bond.Add(Convert.ToString(reader["Bond2"]));
                //    flaw.Add(Convert.ToString(reader["Flaw1"]));
                //    flaw.Add(Convert.ToString(reader["Flaw2"]));
                //}
                //reader.Close();

                background = new Background(bgType.Name, bgType.Description, personality, ideal, bond, flaw);
                background.BackgroundId = backgroundId;

            } catch (SqlException) {
                // Figure out what to give with the exception
                background = null;
            } finally {
                conn.Close();
            }

            return background;
        }

        /// <summary>
        /// Retrieves all backgrounds from the database
        /// </summary>
        /// <returns>Collection of backgrounds</returns>
        //public List<Background> GetAllBackgrounds() {
            // TODO: implement method to retrieve all backgrounds
        //}
    }
}
