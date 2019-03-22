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
using UserManagementLib;
using CharacterCreationLib;

namespace MainNavigationForms {
    public partial class DnDApplicationForm : Form {

        User user;

        // TODO: delete after database is implemented
        List<User> validUsers;

        public DnDApplicationForm(User user, List<User> validUsers) {
            InitializeComponent();
            this.user = user;
            this.validUsers = validUsers;
        }

        /// <summary>
        /// Clears the Form of the current page and Docks a new page to pnlPageView
        /// </summary>
        /// <param name="page">The page to be docked</param>
        private void DockPage(UserControl page) {
            page.Dock = DockStyle.Fill;
            pnlPageView.Controls.Clear();
            pnlPageView.Controls.Add(page);
            page.BringToFront();
        }

        /// <summary>
        /// Docks the home page as soon as the form loads
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void DnDApplicationForm_Load(object sender, EventArgs e) {
            HomePage home = new HomePage();
            DockPage(home);
        }

        /// <summary>
        /// When the See All Characters submenu option is picked, shows a SavedCharacterPage for user
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void seeAllCharactersToolStripMenuItem_Click(object sender, EventArgs e) {
            SavedCharacterPage savedCharacterPage = new SavedCharacterPage(user.UserCharacters);
            DockPage(savedCharacterPage);
        }

        /// <summary>
        /// When the Home option is picked, shows the home page
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void navigationMenuStripToolStripMenuItem_Click(object sender, EventArgs e) {
            HomePage home = new HomePage();
            DockPage(home);
        }

        /// <summary>
        /// When the Create New Character submenu option is picked, shows the create new character form
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void createNewCharacterToolStripMenuItem_Click(object sender, EventArgs e) {
            CharacterCreationPage characterCreationPage = new CharacterCreationPage(user);
            DockPage(characterCreationPage);
        }

        /// <summary>
        /// When the Profile option is picked, shows the user's profile details
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void profileToolStripMenuItem_Click(object sender, EventArgs e) {
            ProfilePage profilePage = new ProfilePage(user);
            DockPage(profilePage);
        }

        /// <summary>
        /// When the See All Campaigns ubmenu option is picked, shows a SavedCampaignsPage for user
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void seeAllCampaignsToolStripMenuItem_Click(object sender, EventArgs e) {
            SavedCampaignsPage savedCampaignsPage = new SavedCampaignsPage(user);
            DockPage(savedCampaignsPage);
        }

        /// <summary>
        /// When the Create New Campaign submenu option is picked, shows the create campaign form
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void createNewCampaignToolStripMenuItem_Click(object sender, EventArgs e) {
            CampaignCreationPage campaignCreationPage = new CampaignCreationPage(validUsers);
            DockPage(campaignCreationPage);
        }

    }
}
