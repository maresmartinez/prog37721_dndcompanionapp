using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace DnDWebApp {
    public partial class Login : System.Web.UI.Page {
        protected void Page_Load(object sender, EventArgs e) {

        }

        protected void BtnAuthenticate_Click(object sender, EventArgs e) {
            string username = TxtUsername.Text;
            string password = TxtPassword.Text;

            // TODO: call authentication method from database
            
        }
    }
}