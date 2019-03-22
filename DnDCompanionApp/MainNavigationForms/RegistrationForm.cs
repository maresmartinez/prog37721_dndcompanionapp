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

namespace MainNavigationForms {
    public partial class RegistrationForm : Form {

        // TODO: this won't be needed once database is implemented
        List<User> validUsers;

        public RegistrationForm(List<User> validUsers) {
            InitializeComponent();
            this.validUsers = validUsers;
        }

        private void btnCreate_Click(object sender, EventArgs e) {
            string errors = "";

            string username = txtUsername.Text;
            if (string.IsNullOrEmpty(username)) {
                errors += "Username must have a value\n";
            }

            string fullName = txtFullName.Text;
            if (string.IsNullOrEmpty(fullName)) {
                errors += "Full Name must have a value\n";
            }

            string password = txtPassword.Text;
            string repeatPassword = txtPasswordRepeat.Text;
            if (string.IsNullOrEmpty(password) || string.IsNullOrEmpty(password)) {
                errors += "Password fields must have values\n";
            } else if (!password.Equals(repeatPassword)) {
                errors += "Passwords must match\n";
            } else if (password.Length < 6) {
                errors += "Password must be at least 6 characters long\n";
            }

            if (!string.IsNullOrEmpty(errors)) {
                MessageBox.Show(errors);
                return;
            }

            User user = null;

            try {
                user = new User(
                    username,
                    fullName,
                    new List<Character>(),
                    password
                );
            } catch (ArgumentException ex) {
                MessageBox.Show(ex.Message);
                return;
            }

            AddToDatabase(user);
            MessageBox.Show("Registered successfully. You may now login.");
            Close();
        }

        private void btnCancel_Click(object sender, EventArgs e) {
            Close();
        }

        private void AddToDatabase(User user) {
            //TODO: this will should add to database, not list
            validUsers.Add(user);
        }
    }
}
