using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CharacterCreationLib {
    /// <summary>
    /// Generates a random integer based on the sides of a dice
    /// </summary>
    public class Dice {

        /// <summary>
        /// The number of sides th dice has
        /// </summary>
        int sides;

        /// <summary>
        /// The number of sides the dice has. Must be greater than 0.
        /// </summary>
        public int Sides {
            get { return sides; }
            set {
                if (value < 1) {
                    throw new ArgumentException("Sides must be greater than 0");
                }
                sides = value;
            }
        }

        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="sides">Number of sides the dice will have</param>
        public Dice(int sides) {
            Sides = sides;
        }

        /// <summary>
        /// Rolls the dice
        /// </summary>
        /// <returns>The value that the dice landed on</returns>
        public int Roll() {
            Random rand = new Random();
            int roll = rand.Next(1, Sides + 1);
            return roll;
        }

        /// <summary>
        /// Rolls the dice multiple times, with different values for each roll
        /// </summary>
        /// <param name="numRolls">The number of times to roll the dice</param>
        /// <returns>The cumulated value of all the rolls</returns>
        public int RollMultiple(int numRolls) {
            int total = 0;
            for (int roll = 0; roll < numRolls; roll++) {
                total += this.Roll();
            }
            return total;
        }

        /// <summary>
        /// Describes the dice
        /// </summary>
        /// <returns>Dice desciption</returns>
        public override string ToString() {
            return $"D{Sides}";
        }
    }
}
