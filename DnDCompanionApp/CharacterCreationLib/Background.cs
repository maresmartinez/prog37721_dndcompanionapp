using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CharacterCreationLib {
    public class Background {


        string name;
        string description;
        List<string> personality;
        List<string> ideals;
        List<string> bonds;
        List<string> flaws;

        public string Name { get; set; }
        public string Description { get; set; }
        public List<string> Personality { get; set; }
        public List<string> Ideals { get; set; }
        public List<string> Bonds { get; set; }
        public List<string> Flaws { get; set; }

        public Background() {

        }

        public Background(string name, string description, List<string> personality, List<string> ideals, List<string> bonds, List<string> flaws) {
            Name = name;
            Description = description;
            Personality = personality;
            Ideals = ideals;
            Bonds = bonds;
            Flaws = flaws;
        }

        public override string ToString() {
            return $"{Name}: {Description}";
        }
    }
}
