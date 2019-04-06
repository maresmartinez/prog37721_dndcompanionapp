using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CharacterCreationLib {
    /// <summary>
    /// Features are special abilities that are available to classes
    /// </summary>
    public class Feature {

        /// <summary>
        /// Name of feature
        /// </summary>
        string name;
        /// <summary>
        /// Name of feature
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
        /// Description of feature
        /// </summary>
        string description;
        /// <summary>
        /// Description of feature
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
        /// Datbase identifier of feature
        /// </summary>
        public int FeatureID { get; set; }

        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="name">Name of feature</param>
        /// <param name="description">Description of feature</param>
        public Feature(string name, string description) {
            Name = name;
            Description = description;
        }

        /// <summary>
        /// Describe the feature
        /// </summary>
        /// <returns>Name and desciption of feature</returns>
        public override string ToString() {
            return $"{Name} - {Description}";
        }
    }
}
