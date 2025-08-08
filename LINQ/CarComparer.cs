using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LINQ
{
    internal class CarComparer : IComparer<Car>
    {
        public int Compare(Car? x, Car? y)
        {
            return x.Make.CompareTo(y.Make);

        }
    }
}
