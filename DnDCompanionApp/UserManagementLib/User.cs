using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CharacterCreationLib;

namespace UserManagementLib {
    /// <summary>
    /// Holds information of user of an application
    /// TODO: Add email to class; think about implementing two-tier authentication
    /// </summary>
    public class User {

        /// <summary>
        /// Username of user
        /// </summary>
        string username;
        /// <summary>
        /// Username of user
        /// </summary>
        public string Username {
            get { return username; }
            set {
                if (string.IsNullOrEmpty(value)) {
                    throw new ArgumentException("Username must have a value.");
                } else {
                    username = value;
                }
            }
        }

        /// <summary>
        /// Full name of user
        /// </summary>
        string fullName;
        /// <summary>
        /// Full name of user
        /// </summary>
        public string FullName {
            get { return fullName; }
            set {
                if (string.IsNullOrEmpty(value)) {
                    throw new ArgumentException("Full Name must have a value.");
                } else {
                    fullName = value;
                }
            }
        }


        /// <summary>
        /// Salted and hashed password of user
        /// </summary>
        string password;
        /// <summary>
        /// Salted and hashed password of user
        /// </summary>
        public string Password {
            get { return password; }
            set {
                if (value.Length < 6) {
                    throw new ArgumentException("Password must be at least 6 characters long.");
                }

                password = HashUtil.GetPasswordHash(value, Salt);
            }
        }

        /// <summary>
        /// Salt to hash password
        /// </summary>
        string salt;
        /// <summary>
        /// Salt to hash password
        /// </summary>
        public string Salt {
            get { return salt; }
            set {
                if (string.IsNullOrEmpty(value)) {
                    throw new ArgumentException("Salt must have a value");
                }

                salt = value;
            }
        }

        /// <summary>
        /// Database identifier for user
        /// </summary>
        int id;
        /// <summary>
        /// Database identifier for user
        /// </summary>
        public int ID {
            get { return id; }
            set {
                if (value < 1) {
                    throw new ArgumentException("ID must be a positive value");
                }

                id = value;
            }
        }

        /// <summary>
        /// Default constructor
        /// </summary>
        public User() {

        }

        /// <summary>
        /// Constructor without ID, used to insert into database
        /// </summary>
        /// <param name="username">Username of user</param>
        /// <param name="fullName">Full name of user</param>
        /// <param name="password">Password of user</param>
        public User(string username, string fullName, string password) {
            Username = username;
            FullName = fullName;
            Salt = HashUtil.GetSalt();
            Password = password;
        }

        /// <summary>
        /// Constructor with ID, is what is returned from database
        /// </summary>
        /// <param name="username">Username of user</param>
        /// <param name="fullName">Full name of user</param>
        /// <param name="password">Password of user</param>
        public User(int id, string username, string fullName, string password, string salt) {
            ID = id;
            Username = username;
            FullName = fullName;
            Salt = salt;
            Password = password;
        }

        /// <summary>
        /// Describes the user
        /// </summary>
        /// <returns>Description of user</returns>
        public override string ToString() {
            return $"Username: {Username}, Full Name: {FullName}";
        }

        /// <summary>
        /// Checks if two users are the same
        /// </summary>
        /// <param name="obj"></param>
        /// <returns></returns>
        public override bool Equals(object obj) {
            if (!(obj is User) || ((User)obj).Username != this.Username) {
                return false;
            } else {
                return true;
            }
        }
    }
}
