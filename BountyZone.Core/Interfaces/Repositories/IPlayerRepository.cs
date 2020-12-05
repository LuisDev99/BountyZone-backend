using BountyZone.Core.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace BountyZone.Core.Interfaces.Repositories
{
    public interface IPlayerRepository
    {
        Player CreatePlayerWithRole(Player player);

        Player FindPlayerByEmail(string email);

        Leader FindLeaderByPlayerID(int id);

        Hunter FindHunterByPlayerID(int id);

        IEnumerable<PlayerRole> GetPlayerRoles();
    }
}
