using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CharacterCreationLib {
    /// <summary>
    /// Race of a character describes the character's heritage and defines their background in the fantasy world of DnD
    /// </summary>
    public class Race : IComparable<Race> {

        /// <summary>
        /// Database identifier of race
        /// </summary>
        int raceId;
        /// <summary>
        /// Database identifier of race
        /// </summary>
        public int RaceId {
            get { return raceId; }
            set {
                if (value < 1) {
                    throw new ArgumentException("RaceID must be a positive value");
                }
                raceId = value;
            }
        }

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
        /// Languages which this race can speak
        /// </summary>
        List<Language> languages;
        /// <summary>
        /// Languages which this race can speak
        /// </summary>
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

        /// <summary>
        /// Constructor without ID, used when inserting a record into the database
        /// </summary>
        /// <param name="name">Name of race</param>
        /// <param name="description">Description of race</param>
        /// <param name="languages">Languages which the race can speak</param>
        public Race(string name, string description, List<Language> languages) {
            Name = name;
            Description = description;
            Languages = languages;
        }

        /// <summary>
        /// Constructor with ID, used when retrieving a record from the database
        /// </summary>
        /// <param name="id">ID of race</param>
        /// <param name="name">Name of race</param>
        /// <param name="description">Description of race</param>
        /// <param name="languages">Languages which the race can speak</param>
        public Race(int id, string name, string description, List<Language> languages) {
            RaceId = id;
            Name = name;
            Description = description;
            Languages = languages;
        }

        /// <summary>
        /// Describe the race
        /// </summary>
        /// <returns>Name of race</returns>
        public override string ToString() {
            return Name;
        }

        /// <summary>
        /// Compares race by Name field
        /// </summary>
        /// <param name="other">Race to compare</param>
        /// <returns>Integer that compares relative position in alphabet</returns>
        public int CompareTo(Race other) {
            return string.Compare(Name, other.Name);
        }
    }
}
