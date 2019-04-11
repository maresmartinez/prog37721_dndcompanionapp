using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using UserManagementLib;
using CharacterCreationLib;
using DnDSQLLib.dal;

namespace DnDWebApp {
    public partial class CreateAccount : System.Web.UI.Page {
        protected void Page_Load(object sender, EventArgs e) {

        }

        protected void BtnCreateAccount_Click(object sender, EventArgs e) {
            // Note that validation is done with Validator objects in ASP.NET

            string username = TxtUsername.Text;
            string fullName = TxtFullName.Text;
            string password = TxtPassword.Text;

            // Check if username is already taken
            LblTaken.Text = "";
            UserDAO userDAO = new UserDAO();
            List<User> allUsers = userDAO.GetAllUsers();
            foreach (User existingUser in allUsers) {
                if (existingUser.Username.Equals(username)) {
                    LblTaken.Text = "(Username is taken)";
                    return;
                }
            }

            // Create user
            User newUser = null;
            try {
                newUser = new User(
                    username,
                    fullName,
                    password
                );
            } catch (ArgumentException ex) {
                LblError.Text = ex.Message;
                return;
            }

            // Add new user to database
            userDAO.AddUser(newUser);
            Response.Redirect("~/Login.aspx?justRegistered=true");
        }

    }
}