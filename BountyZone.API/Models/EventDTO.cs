using BountyZone.Core.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace BountyZone.API.Models
{
    public class EventDTO : BaseEntity
    {
        public int LeaderID { get; set; }

        public int VictimID { get; set; }

        public int HunterID { get; set; }
    }
}
