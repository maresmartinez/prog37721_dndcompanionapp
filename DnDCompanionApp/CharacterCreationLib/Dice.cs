using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CharacterCreationLib {
    public class Dice {
        int sides;

        public int Sides { get; set; }

        public Dice() {

        }

        public Dice(int sides) {
            Sides = sides;
        }


        public int RollDice() {
            Random rand = new Random();
            int roll = rand.Next(1, Sides + 1);
            return roll;
        }

        public override string ToString() {
            return $"d{Sides}";
        }
    }
}
