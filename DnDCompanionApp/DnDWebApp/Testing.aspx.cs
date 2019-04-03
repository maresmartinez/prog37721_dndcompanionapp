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
            StatsDAO statsDAO = new StatsDAO();
            statsDAO.DeleteStats(1);
            List<int> stats = statsDAO.GetStats(1);

            string statconcat = "";
            foreach (int stat in stats)
            {
                statconcat += stats[stat] + ", ";
            }
            Label1.Text = statconcat;
            
        }
    }
}