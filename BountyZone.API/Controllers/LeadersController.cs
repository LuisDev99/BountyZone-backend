using BountyZone.API.Models;
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
        public ActionResult<LeaderDTO> Get()
        {
            var serviceResponse = _leaderService.GetAll();

            if(serviceResponse.ResponseCode == ResponseCode.Error)
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

            return Ok( new LeaderDTO
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
        public void Post([FromBody] string value)
        {
        }

        // PUT api/<LeadersController>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/<LeadersController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
