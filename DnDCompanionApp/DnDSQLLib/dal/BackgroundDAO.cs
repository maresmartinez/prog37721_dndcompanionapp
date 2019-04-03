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
            List<int> personalityId = new List<int>();
            int idealId = 1; // Initializing with a valid value to prevent silliness
            int bondId = 1;
            int flawId = 1;
            int count = 0;

            try
            {
                conn.Open();

                // Getting Personality Ids
                SqlCommand command = new SqlCommand($"" +
                    $"select Id from personality where Description = @p1 OR Description = @p2");
                command.Parameters.AddWithValue("@p1", bg.Personality[0]);
                command.Parameters.AddWithValue("@p2", bg.Personality[1]);
                command.Connection = conn;

                SqlDataReader reader = command.ExecuteReader();
                while (reader.Read())
                    personalityId.Add(Convert.ToInt32(reader["Id"]));
                reader.Close();

                // Getting IdealId
                command = new SqlCommand($"" +
                    $"Select Id from ideal where Description = @ideal");
                command.Parameters.AddWithValue("@ideal", bg.Ideals[0]);
                command.Connection = conn;

                reader = command.ExecuteReader();
                while (reader.Read())
                    idealId = Convert.ToInt32(reader["Id"]);
                reader.Close();

                // Getting BondId
                command = new SqlCommand($"" +
                    $"Select Id from bond where Description = @bond");
                command.Parameters.AddWithValue("@bond", bg.Bonds[0]);
                command.Connection = conn;

                reader = command.ExecuteReader();
                while (reader.Read())
                    bondId = Convert.ToInt32(reader["Id"]);
                reader.Close();

                //Getting FlawId
                command = new SqlCommand($"" +
                    $"Select Id from flaw where Description = @flaw");
                command.Parameters.AddWithValue("@flaw", bg.Flaws[0]);
                command.Connection = conn;

                reader = command.ExecuteReader();
                while (reader.Read())
                    flawId = Convert.ToInt32(reader["Id"]);
                reader.Close();

                // Putting it all together for actually submitting it to the DB
                command = new SqlCommand($"" +
                    $"Insert into background (PersonalityID1, PersonalityID2, IdealID, BondID, FlawID) values (@p1, @p2, @i, @b, @f)");
                command.Parameters.AddWithValue("@p1", personalityId[0]);
                command.Parameters.AddWithValue("@p2", personalityId[1]);
                command.Parameters.AddWithValue("@i", idealId);
                command.Parameters.AddWithValue("@b", bondId);
                command.Parameters.AddWithValue("@f", flawId);

                count = command.ExecuteNonQuery();
            }
            catch (SqlException)
            {
                // Figure out how to deliver a good error message for the user
            }
            finally
            {
                conn.Close();
            }
            return count;
        }
        public int DeleteBackground(int backgroundId)
        {
            int count = 0;
            try
            {
                conn.Open();

                SqlCommand command = new SqlCommand($"" +
                    $"delete from background where Id = @bId");
                command.Parameters.AddWithValue("@bId", backgroundId);
                command.Connection = conn;

                count = command.ExecuteNonQuery();
            }
            catch (SqlException)
            {
                // Figure out how to deliver a good error message for the user
            }
            finally
            {
                conn.Close();
            }

            return count;
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
            catch (SqlException)
            {
                // Figure out what to give with the exception
                background = null;
            }
            finally
            {
                conn.Close();
            }

            return background;
        }
    }
}
