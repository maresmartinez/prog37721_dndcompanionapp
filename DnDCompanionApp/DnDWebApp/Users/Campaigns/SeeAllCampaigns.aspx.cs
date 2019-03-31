using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using UserManagementLib;
using CharacterCreationLib;

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
        /// 
        /// TODO: implement database functionality
        /// </summary>
        private void InitCampaigns() {
            // Create Characters
            Character character1 = new Character();
            character1.Name = "Test Character 1";
            character1.Strength = 20;
            character1.Dexterity = 20;
            character1.Constitution = 20;
            character1.Intelligence = 20;
            character1.Wisdom = 20;
            character1.Charisma = 20;
            character1.StrMod = 5;
            character1.DexMod = 5;
            character1.ConMod = 5;
            character1.IntMod = 5;
            character1.WisMod = 5;
            character1.ChrMod = 5;
            character1.FeatureList = new List<Feature>(
                    // Initializing list with features
                    new Feature[] {
                        new Feature("Second Wind",
                            "You have a limited well of stamina that you can draw on to protect " +
                            "yourself from harm."),
                        new Feature("Action Surge",
                            "You can push yourself beyond your normal limits for a moment. On your " +
                            "turn, you can take one additional action."),
                        new Feature("Martial Archetype",
                            "You choose an archetype that you strive to emulate in your combat styles " +
                            "and techniques. Choose Chamption, Battle Master, or Eldritch Knight.")
                    }
                );
            character1.CharacterBackground = new Background(
                "Acolyte",
                "You have spent your life in the service of a temple to a specific god or pantheon of gods.",
                new List<string>(
                    new string[] {
                        "I idolize a particular hero of my faith, and constantly refer to that person’s deeds and example.",
                        "I can find common ground between the fiercest enemies, empathizing with them and always working toward peace.",
                    }
                ),
                new List<string>(
                    new string[] {
                        "Tradition. The ancient traditions of worship and sacrifice must be preserved and upheld. (Lawful)",
                        "Charity. I always try to help those in need, no matter what the personal cost. (Good)",
                    }
                ),
                new List<string>(
                    new string[] {
                        "I would die to recover an ancient relic of my faith that was lost long ago.",
                        "I will someday get revenge on the corrupt temple hierarchy who branded me a heretic.",
                    }
                ),
                new List<string>(
                    new string[] {
                        "I judge others harshly, and myself even more severely.",
                        "I put too much trust in those who wield power within my temple’s hierarchy.",
                    }
                )
            );
            character1.Hair = "Red";
            character1.Eyes = "Brown";
            character1.Skin = "Scales";
            character1.AdditionalNotes = "N/A";
            character1.Race = new Race(
                "Dragonborn",
                "Dragonborn look very much like dragons standing erect in humanoid form, " +
                "though they lack wings or a tail.",
                new List<Language>(
                    new Language[] {
                        Language.DRACONAIN
                    }
                )
            );
            character1.CharacterClass = new Class(
                "Fighter",
                "A master of martial combat, skilled with a variety of weapons and armor.",
                new List<Feature>(
                    // Initializing list with features
                    new Feature[] {
                        new Feature("Second Wind",
                            "You have a limited well of stamina that you can draw on to protect " +
                            "yourself from harm."),
                        new Feature("Action Surge",
                            "You can push yourself beyond your normal limits for a moment. On your " +
                            "turn, you can take one additional action."),
                        new Feature("Martial Archetype",
                            "You choose an archetype that you strive to emulate in your combat styles " +
                            "and techniques. Choose Chamption, Battle Master, or Eldritch Knight.")
                    }
                ),
                new Dice(10),
                new List<Skills>(
                    new Skills[] {
                        Skills.ACROBATICS,
                        Skills.ANIMAL_HANDLING,
                        Skills.ATHLETICS,
                        Skills.HISTORY,
                        Skills.INSIGHT,
                        Skills.INTIMIDATION,
                        Skills.PERCEPTION,
                        Skills.SURVIVAL
                    }
                )
            );

            Character character2 = new Character();
            character2.Name = "Test Character 2";
            character2.Strength = 20;
            character2.Dexterity = 20;
            character2.Constitution = 20;
            character2.Intelligence = 20;
            character2.Wisdom = 20;
            character2.Charisma = 20;
            character2.StrMod = 5;
            character2.DexMod = 5;
            character2.ConMod = 5;
            character2.IntMod = 5;
            character2.WisMod = 5;
            character2.ChrMod = 5;
            character2.FeatureList = new List<Feature>(
                    // Initializing list with features
                    new Feature[] {
                        new Feature("Second Wind",
                            "You have a limited well of stamina that you can draw on to protect " +
                            "yourself from harm."),
                        new Feature("Action Surge",
                            "You can push yourself beyond your normal limits for a moment. On your " +
                            "turn, you can take one additional action."),
                        new Feature("Martial Archetype",
                            "You choose an archetype that you strive to emulate in your combat styles " +
                            "and techniques. Choose Chamption, Battle Master, or Eldritch Knight.")
                    }
                );
            character2.CharacterBackground = new Background(
                "Acolyte",
                "You have spent your life in the service of a temple to a specific god or pantheon of gods.",
                new List<string>(
                    new string[] {
                        "I idolize a particular hero of my faith, and constantly refer to that person’s deeds and example.",
                        "I can find common ground between the fiercest enemies, empathizing with them and always working toward peace.",
                    }
                ),
                new List<string>(
                    new string[] {
                        "Tradition. The ancient traditions of worship and sacrifice must be preserved and upheld. (Lawful)",
                        "Charity. I always try to help those in need, no matter what the personal cost. (Good)",
                    }
                ),
                new List<string>(
                    new string[] {
                        "I would die to recover an ancient relic of my faith that was lost long ago.",
                        "I will someday get revenge on the corrupt temple hierarchy who branded me a heretic.",
                    }
                ),
                new List<string>(
                    new string[] {
                        "I judge others harshly, and myself even more severely.",
                        "I put too much trust in those who wield power within my temple’s hierarchy.",
                    }
                )
            );
            character2.Hair = "Red";
            character2.Eyes = "Brown";
            character2.Skin = "Scales";
            character2.AdditionalNotes = "N/A";
            character2.Race = new Race(
                "Dragonborn",
                "Dragonborn look very much like dragons standing erect in humanoid form, " +
                "though they lack wings or a tail.",
                new List<Language>(
                    new Language[] {
                        Language.DRACONAIN
                    }
                )
            );
            character2.CharacterClass = new Class(
                "Fighter",
                "A master of martial combat, skilled with a variety of weapons and armor.",
                new List<Feature>(
                    // Initializing list with features
                    new Feature[] {
                        new Feature("Second Wind",
                            "You have a limited well of stamina that you can draw on to protect " +
                            "yourself from harm."),
                        new Feature("Action Surge",
                            "You can push yourself beyond your normal limits for a moment. On your " +
                            "turn, you can take one additional action."),
                        new Feature("Martial Archetype",
                            "You choose an archetype that you strive to emulate in your combat styles " +
                            "and techniques. Choose Chamption, Battle Master, or Eldritch Knight.")
                    }
                ),
                new Dice(10),
                new List<Skills>(
                    new Skills[] {
                        Skills.ACROBATICS,
                        Skills.ANIMAL_HANDLING,
                        Skills.ATHLETICS,
                        Skills.HISTORY,
                        Skills.INSIGHT,
                        Skills.INTIMIDATION,
                        Skills.PERCEPTION,
                        Skills.SURVIVAL
                    }
                )
            );

            // Create user which references these characters
            User testuser0 = new User(
                "testuser0",
                "Test User 0",
                new List<Character>(), // Has no characters
                "password",
                new List<Campaign>()
            );

            User testuser1 = new User(
                "testuser1",
                "Test User 1",
                new List<Character>(
                    new Character[] {
                        character1
                    }
                ),
                "password",
                new List<Campaign>()
            );

            User testuser2 = new User(
                "testuser2",
                "Test User 2",
                new List<Character>(
                    new Character[] {
                        character2
                    }
                ),
                "password",
                new List<Campaign>()
            );

            List<User> validUsers = new List<User>();
            validUsers.Add(testuser0);
            validUsers.Add(testuser1);
            validUsers.Add(testuser2);

            Campaign campaign1 = new Campaign(
                "Campaign 1",
                "A test campaign",
                new List<User>(
                    new User[] {
                        testuser1,
                        testuser2
                    }
                ),
                new List<Character>(
                    new Character[] {
                        testuser1.GetCharacterByName("Test Character 1"),
                        testuser2.GetCharacterByName("Test Character 2")
                    }
                ),
                testuser0
            );
            campaign1.AddCampaignToAllUsers();

            Campaign campaign2 = new Campaign(
                "Campaign 2",
                "A test campaign",
                new List<User>(
                    new User[] {
                        testuser1,
                        testuser2
                    }
                ),
                new List<Character>(
                    new Character[] {
                        testuser1.GetCharacterByName("Test Character 1"),
                        testuser2.GetCharacterByName("Test Character 2")
                    }
                ),
                testuser0
            );
            campaign2.AddCampaignToAllUsers();


            userCampaigns = testuser1.UserCampaigns;
        }

    }
}