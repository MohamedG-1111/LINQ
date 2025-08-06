using System.Reflection;
using LINQ;
namespace LINQ
{
    internal class Program
    {
        static void Main(string[] args)
        {
            var cars= Repository.GetCars();
            //Repository.PrintCars(cars);

            #region Where
            #region QuerySyntax
            //var result =
            //   from c in cars
            //   where c.Color == "Green"
            //   select new { c.Id, c.Model };
            //Repository.PrintCars(result);
            //foreach (var item in result)
            //{
            //    Console.WriteLine($"Id: {item.Id}, Model: {item.Model}");
            //}
            #endregion

            #region MethodSyntax
            // Static method from Static Class Enumerable
            //var result01 = Enumerable(cars, (c) => c.Color == "Green");
            //Repository.PrintCars(result01);
            //Console.WriteLine("------------------------------");
            // Exyension method
            //var result02 = cars.Where(c => c.Color == "Red");
            //Repository.PrintCars(result02);
            //Console.WriteLine("------------------------------");
            //var result03 = cars.Where((c, i) => c.Color == "Red" && i < 15);
            //Repository.PrintCars(result03);
            //var result02 = cars.Where(c => c.Color == "Red").OrderByDescending(c=>c.ManufactorYear);
            //Repository.PrintCars(result02);
            #endregion

            //var lst=new List<int>() { 1,2,3,4,5,6,7,8,9};
            //var result = lst.Where(x => x % 2 == 0);
            //Console.WriteLine(result.GetType().Name);//WhereListIterator`1
            //lst.AddRange(new List<int>() { 10, 11, 12, 13, 14 });
            //foreach (var item in result)
            //{
            //    Console.WriteLine(item);
            //}

            #region Members of WhereListIterator`1 Reflection
            //var type = result.GetType();
            //Console.WriteLine(type);
            ////var members = type.GetMembers();
            ////foreach (var item in members)
            ////{
            ////    Console.WriteLine(item);
            ////}
            #endregion
            #endregion

            #region First
            /*
             * First<TSource>(IEnumerable<TSource>)	
Returns the first element of a sequence.

First<TSource>(IEnumerable<TSource>, Func<TSource,Boolean>)	
Returns the first element in a sequence that satisfies a specified condition.
             */
            #region FirstOverload
            //var result = (from car in cars
            //              select car).First();
            //result = cars.First();
            //Repository.PrintCars([result]);
            // Exceptions
            /*
             cars == > May be Null
            InvalidOperationException
             The source sequence is empty.=>> Not Contain Any Element
             */
            //cars = [];
            //result=cars.First();// 'Sequence contains no elements
            #endregion

            #region SecondOverload
            //var result = cars.First(c => c.Make == "Kia");
            //Repository.PrintCars([result]);
            /*
             ==>Exceptions
            cars ==>May Be NUll
            InvalidOperationException
         No element satisfies the condition in predicate.
             */
            //result = cars.First(c => c.Make == "odi");//System.InvalidOperationException: 'Sequence contains no matching element'
            #endregion

            //May use Where with First Same Performace but not Recommended
            //var result = cars.Where(c => c.Make == "Kia").First();
            //Repository.PrintCars([result]);

            #endregion

            #region FirstOrDefault
            /*
Exceptions
ArgumentNullException
source is null.
            */

            #region FirstOverload
            /*
Returns the first element of a sequence, or a specified
default value if the sequence contains no elements.
             */
            //var result = cars.FirstOrDefault();
            //Repository.PrintCars([result]); //Ok
            //cars = [];
            //var result=cars.FirstOrDefault();
            //Repository.PrintCars([result]); // Default
            // List<int> list = new List<int>();
            //var result= list.FirstOrDefault();
            // Console.WriteLine(result);
            #endregion

            #region SecondOverload
            /* FirstOrDefault<TSource>(IEnumerable<TSource>, Func<TSource, Boolean>)
            Returns the first element of the sequence that satisfies a condition or 
            a default value if no such element is found.*/
            //var result = cars.FirstOrDefault(c => c.Make == "TEST");
            //Console.WriteLine(result); // Do not Return Any Thing
            #endregion

            #region threedOverLoad
            /*
             FirstOrDefault<TSource>(IEnumerable<TSource>, TSource)	
             Returns the first element of a sequence, or a specified default value 
             if the sequence contains no elements.
             */
            //cars = [];
            var DefaultValue = new Car()
            {
                Id = 0,
                Make = "Unknown",
                Model = "Unknown",
                ManufactorYear = 0,
                VIN = "N/A",
                Color = "Unspecified",
                MaxSpeed = 0,
            };
            //var result = cars.FirstOrDefault(DefaultValue);
            //Console.WriteLine(result); // Do not Return Any Thing
            #endregion

            #region FourOVerLoad
            /*FirstOrDefault<TSource>(IEnumerable<TSource>, Func<TSource,Boolean>)	
Returns the first element of the sequence that satisfies a condition or a default value if no such element is found.*/
            //cars = [];
            //var result=cars.FirstOrDefault(c=>c.Make=="Test",DefaultValue);
            //Console.WriteLine(result);
            #endregion

            #endregion
        }

        private static IEnumerable<Car> Enumerable(List<Car> cars, Func<Car, bool> predicate)
        {
            return cars.Where(predicate);
        }
    }
}
