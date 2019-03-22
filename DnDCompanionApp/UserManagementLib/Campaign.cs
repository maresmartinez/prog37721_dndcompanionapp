using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CharacterCreationLib;
using UserManagementLib;

namespace UserManagementLib {
    public class Campaign {

        string campaignName;
        string campaignDescription;
        User dungeonMaster;
        List<User> campaignUsers;
        List<Character> campaignCharacters;

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

        public User DungeonMaster {
            get { return dungeonMaster; }
            set {
                if (value is null) {
                    throw new ArgumentException("Campaign must have a dungeon master");
                } else if (this.IsUserInCampaign(value)) {
                    throw new ArgumentException("Dungeon Master cannot also be in campaign");
                } else {
                    dungeonMaster = value;
                }
            }
        }

        public List<User> CampaignUsers {
            get { return campaignUsers; }
            set {
                if (value.Count < 2) {
                    throw new ArgumentException("Must have at least two Campaign Users");
                }

                campaignUsers = value;
            }
        }

        public List<Character> CampaignCharacters {
            get { return campaignCharacters; }
            set {
                // Ensure that all Characters in List belong to one of the CampaignUsers
                foreach (Character character in value) {
                    bool characterNotValid = true;

                    // characterNotValid will only become false if one of the users own it
                    foreach (User user in CampaignUsers) {
                        if (user.DoesUserOwnCharacter(character)) {
                            characterNotValid = false;
                            break;
                        }
                    }

                    // If flag is 
                    if (characterNotValid) {
                        throw new ArgumentException("Campaign character must be owned by one of the campaign users");
                    }
                }

                // Characters must equal users; users can only play one character
                if (value.Count != CampaignUsers.Count) {
                    throw new ArgumentException("Every user must play exactly one character");
                }

                campaignCharacters = value;
            }
        }

        public Campaign() {

        }

        public Campaign(string campaignName, string campaignDescription, List<User> campaignUsers, 
            List<Character> campaignCharacters, User dungeonMaster
            ) {
            CampaignName = campaignName;
            CampaignDescription = campaignDescription;
            CampaignUsers = campaignUsers;
            CampaignCharacters = campaignCharacters;
            DungeonMaster = dungeonMaster;
        }

        public void AddNewMember(User user, Character character) {
            if (!user.DoesUserOwnCharacter(character)) {
                throw new ArgumentException("User must own character");
            }
            CampaignUsers.Add(user);
            CampaignCharacters.Add(character);
        }

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

        public void AddCampaignToAllUsers() {
            DungeonMaster.AddCampaign(this);
            foreach (User user in CampaignUsers) {
                user.AddCampaign(this);
            }
        }

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

    }
}
