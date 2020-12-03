using BountyZone.API.Models;
using BountyZone.Core.Enums;
using BountyZone.Core.Interfaces;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BountyZone.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class HuntersController : ControllerBase
    {
        private readonly IHunterService _hunterService;

        public HuntersController(IHunterService hunterService)
        {
            _hunterService = hunterService;
        }

        // GET: api/<HuntersController>
        [HttpGet]
        public ActionResult<IEnumerable<HunterDTO>> Get()
        {
            var serviceResponse = _hunterService.GetAll();

            if (serviceResponse.ResponseCode == ResponseCode.Error)
            {
                return BadRequest(serviceResponse.Error);
            }

            if (serviceResponse.ResponseCode == ResponseCode.NotFound)
            {
                return NotFound(serviceResponse.Error);
            }

            var hunters = serviceResponse.Result;

            return Ok(hunters.Select(hunter => new HunterDTO
            {
                ID = hunter.ID,
                Guns = hunter.Guns,
                Bribes = hunter.Bribes,
                PlayerID = hunter.PlayerID,
            }));
        }

        // GET api/<HuntersController>/5
        [HttpGet("{id}")]
        public string Get(int id)
        {
            return "value";
        }

        // POST api/<HuntersController>
        [HttpPost]
        public void Post([FromBody] string value)
        {
        }

        // PUT api/<HuntersController>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/<HuntersController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
