using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using CharacterCreationLib;
using DnDSQLLib.dal;

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
            character.FeatureList = charClass.Features;
            character.CharacterBackground = charBackground;
            character.Hair = (!string.IsNullOrEmpty(hair)) ? hair : "N/A";
            character.Eyes = (!string.IsNullOrEmpty(eyes)) ? eyes : "N/A";
            character.Skin = (!string.IsNullOrEmpty(skin)) ? skin : "N/A";
            character.AdditionalNotes = (!string.IsNullOrEmpty(hair)) ? notes : "N/A";
            character.Race = charRace;
            character.CharacterClass = charClass;

            ViewState["character"] = character;

            DisplayCharacter(character);
        }

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
        /// Populate the page with database queries
        /// 
        /// TODO: implement database functionality
        /// </summary>
        private void InitCreationData() {
            RaceDAO raceDAO = new RaceDAO();
            races = raceDAO.GetAllRaces();

            ClassDAO classDAO = new ClassDAO();
            classes = classDAO.GetAllClasses();

            // Retrieve all backgrounds
            backgrounds.Add(new Background(
                "Acolyte",
                "You have spent your life in the service of a temple to a specific god or pantheon of gods.",
                new List<string>(
                    new string[] {
                        "I idolize a particular hero of my faith, and constantly refer to that person’s deeds and example.",
                        "I can find common ground between the fiercest enemies, empathizing with them and always working toward peace.",
                        "I see omens in every event and action. The gods try to speak to us, we just need to listen.",
                        "Nothing can shake my optimistic attitude.",
                        "I quote (or misquote) sacred texts and proverbs in almost every situation.",
                        "I am tolerant (or intolerant) of other faiths and respect (or condemn) the worship of other gods.",
                        "I’ve enjoyed fine food, drink, and high society among my temple’s elite. Rough living grates on me.",
                        "I’ve spent so long in the temple that I have little practical experience dealing with people in the outside world."
                    }
                ),
                new List<string>(
                    new string[] {
                        "Tradition. The ancient traditions of worship and sacrifice must be preserved and upheld. (Lawful)",
                        "Charity. I always try to help those in need, no matter what the personal cost. (Good)",
                        "Change. We must help bring about the changes the gods are constantly working in the world. (Chaotic)",
                        "Power. I hope to one day rise to the top of my faith’s religious hierarchy. (Lawful)",
                        "Faith. I trust that my deity will guide my actions. I have faith that if I work hard, things will go well. (Lawful)",
                        "Aspiration. I seek to prove myself worthy of my god’s favor by matching my actions against his or her teachings. (Any)"
                    }
                ),
                new List<string>(
                    new string[] {
                        "I would die to recover an ancient relic of my faith that was lost long ago.",
                        "I will someday get revenge on the corrupt temple hierarchy who branded me a heretic.",
                        "I owe my life to the priest who took me in when my parents died.",
                        "Everything I do is for the common people.",
                        "I will do anything to protect the temple where I served.",
                        "I seek to preserve a sacred text that my enemies consider heretical and seek to destroy."
                    }
                ),
                new List<string>(
                    new string[] {
                        "I judge others harshly, and myself even more severely.",
                        "I put too much trust in those who wield power within my temple’s hierarchy.",
                        "My piety sometimes leads me to blindly trust those that profess faith in my god.",
                        "I am inflexible in my thinking.",
                        "I am suspicious of strangers and expect the worst of them.",
                        "Once I pick a goal, I become obsessed with it to the detriment of everything else in my life."
                    }
                )
            ));
            backgrounds.Add(new Background(
                "Noble",
                "You understand wealth, power, and privilege. You carry a noble title, and " +
                "your family owns land, collects taxes, and wields significant political " +
                "influence.",
                new List<string>(
                    new string[] {
                        "My eloquent flattery makes everyone I talk to feel like the most wonderful and important person in the world.",
                        "The common folk love me for my kindness and generosity.",
                        "No one could doubt by looking at my regal bearing that I am a cut above the unwashed masses.",
                        "I take great pains to always look my best and follow the latest fashions.",
                        "I don’t like to get my hands dirty, and I won’t be caught dead in unsuitable accommodations.",
                        "Despite my noble birth, I do not place myself above other folk. We all have the same blood.",
                        "My favor, once lost, is lost forever.",
                        "If you do me an injury, I will crush you, ruin your name, and salt your fields."
                    }
                ),
                new List<string>(
                    new string[] {
                        "Respect. Respect is due to me because of my position, but all people regardless of station deserve to be treated with dignity. (Good)",
                        "Responsibility. It is my duty to respect the authority of those above me, just as those below me must respect mine. (Lawful)",
                        "Independence. I must prove that I can handle myself without the coddling of my family. (Chaotic)",
                        "Power. If I can attain more power, no one will tell me what to do. (Evil)",
                        "Family. Blood runs thicker than water. (Any)",
                        "Noble Obligation. It is my duty to protect and care for the people beneath me. (Good)"
                    }
                ),
                new List<string>(
                    new string[] {
                        "I will face any challenge to win the approval of my family.",
                        "My house’s alliance with another noble family must be sustained at all costs.",
                        "Nothing is more important than the other members of my family.",
                        "I am in love with the heir of a family that my family despises.",
                        "My loyalty to my sovereign is unwavering.",
                        "The common folk must see me as a hero of the people."
                    }
                ),
                new List<string>(
                    new string[] {
                        "I secretly believe that everyone is beneath me.",
                        "I hide a truly scandalous secret that could ruin my family forever.",
                        "I too often hear veiled insults and threats in every word addressed to me, and I’m quick to anger.",
                        "I have an insatiable desire for carnal pleasures.",
                        "In fact, the world does revolve around me.",
                        "By my words and actions, I often bring shame to my family."
                    }
                )
            ));
            backgrounds.Add(new Background(
                "Soldier",
                "War has been your life for as long as you care to remember. You " +
                "trained as a youth, studied the use of weapons and armour, learned basic " +
                "survival techniques, including how to stay alive on the battlefield.",
                new List<string>(
                    new string[] {
                        "I’m always polite and respectful.",
                        "I’m haunted by memories of war. I can’t get the images of violence out of my mind.",
                        "I’ve lost too many friends, and I’m slow to make new ones.",
                        "I’m full of inspiring and cautionary tales from my military experience relevant to almost every combat situation.",
                        "I can stare down a hell hound without flinching.",
                        "I enjoy being strong and like breaking things.",
                        "I have a crude sense of humor.",
                        "I face problems head-on. A simple, direct solution is the best path to success."
                    }
                ),
                new List<string>(
                    new string[] {
                        "Greater Good. Our lot is to lay down our lives in defense of others. (Good)",
                        "Responsibility. I do what I must and obey just authority. (Lawful)",
                        "Independence. When people follow orders blindly, they embrace a kind of tyranny. (Chaotic)",
                        "Might. In life as in war, the stronger force wins. (Evil)",
                        "Live and Let Live. Ideals aren’t worth killing over or going to war for. (Neutral)",
                        "Nation. My city, nation, or people are all that matter. (Any)"
                    }
                ),
                new List<string>(
                    new string[] {
                        "I would still lay down my life for the people I served with.",
                        "Someone saved my life on the battlefield. To this day, I will never leave a friend behind.",
                        "My honor is my life.",
                        "I’ll never forget the crushing defeat my company suffered or the enemies who dealt it.",
                        "Those who fight beside me are those worth dying for.",
                        "I fight for those who cannot fight for themselves."
                    }
                ),
                new List<string>(
                    new string[] {
                        "The monstrous enemy we faced in battle still leaves me quivering with fear.",
                        "I have little respect for anyone who is not a proven warrior.",
                        "I made a terrible mistake in battle that cost many lives—and I would do anything to keep that mistake secret.",
                        "My hatred of my enemies is blind and unreasoning.",
                        "I obey the law, even if the law causes misery.",
                        "I’d rather eat my armor than admit when I’m wrong."
                    }
                )
            ));
        }

        /// <summary>
        /// Saves character to the user's account
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void BtnSave_Click(object sender, EventArgs e) {
            // TODO: insert into database
            Character character = (Character)ViewState["character"];
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