using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace DnDWebApp {
    public partial class DnD : System.Web.UI.MasterPage {
        protected void Page_Load(object sender, EventArgs e) {
            if (Context.User.Identity.IsAuthenticated) {
                BtnLogin.Visible = false;
            }
        }

        protected void BtnLogin_Click(object sender, EventArgs e) {
            Response.Redirect("~/Login.aspx");
        }
    }
}