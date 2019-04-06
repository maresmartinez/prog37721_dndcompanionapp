using CharacterCreationLib;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DnDSQLLib.dal {
    /// <summary>
    /// Interface between character class and character tables in database
    /// </summary>
    public class CharacterDAO {

        /// <summary>
        /// Connection to database
        /// </summary>
        SqlConnection conn;

        /// <summary>
        /// Constructor
        /// </summary>
        public CharacterDAO() {
            conn = ConnectionFactory.GetConnection();
        }

        /// <summary>
        /// Uploads character to database and creates record that associates it with the user who created it
        /// </summary>
        /// <param name="userId">User to be associated with character</param>
        /// <param name="character">Character to be uploaded</param>
        /// <returns>ID of character created</returns>
        public int UploadCharacter(int userId, Character character) {
            int characterId;

            BackgroundDAO backgroundDAO = new BackgroundDAO();
            character.CharBackgroundID = backgroundDAO.UploadBackground(character);

            using (conn) {
                conn.Open();

                SqlCommand cmd = new SqlCommand(
                    "INSERT INTO character (" +
                        "name, notes, raceId, classid, charbackid, " +
                        "str, dex, con, int, wis, chr, " +
                        "strmod, dexmod, conmod, intmod, wismod, chrmod, " +
                        "hair, eyes, skin" +
                    ") VALUES (" +
                        "@Name, @Notes, @RID, @CID, @BGID, " +
                        "@Str, @Dex, @Con, @Int, @Wis, @Chr," +
                        "@StrMod, @DexMod, @ConMod, @IntMod, @WisMod, @ChrMod, " +
                        "@Hair, @Eyes, @Skin" +
                    "); SELECT SCOPE_IDENTITY();"
                );

                cmd.Parameters.AddWithValue("@Name", character.Name);
                cmd.Parameters.AddWithValue("@Notes", character.AdditionalNotes);
                cmd.Parameters.AddWithValue("@RID", character.Race.RaceId);
                cmd.Parameters.AddWithValue("@CID", character.CharacterClass.ClassId);
                cmd.Parameters.AddWithValue("@BGID", character.CharBackgroundID);

                cmd.Parameters.AddWithValue("@Str", character.Strength);
                cmd.Parameters.AddWithValue("@Dex", character.Dexterity);
                cmd.Parameters.AddWithValue("@Con", character.Constitution);
                cmd.Parameters.AddWithValue("@Int", character.Intelligence);
                cmd.Parameters.AddWithValue("@Wis", character.Wisdom);
                cmd.Parameters.AddWithValue("@Chr", character.Charisma);

                cmd.Parameters.AddWithValue("@StrMod", character.StrMod);
                cmd.Parameters.AddWithValue("@DexMod", character.DexMod);
                cmd.Parameters.AddWithValue("@ConMod", character.ConMod);
                cmd.Parameters.AddWithValue("@IntMod", character.IntMod);
                cmd.Parameters.AddWithValue("@WisMod", character.WisMod);
                cmd.Parameters.AddWithValue("@ChrMod", character.ChrMod);

                cmd.Parameters.AddWithValue("@Hair", character.Hair);
                cmd.Parameters.AddWithValue("@Eyes", character.Eyes);
                cmd.Parameters.AddWithValue("@Skin", character.Skin);

                cmd.Connection = conn;
                characterId = Convert.ToInt32(cmd.ExecuteScalar());
                character.DbID = characterId;

                // Associate character with user
                cmd = new SqlCommand("INSERT INTO userCharacter (userid, charid) " +
                    "VALUES (@UID, @CID)");
                cmd.Parameters.AddWithValue("@UID", userId);
                cmd.Parameters.AddWithValue("@CID", characterId);
                cmd.Connection = conn;
                cmd.ExecuteNonQuery();

            }

            return characterId;
        }

        /// <summary>
        /// Removes a character from the database
        /// </summary>
        /// <param name="characterId">Character to be removed</param>
        /// <returns></returns>
        public int DeleteCharacter(int characterId) {
            int count = 0;
            try {
                conn.Open();

                SqlCommand cmd = new SqlCommand($"" +
                    $"delete from character where Id = @cId");
                cmd.Parameters.AddWithValue("@cId", characterId);

                count = cmd.ExecuteNonQuery();
                return count;
            } finally {
                conn.Close();
            }
        }

        /// <summary>
        /// Retrieves character via character ID 
        /// </summary>
        /// <param name="characterId"></param>
        /// <returns>The character or null</returns>
        public Character GetCharacter(int characterId) {
            Character character = null;

            ClassDAO classDAO = new ClassDAO();
            Class charClass = classDAO.GetCharacterClass(characterId);

            RaceDAO raceDAO = new RaceDAO();
            Race race = raceDAO.GetCharacterRace(characterId);

            BackgroundDAO backgroundDAO = new BackgroundDAO();
            Background background = backgroundDAO.GetCharacterBackground(characterId);

            using (conn) {
                conn.Open();

                SqlCommand cmd = new SqlCommand("SELECT * FROM character WHERE id = @CID;");
                cmd.Parameters.AddWithValue("@CID", characterId);
                cmd.Connection = conn;

                SqlDataReader reader = cmd.ExecuteReader();

                if (reader.Read()) {
                    character = new Character(
                        Convert.ToString(reader["name"]),
                        Convert.ToInt32(reader["str"]),
                        Convert.ToInt32(reader["dex"]),
                        Convert.ToInt32(reader["con"]),
                        Convert.ToInt32(reader["int"]),
                        Convert.ToInt32(reader["wis"]),
                        Convert.ToInt32(reader["chr"]),
                        Convert.ToInt32(reader["strmod"]),
                        Convert.ToInt32(reader["dexmod"]),
                        Convert.ToInt32(reader["conmod"]),
                        Convert.ToInt32(reader["intmod"]),
                        Convert.ToInt32(reader["wismod"]),
                        Convert.ToInt32(reader["chrmod"]),
                        background,
                        Convert.ToString(reader["hair"]),
                        Convert.ToString(reader["eyes"]),
                        Convert.ToString(reader["skin"]),
                        Convert.ToString(reader["notes"]),
                        race,
                        charClass
                    );
                }
            }

            return character;
        }
    }
}
