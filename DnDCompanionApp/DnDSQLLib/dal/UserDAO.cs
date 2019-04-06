using CharacterCreationLib;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UserManagementLib;

namespace DnDSQLLib.dal {
    /// <summary>
    /// Inteface between user class and user table in database
    /// </summary>
    public class UserDAO {

        /// <summary>
        /// Connection to database
        /// </summary>
        SqlConnection conn;

        /// <summary>
        /// Constructor
        /// </summary>
        public UserDAO() {
            try {
                conn = ConnectionFactory.GetConnection();
                conn.Open();
                conn.Close();   // Just double checking to make sure that yes, we can indeed access the server
            } catch (SqlException) {
                // Figure out how to let the user know that things just aint happening
            }
        }

        /// <summary>
        /// Adds a user's details as a record in the UserTable
        /// </summary>
        /// <param name="user">The user to be added to the users table</param>
        /// <returns></returns>
        public int AddUser(User user) {
            int count = 0;
            using (conn) {
                conn.Open();

                // Create insert statement depending on whether or not user has a phone number
                SqlCommand cmd = new SqlCommand("INSERT INTO Users (fullname, username, password, salt) " +
                    "VALUES (@FName, @UName, @Password, @Salt)");
                cmd.Parameters.AddWithValue("@FName", user.FullName);
                cmd.Parameters.AddWithValue("@UName", user.Username);
                cmd.Parameters.AddWithValue("@Password", user.Password);
                cmd.Parameters.AddWithValue("@Salt", user.Salt);

                cmd.Connection = conn;

                count = cmd.ExecuteNonQuery();
            }
            return count;
        }

        /// <summary>
        /// Checks a username and password against the records in the users table. If credentials are invalid, this method 
        /// will not specify whether it was the email or password that was incorrect.
        /// </summary>
        /// <param name="email">The email of the user</param>
        /// <param name="plainTextPassword">The password in plain-text of the user</param>
        /// <returns>Whether or not the email and password matched any records in the UserTable</returns>
        public bool AuthenticateUser(string username, string plainTextPassword) {
            using (conn) {
                conn.Open();

                SqlCommand select = new SqlCommand("SELECT id, fullname, username, password, salt " +
                    "FROM users WHERE username=@UName");
                select.Parameters.AddWithValue("@UName", username);
                select.Connection = conn;
                SqlDataReader reader = select.ExecuteReader();

                if (reader.Read()) {
                    string salt = Convert.ToString(reader["salt"]);
                    string storedPassword = Convert.ToString(reader["password"]);

                    // Generate a hash for the entered password with the salt
                    string inputPassword = HashUtil.GetPasswordHash(plainTextPassword, salt);

                    // Check if stored hash password matches the inputted password
                    if (inputPassword.Equals(storedPassword)) {
                        conn.Close();
                        return true;
                    }

                } else {
                    // Username does not exist
                    conn.Close();
                    return false;
                }
            }
            return false;
        }

        /// <summary>
        /// Retrieves all user characters from the database
        /// </summary>
        /// <param name="userId">User whose characters must be retrieved</param>
        /// <returns>Collection of characters</returns>
        public List<Character> GetUserCharacters(int userId) {
            List<Character> characters = new List<Character>();
            List<int> characterIds = new List<int>();
            CharacterDAO cDAO = new CharacterDAO();
            using (conn) {
                conn.Open();
                SqlCommand cmd = new SqlCommand($"" +
                    $"select charId from userCharacter where userId = @uId");
                cmd.Parameters.AddWithValue("@uId", userId);
                cmd.Connection = conn;

                SqlDataReader reader = cmd.ExecuteReader();
                while (reader.Read()) {
                    //characters.Add(cDAO.GetCharacter(Convert.ToInt32(reader["charId"])));
                    characterIds.Add(Convert.ToInt32(reader["charId"]));
                }
                reader.Close();
            }

            foreach (int id in characterIds) {
                characters.Add(cDAO.GetCharacter(id));
            }

            return characters;
        }

        /// <summary>
        /// Retrieves all user campaigns from the database
        /// </summary>
        /// <param name="userId">User whose campaigns must be retrieved</param>
        /// <returns>Collection of campaigns</returns>
        public List<Campaign> GetUserCampaigns(int userId) {
            List<Campaign> campaigns = new List<Campaign>();

            try {
                conn.Open();

                CampaignDAO camDAO = new CampaignDAO();

                SqlCommand cmd = new SqlCommand($"" +
                    $"select CampaignId from userCampaign where userId = @uId");
                cmd.Parameters.AddWithValue("@uId", userId);

                SqlDataReader reader = cmd.ExecuteReader();
                while (reader.Read()) {
                    campaigns.Add(camDAO.GetCampaign(Convert.ToInt32(reader["CampaignId"])));
                }
                reader.Close();
                return campaigns;
            } catch (SqlException) {
                // **ERROR PLACE HOLDER**
                conn.Close();
                return null;
            } finally {
                conn.Close();
            }
        }

        /// <summary>
        /// Retrieves user object by id
        /// </summary>
        /// <param name="userId">id</param>
        /// <returns>User object</returns>
        public User GetUser(int userId) {
            User user = null;

            try {
                conn.Open();
                SqlCommand cmd = new SqlCommand($"" +
                    $"select * from users where id = @uID");
                cmd.Parameters.AddWithValue("@uID", userId);
                cmd.Connection = conn;

                SqlDataReader reader = cmd.ExecuteReader();
                while (reader.Read()) {
                    user = new User(userId,
                        Convert.ToString(reader["userName"]),
                        Convert.ToString(reader["fullName"]),
                        Convert.ToString(reader["Password"]),
                        Convert.ToString(reader["Salt"]));
                }
                reader.Close();

                return user;
            } catch (SqlException) {
                // **ERROR PLACE HOLDER**
                conn.Close();
                return null;
            } finally {
                conn.Close();
            }
        }

        /// <summary>
        /// Retrieves user object by username
        /// </summary>
        /// <param name="username">Username</param>
        /// <returns>User object</returns>
        public User GetUser(string username) {
            User user = null;

            try {
                conn.Open();
                SqlCommand cmd = new SqlCommand($"" +
                    $"select * from users where username = @uName");
                cmd.Parameters.AddWithValue("@uName", username);
                cmd.Connection = conn;

                SqlDataReader reader = cmd.ExecuteReader();
                while (reader.Read()) {
                    int userId = Convert.ToInt32(reader["id"]);
                    user = new User(userId,
                        Convert.ToString(reader["userName"]),
                        Convert.ToString(reader["fullName"]),
                        Convert.ToString(reader["Password"]),
                        Convert.ToString(reader["Salt"]));
                }
                reader.Close();

                return user;
            } catch (SqlException) {
                // **ERROR PLACE HOLDER**
                conn.Close();
                return null;
            } finally {
                conn.Close();
            }
        }
    }
}

