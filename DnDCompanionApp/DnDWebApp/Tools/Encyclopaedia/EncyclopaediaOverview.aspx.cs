using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using CharacterCreationLib;
using DnDSQLLib;
using DnDSQLLib.dal;

namespace DnDWebApp.Tools {
    public partial class EncyclopaediaOverview : System.Web.UI.Page {
        protected void Page_Load(object sender, EventArgs e) {
            if (!IsPostBack) {
                string encyclopaediaReq = "";
                if (Request.QueryString.AllKeys.Contains("encyclopaediaReq")) {
                    encyclopaediaReq = Request.QueryString.Get("encyclopaediaReq");
                }

                //checks to make sure that the string isn't null
                if (encyclopaediaReq.Length > 0) {
                    switch (encyclopaediaReq) {
                        case "classes":
                            name.InnerHtml = "Classes";
                            description.InnerHtml = "<p>People have jobs, but adventurers have classes. Class defines an " +
                                "adventurer’s skillset: Wizards do magic, druids interface with nature, and barbarians hit " +
                                "things. Not a job or an area of study, classes are more like occupations or callings. A bard, " +
                                "for example, might not get paid to play music, but they weave magical music-playing into their " +
                                "life and ambitions.</p>Advancing in a class makes a player’s character more powerful and better" +
                                " able to affect change in the world. It broadens their skillset and better equips them to be " +
                                "heroes.</p>";
                            ClassLinks();
                            break;
                        case "races":
                            name.InnerHtml = "Races";
                            description.InnerHtml = "<p>Your choice of character race provides you with a basic set of " +
                                "advantages and special abilities. If you’re a fighter, are you a stubborn dwarf monster-slayer, " +
                                "a graceful elf blademaster, or a fierce dragonborn gladiator? If you’re a wizard, are you a " +
                                "brave human spell-for-hire or a devious tiefling conjurer? Your character race not only affects " +
                                "your ability scores and powers but also provides the first cues for building your character’s " +
                                "story.</p>";
                            RaceLinks();
                            break;
                        case "spells":
                            name.InnerHtml = "Spell";
                            description.InnerHtml = "Spells are actions which are available to magical classes, such as Clerics, " +
                                "Mages, Bards, etc.";
                            SpellLinks();
                            break;
                        case "backgroundTypes":
                            name.InnerHtml = "Backgrounds";
                            description.InnerHtml = "<p>Your character’s background reveals where you came from, how you became " +
                                "an adventurer, and your place in the world. Your fighter might have been a courageous knight or " +
                                "a grizzled soldier. Your wizard could have been a sage or an artisan. Your rogue might have " +
                                "gotten by as a guild thief or commanded audiences as a jester. Choosing a background provides " +
                                "you with important story cues about your character’s identity.</p>";
                            BackgroundLinks();
                            break;
                        default:
                            description.InnerHtml = "Nothing found by that name";
                            break;
                    }

                }
            }
        }

        private void ClassLinks() {
            string classIDstr = "";
            ClassDAO cDAO = new ClassDAO();
            List<Class> classList = cDAO.GetAllClasses();
            if (Request.QueryString.AllKeys.Contains("classID")) {
                classIDstr = Request.QueryString.Get("classID");
            }

            //checks to make sure that the string isn't null
            if (classIDstr.Length > 0) {
                int classID = int.Parse(classIDstr);
                Class pulledClass = cDAO.GetClass(classID);
                name.InnerHtml = pulledClass.Name;
                description.InnerHtml = pulledClass.Description;
                descriptor2.InnerHtml = "<br>Features:";
                descriptor2.InnerHtml += "<br>";
                foreach (Feature pulledClassFeatures in pulledClass.Features) {
                    descriptor2.InnerHtml += pulledClassFeatures.ToString();
                    descriptor2.InnerHtml += "<br>";
                }
                descriptor3.InnerHtml = "<br>Hit Dice is: " + pulledClass.HitDice.ToString();

                descriptor4.InnerHtml = "<br>Available Skills: ";
                descriptor4.InnerHtml += "<br>";
                foreach (Skills pulledClassSkills in pulledClass.CharacterSkills) {
                    descriptor4.InnerHtml += this.PrettifyEnum(pulledClassSkills.ToString());
                    descriptor4.InnerHtml += "<br>";
                }

            }

            //connect to db and populate the links div with 1 link for each entry to DB
            links.InnerHtml = "";
            links.InnerHtml = "<a href='EncyclopaediaOverview.aspx' class='text-dark'>> Back</a><br>";
            foreach (Class lClass in classList) {
                int clID = lClass.ClassId;
                string clName = lClass.Name;
                links.InnerHtml += "<a href=\"EncyclopaediaOverview.aspx?encyclopaediaReq=classes&classID=" + clID + "\" class='text-dark'>" + clName + "</a><br /> ";
            }
        }


