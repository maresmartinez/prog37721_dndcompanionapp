using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using UserManagementLib;
using CharacterCreationLib;

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
                    new List<Character>(),
                    password,
                    new List<Campaign>()
                );
            } catch (ArgumentException ex) {
                LblError.Text = ex.Message;
                return;
            }

            // TODO: add new user to database
            Response.Write($"{user.Username}, {user.FullName}, {user.Password}, {user.Salt}");
        }

    }
}