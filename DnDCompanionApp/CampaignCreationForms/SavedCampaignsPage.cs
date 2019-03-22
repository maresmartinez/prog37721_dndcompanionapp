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
    public partial class SavedCampaignsPage : UserControl {

        User user;

        public SavedCampaignsPage(User user) {
            InitializeComponent();
            this.user = user;
        }

        private void SavedCampaignsPage_Load(object sender, EventArgs e) {
            foreach (Campaign campaign in user.UserCampaigns) {
                flowSavedCampaigns.Controls.Add(new SavedCampaignControl(campaign));
            }
        }
    }
}
