using BountyZone.Core.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace BountyZone.Core.Interfaces.Repositories
{
    public interface IHunterRepository
    {
        IEnumerable<Bounty> GetAvailableBounties();
    }
}
