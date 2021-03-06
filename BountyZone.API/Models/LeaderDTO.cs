﻿using BountyZone.Core.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace BountyZone.API.Models
{
    public class LeaderDTO : BaseEntity
    {
        public int Money { get; set; }

        public int Reputation { get; set; }

        public int SuccessfulAttacks { get; set; }

        public int SuccessfulDefends { get; set; }

        public int PlayerID { get; set; }

        public Player Player;

    }
}
