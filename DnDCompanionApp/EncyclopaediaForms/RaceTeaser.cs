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

namespace EncyclopaediaForms {
    public partial class RaceTeaser : UserControl {

        Race race;

        public RaceTeaser(Race race) {
            InitializeComponent();
            this.race = race;
        }

        private void RaceTeaser_Load(object sender, EventArgs e) {
            lblName.Text = race.Name;
            if (race.Description.Length > 100) {
                lblDescription.Text = race.Description.Substring(0, 100) + "...";
            } else {
                lblDescription.Text = race.Description;
            }
        }

        private void btnSeeMore_Click(object sender, EventArgs e) {
            RaceDetailsPage raceDetails = new RaceDetailsPage(race);
            raceDetails.ShowDialog();
        }
    }
}
