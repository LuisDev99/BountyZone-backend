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
            var service = _leaderService.GetAll();

            if (service.ResponseCode == ResponseCode.Error)
            {
                return BadRequest(service.Error);
            }

            var leaders = service.Result;

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

        // GET: api/<LeadersController>
        [HttpGet("popular-victims")]
        public ActionResult<IEnumerable<LeaderDTO>> GetPopularVictims()
        {
            var service = _leaderService.GetPopularVictims();

            if (service.ResponseCode == ResponseCode.Error)
            {
                return BadRequest(service.Error);
            }

            var victims = service.Result;

            return Ok(victims.Select(victim => new LeaderDTO
            {
                ID = victim.ID,
                Money = victim.Money,
                Player = victim.Player,
                PlayerID = victim.PlayerID,
                Reputation = victim.Reputation,
                SuccessfulAttacks = victim.SuccessfulAttacks,
                SuccessfulDefends = victim.SuccessfulDefends
            }));
        }

        // GET api/<LeadersController>/5
        [HttpGet("{id}")]
        public ActionResult<LeaderDTO> Get(int id)
        {
            var service = _leaderService.GetByID(id);

            if (service.ResponseCode == ResponseCode.Error)
            {
                return BadRequest(service.Error);
            }

            if (service.ResponseCode == ResponseCode.NotFound)
            {
                return NotFound(service.Error);
            }

            var leader = service.Result;

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

        [HttpGet("{id}/bounties")]
        public ActionResult<IEnumerable<BountyDTO>> GetLeaderBounties(int id)
        {
            var service = _leaderService.GetLeaderBounties(id);

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
                HunterID = bounty.HunterID,
                VictimID = bounty.VictimID,
                IsConfirmed = bounty.IsConfirmed,
            }));
        }

        [HttpGet("{id}/opposing-bounties")]
        public ActionResult<IEnumerable<BountyDTO>> GetBountiesAgainstLeader(int id)
        {
            var service = _leaderService.GetBountiesAgainstLeader(id);

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
                HunterID = bounty.HunterID,
                VictimID = bounty.VictimID,
                IsConfirmed = bounty.IsConfirmed,
            }));
        }

        // POST api/<LeadersController>
        [HttpPost]
        public ActionResult Post([FromBody] AddLeader value)
        {
            var service = _leaderService.Create(new Leader
            {
                Money = value.Money,
                PlayerID = value.PlayerID,
                Reputation = value.Reputation,
                SuccessfulAttacks = value.SuccessfulAttacks,
                SuccessfulDefends = value.SuccessfulDefends,
            });

            if (service.ResponseCode == ResponseCode.Error)
            {
                return BadRequest(service.Error);
            }

            return Ok();
        }

        // POST api/<LeadersController>
        [HttpPost("place-bounty")]
        public ActionResult PlaceBountyOnVictim([FromBody] AddBounty value)
        {
            var service = _leaderService.PlaceBountyOnVictim(new Bounty
            {
                Time = value.Time,
                Price = value.Price,
                LeaderID = value.LeaderID,
                VictimID = value.VictimID,
            });

            if (service.ResponseCode == ResponseCode.Error)
            {
                return BadRequest(service.Error);
            }

            return Ok();
        }

        // PUT api/<LeadersController>/5
        [HttpPut("{id}")]
        public ActionResult Put(int id, [FromBody] AddLeader value)
        {
            var service = _leaderService.Update(new Leader
            {
                ID = id,
                Money = value.Money,
                PlayerID = value.PlayerID,
                Reputation = value.Reputation,
                SuccessfulAttacks = value.SuccessfulAttacks,
                SuccessfulDefends = value.SuccessfulDefends,
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

        // PATCH api/<LeadersController>/5
        [HttpPatch("defend-bounty")]
        public ActionResult DefendFromBounty([FromBody] BountyDTO value)
        {
            var service = _leaderService.DefendFromBounty(new Bounty
            {
                ID = value.ID,
                Time = value.Time,
                Price = value.Price,                
                VictimID = value.VictimID,
                LeaderID = value.LeaderID,
                HunterID = value.HunterID,
                IsConfirmed = value.IsConfirmed,
            });

            if (service.ResponseCode == ResponseCode.Error)
            {
                return BadRequest(service.Error);
            }

            return Ok();
        }

        // DELETE api/<LeadersController>/5
        [HttpDelete("{id}")]
        public ActionResult Delete(int id)
        {
            var service = _leaderService.Delete(new Leader
            {
                ID = id
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
