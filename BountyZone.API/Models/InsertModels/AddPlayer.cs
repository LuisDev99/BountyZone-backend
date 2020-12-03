using BountyZone.Core.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace BountyZone.API.Models.InsertModels
{
    public class AddPlayer : BaseEntity
    {
        public string UserName { get; set; }

        public string NickName { get; set; }

        public string Password { get; set; }
    }
}
