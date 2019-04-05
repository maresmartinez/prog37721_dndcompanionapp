﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CharacterCreationLib;


namespace UserManagementLib {
    [Serializable]
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
        /// Characters owned by user
        /// </summary>
        public List<Character> UserCharacters { get; set; }

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
                } else {
                    password = HashUtil.GetPasswordHash(value, Salt);
                }
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
        /// Campaigns owned by user
        /// </summary>
        List<Campaign> userCampaigns;
        /// <summary>
        /// Campaigns owned by user
        /// </summary>
        public List<Campaign> UserCampaigns {
            get { return userCampaigns; }
            set {

                // Sets campaigns if it is an empty list
                if (value.Count == 0) {
                    userCampaigns = value;
                    return;
                }

                // Ensure that the user is part of the campaign before adding it
                foreach (Campaign campaign in value) {
                    if (campaign.IsUserInCampaign(this)) {
                        userCampaigns = value;
                        break;
                    }
                }
                throw new ArgumentException("User must be in campaign");
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
        /// Constructor
        /// </summary>
        /// <param name="username">Username of user</param>
        /// <param name="fullName">Full name of user</param>
        /// <param name="userCharacters">Characters owned by user</param>
        /// <param name="password">Password of user</param>
        /// <param name="userCampaigns">Campaigns owns by user</param>
        //public User(int id, string username, string fullName, List<Character> userCharacters, string password, List<Campaign> userCampaigns) {
        //    ID = id;
        //    Username = username;
        //    FullName = fullName;
        //    UserCharacters = userCharacters;
        //    Salt = HashUtil.GetSalt();
        //    Password = password;
        //    UserCampaigns = userCampaigns;
        //}

        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="id">ID of user</param>
        /// <param name="username">Username of user</param>
        /// <param name="fullName">Full name of user</param>
        /// <param name="userCharacters">Characters owned by user</param>
        /// <param name="password">Password of user</param>
        /// <param name="userCampaigns">Campaigns owns by user</param>
        public User(string username, string fullName, List<Character> userCharacters, string password, List<Campaign> userCampaigns) {
            Username = username;
            FullName = fullName;
            UserCharacters = userCharacters;
            Salt = HashUtil.GetSalt();
            Password = password;
            UserCampaigns = userCampaigns;
        }

        /// <summary>
        /// Adds a character to UserCharacters
        /// </summary>
        /// <param name="character">The character to add</param>
        public void AddCharacter(Character character) {
            UserCharacters.Add(character);
        }

        /// <summary>
        /// Remove a user's character
        /// </summary>
        /// <param name="character">The character to remove</param>
        public void RemoveCharacter(Character character) {
            UserCharacters.Remove(character);
        }

        /// <summary>
        /// Will add campaign to UserCampaign only if user does not already hold a reference to this campaign, and if user is in the campaign
        /// </summary>
        /// <param name="campaign">The campaign to add</param>
        public void AddCampaign(Campaign campaign) {
            if (UserCampaigns is null) {
                UserCampaigns = new List<Campaign>();
            }

            foreach (Campaign userCampign in UserCampaigns) {
                if (userCampign.Equals(campaign)) {
                    throw new ArgumentException("User already has this campaign");
                }
            }

            if (campaign.IsUserInCampaign(this) || campaign.DungeonMaster.Equals(this)) {
                UserCampaigns.Add(campaign);
            } else {
                throw new ArgumentException("User must be in campagin");
            }
        }

        /// <summary>
        /// Removes a campaign from UserCampaigns
        /// </summary>
        /// <param name="campaign">The campaign to remoe</param>
        public void RemoveCampaign(Campaign campaign) {
            UserCampaigns.Remove(campaign);
        }

        /// <summary>
        /// Check if user owns a character
        /// </summary>
        /// <param name="character">The character to check</param>
        /// <returns>True if the user owns the character, false if not</returns>
        public bool DoesUserOwnCharacter(Character character) {
            foreach (Character ownedCharacter in UserCharacters) {
                if (ownedCharacter.Equals(character)) {
                    return true;
                }
            }
            return false;
        }

        /// <summary>
        /// Retrieves user character depending on name
        /// </summary>
        /// <param name="name">Name of the character</param>
        /// <returns>The character if found, null if not</returns>
        public Character GetCharacterByName(string name) {
            foreach (Character character in UserCharacters) {
                if (character.Name.Equals(name)) {
                    return character;
                }
            }
            return null;
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
