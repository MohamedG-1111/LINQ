using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LINQ
{
    internal class PersonIEqualtabl : IEqualityComparer<Person>
    {
        public bool Equals(Person? x, Person? y)
        {
            if(x == null || y == null) return false;
            return x.Name == y.Name && x.Age==y.Age;    
             

        }

        public int GetHashCode([DisallowNull] Person obj)
        {
            if (obj == null) return 0;

            int hash = 17;
            hash = hash * 23 + (obj.Name?.GetHashCode() ?? 0);
            hash = hash * 23 + obj.Age.GetHashCode();
            return hash;

        }
    }
}
