using CharacterCreationLib;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DnDSQLLib.dal
{
    public class StatsDAO
    {
        SqlConnection conn;
        public StatsDAO()
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

        public int UploadStats(Character character)
        {
            int statsId;
            List<int> stats = new List<int>();
            try
            {
                conn.Open();

                // Adding all the initial stats to the list
                stats.Add(character.Strength);
                stats.Add(character.Dexterity);
                stats.Add(character.Constitution);
                stats.Add(character.Intelligence);
                stats.Add(character.Wisdom);
                stats.Add(character.Charisma);

                // Adding all the mod stats to the list
                stats.Add(character.StrMod);
                stats.Add(character.DexMod);
                stats.Add(character.ConMod);
                stats.Add(character.IntMod);
                stats.Add(character.WisMod);
                stats.Add(character.ChrMod);

                SqlCommand cmd = new SqlCommand($"" +
                    $"Insert into characterStats (Str,Dex,Con,Int,Wis,Chr,StrMod,DexMod,ConMod,IntMod,WisMod,ChrMod)" +
                    $"values (@s,@d,@c,@i,@w,@ch,@sm,@dm,@cm,@im,@wm,@chm");
                cmd.Parameters.AddWithValue("@s", stats[0]);
                cmd.Parameters.AddWithValue("@d", stats[1]);
                cmd.Parameters.AddWithValue("@c", stats[2]);
                cmd.Parameters.AddWithValue("@i", stats[3]);
                cmd.Parameters.AddWithValue("@w", stats[4]);
                cmd.Parameters.AddWithValue("@ch", stats[5]);

                cmd.Parameters.AddWithValue("@sm", stats[6]);
                cmd.Parameters.AddWithValue("@dm", stats[7]);
                cmd.Parameters.AddWithValue("@cm", stats[8]);
                cmd.Parameters.AddWithValue("@im", stats[9]);
                cmd.Parameters.AddWithValue("@wm", stats[10]);
                cmd.Parameters.AddWithValue("@chm", stats[11]);

                cmd.Connection = conn;

                statsId = Convert.ToInt32(cmd.ExecuteScalar());

                character.StatID = statsId;

                return statsId;
            }
            catch (SqlException)
            {
                // **ERROR PLACE HOLDER**
                statsId = -1;
                return statsId;
            }
            finally
            {
                conn.Close();
            }
        }
        public int DeleteStats(int statsId)
        {
            int confirm;
            try
            {
                conn.Open();

                SqlCommand cmd = new SqlCommand($"" +
                    $"Delete From characterStats Where Id = @Id");

                cmd.Parameters.AddWithValue("@Id", statsId);
                cmd.Connection = conn;

                confirm = cmd.ExecuteNonQuery();
            }
            catch (SqlException)
            {
                // **ERROR PLACE HOLDER**
                confirm = -1;
            }
            finally
            {
                conn.Close();
            }
            return confirm;
        }
        public List<int> GetStats(int statsId)
        {
            List<int> stats = new List<int>();
            try
            {
                conn.Open();
                SqlCommand cmd = new SqlCommand($"" +
                    $"Select Str,Dex,Con,Int,Wis,Chr,StrMod,DexMod,ConMod,IntMod,WisMod,ChrMod From characterStats Where Id = @Id");
                cmd.Parameters.AddWithValue("@Id", statsId);
                cmd.Connection = conn;

                SqlDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    for (int i = 0; i < 12; i++)
                    {
                        stats.Add(Convert.ToInt32(reader[i]));
                    }
                }
                reader.Close();
            }
            catch (SqlException)
            {
                // **ERROR PLACE HOLDER**
                stats = null;
            }
            finally
            {
                conn.Close();
            }
            return stats;
        }
        public int UpdateStats(string type, int newValue, int statsId, Character character)
        {
            int confirm = 0;

            try
            {
                conn.Open();
                SqlCommand cmd;
                switch (type)
                {
                    case "str":
                        cmd = new SqlCommand($"Update characterStats Set Str = @nV Where Id = @sI");
                        break;
                    case "dex":
                        cmd = new SqlCommand($"Update characterStats Set Dex = @nV Where Id = @sI");
                        break;
                    case "con":
                        cmd = new SqlCommand($"Update characterStats Set Con = @nV Where Id = @sI");
                        break;
                    case "int":
                        cmd = new SqlCommand($"Update characterStats Set Int = @nV Where Id = @sI");
                        break;
                    case "wis":
                        cmd = new SqlCommand($"Update characterStats Set Wis = @nV Where Id = @sI");
                        break;
                    case "chr":
                        cmd = new SqlCommand($"Update characterStats Set Chr = @nV Where Id = @sI");
                        break;
                    case "strMod":
                        cmd = new SqlCommand($"Update characterStats Set strMod = @nV Where Id = @sI");
                        break;
                    case "dexMod":
                        cmd = new SqlCommand($"Update characterStats Set dexMod = @nV Where Id = @sI");
                        break;
                    case "conMod":
                        cmd = new SqlCommand($"Update characterStats Set conMod = @nV Where Id = @sI");
                        break;
                    case "intMod":
                        cmd = new SqlCommand($"Update characterStats Set intMod = @nV Where Id = @sI");
                        break;
                    case "wisMod":
                        cmd = new SqlCommand($"Update characterStats Set wisMod = @nV Where Id = @sI");
                        break;
                    case "chrMod":
                        cmd = new SqlCommand($"Update characterStats Set chrMod = @nV Where Id = @sI");
                        break;
                    default:
                        return -1;
                }
                cmd.Parameters.AddWithValue("@nV", newValue);
                cmd.Parameters.AddWithValue("@sI", statsId);
                cmd.Connection = conn;

                confirm = cmd.ExecuteNonQuery();

                if (character != null)
                {
                    switch (type)
                    {
                        case "str":
                            character.Strength = newValue;
                            break;
                        case "dex":
                            character.Dexterity = newValue;
                            break;
                        case "con":
                            character.Constitution = newValue;
                            break;
                        case "int":
                            character.Intelligence = newValue;
                            break;
                        case "wis":
                            character.Wisdom = newValue;
                            break;
                        case "chr":
                            character.Charisma = newValue;
                            break;
                        case "strMod":
                            character.StrMod = newValue;
                            break;
                        case "dexMod":
                            character.DexMod = newValue;
                            break;
                        case "conMod":
                            character.ConMod = newValue;
                            break;
                        case "intMod":
                            character.IntMod = newValue;
                            break;
                        case "wisMod":
                            character.WisMod = newValue;
                            break;
                        case "chrMod":
                            character.ChrMod = newValue;
                            break;
                        default:
                            return -1;
                    }
                }
            }
            catch (SqlException)
            {
                // **ERROR PLACE HOLDER**
                return -1;
            }
            finally
            {
                conn.Close();
            }
            return confirm;
        }
    }
}
