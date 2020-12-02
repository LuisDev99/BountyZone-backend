using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BountyZone.Core.Helpers
{
    public static class Validators
    {
        public static bool IsListNullOrEmpty<T>(IEnumerable<T> list)
        {
            return list == null || list.Any();
        }
    }
}
