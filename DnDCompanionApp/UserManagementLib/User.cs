using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CharacterCreationLib;

namespace UserManagementLib {
    public class User {
        public string Username { get; set; }
        public string FullName { get; set; }
        public List<Character> UserCharacters { get; set; }

        public User() {

        }

        public User(string username, string fullName, List<Character> userCharacters) {
            Username = username;
            FullName = fullName;
            UserCharacters = userCharacters;
        }
    }
}
