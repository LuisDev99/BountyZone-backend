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

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace BountyZone.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LeadersController : ControllerBase
    {
        private readonly ILeaderService _leaderService;

        public LeadersController(ILeaderService leaderService)
        {
            _leaderService = leaderService;
        }

        // GET: api/<LeadersController>
        [HttpGet]
        public ActionResult<IEnumerable<LeaderDTO>> Get()
        {
            var serviceResponse = _leaderService.GetAll();

            if (serviceResponse.ResponseCode == ResponseCode.Error)
            {
                return BadRequest(serviceResponse.Error);
            }

            if (serviceResponse.ResponseCode == ResponseCode.NotFound)
            {
                return NotFound(serviceResponse.Error);
            }

            var leaders = serviceResponse.Result;

            return Ok(leaders.Select(leader => new LeaderDTO
            {
                ID = leader.ID,
                Money = leader.Money,
                PlayerID = leader.PlayerID,
                Reputation = leader.Reputation,
                SuccessfulAttacks = leader.SuccessfulAttacks,
                SuccessfulDefends = leader.SuccessfulDefends
            }));
        }

        // GET api/<LeadersController>/5
        [HttpGet("{id}")]
        public ActionResult<LeaderDTO> Get(int id)
        {
            var serviceResponse = _leaderService.GetByID(id);

            if (serviceResponse.ResponseCode == ResponseCode.Error)
            {
                return BadRequest(serviceResponse.Error);
            }

            if (serviceResponse.ResponseCode == ResponseCode.NotFound)
            {
                return NotFound(serviceResponse.Error);
            }

            var leader = serviceResponse.Result;

            return Ok(new LeaderDTO
            {
                ID = leader.ID,
                Money = leader.Money,
                PlayerID = leader.PlayerID,
                Reputation = leader.Reputation,
                SuccessfulAttacks = leader.SuccessfulAttacks,
                SuccessfulDefends = leader.SuccessfulDefends
            });
        }

        // POST api/<LeadersController>
        [HttpPost]
        public ActionResult Post([FromBody] AddLeader value)
        {
            var serviceResponse = _leaderService.Create(new Leader
            {
                Money = value.Money,
                PlayerID = value.PlayerID,
                Reputation = value.Reputation,
                SuccessfulAttacks = value.SuccessfulAttacks,
                SuccessfulDefends = value.SuccessfulDefends,
            });

            if (serviceResponse.ResponseCode == ResponseCode.Error)
            {
                return BadRequest(serviceResponse.Error);
            }

            return Ok();
        }

        // PUT api/<LeadersController>/5
        [HttpPut("{id}")]
        public ActionResult Put(int id, [FromBody] AddLeader value)
        {
            var serviceResponse = _leaderService.Update(new Leader
            {
                ID = id,
                Money = value.Money,
                PlayerID = value.PlayerID,
                Reputation = value.Reputation,
                SuccessfulAttacks = value.SuccessfulAttacks,
                SuccessfulDefends = value.SuccessfulDefends,
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

        // DELETE api/<LeadersController>/5
        [HttpDelete("{id}")]
        public ActionResult Delete(int id)
        {
            var serviceResponse = _leaderService.Delete(new Leader { 
                ID = id
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
