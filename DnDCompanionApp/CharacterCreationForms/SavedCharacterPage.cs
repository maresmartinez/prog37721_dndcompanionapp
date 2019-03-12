using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using CharacterCreationLib;

namespace CharacterCreationForms {
    public partial class SavedCharacterPage : UserControl {

        List<Character> savedCharacters;

        public SavedCharacterPage(List<Character> savedCharacters) {
            InitializeComponent();
            this.savedCharacters = savedCharacters;
        }

        public SavedCharacterPage() {
            InitializeComponent();
            savedCharacters = new List<Character>();
        }

        private void SavedCharacterPage_Load(object sender, EventArgs e) {

            // --------------------------------------------------------------------------------------------------------------------------------
            // TODO: replace the following section with database queries
            // Query database for characters and add them to savedCharacters
            // --------------------------------------------------------------------------------------------------------------------------------

            // ------------------------------------------------       START       -------------------------------------------------------------

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
                Language.DRACONAIN
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
                Language.DRACONAIN
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

            savedCharacters.Add(character1);
            savedCharacters.Add(character2);

            // ------------------------------------------------       END       -------------------------------------------------------------

            // Create character controls for each character
            foreach (Character character in savedCharacters) {
                flowSavedCharacters.Controls.Add(new SavedCharacterControl(character));
            }
        }
    }
}
