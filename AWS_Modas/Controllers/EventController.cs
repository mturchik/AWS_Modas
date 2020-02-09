using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AWS_Modas.Models.Objects;
using AWS_Modas.Models.Repositories;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace AWS_Modas.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EventController : ControllerBase
    {
        private readonly IEventRepository _repository;
        public EventController(IEventRepository repo) => _repository = repo;

        [HttpGet]
        // returns all events (unsorted)
        public IEnumerable<Event> GetAll() => _repository.Events.Include(e => e.Location);

        [HttpGet("{id}")]
        // return specific event
        public Event GetSpecific(int id) => _repository.Events.Include(e => e.Location).FirstOrDefault(e => e.EventId == id);

        [HttpPost]
        // add event
        public Event Post([FromBody] Event evt) => _repository.AddEvent(new Event
        {
            TimeStamp = evt.TimeStamp,
            Flagged = evt.Flagged,
            LocationId = evt.LocationId
        });

        [HttpPut]
        // update event
        public Event Put([FromBody] Event evt) => _repository.UpdateEvent(evt);

        
        [HttpDelete("{id}")]
        // delete event
        public void Delete(int id) => _repository.DeleteEvent(id);
    }
}