using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Drawing;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace LINQ
{
    internal class carIEqualityComparer : IEqualityComparer<Car>
    {
        public bool Equals(Car? x, Car? y)
        {
           if(ReferenceEquals(x, y)) return true;
           if(x == null || y == null) return false;
            return x.Id == y.Id
                 && x.Make == y.Make
                 && x.Model == y.Model
                 && x.ManufactorYear == y.ManufactorYear
                 && x.VIN == y.VIN
                 && x.Color == y.Color
                 && x.MaxSpeed == y.MaxSpeed;
        }

        public int GetHashCode([DisallowNull] Car obj)
        {
            return HashCode.Combine(obj.Model,obj.Id,obj.Color,obj.ManufactorYear,obj.Make,
                obj.MaxSpeed,obj.VIN);
        }
    }
}
