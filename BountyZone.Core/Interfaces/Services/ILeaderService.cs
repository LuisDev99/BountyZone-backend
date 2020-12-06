using BountyZone.Core.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace BountyZone.Core.Interfaces
{
    public interface ILeaderService : IBaseService<Leader>
    {
        ServiceResult<IEnumerable<Leader>> GetPopularVictims();

        ServiceResult<IEnumerable<Bounty>> GetLeaderBounties(int leaderID);

        ServiceResult<Bounty> PlaceBountyOnVictim(Bounty bounty);
    }
}
