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
        public int Id { get; set; }
        public Int64 Hash { get; set; }
        public string name { get; set; }
        public string description { get; set; }
        public Int64 QuestItemHash { get; set; }
        public List<Activity> Activities { get; set; }
        public Int64 VendorHash { get; set; }
        public string ImageUrl { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }

    }

    public class Activity
    {
        public Milestone Milestone{ get; set; }
        [Key]
        public int Id { get; set; }
        public Int64 ActivityHash { get; set; }
        public string name { get; set; }
        public string description { get; set; }
        public string icon { get; set; }
        public List<Modifier> Modifiers { get; set; }
    }

    public class Modifier
    {
        public Activity Activity { get; set; }
        [Key]
        public int Id { get; set; }
        public Int64 ModifierHash { get; set; }
        public string name { get; set; }
        public string description { get; set; }
        public string icon { get; set; }

    }



}
