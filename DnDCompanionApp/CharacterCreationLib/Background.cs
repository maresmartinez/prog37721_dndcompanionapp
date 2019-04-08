using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CharacterCreationLib {
    /// <summary>
    /// The background of a DnD character, which determines personality, ideals, bonds, and flaws to help build a backstory
    /// </summary>
    public class Background : IComparable<Background> {

        /// <summary>
        /// Database identifier of background
        /// </summary>
        public int BackgroundId { get; set; }

        /// <summary>
        /// Name of background
        /// </summary>
        string name;
        /// <summary>
        /// Name of background
        /// </summary>
        public string Name {
            get { return name;  }
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
        /// Personality traits available to background
        /// </summary>
        public List<string> Personality { get; set; }

        /// <summary>
        /// Ideals available to background
        /// </summary>
        public List<string> Ideals { get; set; }

        /// <summary>
        /// Bonds available to background
        /// </summary>
        public List<string> Bonds { get; set; }

        /// <summary>
        /// Flaws available to background
        /// </summary>
        public List<string> Flaws { get; set; }

        /// <summary>
        /// Constructor without ID, used for inserting record into database
        /// </summary>
        /// <param name="name">Name of background</param>
        /// <param name="description">Description of background</param>
        /// <param name="personality">Personality of background</param>
        /// <param name="ideals">Ideals of background</param>
        /// <param name="bonds">Bonds of background</param>
        /// <param name="flaws">Flaws of background</param>
        public Background(string name, string description, 
            List<string> personality, List<string> ideals, List<string> bonds, List<string> flaws) {
            Name = name;
            Description = description;
            Personality = personality;
            Ideals = ideals;
            Bonds = bonds;
            Flaws = flaws;
        }

        /// <summary>
        /// Constructor with ID, used for retrieving record from database
        /// </summary>
        /// <param name="backgroundId">ID of background</param>
        /// <param name="name">Name of background</param>
        /// <param name="description">Description of background</param>
        /// <param name="personality">Personality of background</param>
        /// <param name="ideals">Ideals of background</param>
        /// <param name="bonds">Bonds of background</param>
        /// <param name="flaws">Flaws of background</param>
        public Background(int backgroundId, string name, string description, 
            List<string> personality, List<string> ideals, List<string> bonds, List<string> flaws) {
            BackgroundId = backgroundId;
            Name = name;
            Description = description;
            Personality = personality;
            Ideals = ideals;
            Bonds = bonds;
            Flaws = flaws;
        }

        /// <summary>
        /// Describes the background object
        /// </summary>
        /// <returns>Description of background</returns>
        public override string ToString() {
            return Name;
        }

        /// <summary>
        /// Compares background by Name field
        /// </summary>
        /// <param name="other">Background to compare</param>
        /// <returns>Integer that compares relative position in alphabet</returns>
        public int CompareTo(Background other) {
            return string.Compare(Name, other.Name);
        }
    }
}
