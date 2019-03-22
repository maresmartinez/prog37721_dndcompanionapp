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

namespace MainNavigationForms {
    public partial class ProfilePage : UserControl {

        User user;

        public ProfilePage(User user) {
            InitializeComponent();
            this.user = user;
        }

        private void ProfilePage_Load(object sender, EventArgs e) {
            txtUsername.Text = user.Username;
            txtFullName.Text = user.FullName;
        }

        private void btnEditDetails_Click(object sender, EventArgs e) {
            EditUserForm editUserForm = new EditUserForm(user);
            DialogResult result = editUserForm.ShowDialog();

            // If any changes were made, refresh the details shown
            if (result == DialogResult.OK) {
                txtUsername.Text = user.Username;
                txtFullName.Text = user.FullName;
            }
        }
    }
}
