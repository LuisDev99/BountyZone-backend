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
        public ActionResult<bool> DoesPlayerExists([FromBody] string email)
        {
            var service = _playerService.DoesPlayerExists(email);

            return service.Result == true
                ? Ok()
                : NotFound();

        }

        // POST api/<PlayersController>
        [HttpPost]
        public void Post([FromBody] string value)
        {
        }
    }
}
