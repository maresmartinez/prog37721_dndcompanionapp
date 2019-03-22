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
        List<Campaign> userCampaigns;

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

        public List<Campaign> UserCampaigns {
            get { return userCampaigns; }
            set {
                // Ensure that the user is part of the campaign before adding it
                foreach (Campaign campaign in value) {
                    if (campaign.IsUserInCampaign(this)) {
                        userCampaigns = value;
                        break;
                    }
                }
            }
        }

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

        /// <summary>
        /// Will add campaign to UserCampaign only if user does not already hold a reference to this campaign, and if user is in the campaign
        /// </summary>
        /// <param name="campaign"></param>
        public void AddCampaign(Campaign campaign) {
            foreach (Campaign userCampign in UserCampaigns) {
                if (userCampign.Equals(campaign)) {
                    throw new ArgumentException("User already has this campaign");
                }
            }

            if (campaign.IsUserInCampaign(this)) {
                UserCampaigns.Add(campaign);
            } else { 
                throw new ArgumentException("User must be in campagin");
            }
        }

        public void RemoveCampaign(Campaign campaign) {
            UserCampaigns.Remove(campaign);
        }

        public bool DoesUserOwnCharacter(Character character) {
            foreach (Character ownedCharacter in UserCharacters) {
                if (ownedCharacter.Equals(character)) {
                    return true;
                }
            }
            return false;
        }

        public override bool Equals(object obj) {
            if (!(obj is User) || ((User)obj).Username != this.Username) {
                return false;
            } else {
                return true;
            }
        }
    }
}
