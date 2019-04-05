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

            User user = null;
            try {
                user = new User(
                    username,
                    fullName,
                    password
                );
            } catch (ArgumentException ex) {
                LblError.Text = ex.Message;
                return;
            }

            // Add new user to database
            UserDAO userDAO = new UserDAO();
            userDAO.AddUser(new User(
                username, fullName, password
            ));

            Response.Redirect("~/Login.aspx?justRegistered=true");
        }

    }
}