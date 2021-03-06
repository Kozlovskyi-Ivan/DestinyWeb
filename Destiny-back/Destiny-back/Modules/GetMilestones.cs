﻿using Destiny_back.Modules.EntityTypes;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Destiny_back.Modules
{
    public class GetMilestones: IMilestoneGet
    {
        //Milestone-class gets entities from DBcontext.
        //Milestone is entity with week Activities
        //Activities contains information about itself and modifiers
        ApplicationContext context;

        public GetMilestones()
        {
            this.context = new ApplicationContext();
        }
        public Milestone GetMilestone(uint id)
        {
            var milestone = context.Milestones.FirstOrDefault(x => x.Hash == id);
            return milestone;
        }
        public List<Milestone> GetMilestoneAll()
        {
            var milestone = context.Milestones.Include(x => x.Activities).ToList();
            return milestone;
        }
        public List<Activity> GetActivity(uint id)
        {
            var milestone = GetMilestone(id);
            var Activity = (from n in context.Activites.Include(x => x.Modifiers)
                           where n.Milestone == milestone
                           orderby n
                           select n).ToList();
                           //select new { n.name, n.description, n.icon, n.Modifiers});
            return Activity;
        }

        public List<Activity> GetNightfall(uint id)
        {
            var milestone = GetMilestone(id);
            var nightfall = (from n in context.Activites.Include(x => x.Modifiers)
                            where n.Milestone == milestone 
                            orderby n.Modifiers.Count
                            select n).ToList();
                            //select new { n.name, n.description, n.icon, n.Modifiers };
            return nightfall;
        }
        private bool disposed = false;
        public virtual void Dispose(bool disposing)
        {
            if (!this.disposed)
            {
                if (disposing)
                {
                    context.Dispose();
                }
            }
            this.disposed = true;
        }
        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }
    }
}
