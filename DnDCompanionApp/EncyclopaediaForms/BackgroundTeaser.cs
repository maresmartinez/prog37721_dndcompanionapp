using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using CharacterCreationLib;

namespace EncyclopaediaForms {
    public partial class BackgroundTeaser : UserControl {

        Background background;

        public BackgroundTeaser(Background background) {
            InitializeComponent();
            this.background = background;
        }

        private void BackgroundTeaser_Load(object sender, EventArgs e) {
            lblName.Text = background.Name;
            if (background.Description.Length > 100) {
                lblDescription.Text = background.Description.Substring(0, 100) + "...";
            } else {
                lblDescription.Text = background.Description;
            }
            
        }

        private void btnSeeMore_Click(object sender, EventArgs e) {
            BackgroundDetails backgroundDetails = new BackgroundDetails(background);
            backgroundDetails.ShowDialog();
        }
    }
}
