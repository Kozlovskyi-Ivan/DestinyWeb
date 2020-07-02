using Destiny_back.Modules.EntityTypes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Destiny_back.Modules
{
    interface IMilestoneGet :IDisposable
    {
        public Milestone GetMilestone(uint id);
        public List<Milestone> GetMilestoneAll();
        public List<Activity> GetActivity(uint id); 
        public List<Activity> GetNightfall(uint id);


    }
}