        private void RaceLinks() {
            string raceIDstr = "";
            RaceDAO rDAO = new RaceDAO();
            List<Race> raceList = rDAO.GetAllRaces();
            if (Request.QueryString.AllKeys.Contains("raceID")) {
                raceIDstr = Request.QueryString.Get("raceID");
            }

            //checks to make sure that the string isn't null
            if (raceIDstr.Length > 0) {
                int raceID = int.Parse(raceIDstr);
                Race pulledRace = rDAO.GetRace(raceID);
                name.InnerHtml = pulledRace.Name;
                description.InnerHtml = pulledRace.Description;
                descriptor2.InnerHtml = "<br>Languages: ";
                descriptor2.InnerHtml += "<br>";
                foreach (Language pulledRaceLangages in pulledRace.Languages) {
                    descriptor2.InnerHtml += this.PrettifyEnum(pulledRaceLangages.ToString());
                    descriptor2.InnerHtml += "<br>";
                }
            }

            //connect to db and populate the links div with 1 link for each entry to DB
            links.InnerHtml = "";
            links.InnerHtml = "<a href='EncyclopaediaOverview.aspx' class='text-dark'>> Back</a><br>";
            foreach (Race lRace in raceList) {
                int raID = lRace.RaceId;
                string raName = lRace.Name;
                links.InnerHtml += "<a href=\"EncyclopaediaOverview.aspx?encyclopaediaReq=races&raceID=" + raID + "\" class='text-dark'>" + raName + "</a><br /> ";
            }
        }
        private void SpellLinks() {
            string spellIDstr = "";
            SpellDAO spDAO = new SpellDAO();

            List<Spells> spellList = spDAO.GetAllSpells();

            if (Request.QueryString.AllKeys.Contains("spellID")) {
                spellIDstr = Request.QueryString.Get("spellID");
            }

            //checks to make sure that the string isn't null
            if (spellIDstr.Length > 0) {
                int spellID = int.Parse(spellIDstr);
                int counter = 0;
                while (spellID != spellList[counter].SpellId) {
                    counter++;
                }
                Spells pulledSpell = spellList[counter];

                name.InnerHtml = pulledSpell.Name;
                description.InnerHtml = pulledSpell.Description;
                descriptor2.InnerHtml += "<br>Casting Time: "+ Convert.ToString(pulledSpell.CastingTime) + " minutes";
                descriptor3.InnerHtml += "Duration: " + Convert.ToString(pulledSpell.Duration) + " minutes";
                descriptor4.InnerHtml += "Range: " + Convert.ToString(pulledSpell.Range) + " meters";
            }
            //connect to db and populate the links div with 1 link for each entry to DB
            links.InnerHtml = "";
            links.InnerHtml = "<a href='EncyclopaediaOverview.aspx' class='text-dark'>> Back</a><br>";
            foreach (Spells lSpell in spellList) {
                int spID = lSpell.SpellId;
                string spName = lSpell.Name;
                links.InnerHtml += "<a href=\"EncyclopaediaOverview.aspx?encyclopaediaReq=spells&spellID=" + spID + "\" class='text-dark'>" + spName + "</a><br /> ";
            }

        }

        /// <summary>
        /// Capitalizes first letter of word. Used to display enums prettier
        /// </summary>
        /// <param name="word">Word to capitalize</param>
        /// <returns>Word with first letter capitalized</returns>
        private string FirstCharToUpper(string word) {
            if(string.IsNullOrEmpty(word)) {
                return string.Empty;
            }
            string endOfWord = word.Substring(1);
            return char.ToUpper(word[0]) + endOfWord.ToLower();
        }

        /// <summary>
        /// Replaces enum literal with prettier word
        /// </summary>
        /// <param name="word">Enum literal</param>
        /// <returns>Pretty enum</returns>
        private string PrettifyEnum(string word) {
            string prettyEnum = this.FirstCharToUpper(word);
            return this.ReplaceUnderscore(prettyEnum);
        }

