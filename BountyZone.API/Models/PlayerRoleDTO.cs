using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BountyZone.API.Models
{
    public class PlayerRoleDTO
    {
        public int ID { get; set; }

        public string Type { get; set; }

        public string ImageURL { get; set; }

        public string Description { get; set; }        
    }
}
