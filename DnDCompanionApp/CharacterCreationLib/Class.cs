using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CharacterCreationLib {
    [Serializable]
    public class Class {
        string name;
        string description;
        List<Feature> features;
        Dice hitDice;
        List<Skills> characterSkills;
        List<Spells> classSpells;

        public int ClassId { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public List<Feature> Features { get; set; }
        public Dice HitDice { get; set; }
        public List<Skills> CharacterSkills {
            get {
                return characterSkills;
            }
            set {
                foreach (object skill in value) {
                    if (!Enum.IsDefined(typeof(Skills), skill)) {
                        throw new ArgumentException("Not a Skill enum");
                    }
                }
                characterSkills = value;
            }
        }
        public List<Spells> ClassSpells { get; set; }

        public Class() {

        }

        public Class(string name, string description, List<Feature> features, Dice hitDice, List<Skills> skills) {
            Name = name;
            Description = description;
            Features = features;
            HitDice = hitDice;
            CharacterSkills = skills;
        }

        public Class(int id, string name, string description, List<Feature> features, Dice hitDice, List<Skills> skills) {
            ClassId = id;
            Name = name;
            Description = description;
            Features = features;
            HitDice = hitDice;
            CharacterSkills = skills;
        }

        public override string ToString() {
            return Name;
        }
    }
}
