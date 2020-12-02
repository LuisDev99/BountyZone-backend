using System;
using System.Collections.Generic;
using System.Text;

namespace BountyZone.Core.Entities
{
  public class Bounty : BaseEntity
  {
    public DateTime Time { get; set; }

    public bool IsConfirmed { get; set; }
  }
}
