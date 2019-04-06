using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using UserManagementLib;
using CharacterCreationLib;
using DnDSQLLib.dal;

namespace DnDWebApp.Users {
    public partial class Profile : System.Web.UI.Page {

        /// <summary>
        /// Retrieves the logged in user's information and displays it
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void Page_Load(object sender, EventArgs e) {
            UserDAO userDAO = new UserDAO();
            User loggedInUser = userDAO.GetUser(Context.User.Identity.Name);

            Username.InnerText = loggedInUser.Username;
            FullName.InnerText = loggedInUser.FullName;
        }
    }
}