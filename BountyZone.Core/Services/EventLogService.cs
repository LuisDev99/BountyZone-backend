using BountyZone.Core.Entities;
using BountyZone.Core.Interfaces;
using BountyZone.Core.Interfaces.Services;
using System;
using System.Collections.Generic;
using System.Text;

namespace BountyZone.Core.Services
{
    public class EventLogService : BaseService<EventLog>, IEventLogService
    {
        public EventLogService(IRepository<EventLog> repository) : base(repository)
        {
        }
    }
}
