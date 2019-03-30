using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using CharacterCreationLib;

namespace DnDWebApp.Tools {
    public partial class DiceRoll : System.Web.UI.Page {

        /// <summary>
        /// List of D&D dice
        /// </summary>
        List<Dice> dice = new List<Dice>();

        /// <summary>
        /// Displays the D&D dice to the dropdown list
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void Page_Load(object sender, EventArgs e) {
            dice.Add(new Dice(4));
            dice.Add(new Dice(6));
            dice.Add(new Dice(8));
            dice.Add(new Dice(10));
            dice.Add(new Dice(12));
            dice.Add(new Dice(20));

            if (!IsPostBack) {
                DDDice.DataSource = dice;
                DDDice.DataBind();
            }
        }

        /// <summary>
        /// Generates a number depending on the dice and how many rolls given
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void BtnRoll_Click(object sender, EventArgs e) {
            Dice selectedDice = dice[DDDice.SelectedIndex];
            int rolls = int.Parse(TxtNumRolls.Text);
            LblResult.Text = selectedDice.RollMultiple(rolls).ToString();
        }
    }
}