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
    public partial class CreateNewCharacter : System.Web.UI.Page {

        /// <summary>
        /// All available races
        /// </summary>
        List<Race> races = new List<Race>();

        /// <summary>
        /// All available classes
        /// </summary>
        List<Class> classes = new List<Class>();

        /// <summary>
        /// All available backgrounds
        /// </summary>
        List<Background> backgrounds = new List<Background>();

        /// <summary>
        /// Queries the database for the information needed to create a character, and displays
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void Page_Load(object sender, EventArgs e) {
            InitCreationData();

            if (!IsPostBack) {
                DisplayRace(races[0]);
                DisplayClass(classes[0]);
                DisplayBackground(backgrounds[0]);

                DDRace.DataSource = races;
                DDRace.DataBind();

                DDClass.DataSource = classes;
                DDClass.DataBind();

                DDBackground.DataSource = backgrounds;
                DDBackground.DataBind();

                RollStats();
            }
        }

        /// <summary>
        /// Populate the page with database queries
        /// </summary>
        private void InitCreationData() {
            RaceDAO raceDAO = new RaceDAO();
            races = raceDAO.GetAllRaces();

            ClassDAO classDAO = new ClassDAO();
            classes = classDAO.GetAllClasses();

            BackgroundDAO backgroundDAO = new BackgroundDAO();
            backgrounds = backgroundDAO.GetAllBackgroundTypes();
        }

        /// <summary>
        /// Re-rolls ability score and modifiers
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void BtnRollStats_Click(object sender, EventArgs e) {
            RollStats();
        }

        /// <summary>
        /// Generates ability scores and modifiers, and displays them
        /// </summary>
        private void RollStats() {
            Random rand = new Random();

            // Generate number between 1 and 20
            Str.InnerText = rand.Next(1, 21).ToString();
            Dex.InnerText = rand.Next(1, 21).ToString();
            Con.InnerText = rand.Next(1, 21).ToString();
            Intel.InnerText = rand.Next(1, 21).ToString();
            Wis.InnerText = rand.Next(1, 21).ToString();
            Chr.InnerText = rand.Next(1, 21).ToString();

            // Generate number between -5 and +10
            StrMod.InnerText = (rand.Next(1, 16) - 5).ToString();
            DexMod.InnerText = (rand.Next(1, 16) - 5).ToString();
            ConMod.InnerText = (rand.Next(1, 16) - 5).ToString();
            IntMod.InnerText = (rand.Next(1, 16) - 5).ToString();
            WisMod.InnerText = (rand.Next(1, 16) - 5).ToString();
            ChrMod.InnerText = (rand.Next(1, 16) - 5).ToString();
        }

        /// <summary>
        /// Retrieves the selected index in the race drop down and displays it
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void DDRace_SelectedIndexChanged(object sender, EventArgs e) {
            Race selectedRace = races[DDRace.SelectedIndex];
            DisplayRace(selectedRace);
        }
        /// <summary>
        /// Displays race details on the page
        /// </summary>
        /// <param name="race">Race to be displayed</param>
        private void DisplayRace(Race race) {
            LblRaceName.Text = race.Name;
            RaceDesc.InnerText = race.Description;
            BLLanguages.Items.Clear();
            foreach (Language language in race.Languages) {
                BLLanguages.Items.Add(language.ToString());
            }
        }

        /// <summary>
        /// Retrieves the selected index in the calss drop down and displays it
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void DDClass_SelectedIndexChanged(object sender, EventArgs e) {
            Class selectedClass = classes[DDClass.SelectedIndex];
            DisplayClass(selectedClass);
        }
        /// <summary>
        /// Displays class details on the page
        /// </summary>
        /// <param name="characterClass">Class to be displayed</param>
        private void DisplayClass(Class characterClass) {
            LblClassName.Text = characterClass.Name;
            ClassDesc.InnerText = characterClass.Description;

            BLFeatures.Items.Clear();
            foreach (Feature feature in characterClass.Features) {
                BLFeatures.Items.Add(feature.ToString());
            }

            HitDice.InnerText = characterClass.HitDice.ToString();
            BLSkills.Items.Clear();
            foreach (Skills skill in characterClass.CharacterSkills) {
                BLSkills.Items.Add(skill.ToString());
            }
        }

        /// <summary>
        /// Retrieves the selected index in the background drop down and displays it
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void DDBackground_SelectedIndexChanged(object sender, EventArgs e) {
            Background selectedBackground = backgrounds[DDBackground.SelectedIndex];
            DisplayBackground(selectedBackground);
        }
        /// <summary>
        /// Displays background details on the page
        /// </summary>
        /// <param name="background">Background to be displayed</param>
        private void DisplayBackground(Background background) {
            LblBackgroundName.Text = background.Name;
            BackgroundDesc.InnerText = background.Description;

            ChkLPersonality.Items.Clear();
            foreach (string personalityTrait in background.Personality) {
                ChkLPersonality.Items.Add(personalityTrait);
            }

            ChkLIdeals.Items.Clear();
            foreach (string ideal in background.Ideals) {
                ChkLIdeals.Items.Add(ideal);
            }

            ChkLBonds.Items.Clear();
            foreach (string bond in background.Bonds) {
                ChkLBonds.Items.Add(bond);
            }

            ChkLFlaws.Items.Clear();
            foreach (string flaw in background.Flaws) {
                ChkLFlaws.Items.Add(flaw);
            }
        }

        /// <summary>
        /// Validates the form inputs and creates a character
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void BtnGenerate_Click(object sender, EventArgs e) {
            string name = TxtName.Text;

            Race charRace = races[DDRace.SelectedIndex];

            Class charClass = classes[DDClass.SelectedIndex];

            // Get background selections
            Background stockBackground = backgrounds[DDBackground.SelectedIndex];

            List<string> charPersonality = new List<string>();
            foreach (ListItem item in ChkLPersonality.Items) {
                if (item.Selected) {
                    charPersonality.Add(item.Value);
                }
            }

            List<string> charIdeals = new List<string>();
            foreach (ListItem item in ChkLIdeals.Items) {
                if (item.Selected) {
                    charIdeals.Add(item.Value);
                }
            }

            List<string> charBonds = new List<string>();
            foreach (ListItem item in ChkLBonds.Items) {
                if (item.Selected) {
                    charBonds.Add(item.Value);
                }
            }

            List<string> charFlaws = new List<string>();
            foreach (ListItem item in ChkLFlaws.Items) {
                if (item.Selected) {
                    charFlaws.Add(item.Value);
                }
            }

            Background charBackground = new Background(
                stockBackground.BackgroundId,
                stockBackground.Name,
                stockBackground.Description,
                charPersonality,
                charIdeals,
                charBonds,
                charFlaws
            );

            // Get ability scores and modifiers
            int str = int.Parse(Str.InnerText);
            int dex = int.Parse(Dex.InnerText);
            int con = int.Parse(Con.InnerText);
            int wis = int.Parse(Wis.InnerText);
            int intel = int.Parse(Intel.InnerText);
            int chr = int.Parse(Chr.InnerText);

            int strMod = int.Parse(StrMod.InnerText);
            int dexMod = int.Parse(DexMod.InnerText);
            int conMod = int.Parse(ConMod.InnerText);
            int wisMod = int.Parse(WisMod.InnerText);
            int intelMod = int.Parse(IntMod.InnerText);
            int chrMod = int.Parse(ChrMod.InnerText);

            string hair = TxtHair.Text;
            string eyes = TxtEyes.Text;
            string skin = TxtSkin.Text;
            string notes = TxtAdditionalNotes.Text;

            // Generate character, catch any exceptions
            Character character = new Character();
            character.Name = name;
            character.Strength = str;
            character.Dexterity = dex;
            character.Constitution = con;
            character.Intelligence = intel;
            character.Wisdom = wis;
            character.Charisma = chr;
            character.StrMod = strMod;
            character.DexMod = dexMod;
            character.ConMod = conMod;
            character.IntMod = intelMod;
            character.WisMod = wisMod;
            character.ChrMod = chrMod;
            character.CharacterBackground = charBackground;
            character.Hair = (!string.IsNullOrEmpty(hair)) ? hair : "N/A";
            character.Eyes = (!string.IsNullOrEmpty(eyes)) ? eyes : "N/A";
            character.Skin = (!string.IsNullOrEmpty(skin)) ? skin : "N/A";
            character.AdditionalNotes = (!string.IsNullOrEmpty(hair)) ? notes : "N/A";
            character.Race = charRace;
            character.CharacterClass = charClass;

            Session["character"] = character;

            DisplayCharacter(character);
        }

        /// <summary>
        /// Displays the generated character's details on the page
        /// </summary>
        /// <param name="character">The character to be displayed</param>
        private void DisplayCharacter(Character character) {
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
            BLNewCharLang.Items.Clear();
            foreach (Language language in character.Race.Languages) {
                BLNewCharLang.Items.Add(language.ToString());
            }

            ClassDesc.InnerText = character.CharacterClass.Name + ": " + character.CharacterClass.Description;
            BLNewCharFeats.Items.Clear();
            foreach (Feature feature in character.CharacterClass.Features) {
                BLNewCharFeats.Items.Add(feature.ToString());
            }
            HitDice.InnerText = character.CharacterClass.HitDice.ToString();
            BLNewCharSkills.Items.Clear();
            foreach (Skills skill in character.CharacterClass.CharacterSkills) {
                BLNewCharSkills.Items.Add(skill.ToString());
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
        /// Saves character to the user's account
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void BtnSave_Click(object sender, EventArgs e) {
            // TODO: insert into database
            Character character = (Character)Session["character"];

            UserDAO userDAO = new UserDAO();
            User user = userDAO.GetUser(Context.User.Identity.Name);

            CharacterDAO characterDAO = new CharacterDAO();
            character.DbID = characterDAO.UploadCharacter(user.ID, character);

            Response.Redirect("~/Home.aspx");
        }

        /// <summary>
        /// Discards the created character and refreshes page
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void BtnDiscard_Click(object sender, EventArgs e) {
            Response.Redirect("~/Users/Characters/CreateNewCharacter.aspx");
        }
    }
}