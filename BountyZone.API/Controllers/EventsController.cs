using BountyZone.API.Models;
using BountyZone.Core.Enums;
using BountyZone.Core.Interfaces.Services;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;


namespace BountyZone.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EventsController : ControllerBase
    {
        private readonly IEventService _eventService;

        public EventsController(IEventService eventService)
        {
            _eventService = eventService;
        }

        // GET: api/<EventLogsController>
        [HttpGet]
        public ActionResult<IEnumerable<EventDTO>> Get()
        {
            var service = _eventService.GetAll();

            if (service.ResponseCode == ResponseCode.Error)
            {
                return BadRequest(service.Error);
            }

            var events = service.Result;

            return Ok(events.Select(eventt => new EventDTO
            {
                ID = eventt.ID,
                HunterID = eventt.HunterID,
                LeaderID = eventt.LeaderID,
                VictimID = eventt.VictimID
            }));
        }       
    }
}
