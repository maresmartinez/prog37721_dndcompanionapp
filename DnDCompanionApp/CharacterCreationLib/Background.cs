using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CharacterCreationLib {
    [Serializable]
    public class Background {
        int backgroundId;
        string name;
        string description;
        List<string> personality;
        List<string> ideals;
        List<string> bonds;
        List<string> flaws;

        public int BackgroundId { get; set; }
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

        public Background(int backgroundId, List<string> personality, List<string> ideals, List<string> bonds, List<string> flaws)
        {
            BackgroundId = backgroundId;
            Personality = personality;
            Ideals = ideals;
            Bonds = bonds;
            Flaws = flaws;
        }

        public override string ToString() {
            return $"{Name}: {Description}";
        }

        public string OtherToString()
        {
            return $"{Personality[0]}";
        }
    }
}
