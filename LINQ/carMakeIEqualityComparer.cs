using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LINQ
{
    internal class carMakeIEqualityComparer : IEqualityComparer<Car>
    {
        public bool Equals(Car? x, Car? y)
        {
            return x?.Make == y?.Make;
        }

        public int GetHashCode([DisallowNull] Car obj)
        {
            return HashCode.Combine(obj.Make);
        }
    }
}
