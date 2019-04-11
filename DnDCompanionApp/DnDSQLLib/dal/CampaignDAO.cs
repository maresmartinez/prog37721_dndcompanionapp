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
            conn = ConnectionFactory.GetConnection();
        }

        /// <summary>
        /// Uploads campaign to database and creates record that associates it with the users in it
        /// </summary>
        /// <param name="userId">User to be associated with campaign</param>
        /// <param name="campaign">Campaign to be uploaded</param>
        /// <returns>ID of the campaign that was created</returns>
        public int UploadCampaign(Campaign campaign) {
            int campaignId;

            using (conn = ConnectionFactory.GetConnection()) {
                conn.Open();

                // Insert campaign into campaigns table
                SqlCommand cmd = new SqlCommand("INSERT INTO campaign (name, description, dungeonMasterId) " +
                    "VALUES (@Name, @Description, @DM); SELECT SCOPE_IDENTITY();");
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
                    cmd.Parameters.AddWithValue("@CharID", campaignCharacter.DbID);
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
            List<int> userIds = new List<int>();
            List<int> characterIds = new List<int>();

            string name;
            string description;
            int dungeonMasterID;

            using (conn = ConnectionFactory.GetConnection()) {
                conn.Open();

                // Get the campaign
                SqlCommand cmd = new SqlCommand($"" +
                    $"select * from campaign where Id = @cId;");
                cmd.Parameters.AddWithValue("@cId", campaignId);
                cmd.Connection = conn;

                SqlDataReader reader = cmd.ExecuteReader();
                if (reader.Read()) {
                    name = Convert.ToString(reader["Name"]);
                    description = Convert.ToString(reader["Description"]);
                    dungeonMasterID = Convert.ToInt32(reader["dungeonMasterId"]);
                } else {
                    return null;
                }
                reader.Close();

                // Get ids for users in campaign
                cmd = new SqlCommand($"" +
                    $"select userId from userCampaign where campaignId = @cId;");
                cmd.Parameters.AddWithValue("@cId", campaignId);
                cmd.Connection = conn;

                reader = cmd.ExecuteReader();
                while (reader.Read()) {
                    userIds.Add(Convert.ToInt32(reader["userId"]));
                }
                reader.Close();

                // Get ids for characters in campaign
                cmd = new SqlCommand($"" +
                    $"select CharId from characterCampaign where campaignId = @cId;");
                cmd.Parameters.AddWithValue("@cId", campaignId);
                cmd.Connection = conn;

                reader = cmd.ExecuteReader();
                while (reader.Read()) {
                    characterIds.Add(Convert.ToInt32(reader["charId"]));
                }
                reader.Close();
            }

            // Populate list with users
            List<User> users = new List<User>();
            UserDAO uDAO = new UserDAO();
            foreach (int id in userIds) {
                users.Add(uDAO.GetUser(id));
            }
            User dungeonMaster = uDAO.GetUser(dungeonMasterID);

            // Populate list with characters
            List<Character> characters = new List<Character>();
            CharacterDAO cDAO = new CharacterDAO();
            foreach (int id in characterIds) {
                characters.Add(cDAO.GetCharacter(id));
            }

            // Instantiate campaign
            Campaign campaign = new Campaign(
                campaignId,
                name,
                description,
                users,
                characters,
                dungeonMaster
            );

            return campaign;
        }
    }
}
