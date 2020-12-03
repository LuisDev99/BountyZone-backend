using BountyZone.Core.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace BountyZone.API.Models
{
    public class HunterDTO : BaseEntity
    {
        public int Guns { get; set; }

        public int Bribes { get; set; }

        public int PlayerID { get; set; }
    }
}
