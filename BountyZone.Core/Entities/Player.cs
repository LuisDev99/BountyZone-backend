using System;
using System.Collections.Generic;
using System.Text;

namespace BountyZone.Core.Entities
{
    public class Player : BaseEntity
    {
        public string Email { get; set; }

        public string NickName { get; set; }

        public int PlayerRoleID { get; set; }

        public PlayerRole PlayerRole { get; set; }
    }
}
