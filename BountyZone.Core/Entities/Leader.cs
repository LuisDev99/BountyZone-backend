using System;
using System.Collections.Generic;
using System.Text;

namespace BountyZone.Core.Entities
{
    public class Leader : BaseEntity
    {
        public int Money { get; set; }

        public int Reputation { get; set; }

        public int SuccessfulAttacks { get; set; }

        public int SuccessfulDefends { get; set; }

        public int PlayerID { get; set; }

        public Player Player { get; set; }
    }
}
