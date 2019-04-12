using CharacterCreationLib;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DnDSQLLib.dal {
    /// <summary>
    /// Interface between background class and background table in database
    /// </summary>
    public class BackgroundDAO {

        /// <summary>
        /// Connection to database
        /// </summary>
        SqlConnection conn;

        /// <summary>
        /// Constructor
        /// </summary>
        public BackgroundDAO() {
            conn = ConnectionFactory.GetConnection();
        }

        /// <summary>
        /// Adds character background to the database
        /// </summary>
        /// <param name="character">Character whose background is being added</param>
        /// <returns>Id of background</returns>
        public int UploadBackground(Character character) {
            int charBackgroundID;

            int backgroundTypeID = character.BackgroundTypeID;
            string personality1 = character.CharacterBackground.Personality[0];
            string ideal1 = character.CharacterBackground.Ideals[0];
            string bond1 = character.CharacterBackground.Bonds[0];
            string flaw1 = character.CharacterBackground.Flaws[0];
            string personality2 = character.CharacterBackground.Personality[1];
            string ideal2 = character.CharacterBackground.Ideals[1];
            string bond2 = character.CharacterBackground.Bonds[1];
            string flaw2 = character.CharacterBackground.Flaws[1];

            int personalityID1;
            int personalityID2;
            int idealID1;
            int idealID2;
            int bondID1;
            int bondID2;
            int flawID1;
            int flawID2;

            using (conn = ConnectionFactory.GetConnection()) {
                conn.Open();

                // Personality IDs
                SqlCommand cmd = new SqlCommand("SELECT ID FROM personality WHERE description = @Desc;");
                cmd.Parameters.AddWithValue("@Desc", personality1);
                cmd.Connection = conn;
                personalityID1 = Convert.ToInt32(cmd.ExecuteScalar());

                cmd = new SqlCommand("SELECT ID FROM personality WHERE description = @Desc;");
                cmd.Parameters.AddWithValue("@Desc", personality2);
                cmd.Connection = conn;
                personalityID2 = Convert.ToInt32(cmd.ExecuteScalar());

                // Ideal IDs
                cmd = new SqlCommand("SELECT ID FROM ideal WHERE description = @Desc;");
                cmd.Parameters.AddWithValue("@Desc", ideal1);
                cmd.Connection = conn;
                idealID1 = Convert.ToInt32(cmd.ExecuteScalar());

                cmd = new SqlCommand("SELECT ID FROM ideal WHERE description = @Desc;");
                cmd.Parameters.AddWithValue("@Desc", ideal2);
                cmd.Connection = conn;
                idealID2 = Convert.ToInt32(cmd.ExecuteScalar());

                // Bond IDs
                cmd = new SqlCommand("SELECT ID FROM bond WHERE description = @Desc;");
                cmd.Parameters.AddWithValue("@Desc", bond1);
                cmd.Connection = conn;
                bondID1 = Convert.ToInt32(cmd.ExecuteScalar());

                cmd = new SqlCommand("SELECT ID FROM bond WHERE description = @Desc;");
                cmd.Parameters.AddWithValue("@Desc", bond2);
                cmd.Connection = conn;
                bondID2 = Convert.ToInt32(cmd.ExecuteScalar());

                // Flaw IDs
                cmd = new SqlCommand("SELECT ID FROM flaw WHERE description = @Desc;");
                cmd.Parameters.AddWithValue("@Desc", flaw1);
                cmd.Connection = conn;
                flawID1 = Convert.ToInt32(cmd.ExecuteScalar());

                cmd = new SqlCommand("SELECT ID FROM flaw WHERE description = @Desc;");
                cmd.Parameters.AddWithValue("@Desc", flaw2);
                cmd.Connection = conn;
                flawID2 = Convert.ToInt32(cmd.ExecuteScalar());

                // Insert the record
                cmd = new SqlCommand("INSERT INTO characterBackground " +
                    "(personalityid1, personalityid2, idealid1, idealid2, bondid1, bondid2, flawid1, flawid2, backgroundtypeid)" +
                    "VALUES (@P1, @P2, @I1, @I2, @B1, @B2, @F1, @F2, @BGID); " +
                    "SELECT SCOPE_IDENTITY();");
                cmd.Parameters.AddWithValue("@P1", personalityID1);
                cmd.Parameters.AddWithValue("@P2", personalityID2);
                cmd.Parameters.AddWithValue("@I1", idealID1);
                cmd.Parameters.AddWithValue("@I2", idealID2);
                cmd.Parameters.AddWithValue("@B1", bondID1);
                cmd.Parameters.AddWithValue("@B2", bondID2);
                cmd.Parameters.AddWithValue("@F1", flawID1);
                cmd.Parameters.AddWithValue("@F2", flawID2);
                cmd.Parameters.AddWithValue("@BGID", character.CharacterBackground.BackgroundId);
                cmd.Connection = conn;

                charBackgroundID = Convert.ToInt32(cmd.ExecuteScalar());
            }

            return charBackgroundID;
        }

        /// <summary>
        /// Deletes a background from the database
        /// </summary>
        /// <param name="backgroundId">ID of the background to be deleted</param>
        /// <returns>The number of records that were affected</returns>
        public int DeleteBackground(int backgroundId) {
            int count = 0;
            using (conn = ConnectionFactory.GetConnection()) {
                conn.Open();

                SqlCommand cmd = new SqlCommand($"delete from characterBackground where Id = @bId;");
                cmd.Parameters.AddWithValue("@bId", backgroundId);
                cmd.Connection = conn;

                count = cmd.ExecuteNonQuery();
                return count;
            }
        }

        /// <summary>
        /// Retrieves all types of backgrounds
        /// </summary>
        /// <returns>Collection of backgrounds</returns>
        public List<BackgroundType> GetAllBgTypes() {
            List<BackgroundType> bgTypes = new List<BackgroundType>();

            using (conn = ConnectionFactory.GetConnection()) {
                conn.Open();

                SqlCommand cmd = new SqlCommand($"Select * from backgroundType;");
                cmd.Connection = conn;

                SqlDataReader reader = cmd.ExecuteReader();
                while (reader.Read()) {
                    bgTypes.Add(new BackgroundType(Convert.ToInt32(reader["Id"]), Convert.ToString(reader["Name"]), Convert.ToString(reader["Description"])));
                }
                return bgTypes;
            }
        }

        /// <summary>
        /// Retrieves a specific background type from the database
        /// </summary>
        /// <param name="bgTypeId">ID of background to retrieve</param>
        /// <returns>Background type, or null</returns>
        public BackgroundType GetBgType(int bgTypeId) {
            BackgroundType bgType = null;

            using (conn) {
                conn.Open();

                SqlCommand cmd = new SqlCommand($"select Name, Description from backgroundType where Id = @bId;");
                cmd.Connection = conn;

                SqlDataReader reader = cmd.ExecuteReader();
                while (reader.Read()) {
                    bgType = new BackgroundType(bgTypeId, Convert.ToString(reader["Name"]), Convert.ToString(reader["Description"]));
                }
                reader.Close();
                return bgType;
            }
        }

        /// <summary>
        /// Retrieves all possible traits
        /// </summary>
        /// <param name="bgTypeId">Background type ID</param>
        /// <param name="traitType">Personality, Ideal, Bond, or Flaw trait</param>
        /// <returns>List of traits</returns>
        public List<string> GetPossibleTraits(int bgTypeId, string traitType) {
            List<string> traits = new List<string>();

            using (conn) {
                conn.Open();
                SqlCommand cmd = null;
                switch (traitType) {
                    case "personality":
                        cmd = new SqlCommand($"" +
                            $"select p.Description from personality p" +
                            $"join bgTypePersonality bg on bg.PersonalityId = p.Id" +
                            $"WHERE bg.TypeId = @bId");
                        break;
                    case "ideal":
                        cmd = new SqlCommand($"" +
                            $"select i.Description from ideal i" +
                            $"join bgTypeIdeal bg on bg.IdealId = i.Id" +
                            $"WHERE bg.TypeId = @bId");
                        break;
                    case "bond":
                        cmd = new SqlCommand($"" +
                            $"select b.Description from bond b" +
                            $"join bgTypeBond bg on bg.BondId = b.Id" +
                            $"WHERE bg.TypeId = @bId");
                        break;
                    case "flaw":
                        cmd = new SqlCommand($"" +
                            $"select f.Description from flaw f" +
                            $"join bgTypeFlaw bg on bg.FlawId = f.Id" +
                            $"WHERE bg.TypeId = @bId");
                        break;
                    default:
                        return null;
                }
                cmd.Parameters.AddWithValue("@bId", bgTypeId);
                cmd.Connection = conn;

                SqlDataReader reader = cmd.ExecuteReader();
                while (reader.Read()) {
                    traits.Add(Convert.ToString(reader["Description"]));
                }
                reader.Close();

                return traits;
            }
        }

        /// <summary>
        /// Retrieves the background of a character
        /// </summary>
        /// <param name="characterId">The character id</param>
        /// <returns>The character's background, or null if the character does not exist</returns>
        public Background GetCharacterBackground(int characterId) {
            Background background;

            SqlDataAdapter characterAdapter = new SqlDataAdapter("SELECT charbackid FROM character WHERE id =" + characterId,
                ConnectionFactory.GetConnection());
            DataTable characterTable = new DataTable();
            characterAdapter.Fill(characterTable);

            // Check if character background exists
            if (characterTable == null) {
                return null; // character id does not exist
            }

            // Retrieve character traits
            int backgroundId = characterTable.Rows[0].Field<int>(0);

            // Retrieve background descriptions
            List<string> personality = new List<string>();
            List<string> ideal = new List<string>();
            List<string> bond = new List<string>();
            List<string> flaw = new List<string>();

            // Personality
            SqlDataAdapter personalityAdapter = new SqlDataAdapter(
                $"Select " +
                $"p.Description AS 'P1', p2.Description AS 'P2' " +
                $"FROM characterbackground bg " +
                $"INNER JOIN personality p on p.Id = bg.PersonalityID1 " +
                $"INNER JOIN personality p2 on p2.Id = bg.PersonalityID2 " +
                $"where bg.Id =" + backgroundId + ";",
                ConnectionFactory.GetConnection());
            DataTable personalityTable = new DataTable();
            personalityAdapter.Fill(personalityTable);
            personality.Add(personalityTable.Rows[0].Field<string>(0));
            personality.Add(personalityTable.Rows[0].Field<string>(1));

            // Ideals
            SqlDataAdapter idealsAdapter = new SqlDataAdapter(
                $"Select " +
                $"i.Description AS 'I1', i2.Description AS 'I2' " +
                $"FROM characterbackground bg " +
                $"INNER JOIN ideal i on i.Id = bg.IdealID1 " +
                $"INNER JOIN ideal i2 on i2.Id = bg.IdealID2 " +
                $"where bg.Id =" + backgroundId + ";",
                ConnectionFactory.GetConnection());
            DataTable idealsTable = new DataTable();
            idealsAdapter.Fill(idealsTable);
            ideal.Add(idealsTable.Rows[0].Field<string>(0));
            ideal.Add(idealsTable.Rows[0].Field<string>(1));

            // Bonds
            SqlDataAdapter bondsAdapter = new SqlDataAdapter(
                $"Select " +
                $"b.Description AS 'B1', b2.Description AS 'B2' " +
                $"FROM characterbackground bg " +
                $"INNER JOIN bond b on b.Id = bg.BondID1 " +
                $"INNER JOIN bond b2 on b2.Id = bg.BondID2 " +
                $"where bg.Id = " + backgroundId + ";",
                ConnectionFactory.GetConnection());
            DataTable bondsTable = new DataTable();
            bondsAdapter.Fill(bondsTable);
            bond.Add(bondsTable.Rows[0].Field<string>(0));
            bond.Add(bondsTable.Rows[0].Field<string>(1));

            // Flaws
            SqlDataAdapter flawsAdapter = new SqlDataAdapter(
                $"Select " +
                $"f.Description AS 'F1', f2.Description AS 'F2' " +
                $"FROM characterbackground bg " +
                $"INNER JOIN flaw f on f.Id = bg.FlawID1 " +
                $"INNER JOIN flaw f2 on f2.Id = bg.FlawID2 " +
                $"where bg.Id = " + backgroundId + ";",
                ConnectionFactory.GetConnection());
            DataTable flawsTable = new DataTable();
            flawsAdapter.Fill(flawsTable);
            flaw.Add(flawsTable.Rows[0].Field<string>(0));
            flaw.Add(flawsTable.Rows[0].Field<string>(1));

            // Get background description
            SqlDataAdapter descriptionAdapter = new SqlDataAdapter(
                "SELECT bt.name, bt.description " +
                "FROM backgroundtype bt " +
                "INNER JOIN characterbackground cb " +
                "ON cb.BackgroundTypeID = bt.Id " +
                "WHERE cb.ID =" + characterId + ";",
                ConnectionFactory.GetConnection());
            DataTable descriptionTable = new DataTable();
            descriptionAdapter.Fill(descriptionTable);
            string bgName = descriptionTable.Rows[0].Field<string>(0);
            string bgDescription = descriptionTable.Rows[0].Field<string>(1);

            background = new Background(backgroundId, bgName, bgDescription, personality, ideal, bond, flaw);
            
            return background;
        }

        /// <summary>
        /// Retrieves all backgrounds from the database
        /// </summary>
        /// <returns>Collection of backgrounds</returns>
        public List<Background> GetAllBackgroundTypes() {
            List<Background> backgrounds = new List<Background>();

            SqlDataAdapter backgroundAdapter = new SqlDataAdapter("SELECT id, name, description FROM backgroundType;",
                ConnectionFactory.GetConnection());

            DataTable backgroundTable = new DataTable();
            backgroundAdapter.Fill(backgroundTable);

            // Populate lists with database info
            foreach (DataRow row in backgroundTable.Rows) {
                int backgroundId = row.Field<int>(0);

                // Traits for each background
                List<string> personalityTraits = new List<string>();
                List<string> ideals = new List<string>();
                List<string> bonds = new List<string>();
                List<string> flaws = new List<string>();

                // Personality Traits
                SqlDataAdapter personalityAdapter = new SqlDataAdapter("SELECT description " +
                        "FROM personality p INNER JOIN bgTypePersonality bgp ON bgp.PersonalityId = p.id " +
                        "WHERE bgp.TypeId = " + backgroundId + ";",
                    ConnectionFactory.GetConnection());
                DataTable personalityTable = new DataTable();
                personalityAdapter.Fill(personalityTable);
                foreach (DataRow personalityRow in personalityTable.Rows) {
                    personalityTraits.Add(personalityRow.Field<string>(0));
                }

                // Ideals
                SqlDataAdapter idealsAdapter = new SqlDataAdapter("SELECT description " +
                        "FROM ideal p INNER JOIN bgTypeIdeal bgi ON bgi.IdealID = p.id " +
                        "WHERE bgi.TypeId = " + backgroundId + ";",
                    ConnectionFactory.GetConnection());
                DataTable idealsTable = new DataTable();
                idealsAdapter.Fill(idealsTable);
                foreach (DataRow idealRow in idealsTable.Rows) {
                    ideals.Add(idealRow.Field<string>(0));
                }

                // Bonds
                SqlDataAdapter bondsAdapter = new SqlDataAdapter("SELECT description " +
                        "FROM bond p INNER JOIN bgTypeBond bgb ON bgb.BondID = p.id " +
                        "WHERE bgb.TypeId = " + backgroundId + ";",
                    ConnectionFactory.GetConnection());
                DataTable bondsTable = new DataTable();
                bondsAdapter.Fill(bondsTable);
                foreach (DataRow bondRow in bondsTable.Rows) {
                    bonds.Add(bondRow.Field<string>(0));
                }

                // Flaws
                SqlDataAdapter flawsAdapter = new SqlDataAdapter("SELECT description " +
                        "FROM flaw p INNER JOIN bgTypeFlaw bgf ON bgf.FlawID = p.id " +
                        "WHERE bgf.TypeId = " + backgroundId + ";",
                    ConnectionFactory.GetConnection());
                DataTable flawsTable = new DataTable();
                flawsAdapter.Fill(flawsTable);
                foreach (DataRow flawRow in flawsTable.Rows) {
                    flaws.Add(flawRow.Field<string>(0));
                }

                // Add background and its information to row
                backgrounds.Add(new Background(
                        backgroundId,
                        Convert.ToString(row.Field<string>(1)),
                        Convert.ToString(row.Field<string>(2)),
                        personalityTraits,
                        ideals,
                        bonds,
                        flaws
                    ));
            }

            backgrounds.Sort();
            return backgrounds;
        }
    }
}
