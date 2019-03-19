using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using CharacterCreationForms;
using CampaignCreationForms;

namespace MainNavigationForms {
    public partial class DnDApplicationForm : Form {
        public DnDApplicationForm() {
            InitializeComponent();
        }

        private void DnDApplicationForm_Load(object sender, EventArgs e) {
            HomePage home = new HomePage();
            home.Dock = DockStyle.Fill;
            pnlPageView.Controls.Add(home);
        }

        private void seeAllCharactersToolStripMenuItem_Click(object sender, EventArgs e) {
            SavedCharacterPage savedCharacterPage = new SavedCharacterPage();
            savedCharacterPage.Dock = DockStyle.Fill;
            pnlPageView.Controls.Clear();
            pnlPageView.Controls.Add(savedCharacterPage);
            savedCharacterPage.BringToFront();
        }

        private void navigationMenuStripToolStripMenuItem_Click(object sender, EventArgs e) {
            HomePage home = new HomePage();
            home.Dock = DockStyle.Fill;
            pnlPageView.Controls.Clear();
            pnlPageView.Controls.Add(home);
            home.BringToFront();
        }

        private void createNewCharacterToolStripMenuItem_Click(object sender, EventArgs e) {
            CharacterCreationPage characterCreationPage = new CharacterCreationPage();
            characterCreationPage.Dock = DockStyle.Fill;
            pnlPageView.Controls.Clear();
            pnlPageView.Controls.Add(characterCreationPage);
            characterCreationPage.BringToFront();
        }

        private void profileToolStripMenuItem_Click(object sender, EventArgs e) {
            ProfilePage profilePage = new ProfilePage();
            profilePage.Dock = DockStyle.Fill;
            pnlPageView.Controls.Clear();
            pnlPageView.Controls.Add(profilePage);
            profilePage.BringToFront();
        }

        private void seeAllCampaignsToolStripMenuItem_Click(object sender, EventArgs e) {
            SavedCampaignsPage savedCampaignsPage = new SavedCampaignsPage();
            savedCampaignsPage.Dock = DockStyle.Fill;
            pnlPageView.Controls.Clear();
            pnlPageView.Controls.Add(savedCampaignsPage);
            savedCampaignsPage.BringToFront();
        }

        private void createNewCampaignToolStripMenuItem_Click(object sender, EventArgs e) {
            CampaignCreationPage campaignCreationPage = new CampaignCreationPage();
            campaignCreationPage.Dock = DockStyle.Fill;
            pnlPageView.Controls.Clear();
            pnlPageView.Controls.Add(campaignCreationPage);
            campaignCreationPage.BringToFront();
        }
    }
}
