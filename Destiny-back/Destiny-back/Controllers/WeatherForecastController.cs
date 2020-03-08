using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Destiny_back.Modules;
using Destiny_back.Modules.EntityTypes;

namespace Destiny_back.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class WeatherForecastController : ControllerBase
    {
        private static readonly string[] Summaries = new[]
        {
            "Freezing", "Bracing", "Chilly", "Cool", "Mild", "Warm", "Balmy", "Hot", "Sweltering", "Scorching"
        };

        private readonly ILogger<WeatherForecastController> _logger;

        public WeatherForecastController(ILogger<WeatherForecastController> logger)
        {
            _logger = logger;
        }

        [HttpGet]
        public IEnumerable<WeatherForecast> Get()
        {
            start();
            ParseData parseData = new ParseData();
            parseData.Start();
            var rng = new Random();
            return Enumerable.Range(1, 5).Select(index => new WeatherForecast
            {
                Date = DateTime.Now.AddDays(index),
                TemperatureC = rng.Next(-20, 55),
                Summary = Summaries[rng.Next(Summaries.Length)]
            })
            .ToArray();
        }

        public void start()
        {
            //ApplicationContext context=new ApplicationContext();
            //Modifier modifier = new Modifier() { ModifierHash = 4251631 };
            //Modifier modifier1 = new Modifier() { ModifierHash = 99875259 };
            //List<Modifier> modifiers = new List<Modifier>();
            //modifiers.Add(modifier);
            //modifiers.Add(modifier1);
            //Activity activity = new Activity() { ActivityHash = 12345678, Modifiers = modifiers };
            //List<Activity> activities = new List<Activity>() { activity };
            //Milestone milestone = new Milestone() { Activities = activities, Hash = 12635234 };
            //context.Milestones.Add(milestone);
            //context.SaveChanges();
        }
    }
}
