using BountyZone.Core.Entities;
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
        private readonly ILeaderRepository _leaderRepository;

        public LeaderService(
            IRepository<Leader> repository, 
            ILeaderRepository leaderRepository) : base(repository)
        {
            _leaderRepository = leaderRepository;
        }

        public ServiceResult<IEnumerable<Leader>> GetPopularVictims()
        {
            var victims = _leaderRepository.GetPopularVictims();

            if(victims == null || !victims.Any())
            {
                return ServiceResult<IEnumerable<Leader>>.NotFoundResult("There are no victims at this moment....");
            }

            return ServiceResult<IEnumerable<Leader>>.SuccessResult(victims);
        }

        public ServiceResult<Bounty> PlaceBountyOn(int victimID, int leaderID)
        {
            var bounty = _leaderRepository.PlaceBountyOn(victimID, leaderID);

            if(bounty == null)
            {
                return ServiceResult<Bounty>.ErrorResult("The bounty could not be place on the victim");
            }

            return ServiceResult<Bounty>.SuccessResult(bounty);
        }
    }
}
