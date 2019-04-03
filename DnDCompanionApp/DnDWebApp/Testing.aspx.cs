using CharacterCreationLib;
using DnDSQLLib.dal;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace DnDWebApp
{
    public partial class Testing : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            BackgroundDAO bdao = new BackgroundDAO();
            Background background = bdao.GetBackground(1);

            Label1.Text = background.OtherToString();
            
        }
    }
}