        /// <summary>
        /// Replaces underscores with spaces. Used to display enums prettier
        /// </summary>
        /// <param name="word">Word to replace</param>
        /// <returns>Word with underscores replaced with spaces</returns>
        private string ReplaceUnderscore(string word) {
            string newWord = "";
            foreach (char letter in word) {
                if (letter.Equals('_')) {
                    newWord += ' ';
                } else {
                    newWord += letter;
                }   
            }
            return newWord;
        }


        private void BackgroundLinks() {
            string backgroundIDstr = "";
            BackgroundDAO bDAO = new BackgroundDAO();
            List<Background> backgroundList = bDAO.GetAllBackgroundTypes();
            if (Request.QueryString.AllKeys.Contains("backgroundID")) {
                backgroundIDstr = Request.QueryString.Get("backgroundID");
            }

            //checks to make sure that the string isn't null
            if (backgroundIDstr.Length > 0) {
                int backID = int.Parse(backgroundIDstr);
                int counter = 0;
                while (backID != backgroundList[counter].BackgroundId) {
                    counter++;
                }
                Background pulledBackground = backgroundList[counter];

                name.InnerHtml = pulledBackground.Name;
                description.InnerHtml = pulledBackground.Description;
                descriptor2.InnerHtml = "<br>Personality Traits:";
                descriptor2.InnerHtml += "<br>";
                foreach (String pulledBackgroundPersonalityTrait in pulledBackground.Personality) {
                    descriptor2.InnerHtml += pulledBackgroundPersonalityTrait;
                    descriptor2.InnerHtml += "<br>";
                }
                descriptor3.InnerHtml = "<br>Ideals:";
                descriptor3.InnerHtml += "<br>";
                foreach (String pulledBackgroundIdeal in pulledBackground.Ideals) {
                    descriptor3.InnerHtml += pulledBackgroundIdeal;
                    descriptor3.InnerHtml += "<br>";
                }
                descriptor4.InnerHtml = "<br>Bonds:";
                descriptor4.InnerHtml += "<br>";
                foreach (String pulledBackgroundBond in pulledBackground.Bonds) {
                    descriptor4.InnerHtml += pulledBackgroundBond;
                    descriptor4.InnerHtml += "<br>";
                }
                descriptor5.InnerHtml = "<br>Flaws:";
                descriptor5.InnerHtml += "<br>";
                foreach (String pulledBackgroundFlaw in pulledBackground.Flaws) {
                    descriptor5.InnerHtml += pulledBackgroundFlaw;
                    descriptor5.InnerHtml += "<br>";
                }
            }
            //connect to db and populate the links div with 1 link for each entry to DB
            links.InnerHtml = "";
            links.InnerHtml = "<a href='EncyclopaediaOverview.aspx' class='text-dark'>> Back</a><br>";
            foreach (Background lBackground in backgroundList) {
                int bgID = lBackground.BackgroundId;
                string bgName = lBackground.Name;
                links.InnerHtml += "<a href=\"EncyclopaediaOverview.aspx?encyclopaediaReq=backgroundTypes&backgroundID=" + bgID + "\" class='text-dark'>" + bgName + "</a><br /> ";
            }
        }
        private void FeatureLinks() {
            string featureIDstr = "";
            FeatureDAO fDAO = new FeatureDAO();
            //SpellDAO spDAO = new SpellDAO();

            List<Feature> featureList = fDAO.GetAllFeatures();
            //List<Spells> spellList = spDAO.GetAllSpells();

            if (Request.QueryString.AllKeys.Contains("featureID")) {
                featureIDstr = Request.QueryString.Get("featureID");
            }

            //checks to make sure that the string isn't null
            if (featureIDstr.Length > 0) {
                int featureID = int.Parse(featureIDstr);
                int counter = 0;
                while (featureID != featureList[counter].FeatureID) {
                    counter++;
                }
                Feature pulledFeature = featureList[counter];

                name.InnerHtml = pulledFeature.Name;
                description.InnerHtml = pulledFeature.Description;


            }
            //connect to db and populate the links div with 1 link for each entry to DB
            links.InnerHtml = "";
            links.InnerHtml = "<a href='EncyclopaediaOverview.aspx' class='text-dark'>> Back</a><br>";
            foreach (Feature lFeature in featureList) {
                int ftID = lFeature.FeatureID;
                string ftName = lFeature.Name;
                links.InnerHtml += "<a href=\"EncyclopaediaOverview.aspx?encyclopaediaReq=Features&featureID=" + ftID + "\" class='text-dark'>" + ftName + "</a><br /> ";
            }
        }

    }
}
