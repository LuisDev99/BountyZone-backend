using BountyZone.Core.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace BountyZone.Core.Interfaces.Services
{
    public interface IPlayerService
    {
        ServiceResult<Player> CreatePlayerWithRole(Player player);

        ServiceResult<Player> GetPlayer(string userEmail);

        ServiceResult<Leader> GetLeaderByPlayerID(int id);

        ServiceResult<Hunter> GetHunterByPlayerID(int id);

        ServiceResult<IEnumerable<PlayerRole>> GetPlayerRoles();
    }
}
