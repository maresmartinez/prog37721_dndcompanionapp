using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using CharacterCreationLib;

namespace DiceRollForms {
    public partial class DiceRollPage : UserControl {

        /// <summary>
        /// Constructor
        /// </summary>
        public DiceRollPage() {
            InitializeComponent();
        }

        private void btnRoll_Click(object sender, EventArgs e) {

            int rolls = Convert.ToInt32(numRolls.Value); // num times to roll
            int sides = 0; // num sides of dice

            // Find better way to get selected radio button...
            // Get selected radio button
            if (rbD4.Checked) {
                sides = Convert.ToInt32(rbD4.Tag);
            } else if (rbD6.Checked) {
                sides = Convert.ToInt32(rbD6.Tag);
            } else if (rbD8.Checked) {
                sides = Convert.ToInt32(rbD8.Tag);
            } else if (rbD10.Checked) {
                sides = Convert.ToInt32(rbD10.Tag);
            } else if (rbD12.Checked) {
                sides = Convert.ToInt32(rbD12.Tag);
            } else if (rbD20.Checked) {
                sides = Convert.ToInt32(rbD20.Tag);
            }
            
            Dice dice = new Dice(sides);
            lblResult.Text = dice.RollMultiple(rolls).ToString();
        }


    }
}
