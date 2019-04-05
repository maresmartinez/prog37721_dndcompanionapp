using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace DnDWebApp {
    public partial class DnD : System.Web.UI.MasterPage {

        /// <summary>
        /// Displays either login or logout depending on whether or not user is authenticated
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void Page_Load(object sender, EventArgs e) {
            if (Context.User.Identity.IsAuthenticated) {
                BtnLogin.Visible = false;
                BtnLogout.Visible = true;
            } else {
                BtnLogin.Visible = true;
                BtnLogout.Visible = false;
            }
        }

        /// <summary>
        /// Redirects to login page
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void BtnLogin_Click(object sender, EventArgs e) {
            Response.Redirect("~/Login.aspx");
        }

        /// <summary>
        /// Logs out user
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void BtnLogout_Click(object sender, EventArgs e) {
            FormsAuthentication.SignOut();
            FormsAuthentication.RedirectToLoginPage();
        }
    }
}