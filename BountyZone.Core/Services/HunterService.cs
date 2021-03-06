﻿using BountyZone.Core.Entities;
using BountyZone.Core.Helpers;
using BountyZone.Core.Interfaces;
using BountyZone.Core.Interfaces.Repositories;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;

namespace BountyZone.Core.Services
{
    public class HunterService : BaseService<Hunter>, IHunterService
    {
        private readonly IHunterRepository _hunterRepository;
        private readonly IRepository<Bounty> _baseBountyRepository;

        public HunterService(
            IRepository<Hunter> repository, 
            IRepository<Bounty> baseBountyRepository,
            IHunterRepository hunterRepository) : base(repository)
        {
            _hunterRepository = hunterRepository;
            _baseBountyRepository = baseBountyRepository;
        }

        public ServiceResult<Bounty> ConfirmBounty(Bounty bounty)
        {
            try
            {
                var modifiedBounty = _hunterRepository.ConfirmBounty(bounty);
                return ServiceResult<Bounty>.SuccessResult(modifiedBounty);
            }catch(Exception)
            {
                return ServiceResult<Bounty>.ErrorResult("Error while trying to confirm the bounty");
            }            
        }

        public ServiceResult<IEnumerable<Bounty>> GetAvailableBounties()
        {
            var bounties = _baseBountyRepository.Filter(bounty => !bounty.IsConfirmed && System.DateTime.UtcNow < bounty.Time);
           
            return ServiceResult<IEnumerable<Bounty>>.SuccessResult(bounties);
        }
    }
}
