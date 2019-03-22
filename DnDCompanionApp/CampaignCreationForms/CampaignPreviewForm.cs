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

namespace CampaignCreationForms {
    public partial class CampaignPreviewForm : Form {

        Campaign campaign;

        public CampaignPreviewForm(Campaign campaign) {
            InitializeComponent();
            this.campaign = campaign;
        }

        private void CampaignPreviewForm_Load(object sender, EventArgs e) {
            txtName.Text = campaign.CampaignName;
        }
    }
}
