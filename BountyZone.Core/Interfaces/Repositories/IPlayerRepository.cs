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

        IEnumerable<PlayerRole> GetPlayerRoles();
    }
}
