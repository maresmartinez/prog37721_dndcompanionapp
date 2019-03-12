using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CharacterCreationLib {
    public class Class {
        string name;
        string description;
        List<Feature> features;
        Dice hitDice;
        List<Skills> characterSkills;

        public string Name { get; set; }
        public string Description { get; set; }
        public List<Feature> Features { get; set; }
        public Dice HitDice { get; set; }
        public List<Skills> CharacterSkills { get; set; }

        public Class() {

        }

        public Class(string name, string description, List<Feature> features, Dice hitDice, List<Skills> skills) {
            Name = name;
            Description = description;
            Features = features;
            HitDice = hitDice;
            CharacterSkills = skills;
        }

        public override string ToString() {
            string classDetails = $"{Name}: {Description} {Environment.NewLine}{Environment.NewLine}";

            classDetails += $"Features: {Environment.NewLine}";
            foreach(Feature feature in Features) {
                classDetails += $"{feature.ToString()} {Environment.NewLine}";
            }

            classDetails += $"{Environment.NewLine}Hit Dice: {HitDice} {Environment.NewLine}";

            classDetails += $"{Environment.NewLine}Skills: {Environment.NewLine}";
            foreach (Skills skill in CharacterSkills) {
                classDetails += $"{skill} {Environment.NewLine}";
            }

            return classDetails;
        }
    }
}
