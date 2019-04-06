using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CharacterCreationLib {
    public class BackgroundType {
        public int DbID { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }

        public BackgroundType(int dbId, string name, string description) {
            DbID = dbId;
            Name = name;
            Description = description;
        }
    }
}
