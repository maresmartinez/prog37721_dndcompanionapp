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
            InitCharacters();
            if (characters.Count > 0) {
                DisplayCharacterDetails(characters[0]);
            } else {
                LblCharacter.Visible = false;
                DDCharacters.Visible = false;
                LblNoCharacters.Text = "You have no characters to display.";
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
        /// 
        /// TODO: add database functionality instead of hardcoding
        /// </summary>
        private void InitCharacters() {
            UserDAO userDAO = new UserDAO();
            User user = userDAO.GetUser(Context.User.Identity.Name);
            characters = userDAO.GetUserCharacters(user.ID);

            // Create Characters
            //Character character1 = new Character();
            //character1.Name = "Test Character 1";
            //character1.Strength = 20;
            //character1.Dexterity = 20;
            //character1.Constitution = 20;
            //character1.Intelligence = 20;
            //character1.Wisdom = 20;
            //character1.Charisma = 20;
            //character1.StrMod = 5;
            //character1.DexMod = 5;
            //character1.ConMod = 5;
            //character1.IntMod = 5;
            //character1.WisMod = 5;
            //character1.ChrMod = 5;
            //character1.CharacterBackground = new Background(
            //    "Acolyte",
            //    "You have spent your life in the service of a temple to a specific god or pantheon of gods.",
            //    new List<string>(
            //        new string[] {
            //            "I idolize a particular hero of my faith, and constantly refer to that person’s deeds and example.",
            //            "I can find common ground between the fiercest enemies, empathizing with them and always working toward peace.",
            //        }
            //    ),
            //    new List<string>(
            //        new string[] {
            //            "Tradition. The ancient traditions of worship and sacrifice must be preserved and upheld. (Lawful)",
            //            "Charity. I always try to help those in need, no matter what the personal cost. (Good)",
            //        }
            //    ),
            //    new List<string>(
            //        new string[] {
            //            "I would die to recover an ancient relic of my faith that was lost long ago.",
            //            "I will someday get revenge on the corrupt temple hierarchy who branded me a heretic.",
            //        }
            //    ),
            //    new List<string>(
            //        new string[] {
            //            "I judge others harshly, and myself even more severely.",
            //            "I put too much trust in those who wield power within my temple’s hierarchy.",
            //        }
            //    )
            //);
            //character1.Hair = "Red";
            //character1.Eyes = "Brown";
            //character1.Skin = "Scales";
            //character1.AdditionalNotes = "N/A";
            //character1.Race = new Race(
            //    "Dragonborn",
            //    "Dragonborn look very much like dragons standing erect in humanoid form, " +
            //    "though they lack wings or a tail.",
            //    new List<Language>(
            //        new Language[] {
            //            Language.Draconic
            //        }
            //    )
            //);
            //character1.CharacterClass = new Class(
            //    "Fighter",
            //    "A master of martial combat, skilled with a variety of weapons and armor.",
            //    new List<Feature>(
            //         Initializing list with features
            //        new Feature[] {
            //            new Feature("Second Wind",
            //                "You have a limited well of stamina that you can draw on to protect " +
            //                "yourself from harm."),
            //            new Feature("Action Surge",
            //                "You can push yourself beyond your normal limits for a moment. On your " +
            //                "turn, you can take one additional action."),
            //            new Feature("Martial Archetype",
            //                "You choose an archetype that you strive to emulate in your combat styles " +
            //                "and techniques. Choose Chamption, Battle Master, or Eldritch Knight.")
            //        }
            //    ),
            //    new Dice(10),
            //    new List<Skills>(
            //        new Skills[] {
            //            Skills.ACROBATICS,
            //            Skills.ANIMAL_HANDLING,
            //            Skills.ATHLETICS,
            //            Skills.HISTORY,
            //            Skills.INSIGHT,
            //            Skills.INTIMIDATION,
            //            Skills.PERCEPTION,
            //            Skills.SURVIVAL
            //        }
            //    )
            //);

            //Character character2 = new Character();
            //character2.Name = "Test Character 2";
            //character2.Strength = 20;
            //character2.Dexterity = 20;
            //character2.Constitution = 20;
            //character2.Intelligence = 20;
            //character2.Wisdom = 20;
            //character2.Charisma = 20;
            //character2.StrMod = 5;
            //character2.DexMod = 5;
            //character2.ConMod = 5;
            //character2.IntMod = 5;
            //character2.WisMod = 5;
            //character2.ChrMod = 5;
            //character2.CharacterBackground = new Background(
            //    "Acolyte",
            //    "You have spent your life in the service of a temple to a specific god or pantheon of gods.",
            //    new List<string>(
            //        new string[] {
            //            "I idolize a particular hero of my faith, and constantly refer to that person’s deeds and example.",
            //            "I can find common ground between the fiercest enemies, empathizing with them and always working toward peace.",
            //        }
            //    ),
            //    new List<string>(
            //        new string[] {
            //            "Tradition. The ancient traditions of worship and sacrifice must be preserved and upheld. (Lawful)",
            //            "Charity. I always try to help those in need, no matter what the personal cost. (Good)",
            //        }
            //    ),
            //    new List<string>(
            //        new string[] {
            //            "I would die to recover an ancient relic of my faith that was lost long ago.",
            //            "I will someday get revenge on the corrupt temple hierarchy who branded me a heretic.",
            //        }
            //    ),
            //    new List<string>(
            //        new string[] {
            //            "I judge others harshly, and myself even more severely.",
            //            "I put too much trust in those who wield power within my temple’s hierarchy.",
            //        }
            //    )
            //);
            //character2.Hair = "Red";
            //character2.Eyes = "Brown";
            //character2.Skin = "Scales";
            //character2.AdditionalNotes = "N/A";
            //character2.Race = new Race(
            //    "Dragonborn",
            //    "Dragonborn look very much like dragons standing erect in humanoid form, " +
            //    "though they lack wings or a tail.",
            //    new List<Language>(
            //        new Language[] {
            //            Language.Draconic
            //        }
            //    )
            //);
            //character2.CharacterClass = new Class(
            //    "Fighter",
            //    "A master of martial combat, skilled with a variety of weapons and armor.",
            //    new List<Feature>(
            //        // Initializing list with features
            //        new Feature[] {
            //            new Feature("Second Wind",
            //                "You have a limited well of stamina that you can draw on to protect " +
            //                "yourself from harm."),
            //            new Feature("Action Surge",
            //                "You can push yourself beyond your normal limits for a moment. On your " +
            //                "turn, you can take one additional action."),
            //            new Feature("Martial Archetype",
            //                "You choose an archetype that you strive to emulate in your combat styles " +
            //                "and techniques. Choose Chamption, Battle Master, or Eldritch Knight.")
            //        }
            //    ),
            //    new Dice(10),
            //    new List<Skills>(
            //        new Skills[] {
            //            Skills.ACROBATICS,
            //            Skills.ANIMAL_HANDLING,
            //            Skills.ATHLETICS,
            //            Skills.HISTORY,
            //            Skills.INSIGHT,
            //            Skills.INTIMIDATION,
            //            Skills.PERCEPTION,
            //            Skills.SURVIVAL
            //        }
            //    )
            //);

            //characters.Add(character1);
            //characters.Add(character2);
        }
    }
}