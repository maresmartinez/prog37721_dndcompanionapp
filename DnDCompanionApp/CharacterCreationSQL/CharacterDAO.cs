using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using CharacterCreationLib;

namespace CharacterCreationSQL
{
    public class CharacterDAO
    {
        string server = "Data Source=.\\SQLEXPRESS;Initial Catalog=dnd;Integrated Security=True";
        SqlConnection cnn;

        public CharacterDAO()
        {
            try
            {
                cnn = new SqlConnection(server);
                cnn.Open();
                cnn.Close();
            }
            catch (SqlException)
            {
                MessageBox.Show("Cannot connect to the database at this time",
                    "Error!", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        public int uploadCharacter(Character character)
        {
            return 0;
        }
        public Character downloadCharacter()
        {
            return null;
        }
        public int updateCharacter(Character character)
        {
            return 0;
        }
        public int deleteCharacter(Character character)
        {
            return 0;
        }
    }
}
