using BountyZone.Core.Entities;
using BountyZone.Core.Interfaces;
using BountyZone.Core.Interfaces.Repositories;
using BountyZone.Core.Interfaces.Services;
using System;
using System.Collections.Generic;
using System.Text;

namespace BountyZone.Core.Services
{
    public class PlayerService :  IPlayerService
    {
        private readonly IPlayerRepository _playerRepository;

        public PlayerService(IPlayerRepository playerRepository)
        {
            _playerRepository = playerRepository;
        }

        public ServiceResult<bool> DoesPlayerExists(string userEmail)
        {
            var player = _playerRepository.FindPlayerByEmail(userEmail);

            return ServiceResult<bool>.SuccessResult(player != null);
        }
    }
}
