using BountyZone.Core.Entities;
using BountyZone.Core.Interfaces.Repositories;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BountyZone.Infrastructure.Repositories
{
    public class HunterRepository : EntityFrameworkRepository<Hunter>, IHunterRepository
    {
        public HunterRepository(BountyZoneDbContext dbContext) : base(dbContext)
        {
        }

        public Bounty ConfirmBounty(int bountyID, int hunterID)
        {
            var modifiedBounty = new Bounty
            {
                ID = bountyID,
                IsConfirmed = true,
                HunterID = hunterID
            };

            _dbContext.Attach(modifiedBounty);

            _dbContext.Entry(modifiedBounty).Property(b => b.HunterID).IsModified = true;
            _dbContext.Entry(modifiedBounty).Property(b => b.IsConfirmed).IsModified = true;

            _dbContext.Entry(modifiedBounty).State = EntityState.Modified;
            _dbContext.SaveChanges();

            return modifiedBounty;
        }
    }
}
