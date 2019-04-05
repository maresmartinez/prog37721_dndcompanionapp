using CharacterCreationLib;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UserManagementLib;

namespace DnDSQLLib.dal
{
    public class UserDAO
    {
        SqlConnection conn;

        public UserDAO()
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

        public List<Character> GetUserCharacters(int userId)
        {
            List<Character> characters = new List<Character>();

            try
            {
                conn.Open();
                SqlCommand cmd = new SqlCommand($"" +
                    $"select charId from userCharacter where userId = @uId");
                cmd.Parameters.AddWithValue("@uId", userId);
                cmd.Connection = conn;

                CharacterDAO cDAO = new CharacterDAO();

                SqlDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    characters.Add(cDAO.GetCharacter(Convert.ToInt32(reader["charId"])));
                }
                reader.Close();

                return characters;
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

        public List<Campaign> GetUserCampaigns(int userId)
        {
            List<Campaign> campaigns = new List<Campaign>();

            try
            {
                conn.Open();

                CampaignDAO camDAO = new CampaignDAO();

                SqlCommand cmd = new SqlCommand($"" +
                    $"select CampaignId from userCampaign where userId = @uId");
                cmd.Parameters.AddWithValue("@uId", userId);

                SqlDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    campaigns.Add(camDAO.GetCampaign(Convert.ToInt32(reader["CampaignId"])));
                }
                reader.Close();
                return campaigns;
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

        public User GetUser(int userId)
        {
            User user = null;

            try
            {
                conn.Open();
                SqlCommand cmd = new SqlCommand($"" +
                    $"select * from users where Id = @uId");
                cmd.Parameters.AddWithValue("@uId", userId);
                cmd.Connection = conn;

                SqlDataReader reader = cmd.ExecuteReader();
                while(reader.Read())
                {
                    user = new User(Convert.ToString(reader["userName"]),
                        Convert.ToString(reader["fullName"]),
                        GetUserCharacters(userId),
                        Convert.ToString(reader["Password"]),
                        GetUserCampaigns(userId));
                }
                reader.Close();

                return user;
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
