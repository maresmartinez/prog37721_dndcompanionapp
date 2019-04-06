using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using DnDSQLLib.dal;

namespace DnDWebApp {
    public partial class Login : System.Web.UI.Page {

        /// <summary>
        /// If redirected from registered page will display an alert
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void Page_Load(object sender, EventArgs e) {
            if(Request.QueryString["justRegistered"] != null) {
                Registered.Visible = true;
            }
        }

        /// <summary>
        /// Checks username and password that were entered against the database, and logs in if authenticated
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void BtnAuthenticate_Click(object sender, EventArgs e) {
            string username = TxtUsername.Text;
            string password = TxtPassword.Text;

            UserDAO userDAO = new UserDAO();
            if (userDAO.AuthenticateUser(username, password)) {
                // Successful
                FormsAuthentication.RedirectFromLoginPage(username, false);
            } else {
                // Incorrect
                LblFail.Text = "Username or password incorrect";
            }
        }
    }
}