using System;
using System.Collections.Generic;
using System.Text;

namespace BountyZone.Core.Entities
{
    public class Bounty : BaseEntity
    {
        public int Price { get; set; }

        public bool Bribed { get; set; }

        public DateTime Time { get; set; }

        public bool IsConfirmed { get; set; }

        public int LeaderID { get; set; }

        public int VictimID { get; set; }

        public int? HunterID { get; set; }

        public Leader Leader { get; set; }

        public Leader Victim { get; set; }

        public Hunter Hunter { get; set; }

    }
}
