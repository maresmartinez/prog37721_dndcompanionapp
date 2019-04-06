using CharacterCreationLib;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UserManagementLib;

namespace DnDSQLLib.dal {
    /// <summary>
    /// Interface between campaign class and campaign tables in database
    /// </summary>
    public class CampaignDAO {

        /// <summary>
        /// Connection to database
        /// </summary>
        SqlConnection conn;

        /// <summary>
        /// Constructor
        /// </summary>
        public CampaignDAO() {
            try {
                conn = ConnectionFactory.GetConnection();
                conn.Open();
                conn.Close();   // Just double checking to make sure that yes, we can indeed access the server
            } catch (SqlException) {
                // Figure out how to let the user know that things just aint happening
            }
        }

        /// <summary>
        /// Uploads campaign to database and creates record that associates it with the users in it
        /// </summary>
        /// <param name="userId">User to be associated with campaign</param>
        /// <param name="campaign">Campaign to be uploaded</param>
        /// <returns>Number of rows that were affected in the database</returns>
        public int UploadCampaign(Campaign campaign) {
            int campaignId;

            using (conn) {
                conn.Open();

                // Insert campaign into campaigns table
                SqlCommand cmd = new SqlCommand("INSERT INTO campaign (id, name, description, dungeonMasterId) " +
                    "VALUES (@CID, @Name, @Description, @DM)");
                cmd.Parameters.AddWithValue("@CID", campaign.ID);
                cmd.Parameters.AddWithValue("@Name", campaign.CampaignName);
                cmd.Parameters.AddWithValue("@Description", campaign.CampaignDescription);
                cmd.Parameters.AddWithValue("@DM", campaign.DungeonMaster.ID);
                cmd.Connection = conn;

                campaignId = Convert.ToInt32(cmd.ExecuteScalar());
                campaign.ID = campaignId;

                // Insert campaign into userCampaign table to associate with users
                foreach (User campaignUser in campaign.CampaignUsers) {
                    cmd = new SqlCommand("INSERT INTO userCampaign (userid, campaignid) " +
                    "VALUES (@UID, @CID)");
                    cmd.Connection = conn;
                    cmd.Parameters.AddWithValue("@UID", campaignUser.ID);
                    cmd.Parameters.AddWithValue("@CID", campaign.ID);
                    cmd.ExecuteNonQuery();
                }

                // Insert campaign into characterCampaign table to associate with characters
                foreach (Character campaignCharacter in campaign.CampaignCharacters) {
                    cmd = new SqlCommand("INSERT INTO characterCampaign (charId, campaignId) " +
                    "VALUES (@CharID, @CampID)");
                    cmd.Connection = conn;
                    //cmd.Parameters.AddWithValue("@CharID", campaignCharacter.ID); //TODO: add ID to character class
                    cmd.Parameters.AddWithValue("@CampID", campaign.ID);
                    cmd.ExecuteNonQuery();
                }
            }

            return campaignId;
        }

        /// <summary>
        /// Retrieves campaign record from database
        /// </summary>
        /// <param name="campaignId">Campaign to be retrieved</param>
        /// <returns>Campaign</returns>
        public Campaign GetCampaign(int campaignId) {
            Campaign campaign = null;

            try {
                conn.Open();
                // Get the users in campaign
                List<User> users = new List<User>();
                UserDAO uDAO = new UserDAO();
                SqlCommand cmd = new SqlCommand($"" +
                    $"select userId from campaign where Id = @cId");
                cmd.Parameters.AddWithValue("@cId", campaignId);
                cmd.Connection = conn;

                SqlDataReader reader = cmd.ExecuteReader();
                while (reader.Read()) {
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
                while (reader.Read()) {
                    characters.Add(cDAO.GetCharacter(Convert.ToInt32(reader["CharId"])));
                }
                reader.Close();

                cmd = new SqlCommand($"" +
                    $"select * from campaign where Id = @cId");
                cmd.Parameters.AddWithValue("@cId", campaignId);
                cmd.Connection = conn;

                // Get the campaign
                reader = cmd.ExecuteReader();
                while (reader.Read()) {
                    campaign = new Campaign(Convert.ToInt32(reader["id"]),
                        Convert.ToString(reader["Name"]),
                        Convert.ToString(reader["Description"]),
                        users,
                        characters,
                        uDAO.GetUser(Convert.ToInt32(reader["dungeonMasterId"])));
                }
                reader.Close();
                return campaign;
            } catch (SqlException) {
                // **ERROR PLACE HOLDER**
                return null;
            } finally {
                conn.Close();
            }
        }
    }
}
