﻿namespace BountyZone.Core.Entities
{
    public class PlayerRole : BaseEntity
    {
        public string Type { get; set; }

        public string ImageURL { get; set; }

        public string Description { get; set; }
    }
}