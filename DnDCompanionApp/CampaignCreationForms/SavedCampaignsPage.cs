using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using CampaignCreationLib;

namespace CampaignCreationForms {
    public partial class SavedCampaignsPage : UserControl {

        List<Campaign> savedCampaigns;

        public SavedCampaignsPage() {
            InitializeComponent();
            savedCampaigns = new List<Campaign>();
        }

        public SavedCampaignsPage(List<Campaign> savedCampaigns) {
            InitializeComponent();
            this.savedCampaigns = savedCampaigns;
        }

        private void SavedCampaignsPage_Load(object sender, EventArgs e) {
            // --------------------------------------------------------------------------------------------------------------------------------
            // TODO: replace the following section with database queries
            // Query database for campaigns that user is part of and add that to campaigns list
            // --------------------------------------------------------------------------------------------------------------------------------

            // ------------------------------------------------       START       -------------------------------------------------------------

            Campaign campaign1 = new Campaign();
            campaign1.CampaignName = "Campaign 1";
            Campaign campaign2 = new Campaign();
            campaign2.CampaignName = "Campaign 2";

            savedCampaigns.Add(campaign1);
            savedCampaigns.Add(campaign2);


            // ------------------------------------------------       END       -------------------------------------------------------------

            foreach (Campaign campaign in savedCampaigns) {
                flowSavedCampaigns.Controls.Add(new SavedCampaignControl(campaign));
            }
        }
    }
}
