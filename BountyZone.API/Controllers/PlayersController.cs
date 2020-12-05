using BountyZone.API.Models;
using BountyZone.API.Models.InsertModels;
using BountyZone.Core.Entities;
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
    public class PlayersController : ControllerBase
    {
        private readonly IPlayerService _playerService;

        public PlayersController(IPlayerService playerService)
        {
            _playerService = playerService;
        }


        // GET api/<PlayersController>/5
        [HttpGet]
        public ActionResult<PlayerDTO> GetPlayerFromEmail([FromQuery] string email)
        {
            var service = _playerService.GetPlayer(email);

            if (service.ResponseCode == ResponseCode.NotFound)
                return NotFound(service.Error);

            var player = service.Result;

            return Ok(new PlayerDTO {
                ID = player.ID,
                Email = player.Email,
                NickName = player.NickName,
                PlayerRole = player.PlayerRole,                
            });

        }

        // GET api/<PlayersController>/roles
        [HttpGet("roles")]
        public ActionResult<IEnumerable<PlayerRoleDTO>> GetPlayerRoles()
        {
            var service = _playerService.GetPlayerRoles();

            if (service.ResponseCode == ResponseCode.NotFound)
                return NotFound(service.Error);

            var roles = service.Result;

            return Ok(roles.Select(role => new PlayerRoleDTO
            {
                ID = role.ID,
                Type = role.Type,
                ImageURL = role.ImageURL,
                Description = role.Description,
            }));
        }

        // GET api/<PlayersController>/5/leader
        [HttpGet("{id}/leader")]
        public ActionResult<LeaderDTO> GetLeaderByPlayerID(int id)
        {
            var service = _playerService.GetLeaderByPlayerID(id);

            if (service.ResponseCode == ResponseCode.NotFound)
                return NotFound(service.Error);

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

        // GET api/<PlayersController>/5/hunter
        [HttpGet("{id}/hunter")]
        public ActionResult<HunterDTO> GetHunterByPlayerID(int id)
        {
            var service = _playerService.GetHunterByPlayerID(id);

            if (service.ResponseCode == ResponseCode.NotFound)
                return NotFound(service.Error);

            var hunter = service.Result;

            return Ok(new HunterDTO
            {
                ID = hunter.ID,
                Guns = hunter.Guns,
                Bribes = hunter.Bribes,
                PlayerID = hunter.PlayerID
            });
        }

        // POST api/<PlayersController>
        [HttpPost]
        public ActionResult<PlayerDTO> CreatePlayerWithRole([FromBody] AddPlayer value)
        {
            var service = _playerService.CreatePlayerWithRole(new Player {
                Email = value.Email,
                NickName = value.NickName,
                PlayerRoleID = value.PlayerRoleID
            });

            if(service.ResponseCode == ResponseCode.Error)
            {
                return BadRequest(service.Error);
            }

            var newPlayer = service.Result;

            return Ok(new PlayerDTO
            {
                ID = newPlayer.ID,
                Email = newPlayer.Email,
                NickName = newPlayer.NickName,
                PlayerRole = newPlayer.PlayerRole
            });
        }
    }
}
