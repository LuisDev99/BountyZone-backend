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

        public Bounty PlaceBountyOnVictimAndDiscountPrice(Bounty bounty)
        {
            var leader = _dbContext.Leaders.Find(bounty.LeaderID);

            if (leader.Money - bounty.Price < 0)
                return null;

            leader.Money -= bounty.Price;

            var newBounty = _dbContext.Bounties.Add(bounty);

            _dbContext.SaveChanges();

            return newBounty.Entity;
        }

        public Bounty DefendFromBountyAndIncrementLeaderDefends(Bounty bounty)
        {
            var leader = _dbContext.Leaders.Find(bounty.VictimID);

            if (leader.Money - bounty.Price < 0)
                return null;

            leader.Money -= bounty.Price;
            leader.SuccessfulDefends++;

            bounty.Bribed = true;

            _dbContext.Bounties.Attach(bounty);
            _dbContext.Entry(bounty).Property(b => b.Bribed).IsModified = true;

            _dbContext.Entry(bounty).State = EntityState.Modified;
            _dbContext.SaveChanges();

            return bounty;
        }
    }
}
