﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CharacterCreationLib {
    class Race {
        string name;
        string description;
        Language languages;

        public string Name { get; set; }
        public string Description { get; set; }
        public Language Languages { get; set; }

        public Race()
        {

        }
        public Race(string name, string description, Language languages)
        {
            Name = name;
            Description = description;
            Languages = languages;
        }
    }
}
