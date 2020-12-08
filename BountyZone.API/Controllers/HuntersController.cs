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
            var service = _hunterService.GetAll();

            if (service.ResponseCode == ResponseCode.Error)
            {
                return BadRequest(service.Error);
            }

            var hunters = service.Result;

            return Ok(hunters.Select(hunter => new HunterDTO
            {
                ID = hunter.ID,
                Guns = hunter.Guns,
                Bribes = hunter.Bribes,
                PlayerID = hunter.PlayerID,
            }));
        }

        // GET: api/<HuntersController>
        [HttpGet("bounties")]
        public ActionResult<IEnumerable<BountyDTO>> GetBounties()
        {
            var service = _hunterService.GetAvailableBounties();

            if (service.ResponseCode == ResponseCode.Error)
            {
                return BadRequest(service.Error);
            }

            var bounties = service.Result;

            return Ok(bounties.Select(bounty => new BountyDTO
            {
                ID = bounty.ID,
                Time = bounty.Time,
                Price = bounty.Price,
                Bribed = bounty.Bribed,                
                LeaderID = bounty.LeaderID,
                VictimID = bounty.VictimID,               
                IsConfirmed = bounty.IsConfirmed,
            }));
        }

        // GET api/<HuntersController>/5
        [HttpGet("{id}")]
        public ActionResult<HunterDTO> Get(int id)
        {
            var service = _hunterService.GetByID(id);

            if (service.ResponseCode == ResponseCode.Error)
            {
                return BadRequest(service.Error);
            }

            if (service.ResponseCode == ResponseCode.NotFound)
            {
                return NotFound(service.Error);
            }

            var hunter = service.Result;

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
            var service = _hunterService.Create(new Hunter
            {
                Guns = value.Guns,
                Bribes = value.Bribes,
                PlayerID = value.PlayerID
            });

            if (service.ResponseCode == ResponseCode.Error)
            {
                return BadRequest(service.Error);
            }

            if (service.ResponseCode == ResponseCode.NotFound)
            {
                return NotFound(service.Error);
            }

            return Ok();
        }

        // PUT api/<HuntersController>/5
        [HttpPut("{id}")]
        public ActionResult Put(int id, [FromBody] AddHunter value)
        {
            var service = _hunterService.Update(new Hunter
            {
                ID = id,
                Guns = value.Guns,
                Bribes = value.Bribes,
                PlayerID = value.PlayerID
            });

            if (service.ResponseCode == ResponseCode.Error)
            {
                return BadRequest(service.Error);
            }

            if (service.ResponseCode == ResponseCode.NotFound)
            {
                return NotFound(service.Error);
            }

            return Ok();
        }

        // PATCH api/<HuntersController>/5/confirm-bounty
        [HttpPatch("{id}/confirm-bounty")]
        public ActionResult ConfirmBounty(int id, [FromBody] BountyDTO value)
        {
            var service = _hunterService.ConfirmBounty(new Bounty
            {
                ID = value.ID,
                Time = value.Time,
                Price = value.Price,
                VictimID = value.VictimID,
                LeaderID = value.LeaderID,
                HunterID = id,
            });

            if (service.ResponseCode == ResponseCode.Error)
            {
                return BadRequest(service.Error);
            }

            return Ok();
        }

        // DELETE api/<HuntersController>/5
        [HttpDelete("{id}")]
        public ActionResult Delete(int id)
        {
            var service = _hunterService.Delete(new Hunter
            {
                ID = id,
            });

            if (service.ResponseCode == ResponseCode.Error)
            {
                return BadRequest(service.Error);
            }

            if (service.ResponseCode == ResponseCode.NotFound)
            {
                return NotFound(service.Error);
            }

            return Ok();
        }
    }
}
