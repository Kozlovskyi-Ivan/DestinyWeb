using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Destiny_back.Modules.EntityTypes
{
    class DestinyPublicMilestone
    {
        public uint milestoneHash { get; set; }
        public List<AvailableQuests> availableQuests { get; set; }
        public List<DestinyPublicMilestoneChallengeActivity> activities { get; set; }
        public List<DestinyPublicMilestoneVendor> vendors { get; set; }
        public DateTime startDate { get; set; }
        public DateTime endDate { get; set; }
    }

    class AvailableQuests
    {
        public uint questItemHash { get; set; }
        public DestinyDisplayPropertiesDefinition displayProperties { get; set; }
        public List<MilestoneActivity> activity { get; set; }
    }

    class MilestoneActivity
    {
        public uint activityHash { get; set; }
        public List<uint> challengeObjectiveHashes { get; set; }

    }
    class DestinyPublicMilestoneChallengeActivity
    {
        public DestinyDisplayPropertiesDefinition displayProperties { get; set; }
        public uint activityHash { get; set; }
        public List<uint> challengeObjectiveHashes { get; set; }
        public List<uint> modifierHashes { get; set; }
        public List<DestinyActivityModifierDefinition> modifiers = new List<DestinyActivityModifierDefinition>();
        public List<uint> phaseHashes { get; set; }
    }

    class DestinyPublicMilestoneVendor
    {
        public uint vendorHash { get; set; }
    }
    class DestinyActivityModifierDefinition
    {
        public uint modifierHashes { get; set; }
        public DestinyDisplayPropertiesDefinition displayProperties { get; set; }
    }

    class DestinyDisplayPropertiesDefinition
    {
        public string description { get; set; }
        public string name { get; set; }
    }
}
