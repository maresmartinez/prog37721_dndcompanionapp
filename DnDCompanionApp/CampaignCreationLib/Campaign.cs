using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CharacterCreationLib;
using UserManagementLib;

namespace CampaignCreationLib {
    public class Campaign {

        string campaignName;
        string campaignDescription;
        User dungeonMaster;
        List<Character> campaignCharacters;
        List<User> campaignUsers;

        public string CampaignName { get; set; }
        public string CampaignDescription { get; set; }
        public User DungeonMaster { get; set; }
        public List<Character> CampaignCharacters { get; set; }
        public List<User> CampaignUsers { get; set; }

        public Campaign() {

        }

        public Campaign(string campaignName, User dungeonMaster, List<Character> campaignCharacters,
            List<User> campaignUsers, string campaignDescription) {
            CampaignName = campaignName;
            CampaignDescription = campaignDescription;
            DungeonMaster = dungeonMaster;
            CampaignCharacters = campaignCharacters;
            CampaignUsers = campaignUsers;
        }

    }
}
