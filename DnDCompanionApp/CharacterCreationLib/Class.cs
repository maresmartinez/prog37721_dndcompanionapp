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
        List<string> skills;

        public string Name { get; set; }
        public string Description { get; set; }
        public List<Feature> Features { get; set; }
        public Dice HitDice { get; set; }
        public List<string> Skills { get; set; }

        public Class()
        {

        }
        
        public Class(string name, string description, List<Feature> features, Dice hitDice, List<string> skills)
        {
            Name = name;
            Description = description;
            Features = features;
            HitDice = hitDice;
            Skills = skills;
        }
    }
}
