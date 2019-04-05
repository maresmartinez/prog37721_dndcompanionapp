using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CharacterCreationLib {
    [Serializable]
    public class Race {
        string name;
        string description;
        List<Language> languages;

        public int RaceId { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public List<Language> Languages {
            get {
                return languages;
            }
            set {
                foreach (object language in value) {
                    if (!Enum.IsDefined(typeof(Language), language)) {
                        throw new ArgumentException("Not a Language enum");
                    }
                }
                languages = value;
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
            return Name;
        }
    }
}
