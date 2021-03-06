﻿using BountyZone.Core.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace BountyZone.Core.Interfaces
{
    public interface IHunterService : IBaseService<Hunter>
    {
        ServiceResult<Bounty> ConfirmBounty(Bounty bounty);

        ServiceResult<IEnumerable<Bounty>> GetAvailableBounties();        
    }
}
