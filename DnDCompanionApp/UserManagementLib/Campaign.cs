using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CharacterCreationLib;
using UserManagementLib;

namespace UserManagementLib {
    /// <summary>
    /// A D&D campaign which holds groups for the users and characters within the campaign
    /// TODO: find way to validate campaign lists without needing methods in user class... the commented out code was buggy
    /// </summary>
    public class Campaign {

        /// <summary>
        /// Name of campaign
        /// </summary>
        string campaignName;
        /// <summary>
        /// Name of campaign
        /// </summary>
        public string CampaignName {
            get { return campaignName; }
            set {
                if (string.IsNullOrEmpty(value)) {
                    throw new ArgumentException("Campaign Name must have a value");
                } else {
                    campaignName = value;
                }
            }
        }

        /// <summary>
        /// Description of campaign
        /// </summary>
        string campaignDescription;
        /// <summary>
        /// Description of campaign
        /// </summary>
        public string CampaignDescription {
            get { return campaignDescription; }
            set {
                if (string.IsNullOrEmpty(value)) {
                    throw new ArgumentException("Campaign Description must have a value");
                } else {
                    campaignDescription = value;
                }
            }
        }

        /// <summary>
        /// Dungeon master of campaign
        /// </summary>
        User dungeonMaster;
        /// <summary>
        /// Dungeon master of campaign
        /// </summary>
        public User DungeonMaster {
            get { return dungeonMaster; }
            set {
                if (value == null) {
                    throw new ArgumentException("Campaign must have a dungeon master");
                }
                dungeonMaster = value;
            }
        }

        ///// <summary>
        ///// All users in the campaign
        ///// </summary>
        //List<User> campaignUsers;
        ///// <summary>
        ///// All users in the campaign
        ///// </summary>
        //public List<User> CampaignUsers {
        //    get { return campaignUsers; }
        //    set {
        //        if (value.Count < 2) {
        //            throw new ArgumentException("Must have at least two Campaign Users");
        //        }

        //        campaignUsers = value;
        //    }
        //}
        public List<User> CampaignUsers { get; set; }

        /// <summary>
        /// The user characters that are in the campaign
        /// </summary>
        //List<Character> campaignCharacters;
        /// <summary>
        /// The user characters that are in the campaign
        /// </summary>
        //public List<Character> CampaignCharacters {
        //    get { return campaignCharacters; }
        //    set {
        //        // Ensure that all Characters in List belong to one of the CampaignUsers
        //        foreach (Character character in value) {
        //            bool characterNotValid = true;

        //            // characterNotValid will only become false if one of the users own it
        //            foreach (User user in CampaignUsers) {
        //                if (user.DoesUserOwnCharacter(character)) {
        //                    characterNotValid = false;
        //                    break;
        //                }
        //            }

        //            // If flag is 
        //            if (characterNotValid) {
        //                throw new ArgumentException("Campaign character must be owned by one of the campaign users");
        //            }
        //        }

        //        // Characters must equal users; users can only play one character
        //        if (value.Count != CampaignUsers.Count) {
        //            throw new ArgumentException("Campaign users must equal characters");
        //        }

        //        campaignCharacters = value;
        //    }
        //}
        public List<Character> CampaignCharacters { get; set; }

        /// <summary>
        /// Unique identifier for campaign
        /// </summary>
        int id;
        /// <summary>
        /// Unique identifier for campaign
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
        public Campaign() {

        }

        /// <summary>
        /// Constructor without ID, used when inserting into database. Generates a unique ID.
        /// </summary>
        /// <param name="campaignName">Name of campaign</param>
        /// <param name="campaignDescription">Description of campaign</param>
        /// <param name="campaignUsers">Users in the campaign</param>
        /// <param name="campaignCharacters">The user characters which are in the campaign</param>
        /// <param name="dungeonMaster">The dungeon master of the campaign</param>
        public Campaign(string campaignName, string campaignDescription, List<User> campaignUsers,
            List<Character> campaignCharacters, User dungeonMaster
            ) {
            CampaignName = campaignName;
            CampaignDescription = campaignDescription;
            CampaignUsers = campaignUsers;
            CampaignCharacters = campaignCharacters;
            DungeonMaster = dungeonMaster;
        }

        /// <summary>
        /// Constructor with ID, used when retrieving from database
        /// </summary>
        /// <param name="id">ID of campaign</param>
        /// <param name="campaignName">Name of campaign</param>
        /// <param name="campaignDescription">Description of campaign</param>
        /// <param name="campaignUsers">Users in the campaign</param>
        /// <param name="campaignCharacters">The user characters which are in the campaign</param>
        /// <param name="dungeonMaster">The dungeon master of the campaign</param>
        public Campaign(int id, string campaignName, string campaignDescription, List<User> campaignUsers, 
            List<Character> campaignCharacters, User dungeonMaster
            ) {
            ID = id;
            CampaignName = campaignName;
            CampaignDescription = campaignDescription;
            CampaignUsers = campaignUsers;
            CampaignCharacters = campaignCharacters;
            DungeonMaster = dungeonMaster;
        }

        /// <summary>
        /// Adds a new member to the campaign
        /// </summary>
        /// <param name="user">The user to add</param>
        /// <param name="character">The user's character to add</param>
        public void AddNewMember(User user, Character character) {
            //if (!user.DoesUserOwnCharacter(character)) {
            //    throw new ArgumentException("User must own character");
            //}
            CampaignUsers.Add(user);
            CampaignCharacters.Add(character);
        }

        /// <summary>
        /// Checks if the given user is part of this campaign, either as a user or dungeon master
        /// </summary>
        /// <param name="user">User to look for</param>
        /// <returns>Whether or not the user is in the campaign</returns>
        public bool IsUserInCampaign(User user) {
            if (CampaignUsers is null) {
                return false;
            }
            if (!(DungeonMaster is null) && DungeonMaster.Equals(user)) {
                return true;
            }
            foreach (User campaignUser in CampaignUsers) {
                if (campaignUser.Equals(user)) {
                    return true;
                }
            }
            return false;
        }

        /// <summary>
        /// Determines equality by checking if two campaign objects share the same name, 
        /// description, dungeon master, users, and characters
        /// </summary>
        /// <param name="obj"></param>
        /// <returns>Whether or not the given object is equal to this campaign</returns>
        public override bool Equals(object obj) {
            if (!(obj is Campaign)) {
                return false;
            }

            Campaign campObj = (Campaign)obj;

            //Check if name, description, users, and characters match
            if (!campObj.CampaignName.Equals(this.CampaignName)
                || !campObj.CampaignDescription.Equals(this.CampaignDescription)
                || !campObj.DungeonMaster.Equals(this.DungeonMaster)
                || !campObj.CampaignUsers.Equals(this.CampaignUsers)
                || !campObj.CampaignCharacters.Equals(this.CampaignCharacters)) {
                return false;
            }

            return true;

        }

        /// <summary>
        /// Describes the Campaign
        /// </summary>
        /// <returns>Name of the campaign</returns>
        public override string ToString() {
            return CampaignName;
        }

        /// <summary>
        /// Generates a hash code
        /// </summary>
        /// <returns>Hash code</returns>
        public override int GetHashCode() {
            return base.GetHashCode();
        }
    }
}
