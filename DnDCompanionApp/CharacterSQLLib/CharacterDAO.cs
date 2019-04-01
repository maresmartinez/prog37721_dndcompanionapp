using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using CharacterCreationLib;

namespace CharacterSQLLib
{
    public class CharacterDAO
    {
        string server = "Data Source=.\\SQLEXPRESS;Initial Catalog=dnd;Integrated Security=True";
        SqlConnection conn;
        Character character;

        public CharacterDAO(Character character)
        {
            try
            {
                this.character = character;
            }
            catch (ArgumentNullException)
            {
                MessageBox.Show("Null Character Error", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

            try
            {
                conn = new SqlConnection(server);
                conn.Open();
                conn.Close();
            }
            catch (SqlException)
            {
                MessageBox.Show("Cannot connect to the database", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        public int addCharacter(Character character)
        {
            conn.Open();
            
            return 0;
        }

        public int deleteCharacter(int characterID)
        {
            return 0;
        }

        public Character getCharacter(int characterID)
        {
            return null;
        }

        public int updateCharacter(int characterID)
        {
            return 0;
        }
    }
}
