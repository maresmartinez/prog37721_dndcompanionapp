using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CharacterCreationLib {
    /// <summary>
    /// Skills of a character which defines what particular types of rolls they may have an advantage in. 
    /// Essentially, if a character has one of these skills, they get a bonus when doing anything story-related to that skill.
    /// </summary>
    public enum Skills {
        ACROBATICS = 1,
        ANIMAL_HANDLING = 2,
        ARCANA = 3,
        ATHLETICS = 4,
        DECEPTION = 5,
        HISTORY = 6,
        INSIGHT = 7,
        INTIMIDATION = 8,
        MEDICINE = 9,
        NATURE = 10,
        PERCEPTION = 11,
        PERFORMANCE = 12,
        PERSUASION = 13,
        RELIGION = 14,
        SLEIGHT_OF_HAND = 15,
        STEALTH = 16,
        SURVIVAL = 17
    }
}
