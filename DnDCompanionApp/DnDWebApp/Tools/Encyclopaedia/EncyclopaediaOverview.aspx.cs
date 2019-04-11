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
                            name.InnerText = "Classes";
                            ClassLinks();
                            break;
                        case "races":
                            name.InnerText = "Races";
                            RaceLinks();
                            break;
                        case "spells":
                            name.InnerText = "Spell";
                            SpellLinks();
                            break;
                        case "backgroundTypes":
                            name.InnerText = "Backgrounds";
                            BackgroundLinks();
                            break;
                        case "features":
                            name.InnerText = "Features";
                            FeatureLinks();
                            break;
                        default:
                            description.InnerText = "Nothing found by that name";
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
                name.InnerText = pulledClass.Name;
                description.InnerText = "Description: <br />";
                description.InnerText += pulledClass.Description;
                descriptor2.InnerText = "Features: <br />";
                foreach (Feature pulledClassFeatures in pulledClass.Features) {
                    descriptor2.InnerText += pulledClassFeatures.ToString();
                    descriptor2.InnerText += "<br />";
                }
                descriptor3.InnerText = "Hit Dice is:" + pulledClass.HitDice.ToString();


                descriptor4.InnerText = "Available Skills: <br />";
                foreach (Skills pulledClassSkills in pulledClass.CharacterSkills) {
                    descriptor4.InnerText += pulledClassSkills.ToString();
                    descriptor4.InnerText += "<br />";
                }

            }

            //connect to db and populate the links div with 1 link for each entry to DB
            links.InnerText = "";
            foreach (Class lClass in classList) {
                int clID = lClass.ClassId;
                string clName = lClass.Name;
                links.InnerHtml += "<a href=\"EncyclopaediaOverview.aspx?encyclopaediaReq=classes?classID=" + clID + "\"></a>" + clName + "<br /> ";
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
                name.InnerText = pulledRace.Name;
                description.InnerText = "Description: <br />";
                description.InnerText += pulledRace.Description;
                descriptor2.InnerText = "Languages: <br />";
                foreach (Language pulledRaceLangages in pulledRace.Languages) {
                    switch (pulledRaceLangages) {
                        case Language.Common:
                            descriptor2.InnerText += "Common";
                            break;
                        case Language.Aarakocra:
                            descriptor2.InnerText += "Aarakocra";
                            break;
                        case Language.Auran:
                            descriptor2.InnerText += "Auran";
                            break;
                        case Language.Draconic:
                            descriptor2.InnerText += "Draconic";
                            break;
                        case Language.Dwarvish:
                            descriptor2.InnerText += "Dwarvish";
                            break;
                        case Language.Elvish:
                            descriptor2.InnerText += "Elvish";
                            break;
                        case Language.Primordial:
                            descriptor2.InnerText += "Primordial";
                            break;
                        case Language.Gnomish:
                            descriptor2.InnerText += "Gnomish";
                            break;
                        case Language.Undercommon:
                            descriptor2.InnerText += "Undercommon";
                            break;
                        case Language.Giant:
                            descriptor2.InnerText += "Giant";
                            break;
                        case Language.Orc:
                            descriptor2.InnerText += "Orc";
                            break;
                        case Language.Halfling:
                            descriptor2.InnerText += "Halfling";
                            break;
                        case Language.Infernal:
                            descriptor2.InnerText += "Inernal";
                            break;
                        case Language.Celestial:
                            descriptor2.InnerText += "Celestial";
                            break;
                        default:
                            break;
                    }
                    descriptor2.InnerText += "<br />";
                }
            }

            //connect to db and populate the links div with 1 link for each entry to DB
            links.InnerText = "";
            foreach (Race lRace in raceList) {
                int raID = lRace.RaceId;
                string raName = lRace.Name;
                links.InnerHtml += "<a href=\"EncyclopaediaOverview.aspx?encyclopaediaReq=races?raceID=" + raID + "\"></a>" + raName + "<br /> ";
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

                name.InnerText = pulledSpell.Name;
                description.InnerText = "Description: <br />";
                description.InnerText += pulledSpell.Description;
                descriptor2.InnerText = "CastingTime: <br />";
                descriptor2.InnerText = Convert.ToString(pulledSpell.CastingTime);
                descriptor3.InnerText = "Duration: <br />";
                descriptor3.InnerText = Convert.ToString(pulledSpell.Duration);
                descriptor4.InnerText = "range: <br />";
                descriptor4.InnerText = Convert.ToString(pulledSpell.Range);

                //connect to db and populate the links div with 1 link for each entry to DB
                links.InnerText = "";
                foreach (Spells lSpell in spellList) {
                    int spID = lSpell.SpellId;
                    string spName = lSpell.Name;
                    links.InnerText += "<a href=\"EncyclopaediaOverview.aspx?encyclopaediaReq=spells?spellID=" + spID + "\"></a>" + spName + "<br /> ";
                }
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

                name.InnerText = pulledBackground.Name;
                description.InnerText = "Description: <br />";
                description.InnerText += pulledBackground.Description;
                descriptor2.InnerText = "PersonalityTraits: <br />";
                foreach (String pulledBackgroundPersonalityTrait in pulledBackground.Personality) {
                    descriptor2.InnerText = pulledBackgroundPersonalityTrait + "<br />";
                }
                descriptor3.InnerText = "Ideals: <br />";
                foreach (String pulledBackgroundIdeal in pulledBackground.Ideals) {
                    descriptor3.InnerText = pulledBackgroundIdeal + "<br />";
                }
                descriptor4.InnerText = "Bonds: <br />";
                foreach (String pulledBackgroundBond in pulledBackground.Bonds) {
                    descriptor4.InnerText = pulledBackgroundBond + "<br />";
                }
                descriptor4.InnerText = "PersonalityTraits: <br />";
                foreach (String pulledBackgroundFlaw in pulledBackground.Flaws) {
                    descriptor4.InnerText = pulledBackgroundFlaw + "<br />";
                }
                //connect to db and populate the links div with 1 link for each entry to DB
                links.InnerText = "";
                foreach (Background lBackground in backgroundList) {
                    int bgID = lBackground.BackgroundId;
                    string bgName = lBackground.Name;
                    links.InnerText += "<a href=\"EncyclopaediaOverview.aspx?encyclopaediaReq=backgroundTypes?backgroundID=" + bgID + "\"></a>" + bgName + "<br /> ";
                }
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

                name.InnerText = pulledFeature.Name;
                description.InnerText = "Description: <br />";
                description.InnerText += pulledFeature.Description;


                //connect to db and populate the links div with 1 link for each entry to DB
                links.InnerText = "";
                foreach (Feature lFeature in featureList) {
                    int ftID = lFeature.FeatureID;
                    string ftName = lFeature.Name;
                    links.InnerText += "<a href=\"EncyclopaediaOverview.aspx?encyclopaediaReq=Features?spellID=" + ftID + "\"></a>" + ftName + "<br /> ";
                }
            }
        }

    }
}
