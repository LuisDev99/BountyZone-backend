using BountyZone.Core.Entities;
using BountyZone.Core.Helpers;
using BountyZone.Core.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace BountyZone.Core.Services
{
    public class HunterService : BaseService<Hunter>, IHunterService
    {
        private readonly IRepository<Bounty> _baseBountyRepository;

        public HunterService(IRepository<Hunter> repository, IRepository<Bounty> baseBountyRepository) : base(repository)
        {
            _baseBountyRepository = baseBountyRepository;
        }

        public ServiceResult<IEnumerable<Bounty>> GetAvailableBounties()
        {
            var bounties = _baseBountyRepository.Filter(bounty => !bounty.IsConfirmed && System.DateTime.UtcNow < bounty.Time);

            if(Validators.IsListNullOrEmpty(bounties))
            {
                return ServiceResult<IEnumerable<Bounty>>.NotFoundResult("There are no victims at the moment...");
            }

            return ServiceResult<IEnumerable<Bounty>>.SuccessResult(bounties);
        }
    }
}
