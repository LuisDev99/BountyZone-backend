using BountyZone.Core.Entities;
using BountyZone.Core.Interfaces.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BountyZone.Infrastructure.Repositories
{
    public class PlayerRepository : EntityFrameworkRepository<Player>, IPlayerRepository
    {
        public PlayerRepository(BountyZoneDbContext dbContext) : base(dbContext)
        {
        }

        public Player FindPlayerByEmail(string email)
        {
            return _dbContext.Players.FirstOrDefault(player => player.Email == email);
        }
    }
}
