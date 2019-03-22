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

namespace CampaignCreationForms {
    public partial class SavedCampaignControl : UserControl {

        Campaign campaign;

        public SavedCampaignControl(Campaign campaign) {
            InitializeComponent();
            this.campaign = campaign;
        }

        private void SavedCampaignControl_Load(object sender, EventArgs e) {
            lblName.Text = campaign.CampaignName;
        }

        private void picCampaign_Click(object sender, EventArgs e) {
            SavedCampaignPreviewForm form = new SavedCampaignPreviewForm(campaign);
            form.Show();
        }
    }
}
