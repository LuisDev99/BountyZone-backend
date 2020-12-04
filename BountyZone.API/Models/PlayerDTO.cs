using BountyZone.Core.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace BountyZone.API.Models
{
    public class PlayerDTO : BaseEntity
    {
        public string Email { get; set; }

        public string NickName { get; set; }

        public PlayerRole PlayerRole { get; set; }
    }
}
