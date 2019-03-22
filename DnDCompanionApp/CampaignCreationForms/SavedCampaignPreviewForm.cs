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
    public partial class SavedCampaignPreviewForm : Form {

        Campaign campaign;

        public SavedCampaignPreviewForm(Campaign campaign) {
            InitializeComponent();
            this.campaign = campaign;
        }

        private void SavedCampaignPreviewForm_Load(object sender, EventArgs e) {
            txtName.Text = campaign.CampaignName;
            txtDescription.Text = campaign.CampaignDescription;
            txtDungeonMaster.Text = campaign.DungeonMaster.ToString();

            cbCharacters.DataSource = campaign.CampaignCharacters;
            cbCharacters.DisplayMember = "Name";
        }

        private void cbCharacters_SelectedIndexChanged(object sender, EventArgs e) {
            if (cbCharacters.SelectedValue is null) {
                return;
            }
            txtCharacterDesc.Text = ((Character)cbCharacters.SelectedValue).ToString();
        }
    }
}
