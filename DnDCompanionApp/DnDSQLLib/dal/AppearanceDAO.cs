using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CharacterCreationLib;

namespace DnDSQLLib.dal
{
    public class AppearanceDAO
    {
        SqlConnection conn;
        public AppearanceDAO()
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

        public int UploadAppearance(Character character)
        {
            int appearanceId;
            List<string> details = new List<string>();
            try
            {
                conn.Open();
                details.Add(character.Hair);
                details.Add(character.Eyes);
                details.Add(character.Skin);

                SqlCommand cmd = new SqlCommand($"" +
                    $"Insert Into characterAppearance (Hair, Eyes, Skin) Values (@h, @e, @s)");
                cmd.Parameters.AddWithValue("@h", details[0]);
                cmd.Parameters.AddWithValue("@e", details[1]);
                cmd.Parameters.AddWithValue("@s", details[2]);

                cmd.Connection = conn;
                appearanceId = Convert.ToInt32(cmd.ExecuteScalar());

                character.AppearanceID = appearanceId;

                return appearanceId;
            }
            catch (SqlException)
            {
                // **ERROR PLACE HOLDER**
                return -1;
            }
            finally
            {
                conn.Close();
            }
        }
        public int DeleteAppearance(int appearanceID)
        {
            int confirm;
            try
            {
                conn.Open();

                SqlCommand cmd = new SqlCommand($"" +
                    $"Delete From characterAppearance Where Id = @Id");

                cmd.Parameters.AddWithValue("@Id", appearanceID);
                cmd.Connection = conn;

                confirm = cmd.ExecuteNonQuery();
            }
            catch (SqlException)
            {
                // **ERROR PLACE HOLDER**
                confirm = -1;
            }
            finally
            {
                conn.Close();
            }
            return confirm;
        }
        public List<string> GetAppearance(int appearanceID)
        {
            List<string> details = new List<string>();

            try
            {
                conn.Open();
                SqlCommand cmd = new SqlCommand($"" +
                    $"Select Hair, Eyes, Skin From characterAppearance Where Id = @Id");
                cmd.Parameters.AddWithValue("@Id", appearanceID);
                cmd.Connection = conn;

                SqlDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    for (int i = 0; i < 3; i++)
                    {
                        details.Add(Convert.ToString(reader[i]));
                    }
                }
                reader.Close();
            }
            catch (SqlException)
            {
                // **ERROR PLACE HOLDER**
                details = null;
            }
            finally
            {
                conn.Close();
            }
            return details;
        }
        public int UpdateAppearance(string type, string newValue, int appearanceId, Character character)
        {
            int confirm = 0;

            try
            {
                conn.Open();
                SqlCommand cmd;
                switch (type)
                {
                    case "hair":
                        cmd = new SqlCommand($"Update characterAppearance Set Hair = @nV Where Id = @aI");
                        break;
                    case "eyes":
                        cmd = new SqlCommand($"Update characterAppearance Set Eyes = @nV Where Id = @aI");
                        break;
                    case "skin":
                        cmd = new SqlCommand($"Update characterAppearance Set Skin = @nV Where Id = @aI");
                        break;
                    default:
                        return -1;
                }
                cmd.Parameters.AddWithValue("@nV", newValue);
                cmd.Parameters.AddWithValue("@aI", appearanceId);
                cmd.Connection = conn;

                confirm = cmd.ExecuteNonQuery();

                if (character != null)
                {
                    switch (type)
                    {
                        case "hair":
                            character.Hair = newValue;
                            break;
                        case "eyes":
                            character.Eyes = newValue;
                            break;
                        case "skin":
                            character.Skin = newValue;
                            break;
                        default:
                            return -1;
                    }
                }
            }
            catch (SqlException)
            {
                // **ERROR PLACE HOLDER**
                return -1;
            }

            return 0;
        }

    }
}
