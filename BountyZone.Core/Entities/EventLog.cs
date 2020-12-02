using System;
using System.Collections.Generic;
using System.Text;

namespace BountyZone.Core.Entities
{
    public class EventLog : BaseEntity
    {
        public int LeaderID { get; set; }

        public int VictimID { get; set; }

        public int HunterID { get; set; }

        public Leader Leader { get; set; }

        public Leader Victim { get; set; }

        public Hunter Hunter { get; set; }
    }
}
