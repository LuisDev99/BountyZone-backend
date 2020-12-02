using System;
using System.Collections.Generic;
using System.Text;

namespace BountyZone.Core.Entities
{
    public class Player : BaseEntity
    {
        public string UserName { get; set; }

        public string NickName { get; set; }

        public string Password { get; set; }
    }
}
