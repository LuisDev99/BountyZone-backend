﻿using BountyZone.Core.Entities;
using BountyZone.Core.Helpers;
using BountyZone.Core.Interfaces;
using BountyZone.Core.Interfaces.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BountyZone.Core.Services
{
    public class LeaderService : BaseService<Leader>, ILeaderService
    {
        private readonly IRepository<Bounty> _bountyBaseRepository;
        private readonly ILeaderRepository _leaderRepository;

        public LeaderService(
            IRepository<Leader> repository,
            IRepository<Bounty> bountyBaseRepository,
            ILeaderRepository leaderRepository) : base(repository)
        {
            _bountyBaseRepository = bountyBaseRepository;
            _leaderRepository = leaderRepository;
        }

        public ServiceResult<IEnumerable<Leader>> GetPopularVictims()
        {
            var victims = _leaderRepository.GetPopularVictims();

            if (Validators.IsListNullOrEmpty(victims))
            {
                return ServiceResult<IEnumerable<Leader>>.NotFoundResult("There are no victims at this moment....");
            }

            return ServiceResult<IEnumerable<Leader>>.SuccessResult(victims);
        }

        public ServiceResult<Bounty> PlaceBountyOnVictim(Bounty bounty)
        {
            var newBounty = _bountyBaseRepository.Add(bounty);

            if(newBounty == null)
            {
                return ServiceResult<Bounty>.ErrorResult("The bounty could not be place on the victim");
            }

            return ServiceResult<Bounty>.SuccessResult(newBounty);
        }
    }
}
