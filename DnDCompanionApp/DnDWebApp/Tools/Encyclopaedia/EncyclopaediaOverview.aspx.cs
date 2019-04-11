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
                            ClassLinks();
                            break;
                        case "races":
                            name.InnerHtml = "Races";
                            RaceLinks();
                            break;
                        case "spells":
                            name.InnerHtml = "Spell";
                            SpellLinks();
                            break;
                        case "backgroundTypes":
                            name.InnerHtml = "Backgrounds";
                            BackgroundLinks();
                            break;
                        case "features":
                            name.InnerHtml = "Features";
                            FeatureLinks();
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
                description.InnerHtml = "Description:";
                description.InnerHtml += "<br>";
                description.InnerHtml += pulledClass.Description;
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
                    descriptor4.InnerHtml += pulledClassSkills.ToString();
                    descriptor4.InnerHtml += "<br>";
                }

            }

            //connect to db and populate the links div with 1 link for each entry to DB
            links.InnerHtml = "";
            foreach (Class lClass in classList) {
                int clID = lClass.ClassId;
                string clName = lClass.Name;
                links.InnerHtml += "<a href=\"EncyclopaediaOverview.aspx?encyclopaediaReq=classes&classID=" + clID + "\">" + clName + "</a><br /> ";
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
                description.InnerHtml = "Description: ";
                description.InnerHtml += "<br>";
                description.InnerHtml += pulledRace.Description;
                descriptor2.InnerHtml = "Languages: ";
                descriptor2.InnerHtml += "<br>";
                foreach (Language pulledRaceLangages in pulledRace.Languages) {
                    switch (pulledRaceLangages) {
                        case Language.Common:
                            descriptor2.InnerHtml += "Common";
                            break;
                        case Language.Aarakocra:
                            descriptor2.InnerHtml += "Aarakocra";
                            break;
                        case Language.Auran:
                            descriptor2.InnerHtml += "Auran";
                            break;
                        case Language.Draconic:
                            descriptor2.InnerHtml += "Draconic";
                            break;
                        case Language.Dwarvish:
                            descriptor2.InnerHtml += "Dwarvish";
                            break;
                        case Language.Elvish:
                            descriptor2.InnerHtml += "Elvish";
                            break;
                        case Language.Primordial:
                            descriptor2.InnerHtml += "Primordial";
                            break;
                        case Language.Gnomish:
                            descriptor2.InnerHtml += "Gnomish";
                            break;
                        case Language.Undercommon:
                            descriptor2.InnerHtml += "Undercommon";
                            break;
                        case Language.Giant:
                            descriptor2.InnerHtml += "Giant";
                            break;
                        case Language.Orc:
                            descriptor2.InnerHtml += "Orc";
                            break;
                        case Language.Halfling:
                            descriptor2.InnerHtml += "Halfling";
                            break;
                        case Language.Infernal:
                            descriptor2.InnerHtml += "Inernal";
                            break;
                        case Language.Celestial:
                            descriptor2.InnerHtml += "Celestial";
                            break;
                        default:
                            break;
                    }
                    descriptor2.InnerHtml += "<br>";
                }
            }

            //connect to db and populate the links div with 1 link for each entry to DB
            links.InnerHtml = "";
            foreach (Race lRace in raceList) {
                int raID = lRace.RaceId;
                string raName = lRace.Name;
                links.InnerHtml += "<a href=\"EncyclopaediaOverview.aspx?encyclopaediaReq=races&raceID=" + raID + "\">" + raName + "</a><br /> ";
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
                description.InnerHtml = "Description:";
                description.InnerHtml += "<br>";
                description.InnerHtml += pulledSpell.Description;
                descriptor2.InnerHtml = "CastingTime:";
                descriptor2.InnerHtml += "<br>";
                descriptor2.InnerHtml = Convert.ToString(pulledSpell.CastingTime);
                descriptor3.InnerHtml = "Duration:";
                descriptor3.InnerHtml += "<br>";
                descriptor3.InnerHtml = Convert.ToString(pulledSpell.Duration);
                descriptor4.InnerHtml = "range:";
                descriptor4.InnerHtml += "<br>";
                descriptor4.InnerHtml = Convert.ToString(pulledSpell.Range);
            }
            //connect to db and populate the links div with 1 link for each entry to DB
            links.InnerHtml = "";
            foreach (Spells lSpell in spellList) {
                int spID = lSpell.SpellId;
                string spName = lSpell.Name;
                links.InnerHtml += "<a href=\"EncyclopaediaOverview.aspx?encyclopaediaReq=spells&spellID=" + spID + "\">" + spName + "</a><br /> ";
            }

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
                description.InnerHtml = "Description:";
                description.InnerHtml += "<br>";
                description.InnerHtml += pulledBackground.Description;
                descriptor2.InnerHtml = "PersonalityTraits:";
                descriptor2.InnerHtml += "<br>";
                foreach (String pulledBackgroundPersonalityTrait in pulledBackground.Personality) {
                    descriptor2.InnerHtml = pulledBackgroundPersonalityTrait;
                    descriptor2.InnerHtml += "<br>";
                }
                descriptor3.InnerHtml = "Ideals:";
                descriptor3.InnerHtml += "<br>";
                foreach (String pulledBackgroundIdeal in pulledBackground.Ideals) {
                    descriptor3.InnerHtml = pulledBackgroundIdeal;
                    descriptor3.InnerHtml += "<br>";
                }
                descriptor4.InnerHtml = "Bonds:";
                descriptor4.InnerHtml += "<br>";
                foreach (String pulledBackgroundBond in pulledBackground.Bonds) {
                    descriptor4.InnerHtml = pulledBackgroundBond;
                    descriptor4.InnerHtml += "<br>";
                }
                descriptor5.InnerHtml = "PersonalityTraits:";
                descriptor5.InnerHtml += "<br>";
                foreach (String pulledBackgroundFlaw in pulledBackground.Flaws) {
                    descriptor5.InnerHtml = pulledBackgroundFlaw;
                    descriptor5.InnerHtml += "<br>";
                }
            }
            //connect to db and populate the links div with 1 link for each entry to DB
            links.InnerHtml = "";
            foreach (Background lBackground in backgroundList) {
                int bgID = lBackground.BackgroundId;
                string bgName = lBackground.Name;
                links.InnerHtml += "<a href=\"EncyclopaediaOverview.aspx?encyclopaediaReq=backgroundTypes&backgroundID=" + bgID + "\">" + bgName + "</a><br /> ";
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
                description.InnerHtml = "Description:";
                description.InnerHtml += "<br>";
                description.InnerHtml += pulledFeature.Description;


            }
            //connect to db and populate the links div with 1 link for each entry to DB
            links.InnerHtml = "";
            foreach (Feature lFeature in featureList) {
                int ftID = lFeature.FeatureID;
                string ftName = lFeature.Name;
                links.InnerHtml += "<a href=\"EncyclopaediaOverview.aspx?encyclopaediaReq=Features&featureID=" + ftID + "\">" + ftName + "</a><br /> ";
            }
        }

    }
}
