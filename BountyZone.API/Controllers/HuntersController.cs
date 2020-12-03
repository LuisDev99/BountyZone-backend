using BountyZone.API.Models;
using BountyZone.API.Models.InsertModels;
using BountyZone.Core.Entities;
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
        public ActionResult<HunterDTO> Get(int id)
        {
            var serviceResponse = _hunterService.GetByID(id);

            if (serviceResponse.ResponseCode == ResponseCode.Error)
            {
                return BadRequest(serviceResponse.Error);
            }

            if (serviceResponse.ResponseCode == ResponseCode.NotFound)
            {
                return NotFound(serviceResponse.Error);
            }

            var hunter = serviceResponse.Result;

            return Ok(new HunterDTO
            {
                ID = hunter.ID,
                Guns = hunter.Guns,
                Bribes = hunter.Bribes,
                PlayerID = hunter.PlayerID,
            });
        }

        // POST api/<HuntersController>
        [HttpPost]
        public ActionResult Post([FromBody] AddHunter value)
        {
            var serviceResponse = _hunterService.Create(new Hunter
            {
                Guns = value.Guns,
                Bribes = value.Bribes,
                PlayerID = value.PlayerID
            });

            if (serviceResponse.ResponseCode == ResponseCode.Error)
            {
                return BadRequest(serviceResponse.Error);
            }

            if (serviceResponse.ResponseCode == ResponseCode.NotFound)
            {
                return NotFound(serviceResponse.Error);
            }

            return Ok();
        }

        // PUT api/<HuntersController>/5
        [HttpPut("{id}")]
        public ActionResult Put(int id, [FromBody] AddHunter value)
        {
            var serviceResponse = _hunterService.Update(new Hunter
            {
                ID = id,
                Guns = value.Guns,
                Bribes = value.Bribes,
                PlayerID = value.PlayerID
            });

            if (serviceResponse.ResponseCode == ResponseCode.Error)
            {
                return BadRequest(serviceResponse.Error);
            }

            if (serviceResponse.ResponseCode == ResponseCode.NotFound)
            {
                return NotFound(serviceResponse.Error);
            }

            return Ok();
        }

        // DELETE api/<HuntersController>/5
        [HttpDelete("{id}")]
        public ActionResult Delete(int id)
        {
            var serviceResponse = _hunterService.Delete(new Hunter
            {
                ID = id,
            });

            if (serviceResponse.ResponseCode == ResponseCode.Error)
            {
                return BadRequest(serviceResponse.Error);
            }

            if (serviceResponse.ResponseCode == ResponseCode.NotFound)
            {
                return NotFound(serviceResponse.Error);
            }

            return Ok();
        }
    }
}
