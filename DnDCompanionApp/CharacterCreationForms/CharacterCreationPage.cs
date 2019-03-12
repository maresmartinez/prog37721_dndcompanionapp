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
    public partial class CharacterCreationPage : UserControl {

        public CharacterCreationPage() {
            InitializeComponent();
        }

        private void CharacterCreationPage_Load(object sender, EventArgs e) {

            // --------------------------------------------------------------------------------------------------------------------------------
            // TODO: replace the following section with database queries
            // --------------------------------------------------------------------------------------------------------------------------------

            // ------------------------------------------------       START       -------------------------------------------------------------

            // Retrieve all Races 
            // Ref: https://www.dndbeyond.com/races
            List<Race> races = new List<Race>();
            races.Add(new Race(
                "Dragonborn",
                "Dragonborn look very much like dragons standing erect in humanoid form, " +
                "though they lack wings or a tail.",
                new List<Language>(
                    new Language[] {
                        Language.DRACONAIN
                    }
                )
            ));
            races.Add(new Race(
                "Elvish",
                "Elves are a magical people of otherworldly grace, " +
                "living in the world but not entirely part of it.",
                new List<Language>(
                    new Language[] {
                        Language.ELVISH
                    }
                )
            ));
            races.Add(new Race(
                "Human",
                "Humans are the most adaptable and ambitious people among the common races. " +
                "Whatever drives them, humans are the innovators, the achievers, and the pioneers " +
                "of the worlds.",
                new List<Language>(
                    new Language[] {
                        Language.COMMON
                    }
                )
            ));
            
            // Retrieve all Classes
            // Ref: https://www.dndbeyond.com/classes
            List<Class> classes = new List<Class>();
            classes.Add(new Class(
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
            ));
            classes.Add(new Class(
                "Sorcerer",
                "A spellcaster who draws on inherent magic from a gift or bloodline.",
                new List<Feature>(
                    // Initializing list with features
                    new Feature[] {
                        new Feature("Sorcerous Origin",
                            "Choose a sorcerous origin, which describes the source of your innate magical " +
                            "power: Draconic Bloodline, wild magic, or other."),
                        new Feature("Font of Magic",
                            "You tap into a deep wellspring of magic within yourself. This wellspring is " +
                            "represented by sorcery points, which allow you to create a variety of magical " +
                            "effects."),
                        new Feature("Metamagic",
                            "You gain the ability to twist your spells to suit your needs. You gain two of the " +
                            "following Metamagic options: Careful Spell, Distant Spell, Empowered Spell, " +
                            "Extended Spell, Heightened Spell, Quickened Spell, Subtle Spell, or Twinned " +
                            "Spell."),
                    }
                ),
                new Dice(6),
                new List<Skills>(
                    new Skills[] {
                        Skills.ARCANA,
                        Skills.DECEPTION,
                        Skills.INSIGHT,
                        Skills.INTIMIDATION,
                        Skills.PERSUASION,
                        Skills.RELIGION
                    }
                )
            ));
            classes.Add(new Class(
                "Bard",
                "An inspiting magician whose power echoes the music of creation.",
                new List<Feature>(
                    // Initializing list with features
                    new Feature[] {
                        new Feature("Bardic Inspiration",
                            "You can inspire others through stirring words or music. To do so, you use " +
                            "a bonus acation on your turn to choose one creature other than yourself " +
                            "within 60 =ft of you who can hear you. That creature gains one Bardic Inspiration " +
                            "die, a D6."),
                        new Feature("Jack of All Trades",
                            "You can add half your proficiency bonus, rounded down, to any ability check " +
                            "that doesn't already include your proficiency bonus."),
                        new Feature("Song of Rest",
                            "You can use soothing music or oration to help revitalize your wounded allies " +
                            "during a short rest. Each of those creatures regains an extra 1d6 hit points."),
                    }
                ),
                new Dice(8),
                // This class has ALL skills
                new List<Skills>(
                    (Skills[])Enum.GetValues(typeof(Skills))
                )
            ));

            // Retrieve all backgrounds 
            // Ref: https://www.dndbeyond.com/backgrounds
            List<Background> backgrounds = new List<Background>();
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

            // ------------------------------------------------       END       -------------------------------------------------------------

            // Add races, classes, and backgrounds to combo boxes 
            cbRace.DataSource = races;
            cbRace.DisplayMember = "Name";

            cbClass.DataSource = classes;
            cbClass.DisplayMember = "Name";

            cbBackground.DataSource = backgrounds;
            cbBackground.DisplayMember = "Name";

        }

        private void btnGenerate_Click(object sender, EventArgs e) {
            // Form validation
            string errors = ""; // Describes errors

            string name = txtName.Text;
            if (string.IsNullOrEmpty(name)) {
                errors += "Name must have a value.\n";
            }

            Race selectedRace = (Race) cbRace.SelectedItem;

            Class selectedClass = (Class) cbClass.SelectedItem;

            Background selectedBackground = (Background) cbBackground.SelectedItem;
            List<string> personality = lbPersonality.SelectedItems.Cast<string>().ToList();
            if (personality.Count != 2) {
                errors += "Exactly TWO personality traits must be chosen.\n";
            }
            List<string> ideals = lbIdeals.SelectedItems.Cast<string>().ToList();
            if (ideals.Count != 2) {
                errors += "Exactly TWO ideals must be chosen.\n";
            }
            List<string> bonds = lbBonds.SelectedItems.Cast<string>().ToList();
            if (bonds.Count != 2) {
                errors += "Exactly TWO bonds must be chosen.\n";
            }
            List<string> flaws = lbFlaws.SelectedItems.Cast<string>().ToList();
            if (flaws.Count != 2) {
                errors += "Exactly TWO Flaws must be chosen.\n";
            }

            // No need to validate stats because they are generated by the application
            if (string.IsNullOrEmpty(txtStrength.Text)) {
                errors += "Stats must be rolled.";
            }

            if (!string.IsNullOrEmpty(errors)) {
                MessageBox.Show(errors);
                return;
            }

            int strength = int.Parse(txtStrength.Text);
            int dexterity = int.Parse(txtDexterity.Text);
            int constitution = int.Parse(txtConstitution.Text);
            int intelligence = int.Parse(txtIntelligence.Text);
            int wisdom = int.Parse(txtWisdom.Text);
            int charisma = int.Parse(txtCharisma.Text);
            int strMod = int.Parse(txtStrMod.Text);
            int dexMod = int.Parse(txtDexMod.Text);
            int conMod = int.Parse(txtConMod.Text);
            int intMod = int.Parse(txtIntMod.Text);
            int wisMod = int.Parse(txtWisMod.Text);
            int chrMod = int.Parse(txtChrMod.Text);

            // These fields can be null
            string hair = txtHair.Text;
            string eyes = txtEyes.Text;
            string skin = txtSkin.Text;
            string notes = txtNotes.Text;

            // Generate character
            Character character = new Character();
            character.Name = name;
            character.Strength = strength;
            character.Dexterity = dexterity;
            character.Constitution = constitution;
            character.Intelligence = intelligence;
            character.Wisdom = wisdom;
            character.Charisma = charisma;
            character.StrMod = strMod;
            character.DexMod = dexMod;
            character.ConMod = conMod;
            character.IntMod = intMod;
            character.WisMod = wisMod;
            character.ChrMod = chrMod;
            character.FeatureList = selectedClass.Features;
            character.CharacterBackground = new Background(
                selectedBackground.Name,
                selectedBackground.Description,
                personality,
                ideals,
                bonds,
                flaws
            );
            character.Hair = (!string.IsNullOrEmpty(hair)) ? hair : "N/A";
            character.Eyes = (!string.IsNullOrEmpty(eyes)) ? eyes : "N/A";
            character.Skin = (!string.IsNullOrEmpty(skin)) ? skin : "N/A";
            character.AdditionalNotes = (!string.IsNullOrEmpty(hair)) ? notes : "N/A";
            character.Race = selectedRace;
            character.CharacterClass = selectedClass;

            // Go to Character Output Page
            CharacterPreviewForm preview = new CharacterPreviewForm(character);
            DialogResult result = preview.ShowDialog();
            if (result == DialogResult.OK) {
                MessageBox.Show("Save functionality not implemented yet.");
            }
        }

        private void cbRace_SelectedIndexChanged(object sender, EventArgs e) {
            if (cbRace.SelectedItem == null) {
                return;
            }
            txtRaceDesc.Text = ((Race)cbRace.SelectedItem).ToString();
        }

        private void cbClass_SelectedIndexChanged(object sender, EventArgs e) {
            if (cbClass.SelectedItem == null) {
                return;
            }
            txtClassDesc.Text = ((Class)cbClass.SelectedItem).ToString();
        }

        private void cbBackground_SelectedIndexChanged(object sender, EventArgs e) {
            if (cbBackground.SelectedItem == null) {
                return;
            }

            Background selectedBackground = (Background)cbBackground.SelectedItem;

            txtBackgroundDesc.Text = selectedBackground.ToString();

            lbPersonality.DataSource = selectedBackground.Personality;
            lbPersonality.SelectedItems.Clear();
            lbIdeals.DataSource = selectedBackground.Ideals;
            lbIdeals.SelectedItems.Clear();
            lbBonds.DataSource = selectedBackground.Bonds;
            lbBonds.SelectedItems.Clear();
            lbFlaws.DataSource = selectedBackground.Flaws;
            lbFlaws.SelectedItems.Clear();
        }

        private void btnRollStats_Click(object sender, EventArgs e) {

            Random rand = new Random();

            // Generate number between 1 and 20
            txtStrength.Text = rand.Next(1, 21).ToString();
            txtDexterity.Text = rand.Next(1, 21).ToString();
            txtConstitution.Text = rand.Next(1, 21).ToString();
            txtIntelligence.Text = rand.Next(1, 21).ToString();
            txtWisdom.Text = rand.Next(1, 21).ToString();
            txtCharisma.Text = rand.Next(1, 21).ToString();

            // Generate number between -5 and +10
            txtStrMod.Text = (rand.Next(1, 16) - 5).ToString();
            txtDexMod.Text = (rand.Next(1, 16) - 5).ToString();
            txtConMod.Text = (rand.Next(1, 16) - 5).ToString();
            txtIntMod.Text = (rand.Next(1, 16) - 5).ToString();
            txtWisMod.Text = (rand.Next(1, 16) - 5).ToString();
            txtChrMod.Text = (rand.Next(1, 16) - 5).ToString();
        }
    }
}
