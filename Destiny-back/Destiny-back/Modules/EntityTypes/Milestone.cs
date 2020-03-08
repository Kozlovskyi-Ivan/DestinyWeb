using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Destiny_back.Modules.EntityTypes
{
    public class Milestone
    {
        [Key]
        public uint Hash { get; set; }
        public string name { get; set; }
        public string description { get; set; }
        public uint QuestItemHash { get; set; }
        public List<Activity> Activities { get; set; }
        public uint VendorHash { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
    }

    public class Activity
    {
        public Milestone Milestone{ get; set; }
        [Key]
        public uint ActivityHash { get; set; }
        public string name { get; set; }
        public string description { get; set; }
        public List<Modifier> Modifiers { get; set; }
    }

    public class Modifier
    {
        public Activity Activity { get; set; }
        [Key]
        public uint ModifierHash { get; set; }
        public string name { get; set; }
        public string description { get; set; }

    }



}
