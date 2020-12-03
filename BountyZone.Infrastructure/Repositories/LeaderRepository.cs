using BountyZone.Core.Entities;
using BountyZone.Core.Interfaces.Repositories;
using System;
using System.Collections.Generic;
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
            throw new NotImplementedException();
        }

        public Bounty PlaceBountyOn(int victimID, int leaderID)
        {
            throw new NotImplementedException();
        }
    }
}
