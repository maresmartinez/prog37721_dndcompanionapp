using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CharacterCreationLib;

namespace UserManagementLib {
    public class User {

        string username;
        string fullName;
        string password;

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

        public List<Character> UserCharacters { get; set; }

        public string Password {
            get { return password; }
            set {
                if (value.Length < 6) {
                    throw new ArgumentException("Password must be at least 6 characters long.");
                } else {
                    password = value;
                }
            }
        }

        // TODO add salt utility so that password is not saved as plain text

        public User() {

        }

        public User(string username, string fullName, List<Character> userCharacters, string password) {
            Username = username;
            FullName = fullName;
            UserCharacters = userCharacters;
            Password = password;
        }

        public void AddCharacter(Character character) {
            UserCharacters.Add(character);
        }

        public void RemoveCharacter(Character character) {
            UserCharacters.Remove(character);
        }
    }
}
