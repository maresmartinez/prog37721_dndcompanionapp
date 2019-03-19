using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CharacterCreationLib {
    public class Race {
        string name;
        string description;
        List<Language> languages;

        public string Name { get; set; }
        public string Description { get; set; }
        public List<Language> Languages {
            get {
                return languages;
            }
            set {
                int track = 1;
                foreach (int i in value) {
                    if (!Enum.IsDefined(typeof(Skills), value)) {
                        track = 0;
                    }
                }
                if (track == 1) {
                    languages = value;
                } else {
                    throw new ArgumentException("Character skills is not valid");
                }
            }
        }

        public Race() {

        }
        public Race(string name, string description, List<Language> languages) {
            Name = name;
            Description = description;
            Languages = languages;
        }

        public override string ToString() {
            string raceDesc = $"{Name}: {Description} {Environment.NewLine}" +
                $"Languages: {Environment.NewLine}";
            foreach (Language language in Languages) {
                raceDesc += $"{language}";
            }

            return raceDesc;
        }
    }
}
