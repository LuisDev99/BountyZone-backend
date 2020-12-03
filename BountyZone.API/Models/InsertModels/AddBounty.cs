using BountyZone.Core.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace BountyZone.API.Models.InsertModels
{
    public class AddBounty
    {
        public int Price { get; set; }

        public bool Bribed { get; set; }

        public DateTime Time { get; set; }

        public bool IsConfirmed { get; set; }

        public int LeaderID { get; set; }

        public int VictimID { get; set; }
    }
}
