using BountyZone.Core.Entities;
using BountyZone.Core.Interfaces.Repositories;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BountyZone.Infrastructure.Repositories
{
    public class LeaderRepository : EntityFrameworkRepository<Leader>, ILeaderRepository
    {
        public LeaderRepository(BountyZoneDbContext dbContext) : base(dbContext)
        {
        }

        public IEnumerable<Leader> GetPopularVictims()
        {
            return _dbContext.Leaders
                .Include(leader => leader.Player)
                .OrderByDescending(leader => leader.Reputation)
                .Take(50)
                .ToList();
        }
     
    }
}
