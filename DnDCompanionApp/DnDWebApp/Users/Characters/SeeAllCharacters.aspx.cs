using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using CharacterCreationLib;
using DnDSQLLib.dal;
using UserManagementLib;

namespace DnDWebApp.Users.Characters {
    public partial class SeeAllCharacters : System.Web.UI.Page {

        /// <summary>
        /// Reference to all the logged in user's characters
        /// </summary>
        List<Character> characters = new List<Character>();
        
        /// <summary>
        /// Retrieves all the logged in user's character and displays them, if any.
        /// If the user has no characters, then a message is displayed telling them so.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void Page_Load(object sender, EventArgs e) {
            if (Request.QueryString["newCharacter"] != null) {
                NewCharacter.Visible = true;
            }
            InitCharacters();
            if (characters.Count > 0) {
                DisplayCharacterDetails(characters[0]);
            } else {
                LblCharacter.Visible = false;
                DDCharacters.Visible = false;
                NoCharacters.Visible = true;
            }

            if (!IsPostBack) {
                DDCharacters.DataSource = characters;
                DDCharacters.DataBind();
            }
        }

        /// <summary>
        /// Displays the selected character
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void DDCharacters_SelectedIndexChanged(object sender, EventArgs e) {
            Character selectedCharacter = characters[DDCharacters.SelectedIndex];
            DisplayCharacterDetails(selectedCharacter);
        }

        /// <summary>
        /// Displays the selected character
        /// </summary>
        /// <param name="character">Character to be displayed</param>
        private void DisplayCharacterDetails(Character character) {
            LblCharacterName.Text = character.Name;
            CharacterDetails.Visible = true;

            BLStats.Items.Clear();
            BLStats.Items.Add("Strength: " + character.Strength + ", Mod " + character.StrMod);
            BLStats.Items.Add("Dexterity: " + character.Dexterity + ", Mod " + character.DexMod);
            BLStats.Items.Add("Constitution: " + character.Constitution + ", Mod " + character.ConMod);
            BLStats.Items.Add("Intelligence: " + character.Intelligence + ", Mod " + character.IntMod);
            BLStats.Items.Add("Wisdom: " + character.Wisdom + ", Mod " + character.WisMod);
            BLStats.Items.Add("Charisma: " + character.Charisma + ", Mod " + character.ChrMod);

            RaceDesc.InnerText = character.Race.Name + ": " + character.Race.Description;
            BLLanguages.Items.Clear();
            foreach (Language language in character.Race.Languages) {
                BLLanguages.Items.Add(EnumPrettify.Prettify(language.ToString()));
            }

            ClassDesc.InnerText = character.CharacterClass.Name + ": " + character.CharacterClass.Description;
            BLFeatures.Items.Clear();
            foreach (Feature feature in character.CharacterClass.Features) {
                BLFeatures.Items.Add(feature.ToString());
            }
            HitDice.InnerText = character.CharacterClass.HitDice.ToString();
            BLSkills.Items.Clear();
            foreach (Skills skill in character.CharacterClass.CharacterSkills) {
                BLSkills.Items.Add(EnumPrettify.Prettify(skill.ToString()));
            }

            BackgroundDesc.InnerText = character.CharacterBackground.Name + ": " + character.CharacterBackground.Description;
            BLPersonality.Items.Clear();
            foreach (string personalityTrait in character.CharacterBackground.Personality) {
                BLPersonality.Items.Add(personalityTrait);
            }
            BLIdeals.Items.Clear();
            foreach (string ideal in character.CharacterBackground.Ideals) {
                BLIdeals.Items.Add(ideal);
            }
            BLBonds.Items.Clear();
            foreach (string bond in character.CharacterBackground.Bonds) {
                BLBonds.Items.Add(bond);
            }
            BLFlaws.Items.Clear();
            foreach (string flaw in character.CharacterBackground.Flaws) {
                BLFlaws.Items.Add(flaw);
            }

            PhysicalDesc.InnerText = $"Hair: {character.Hair}, Eyes: {character.Eyes}, Skin: {character.Skin}";
            AdditionalNotes.InnerText = character.AdditionalNotes;
        }

        /// <summary>
        /// Queries the database for all the users's characters
        /// </summary>
        private void InitCharacters() {
            UserDAO userDAO = new UserDAO();
            User user = userDAO.GetUser(Context.User.Identity.Name);
            characters = userDAO.GetUserCharacters(user.ID);
        }
    }
}