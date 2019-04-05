using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CharacterCreationLib {
    [Serializable]
    public class Feature {

        string name;
        public string Name {
            get { return name; }
            set {
                if (string.IsNullOrEmpty(value)) {
                    throw new ArgumentException("Name must have a value");
                }
                name = value;
            }
        }

        string description;
        public string Description {
            get { return description; }
            set {
                if (string.IsNullOrEmpty(value)) {
                    throw new ArgumentException("Description must have a value");
                }
                description = value;
            }
        }

        public int FeatureID { get; set; }

        public Feature() {

        }
        public Feature(string name, string description) {
            Name = name;
            Description = description;
        }

        public override string ToString() {
            return $"{Name} - {Description}";
        }
    }
}
