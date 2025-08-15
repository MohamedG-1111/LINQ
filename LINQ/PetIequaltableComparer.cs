using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LINQ
{
    internal class PetIequaltableComparer : IEqualityComparer<pet>
    {
        public bool Equals(pet? x, pet? y)
        {
            if (ReferenceEquals(x, y)) return true;
            if (x is null || y is null) return false;
            return x?.Name==y?.Name && x?.Age==y?.Age;  
        }

        public int GetHashCode([DisallowNull] pet obj)
        {
          return HashCode.Combine(obj.Name, obj.Age);
        }
    }
}
