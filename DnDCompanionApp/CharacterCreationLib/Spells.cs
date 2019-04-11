using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CharacterCreationLib {
    /// <summary>
    /// Spells are attacks that some classes can use
    /// TODO: implement spells into character creation
    /// </summary>
    public class Spells {

        /// <summary>
        /// Name of Spell
        /// </summary>
        string name;
        /// <summary>
        /// Name of Spell
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
        /// How long it takes (in minutes) for the spell to charge before it can be cast
        /// </summary>
        int castingTime;
        /// <summary>
        /// How long it takes (in minutes) for the spell to charge before it can be cast
        /// </summary>
        public int CastingTime {
            get { return castingTime; }
            set {
                if (value < 0) {
                    throw new ArgumentException("Casting time cannot be negative");
                }
                castingTime = value;
            }
        }

        /// <summary>
        /// How long the spell lasts in minutes
        /// </summary>
        int duration;
        /// <summary>
        /// How long the spell lasts in minutes
        /// </summary>
        public int Duration {
            get { return duration;  }
            set {
                if (value < 0) {
                    throw new ArgumentException("Duration cannot be negative");
                }
                duration = value;
            }
        }

        /// <summary>
        /// The radius around the character which will be affected by the spell, in meters
        /// </summary>
        int range;
        /// <summary>
        /// The radius around the character which will be affected by the spell, in meters
        /// </summary>
        public int Range {
            get { return range; }
            set {
                if (value < 0) {
                    throw new ArgumentException("Range cannot be negative");
                }
                range = value;
            }
        }

        /// <summary>
        /// Database identifier
        /// </summary>
        int spellId;
        /// <summary>
        /// Database identifier
        /// </summary>
        public int SpellId {
            get { return spellId; }
            set {
                if (value < 0) {
                    throw new ArgumentException("SpellID cannot be negative");
                }
                spellId = value;
            }
        }

        /// <summary>
        /// Constructor without id, used when inserting a spell into the database
        /// </summary>
        /// <param name="name">Name of spell</param>
        /// <param name="castingtime">Casting time of spell</param>
        /// <param name="duration">Duration of spell</param>
        /// <param name="description">Description of spell</param>
        public Spells(string name, int castingtime, int duration, string description) {
            Name = name;
            CastingTime = castingtime;
            Duration = duration;
            Description = description;
        }

        /// <summary>
        /// Constructor without id, used when inserting a spell into the database
        /// </summary>
        /// <param name="id">ID of spell</param>
        /// <param name="name">Name of spell</param>
        /// <param name="castingtime">Casting time of spell</param>
        /// <param name="duration">Duration of spell</param>
        /// <param name="description">Description of spell</param>
        public Spells(int id, string name, int castingtime, int duration, int range, string description) {
            SpellId = id;
            Name = name;
            CastingTime = castingtime;
            Duration = duration;
            Description = description;
        }
    }
}
