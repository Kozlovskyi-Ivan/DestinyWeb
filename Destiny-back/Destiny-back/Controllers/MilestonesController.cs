using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Destiny_back.Modules.EntityTypes;
using Destiny_back.Modules;
using Microsoft.EntityFrameworkCore;

namespace Destiny_back.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MilestonesController : ControllerBase
    {
        private ApplicationContext context;
        public MilestonesController(ApplicationContext context)
        {
            this.context = context;
        }

        [HttpGet]
        public IEnumerable<Milestone> Get()
        {
             return context.Milestones.Include(x=>x.Activities);
        }

        // GET: api/Milestones/5
        [HttpGet("{id}")]
        public async Task<IActionResult> GetMilestone([FromRoute] uint id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            var milestone = context.Milestones.FirstOrDefault(x=>x.Hash==id);

            //Milestone milestone = new Milestone { name = "asda", Activities = context.Milestones.FirstOrDefault(x => x.name == name).Activities };
            if (milestone==null)
            {
                return NotFound();
            }
            return Ok(milestone);
        }
        // GET: api/Milestones/5
        [HttpGet("Nightfall/{id}")]
        public async Task<IActionResult> GetNightfall([FromRoute] uint id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            var milestone = context.Milestones.FirstOrDefault(x => x.Hash == id);
            var nightfall = from n in context.Activites.Include(x => x.Modifiers)
                            where n.Milestone == milestone
                            orderby n
                            select new { n.name , n.description,n.Modifiers};
                            //select n;
            

            //Milestone milestone = new Milestone { name = "asda", Activities = context.Milestones.FirstOrDefault(x => x.name == name).Activities };
            if (nightfall == null)
            {
                return NotFound();
            }
            return Ok(nightfall);
        }

        // POST: api/Milestones
        [HttpPost]
        public void Post([FromBody] string value)
        {
        }

        // PUT: api/Milestones/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE: api/ApiWithActions/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}