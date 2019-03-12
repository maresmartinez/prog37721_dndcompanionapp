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
        List<Skills> skillList;
        List<string> actions;
        List<Spells> spellList;
        List<Feature> featureList;
        Background characterBackground;
        string hair;//can be null
        string eyes;//can be null
        string skin;//can be null
        string additionalNotes;//can be null
        Race race;
        Class characterClass;

        public string Name { get; set; }
        public int Strength { get; set; }
        public int Dexterity { get; set; }
        public int Constitution { get; set; }
        public int Intelligence { get; set; }
        public int Wisdom { get; set; }
        public int Charisma { get; set; }
        public int StrMod { get; set; }
        public int DexMod { get; set; }
        public int ConMod { get; set; }
        public int IntMod { get; set; }
        public int WisMod { get; set; }
        public int ChrMod { get; set; }
        public List<Skills> SkillList { get; set; }
        public List<string> Actions { get; set; }
        public List<Spells> SpellList { get; set; }
        public List<Feature> FeatureList { get; set; }
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
            int dexMod, int conMod, int intMod, int wisMod, int chrMod, List<Skills> skills, List<string> actions, List<Spells> spells,
            List<Feature> features, Background characterBackground, string hair, string eyes, string skin, string additionalNotes, Race race, Class characterClass) {
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
            SkillList = skills;
            Actions = actions;
            SpellList = spells;
            FeatureList = features;
            CharacterBackground = characterBackground;
            Hair = hair;
            Eyes = eyes;
            Skin = skin;
            AdditionalNotes = additionalNotes;
            Race = race;
            CharacterClass = characterClass;
        }



        public override string ToString() {
            return name;
        }

    }
}
