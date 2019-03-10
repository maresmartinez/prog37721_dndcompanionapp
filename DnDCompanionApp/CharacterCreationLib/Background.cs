﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CharacterCreationLib {
    class Background {
        List<string> personality;
        List<string> ideals;
        List<string> bonds;
        List<string> flaws;

        public List<string> Personality { get; set; }
        public List<string> Ideals { get; set; }
        public List<string> Bonds { get; set; }
        public List<string> Flaws { get; set; }

        public Background()
        {

        }

        public Background(List<string> personality, List<string> ideals, List<string> bonds, List<string> flaws)
        {
            Personality = personality;
            Ideals = ideals;
            Bonds = bonds;
            Flaws = flaws;
        }
    }
}
