using System;
using System.Collections.Generic;
using System.Text;

namespace TestReq.EntityType
{
    class DestinyPublicMilestone
    {
        public uint milestoneHash { get; set; }
        //public string[] activities { get; set; }
        public List<AvailableQuests> availableQuests { get; set; }
        public List<DestinyPublicMilestoneChallengeActivity> activities { get; set; }
        public List<DestinyPublicMilestoneVendor> vendors { get; set; }
        public DateTime startDate { get; set; }
        public DateTime endDate { get; set; }
    }

    class AvailableQuests
    {
        public uint questItemHash { get; set; }
        public List<Activity> activity { get; set; }
    }

    class Activity
    {
        public uint activityHash { get; set; }
        public List<uint> challengeObjectiveHashes { get; set; }

    }
    class DestinyPublicMilestoneChallengeActivity
    {
        public uint activityHash { get; set; }
        public List<uint> challengeObjectiveHashes { get; set; }
        public List<uint> modifierHashes { get; set; }
        public List<uint> phaseHashes { get; set; }
    }

    class DestinyPublicMilestoneVendor
    {
        public uint vendorHash { get; set; }
    }

    class DestinyMilestoneDefinition
    {
        public string friendlyName { get; set; }

    }

    class DestinyMilestoneQuestDefinition
    {
        public uint questItemHash { get; set; }
        public uint destinationHash { get; set; }
    }

    class DestinyDisplayPropertiesDefinition
    {
        public string description { get; set; }
        public string name { get; set; }
    }

    enum MyEnum :UInt32
    {
        Flashpoint = 463010297,
        Weekly_Clan_Engrams = 4253138191,
        Crucible_Rotator_Playlist_Challenge= 4191379729,
        The_Revelry_Begins= 3915793660, //EVA
        Spare_Parts= 3899487295, //Gunsmith
        Shady_Schemes= 3802603984,//DRIFTER
        Leviathan_Raid= 3660836525,
        Clan_Rewards= 3603098564,//5k xp
        Weekly_Gambit_Challenge= 3448738070,
        Iron_Banner= 3427325023,
        Last_Wish_Raid= 3181387331,
        Leviathan_Eater_of_Worlds_Raid_Lair= 2986584050,
        The_Lost_Cryptarch= 2958665367,
        Spring_Comes_to_Eververse= 291994631,
        Garden_of_Salvation= 2712317338,
        Vanguard_Service= 2709491520,
        Spire_of_Stars_Raid_Lair= 2683538554,
        Live_Fire_Exercises= 2594202463,//Shaxx baunty
        Crown_of_Sorrow= 2590427074,
        Crucible_Core_Playlist_Challenge= 2434762343,
        Nightfall_The_Ordeal_Weekly_Score= 2029743966,
        Nightfall_The_Ordeal_Weekly_Completions= 1942283261,
        Scourge_of_the_Past= 1342567285

    }
}
