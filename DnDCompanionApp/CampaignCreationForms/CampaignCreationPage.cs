﻿using System;
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
    public partial class CampaignCreationPage : UserControl {

        public CampaignCreationPage() {
            InitializeComponent();
        }

        private void btnGenerate_Click(object sender, EventArgs e) {

            Campaign campaign = new Campaign();
            campaign.CampaignName = "Test Campaign";

            // Go to Campaign Preview Page
            CampaignPreviewForm preview = new CampaignPreviewForm(campaign);
            DialogResult result = preview.ShowDialog();
            if (result == DialogResult.OK) {
                MessageBox.Show("Save functionality not implemented yet.");
            }
        }
    }
}