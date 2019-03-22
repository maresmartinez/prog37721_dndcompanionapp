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

namespace MainNavigationForms {
    public partial class EditUserForm : Form {

        User user;

        public EditUserForm(User user) {
            InitializeComponent();
            this.user = user;
        }

        private void EditUserForm_Load(object sender, EventArgs e) {
            txtFullName.Text = user.FullName;
            txtPassword.Text = user.Password;
            txtPasswordRepeat.Text = user.Password;
        }

        private void btnSaveChanges_Click(object sender, EventArgs e) {
            if (txtPassword.Text != txtPasswordRepeat.Text) {
                MessageBox.Show("Passwords must match. Changes were not saved.");
            } else {
                user.FullName = txtFullName.Text;
                user.Password = txtPassword.Text;
            }
        }

        private void btnCancel_Click(object sender, EventArgs e) {
            this.Close();
        }
        
    }
}
