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
    public class CampaignDAO
    {
        SqlConnection conn;

        public CampaignDAO()
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

        public Campaign GetCampaign(int campaignId)
        {
            Campaign campaign = null;

            try
            {
                conn.Open();
                // Get the users in campaign
                List<User> users = new List<User>();
                UserDAO uDAO = new UserDAO();
                SqlCommand cmd = new SqlCommand($"" +
                    $"select userId from campaign where Id = @cId");
                cmd.Parameters.AddWithValue("@cId", campaignId);
                cmd.Connection = conn;

                SqlDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    users.Add(uDAO.GetUser(Convert.ToInt32(reader["UserId"])));
                }
                reader.Close();

                // Get the characters in campaign
                List<Character> characters = new List<Character>();
                CharacterDAO cDAO = new CharacterDAO();
                cmd = new SqlCommand($"" +
                    $"select CharId from campaign where Id = @cId");
                cmd.Parameters.AddWithValue("@cId", campaignId);
                cmd.Connection = conn;

                reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    characters.Add(cDAO.GetCharacter(Convert.ToInt32(reader["CharId"])));
                }
                reader.Close();

                cmd = new SqlCommand($"" +
                    $"select * from campaign where Id = @cId");
                cmd.Parameters.AddWithValue("@cId", campaignId);
                cmd.Connection = conn;

                // Get the campaign
                reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    campaign = new Campaign(Convert.ToString(reader["Name"]),
                        Convert.ToString(reader["Description"]),
                        users,
                        characters,
                        uDAO.GetUser(Convert.ToInt32(reader["dungeonMasterId"])));
                }
                reader.Close();
                return campaign;
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
