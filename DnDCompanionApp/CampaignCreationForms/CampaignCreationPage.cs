using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using UserManagementLib;
using CharacterCreationLib;

namespace CampaignCreationForms {
    public partial class CampaignCreationPage : UserControl {

        // TODO: allow for the ability to remove Users/Characters if they were added by mistake

        List<User> validUsers;
        List<User> selectedUsers = new List<User>();
        List<Character> selectedCharacters = new List<Character>();

        public CampaignCreationPage(List<User> validUsers) {
            InitializeComponent();
            this.validUsers = validUsers;
        }

        private void CampaignCreationPage_Load(object sender, EventArgs e) {
            cbDungeonMaster.DataSource = validUsers;
            cbDungeonMaster.DisplayMember = "Username";

            cbUsers.BindingContext = new BindingContext();
            cbUsers.DataSource = validUsers;
            cbUsers.DisplayMember = "Username";

            lstSelectedCharacters.DataSource = selectedCharacters;
            lstSelectedCharacters.DisplayMember = "Name";
        }

        private void btnGenerate_Click(object sender, EventArgs e) {

            string errors = "";

            // Form validation
            string name = txtName.Text;
            if (string.IsNullOrEmpty(name)) {
                errors += "Name must have a value\n";
            }

            string description = txtDescription.Text;
            if (string.IsNullOrEmpty(description)) {
                errors += "Description must have a value\n";
            }

            User dungeonMaster = (User)(cbDungeonMaster.SelectedItem);
            if (selectedUsers.Contains(dungeonMaster)) {
                errors += "Dungeon Master cannot also be player";
            }

            if (!string.IsNullOrEmpty(errors)) {
                MessageBox.Show(errors);
            }

            Campaign campaign = null;
            try {
                campaign = new Campaign(
                    name,
                    description,
                    selectedUsers,
                    selectedCharacters,
                    dungeonMaster
                );
            } catch (ArgumentException ex) {
                MessageBox.Show(ex.Message);
                return;
            }

            // Go to Campaign Preview Page
            CampaignPreviewForm preview = new CampaignPreviewForm(campaign);
            DialogResult result = preview.ShowDialog();
            if (result == DialogResult.OK) {
                campaign.AddCampaignToAllUsers();
                MessageBox.Show("Campaign was successfully saved.");
            }
        }

        private void cbUsers_SelectedIndexChanged(object sender, EventArgs e) {
            if (cbUsers.SelectedValue is null) {
                return;
            }

            User selectedUser = (User) cbUsers.SelectedValue;
            cbCharacters.DataSource = selectedUser.UserCharacters;
            cbCharacters.DisplayMember = "Name";
        }

        private void btnAddPartyMember_Click(object sender, EventArgs e) {
            if (cbCharacters.SelectedItem is null) {
                return;
            }

            if (!selectedUsers.Contains((User)cbUsers.SelectedItem)) {
                selectedUsers.Add((User)cbUsers.SelectedItem);
            }

            if (!selectedCharacters.Contains((Character)cbCharacters.SelectedItem)) {
                selectedCharacters.Add((Character)cbCharacters.SelectedItem);
            }

            CurrencyManager manager = (CurrencyManager)(lstSelectedCharacters.BindingContext[selectedCharacters]);
            manager.Refresh();
        }
    }
}
