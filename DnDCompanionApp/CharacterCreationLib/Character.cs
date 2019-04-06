using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CharacterCreationLib {
    public class Character {
        string name;
        int strength;
        int dexterity;
        int constitution;
        int intelligence;
        int wisdom;
        int charisma;
        int strMod;
        int dexMod;
        int conMod;
        int intMod;
        int wisMod;
        int chrMod;

        // Various DB variables
        public int DbID { get; set; }
        //public int RaceID { get; set; }
        //public int ClassID { get; set; }
        public int BackgroundTypeID { get; set; }
        public int CharBackgroundID { get; set; }
        public int AvailSpellID { get; set; }

        public string Name {
            get { return name;  }
            set {
                if (string.IsNullOrEmpty(value)) {
                    throw new ArgumentException("Name must have a value");
                }
                name = value;
            }
        }

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
        public Background CharacterBackground { get; set; }
        public string Hair { get; set; }
        public string Eyes { get; set; }
        public string Skin { get; set; }
        public string AdditionalNotes { get; set; }
        public Race Race { get; set; }
        public Class CharacterClass { get; set; }

        public Character() {

        }

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

        public override string ToString() {
            return $"{Name}: {Race.Name}, {CharacterClass.Name}, {CharacterBackground.Name}";
        }

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
