using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CharacterCreationLib
{
    class Skills
    {
        string name;
        string description;

        public string Name { get; set; }
        public string Description { get; set; }

        public Skills()
        {

        }
        public Skills(string name, string description)
        {
            Name = name;
            Description = description;
        }
    }
}
