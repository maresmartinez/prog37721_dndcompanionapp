using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using UserManagementLib;
using CharacterCreationLib;
using DnDSQLLib.dal;

namespace DnDWebApp.Users.Campaigns {
    public partial class SeeAllCampaigns : System.Web.UI.Page {

        /// <summary>
        /// Reference to all of the logged in user's campaigns
        /// </summary>
        List<Campaign> userCampaigns;

        /// <summary>
        /// Retrieves all the logged in user's campaigns and displays them, if any.
        /// If the user has no characters, then a message is displayed telling them so.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void Page_Load(object sender, EventArgs e) {

            if (Request.QueryString["newCampaign"] != null) {
                NewCampaign.Visible = true;
            }

            InitCampaigns();

            if (!IsPostBack) {
                if (userCampaigns.Count > 0) {
                    DisplayCampaignDetails(userCampaigns[0]);
                } else {
                    LblCampaigns.Visible = false;
                    DDCampaigns.Visible = false;
                    LblNoCampaigns.Text = "You have no campaigns to display.";
                }

                DDCampaigns.DataSource = userCampaigns;
                DDCampaigns.DataBind();
            }
        }

        /// <summary>
        /// Displays the selected campaign
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void DDCampaigns_SelectedIndexChanged(object sender, EventArgs e) {
            Campaign campaign = userCampaigns[DDCampaigns.SelectedIndex];
            DisplayCampaignDetails(campaign);
        }

        /// <summary>
        /// Displays the selected campaign
        /// </summary>
        /// <param name="campaign">Campaign to be displayed</param>
        private void DisplayCampaignDetails(Campaign campaign) {
            LblCampaignName.Text = campaign.CampaignName;
            CampaignDescription.InnerText = campaign.CampaignDescription;
            DMName.InnerText = campaign.DungeonMaster.FullName + " (" + campaign.DungeonMaster.Username + ")";

            DDPartyMembers.DataSource = campaign.CampaignCharacters;
            DDPartyMembers.DataBind();

            // Ensure the first character is displayed
            DisplayCharacterDetails(campaign.CampaignUsers[0], campaign.CampaignCharacters[0]);

            CampaignDetails.Visible = true;
        }

        /// <summary>
        /// Displays the selected campaign character's details
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void DDPartyMembers_SelectedIndexChanged(object sender, EventArgs e) {
            User user = userCampaigns[DDCampaigns.SelectedIndex].CampaignUsers[DDPartyMembers.SelectedIndex];
            Character character = userCampaigns[DDCampaigns.SelectedIndex].CampaignCharacters[DDPartyMembers.SelectedIndex];
            DisplayCharacterDetails(user, character);
        }

        /// <summary>
        /// Displays the selected campaign character's details
        /// </summary>
        /// <param name="character">The campaign character to display</param>
        private void DisplayCharacterDetails(User user, Character character) {
            CharacterUser.InnerText = user.FullName + " (" + user.Username + ")";

            RaceDesc.InnerText = character.Race.Name + ": " + character.Race.Description;
            BLLanguages.Items.Clear();
            foreach (Language language in character.Race.Languages) {
                BLLanguages.Items.Add(language.ToString());
            }

            ClassDesc.InnerText = character.CharacterClass.Name + ": " + character.CharacterClass.Description;
            BLFeatures.Items.Clear();
            foreach (Feature feature in character.CharacterClass.Features) {
                BLFeatures.Items.Add(feature.ToString());
            }
            HitDice.InnerText = character.CharacterClass.HitDice.ToString();
            BLSkills.Items.Clear();
            foreach (Skills skill in character.CharacterClass.CharacterSkills) {
                BLSkills.Items.Add(skill.ToString());
            }

            BackgroundDesc.InnerText = character.CharacterBackground.Name + ": " + character.CharacterBackground.Description;

            PhysicalDesc.InnerText = $"Hair: {character.Hair}, Eyes: {character.Eyes}, Skin: {character.Skin}";
        }

        /// <summary>
        /// Queries the database and retrieves all of the logged in user's campaigns
        /// </summary>
        private void InitCampaigns() {
            UserDAO userDAO = new UserDAO();
            User user = userDAO.GetUser(Context.User.Identity.Name);
            userCampaigns = userDAO.GetUserCampaigns(user.ID);
        }

    }
}