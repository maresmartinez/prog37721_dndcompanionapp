using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CharacterCreationLib {
    /// <summary>
    /// Class describes the skillset of a character and what their abilities are, in and out of combay
    /// </summary>
    public class Class : IComparable<Class> {
        
        /// <summary>
        /// Database identifier of class
        /// </summary>
        public int ClassId { get; set; }

        /// <summary>
        /// Name of background
        /// </summary>
        string name;
        /// <summary>
        /// Name of background
        /// </summary>
        public string Name {
            get { return name; }
            set {
                if (string.IsNullOrEmpty(value)) {
                    throw new ArgumentException("Name must have a value");
                }
                name = value;
            }
        }

        /// <summary>
        /// Description of background
        /// </summary>
        string description;
        /// <summary>
        /// Description of background
        /// </summary>
        public string Description {
            get { return description; }
            set {
                if (string.IsNullOrEmpty(value)) {
                    throw new ArgumentException("Description must have a value");
                }
                description = value;
            }
        }

        /// <summary>
        /// Features of class which give special abilities
        /// </summary>
        public List<Feature> Features { get; set; }

        /// <summary>
        /// Hit dice which is rolled when character attacks
        /// </summary>
        public Dice HitDice { get; set; }

        /// <summary>
        /// Skills available to character
        /// </summary>
        List<Skills> characterSkills;
        /// <summary>
        /// Skills available to character
        /// </summary>
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

        /// <summary>
        /// The spells available to the class
        /// </summary>
        public List<Spells> ClassSpells { get; set; }

        /// <summary>
        /// Constructor without ID, used when inserting into database
        /// </summary>
        /// <param name="name">Name of class</param>
        /// <param name="description">Description of class</param>
        /// <param name="features">Features of class</param>
        /// <param name="hitDice">Hit dice which is rolled when class attacks</param>
        /// <param name="skills">Skills available to the class</param>
        public Class(string name, string description, List<Feature> features, Dice hitDice, List<Skills> skills) {
            Name = name;
            Description = description;
            Features = features;
            HitDice = hitDice;
            CharacterSkills = skills;
        }

        /// <summary>
        /// Constructor with ID, used when retrieving record from database
        /// </summary>
        /// <param name="id">ID of class</param>
        /// <param name="name">Name of class</param>
        /// <param name="description">Description of class</param>
        /// <param name="features">Features of class</param>
        /// <param name="hitDice">Hit dice which is rolled when class attacks</param>
        /// <param name="skills">Skills available to the class</param>
        public Class(int id, string name, string description, List<Feature> features, Dice hitDice, List<Skills> skills) {
            ClassId = id;
            Name = name;
            Description = description;
            Features = features;
            HitDice = hitDice;
            CharacterSkills = skills;
        }

        /// <summary>
        /// Description of Class
        /// </summary>
        /// <returns>Name of class</returns>
        public override string ToString() {
            return Name;
        }

        /// <summary>
        /// Compares class by Name field
        /// </summary>
        /// <param name="other">Class to compare</param>
        /// <returns>Integer that compares relative position in alphabet</returns>
        public int CompareTo(Class other) {
            return string.Compare(Name, other.Name);
        }
    }
}
