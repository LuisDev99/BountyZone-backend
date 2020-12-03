using BountyZone.Core.Entities;
using BountyZone.Core.Interfaces;
using BountyZone.Core.Interfaces.Services;
using System;
using System.Collections.Generic;
using System.Text;

namespace BountyZone.Core.Services
{
    public class EventService : BaseService<Event>, IEventService
    {
        public EventService(IRepository<Event> repository) : base(repository)
        {
        }
    }
}
