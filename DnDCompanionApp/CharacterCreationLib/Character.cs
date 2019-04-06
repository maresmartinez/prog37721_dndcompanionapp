using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CharacterCreationLib {
    /// <summary>
    /// The character is the persona through which a player explores the fantasy world of DnD
    /// </summary>
    public class Character {

        /// <summary>
        /// Database identifier
        /// </summary>
        int dbID;
        /// <summary>
        /// Database identifier
        /// </summary>
        public int DbID {
            get { return dbID; }
            set {
                if (value < 0) {
                    throw new ArgumentException("Database ID must be a positive value");
                }
                dbID = value;
            }
        }

        /// <summary>
        /// Database ID of the type of background the character has
        /// </summary>
        int backgroundTypeID;
        /// <summary>
        /// Database ID of the type of background the character has
        /// </summary>
        public int BackgroundTypeID {
            get { return backgroundTypeID; }
            set {
                if (value < 0) {
                    throw new ArgumentException("Background Type ID must be a postive value");
                }
                backgroundTypeID = value;
            }
        }

        /// <summary>
        /// Datbase ID of the specific background traits the character has (which are based off the base background type)
        /// </summary>
        int charBackgroundID;
        /// <summary>
        /// Datbase ID of the specific background traits the character has (which are based off the base background type)
        /// </summary>
        public int CharBackgroundID {
            get { return charBackgroundID; }
            set {
                if (value < 0) {
                    throw new ArgumentException("Character Background ID must be a positive value");
                }
                charBackgroundID = value;
            }
        }

        /// <summary>
        /// Name of character
        /// </summary>
        string name;
        /// <summary>
        /// Name of character
        /// </summary>
        public string Name {
            get { return name;  }
            set {
                if (string.IsNullOrEmpty(value)) {
                    throw new ArgumentException("Name must have a value");
                }
                name = value;
            }
        }

        /// <summary>
        /// Measures a character's physical power
        /// </summary>
        int strength;
        /// <summary>
        /// Measures a character's physical power
        /// </summary>
        public int Strength {
            get {
                return strength;
            }
            set {
                if (value >= 1 && value <= 20) {
                    strength = value;
                } else throw new ArgumentException(value + " is out of the range of strength");
            }
        }

        /// <summary>
        /// Measures a character's agility
        /// </summary>
        int dexterity;
        /// <summary>
        /// Measures a character's agility
        /// </summary>
        public int Dexterity {
            get {
                return dexterity;
            }
            set {
                if (value >= 1 && value <= 20) {
                    dexterity = value;
                } else throw new ArgumentException(value + " is out of the range of dexterity");
            }
        }

        /// <summary>
        /// Measures a character's endurance
        /// </summary>
        int constitution;
        /// <summary>
        /// Measures a character's endurance
        /// </summary>
        public int Constitution {
            get {
                return constitution;
            }
            set {
                if (value >= 1 && value <= 20) {
                    constitution = value;
                } else throw new ArgumentException(value + " is out of the range of constitution");
            }
        }

        /// <summary>
        /// Mesaures a character's reasoning and memory
        /// </summary>
        int intelligence;
        /// <summary>
        /// Mesaures a character's reasoning and memory
        /// </summary>
        public int Intelligence {
            get {
                return intelligence;
            }
            set {
                if (value >= 1 && value <= 20) {
                    intelligence = value;
                } else throw new ArgumentException(value + " is out of the range of intelligence");
            }
        }

        /// <summary>
        /// Measures a character's perception and insight
        /// </summary>
        int wisdom;
        /// <summary>
        /// Measures a character's perception and insight
        /// </summary>
        public int Wisdom {
            get {
                return wisdom;
            }
            set {
                if (value >= 1 && value <= 20) {
                    wisdom = value;
                } else throw new ArgumentException(value + " is out of the range of wisdom");
            }
        }

        /// <summary>
        /// Measures a character's force of personality
        /// </summary>
        int charisma;
        /// <summary>
        /// Measures a character's force of personality
        /// </summary>
        public int Charisma {
            get {
                return charisma;
            }
            set {
                if (value >= 1 && value <= 20) {
                    charisma = value;
                } else throw new ArgumentException(value + " is out of the range of charisma");
            }
        }

        /// <summary>
        /// The strength modifier that is added when making strength skill checks
        /// </summary>
        int strMod;
        /// <summary>
        /// The strength modifier that is added when making strength skill checks
        /// </summary>
        public int StrMod {
            get {
                return strMod;
            }
            set {
                if (value >= -5 && value <= 15) {
                    strMod = value;
                } else throw new ArgumentException(value + " is out of the range of strMod");
            }
        }

        /// <summary>
        /// The dexterity modifier that is added when making strength skill checks
        /// </summary>
        int dexMod;
        /// <summary>
        /// The dexterity modifier that is added when making strength skill checks
        /// </summary>
        public int DexMod {
            get {
                return dexMod;
            }
            set {
                if (value >= -5 && value <= 15) {
                    dexMod = value;
                } else throw new ArgumentException(value + " is out of the range of dexMod");
            }
        }

        /// <summary>
        /// The constitution modifier that is added when making strength skill checks
        /// </summary>
        int conMod;
        /// <summary>
        /// The constitution modifier that is added when making strength skill checks
        /// </summary>
        public int ConMod {
            get {
                return conMod;
            }
            set {
                if (value >= -5 && value <= 15) {
                    conMod = value;
                } else throw new ArgumentException(value + " is out of the range of conMod");
            }
        }

        /// <summary>
        /// The intelligence modifier that is added when making strength skill checks
        /// </summary>
        int intMod;
        /// <summary>
        /// The intelligence modifier that is added when making strength skill checks
        /// </summary>
        public int IntMod {
            get {
                return intMod;
            }
            set {
                if (value >= -5 && value <= 15) {
                    intMod = value;
                } else throw new ArgumentException(value + " is out of the range of intMod");
            }
        }

        /// <summary>
        /// The wisdom modifier that is added when making strength skill checks
        /// </summary>
        int wisMod;
        /// <summary>
        /// The wisdom modifier that is added when making strength skill checks
        /// </summary>
        public int WisMod {
            get {
                return wisMod;
            }
            set {
                if (value >= -5 && value <= 15) {
                    wisMod = value;
                } else throw new ArgumentException(value + " is out of the range of wisMod");
            }
        }

        /// <summary>
        /// The charisma modifier that is added when making strength skill checks
        /// </summary>
        int chrMod;
        /// <summary>
        /// The charisma modifier that is added when making strength skill checks
        /// </summary>
        public int ChrMod {
            get {
                return chrMod;
            }
            set {
                if (value >= -5 && value <= 15) {
                    chrMod = value;
                } else throw new ArgumentException(value + " is out of the range of ChrMod");
            }
        }

        /// <summary>
        /// The character's background and the specific personality, ideal, bonds, and flaws that were chosen from that background
        /// </summary>
        public Background CharacterBackground { get; set; }

        /// <summary>
        /// Description of the character's hair, can be null
        /// </summary>
        public string Hair { get; set; }

        /// <summary>
        /// Description of the character's eyes, can be null
        /// </summary>
        public string Eyes { get; set; }

        /// <summary>
        /// Description of the character's skin, can be null
        /// </summary>
        public string Skin { get; set; }

        /// <summary>
        /// Additional notes that the player may want to use to describe their character, can be null
        /// </summary>
        public string AdditionalNotes { get; set; }

        /// <summary>
        /// The race of the character
        /// </summary>
        Race race;
        /// <summary>
        /// The race of the character
        /// </summary>
        public Race Race {
            get { return race; }
            set {
                race = value ?? throw new ArgumentException("Race cannot be null");
            }
        }

        Class characterClass;
        /// <summary>
        /// The class of the character
        /// </summary>
        public Class CharacterClass {
            get { return characterClass; }
            set {
                characterClass = value ?? throw new ArgumentException("Character class cannot be null");
            }
        }

        /// <summary>
        /// Constructor with ID, used for retrieving a record from the database
        /// </summary>
        /// <param name="id">ID of character</param>
        /// <param name="name">Name of character</param>
        /// <param name="strength">Strength stat of character</param>
        /// <param name="dexterity">Dexterity stat of character</param>
        /// <param name="constitution">Constitution stat of character</param>
        /// <param name="intelligence">Intelligence stat of character</param>
        /// <param name="wisdom">Wisdom stat of character</param>
        /// <param name="charisma">Charisma stat of character</param>
        /// <param name="strMod">Strength modifier of character</param>
        /// <param name="dexMod">Dexterity modifier of character</param>
        /// <param name="conMod">Constitution modifier of character</param>
        /// <param name="intMod">Intelligence modifier of character</param>
        /// <param name="wisMod">Wisdom modifier of character</param>
        /// <param name="chrMod">Charisma modifier of character</param>
        /// <param name="characterBackground">Background of character</param>
        /// <param name="hair">Description of character's hair</param>
        /// <param name="eyes">Description of character's eyes</param>
        /// <param name="skin">Description of character's skin</param>
        /// <param name="additionalNotes">Additional notes that the user may want to input about the character</param>
        /// <param name="race">Race of character</param>
        /// <param name="characterClass">Class of character</param>
        public Character(string name, int strength, int dexterity, int constitution, int intelligence, int wisdom, int charisma, int strMod,
            int dexMod, int conMod, int intMod, int wisMod, int chrMod, Background characterBackground, string hair, 
            string eyes, string skin, string additionalNotes, Race race, Class characterClass) {
            Name = name;
            Strength = strength;
            Dexterity = dexterity;
            Constitution = constitution;
            Intelligence = intelligence;
            Wisdom = wisdom;
            Charisma = charisma;
            StrMod = strMod;
            DexMod = dexMod;
            ConMod = conMod;
            IntMod = intMod;
            WisMod = wisMod;
            ChrMod = chrMod;
            CharacterBackground = characterBackground;
            Hair = hair;
            Eyes = eyes;
            Skin = skin;
            AdditionalNotes = additionalNotes;
            Race = race;
            CharacterClass = characterClass;
        }

        /// <summary>
        /// Constructor with ID, used for retrieving a record from the database
        /// </summary>
        /// <param name="id">ID of character</param>
        /// <param name="name">Name of character</param>
        /// <param name="strength">Strength stat of character</param>
        /// <param name="dexterity">Dexterity stat of character</param>
        /// <param name="constitution">Constitution stat of character</param>
        /// <param name="intelligence">Intelligence stat of character</param>
        /// <param name="wisdom">Wisdom stat of character</param>
        /// <param name="charisma">Charisma stat of character</param>
        /// <param name="strMod">Strength modifier of character</param>
        /// <param name="dexMod">Dexterity modifier of character</param>
        /// <param name="conMod">Constitution modifier of character</param>
        /// <param name="intMod">Intelligence modifier of character</param>
        /// <param name="wisMod">Wisdom modifier of character</param>
        /// <param name="chrMod">Charisma modifier of character</param>
        /// <param name="characterBackground">Background of character</param>
        /// <param name="hair">Description of character's hair</param>
        /// <param name="eyes">Description of character's eyes</param>
        /// <param name="skin">Description of character's skin</param>
        /// <param name="additionalNotes">Additional notes that the user may want to input about the character</param>
        /// <param name="race">Race of character</param>
        /// <param name="characterClass">Class of character</param>
        public Character(int id, string name, int strength, int dexterity, int constitution, int intelligence, int wisdom, int charisma, int strMod,
            int dexMod, int conMod, int intMod, int wisMod, int chrMod, Background characterBackground, string hair,
            string eyes, string skin, string additionalNotes, Race race, Class characterClass) {
            DbID = id;
            Name = name;
            Strength = strength;
            Dexterity = dexterity;
            Constitution = constitution;
            Intelligence = intelligence;
            Wisdom = wisdom;
            Charisma = charisma;
            StrMod = strMod;
            DexMod = dexMod;
            ConMod = conMod;
            IntMod = intMod;
            WisMod = wisMod;
            ChrMod = chrMod;
            CharacterBackground = characterBackground;
            Hair = hair;
            Eyes = eyes;
            Skin = skin;
            AdditionalNotes = additionalNotes;
            Race = race;
            CharacterClass = characterClass;
        }

        /// <summary>
        /// Description of character
        /// </summary>
        /// <returns>Name, Race, Class, and Background of character</returns>
        public override string ToString() {
            return $"{Name}: {Race.Name}, {CharacterClass.Name}, {CharacterBackground.Name}";
        }

        /// <summary>
        /// Checks equality of this character with another object
        /// </summary>
        /// <param name="obj">Object to compate</param>
        /// <returns>Whether or not the character is equal to the given object</returns>
        public override bool Equals(object obj) {
            if (!(obj is Character)) {
                return false;
            }
            Character charObj = (Character)obj;

            // If character name, character race, and character class match, it is the same object
            if (charObj.Name.Equals(this.Name)
                && charObj.Race.Name.Equals(this.Race.Name)
                && charObj.CharacterClass.Name.Equals(this.CharacterClass.Name)) {
                return true;
            }

            return false;
        }

    }
}
