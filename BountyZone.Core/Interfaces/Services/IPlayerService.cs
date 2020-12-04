using BountyZone.Core.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace BountyZone.Core.Interfaces.Services
{
    public interface IPlayerService
    {
        ServiceResult<Player> CreatePlayerWithRole(Player player);

        ServiceResult<bool> DoesPlayerExists(string userEmail);
    }
}
