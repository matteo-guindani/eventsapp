using System;
using EventsApp.Models;
using EventsApp.Repositories;
using Microsoft.AspNetCore.Mvc;

namespace EventsApp.Controllers
{
    [Route("api/event")]
    public class EventController : Controller
    {
        private readonly EventRepository _repository;

        public EventController(EventRepository repository)
        {
            _repository = repository;
        }

        [HttpGet("populate")]
        public int Populate()
        {
            _repository.Truncate();
            for (var i = 0; i < 10000; i++)
            {
                _repository.Add(new TestEvent
                {
                    Metadata = new EventMetadata(RandomizeType()),
                    Payload = new TestEventData("Codice", i)
                });
            }

            return 1;
        }

        [HttpGet("analyze")]
        public JsonResult Analyze([FromQuery] string excludedType)
        {
            return Json(_repository.CountByType(excludedType));
        }

        [HttpPost]
        public Event Create([FromBody]TestEvent entity)
        {
            _repository.Add(entity);

            return entity;
        }

        private string RandomizeType()
        {
            var rand = new Random();
            var types = new[] {"type-a", "type-b", "type-c", "type-d"};

            return types[rand.Next(0, types.Length)];
        }
    }
}
