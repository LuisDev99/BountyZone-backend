using BountyZone.Core.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace BountyZone.API.Models.InsertModels
{
    public class AddHunter
    {
        public int Guns { get; set; }

        public int Bribes { get; set; }

        public int PlayerID { get; set; }
    }
}
