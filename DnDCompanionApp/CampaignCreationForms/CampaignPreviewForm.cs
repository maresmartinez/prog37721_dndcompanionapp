using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using UserManagementLib;
using CharacterCreationLib;

namespace CampaignCreationForms {
    public partial class CampaignPreviewForm : Form {

        Campaign campaign;

        public CampaignPreviewForm(Campaign campaign) {
            InitializeComponent();
            this.campaign = campaign;
        }

        private void CampaignPreviewForm_Load(object sender, EventArgs e) {
            txtName.Text = campaign.CampaignName;
            txtDescription.Text = campaign.CampaignDescription;
            txtDungeonMaster.Text = campaign.DungeonMaster.ToString();

            cbCharacters.DataSource = campaign.CampaignCharacters;
            cbCharacters.DisplayMember = "Name";
        }

        private void cbCharacters_SelectedIndexChanged(object sender, EventArgs e) {
            if (cbCharacters.SelectedItem is null) {
                return;
            }

            Character selectedCharacter = (Character)cbCharacters.SelectedItem;
            txtCharacterDesc.Text = selectedCharacter.ToString();
        }
    }
}
