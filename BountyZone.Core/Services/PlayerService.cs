using BountyZone.Core.Entities;
using BountyZone.Core.Helpers;
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

        public ServiceResult<Player> CreatePlayerWithRole(Player player)
        {
            try
            {
                var newPlayer = _playerRepository.CreatePlayerWithRole(player);
                return ServiceResult<Player>.SuccessResult(newPlayer);
            }catch(Exception)
            {                
                return ServiceResult<Player>.ErrorResult("Error. Player was not created.");
            }
        }

        public ServiceResult<Player> GetPlayer(string userEmail)
        {
            var player = _playerRepository.FindPlayerByEmail(userEmail);

            if (player == null)
                return ServiceResult<Player>.NotFoundResult($"Player {userEmail} was not found");

            return ServiceResult<Player>.SuccessResult(player);
        }

        public ServiceResult<Leader> GetLeaderByPlayerID(int id)
        {
            var leader = _playerRepository.FindLeaderByPlayerID(id);

            if (leader == null)
                return ServiceResult<Leader>.NotFoundResult($"Leader with player ID {id} was not found");

            return ServiceResult<Leader>.SuccessResult(leader);
        }

        public ServiceResult<Hunter> GetHunterByPlayerID(int id)
        {
            var hunter = _playerRepository.FindHunterByPlayerID(id);

            if (hunter == null)
                return ServiceResult<Hunter>.NotFoundResult($"Hunter with player ID {id} was not found");

            return ServiceResult<Hunter>.SuccessResult(hunter);
        }

        public ServiceResult<IEnumerable<PlayerRole>> GetPlayerRoles()
        {
            var roles = _playerRepository.GetPlayerRoles();

            if(Validators.IsListNullOrEmpty(roles))
            {
                return ServiceResult<IEnumerable<PlayerRole>>.ErrorResult("No player roles found");
            }

            return ServiceResult<IEnumerable<PlayerRole>>.SuccessResult(roles);
        }
    }
}
