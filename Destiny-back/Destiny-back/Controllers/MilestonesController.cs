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
        GetFromDbControllerMilestone GetFromDb;
        public MilestonesController()
        {
            GetFromDb = new GetFromDbControllerMilestone(new ApplicationContext());
        }

        [HttpGet]
        public async Task<IActionResult> Get()
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            var milestone = GetFromDb.GetMilestoneAll();

            if (milestone == null)
            {
                return NotFound();
            }
            return Ok(milestone);
        }

        // GET: api/Milestones/5
        [HttpGet("{id}")]
        public async Task<IActionResult> GetMilestone([FromRoute] uint id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            var milestone = GetFromDb.GetMilestone(id);

            if (milestone==null)
            {
                return NotFound();
            }
            return Ok(milestone);
        }
        // GET: api/Milestones/Activity/id
        [HttpGet("Milestones/{id}")]
        public async Task<IActionResult> GetActivity([FromRoute] uint id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            var activity = GetFromDb.GetActivity(id);

            if (activity == null)
            {
                return NotFound();
            }
            return Ok(activity);
        }

        // GET: api/Milestones/Activity/id
        [HttpGet("Nightfall/{id}")]
        public async Task<IActionResult> GetNightfall([FromRoute] uint id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            var nightfall = GetFromDb.GetNightfall(id);
            if (nightfall == null)
            {
                return NotFound();
            }
            return Ok(nightfall);
        }


        // GET: api/Milestones/5 test
        [HttpGet("test/{id}")]
        public async Task<IActionResult> GetTest([FromRoute] uint id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            Milestone milestone = new Milestone { name = "asda", description="id"};
            if (milestone == null)
            {
                return NotFound();
            }
            return Ok(milestone);
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