using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CharacterCreationLib {
    /// <summary>
    /// Overview of background types, without personality, ideals, bonds, and flaws included
    /// </summary>
    public class BackgroundType {

        /// <summary>
        /// Database identifier for background
        /// </summary>
        public int DbID { get; set; }

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
            get { return name; }
            set {
                if (string.IsNullOrEmpty(value)) {
                    throw new ArgumentException("Description must have a value");
                }
                description = value;
            }
        }

        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="dbId">ID of background</param>
        /// <param name="name">Name of background</param>
        /// <param name="description">Description of background</param>
        public BackgroundType(int dbId, string name, string description) {
            DbID = dbId;
            Name = name;
            Description = description;
        }
    }
}
