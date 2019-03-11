using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CharacterCreationLib
{
    public class Spells
    {
        string name;
        int castingTime;
        int duration; //could be hours or minutes have to decide
        int range; //in feat
        string description;

        public string Name { get; set; }
        public int CastingTime { get; set; }
        public int Duration { get; set; }
        public int Range { get; set; }
        public string Description { get; set; }

        public Spells()
        {

        }

        public Spells(string name, int castingtime, int duration, string description)
        {
            Name = name;
            CastingTime = castingtime;
            Duration = duration;
            Description = description;
        }
    }
}
