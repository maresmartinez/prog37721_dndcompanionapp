using CharacterCreationLib;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DnDSQLLib.dal
{
    public class BackgroundDAO
    {
        SqlConnection conn;

        public BackgroundDAO()
        {
            try
            {
                conn = ConnectionFactory.GetConnection();
                conn.Open();
                conn.Close();   // Just double checking to make sure that yes, we can indeed access the server
            }
            catch (SqlException)
            {
                // Figure out how to let the user know that things just aint happening
            }
        }

        public int UploadBackground(Background bg)
        {
            try
            {
                conn.Open();

                SqlCommand command = new SqlCommand();
            }
            catch (SqlException)
            {

            }
            return 0;
        }
        public int DeleteBackground(int backgroundId)
        {
            return 0;
        }
        public Background GetBackground(int backgroundId)
        {
            Background background;
            List<String> personality = new List<string>();
            List<String> ideal = new List<string>();
            List<String> bond = new List<string>();
            List<String> flaw = new List<string>();

            try
            {
                conn.Open();

                // Personality
                SqlCommand command = new SqlCommand($"" +
                    $"SELECT description FROM personality inner join background on background.PersonalityID1 = personality.Id or background.PersonalityID2 = personality.Id WHERE background.Id = @bId");
                command.Parameters.AddWithValue("@bId", backgroundId);
                command.Connection = conn;

                SqlDataReader reader = command.ExecuteReader();
                while (reader.Read())
                    personality.Add(Convert.ToString(reader["description"]));
            reader.Close();

                // Ideals
                command = new SqlCommand($"" +
                    $"SELECT description from ideal join background on background.IdealID = ideal.Id WHERE background.Id = @bId");
                command.Parameters.AddWithValue("@bId", backgroundId);
                command.Connection = conn;

                reader = command.ExecuteReader();
                while (reader.Read())
                    ideal.Add(Convert.ToString(reader["description"]));
            reader.Close();

            // Bonds
            command = new SqlCommand($"" +
                    $"SELECT description from bond join background on background.BondID = bond.Id WHERE background.Id = @bId");
                command.Parameters.AddWithValue("@bId", backgroundId);
                command.Connection = conn;

                reader = command.ExecuteReader();
                while (reader.Read())
                    bond.Add(Convert.ToString(reader["description"]));
            reader.Close();

            // Flaws
            command = new SqlCommand($"" +
                    $"SELECT description from flaw join background on background.FlawID = flaw.Id WHERE background.Id = @bId");
                command.Parameters.AddWithValue("@bId", backgroundId);
                command.Connection = conn;

                reader = command.ExecuteReader();
                while (reader.Read())
                    flaw.Add(Convert.ToString(reader["description"]));
            reader.Close();

                background = new Background(backgroundId, personality, ideal, bond, flaw);

            }
            catch (SqlException s)
            {
                // Figure out what to give with the exception
                background = null;
            }

            return background;
        }
        public int UpdateBackground(int backgroundId)
        {
            return 0;
        }
    }
}
