using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using UserManagementLib;
using CharacterCreationLib;

namespace DnDWebApp.Users {
    public partial class Profile : System.Web.UI.Page {

        /// <summary>
        /// Retrieves the logged in user's information and displays it
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void Page_Load(object sender, EventArgs e) {
            // TODO: retrieve logged in user
            User testuser0 = new User(
                "testuser0",
                "Test User 0",
                new List<Character>(), // Has no characters
                "password",
                new List<Campaign>()
            );

            Username.InnerText = testuser0.Username;
            FullName.InnerText = testuser0.FullName;
        }

        // TODO: once database is implemented, allow user to change full name and password
    }
}