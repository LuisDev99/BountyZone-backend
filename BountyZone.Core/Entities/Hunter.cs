using System;
using System.Collections.Generic;
using System.Text;

namespace BountyZone.Core.Entities
{
    public class Hunter : BaseEntity
    {
        public int Guns { get; set; }

        public int Bribes { get; set; }

        public int PlayerID { get; set; }

        public Player Player { get; set; }
    }
}
