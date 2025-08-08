using System.Reflection;
using System.Text.RegularExpressions;
using LINQ;
using static System.Formats.Asn1.AsnWriter;
namespace LINQ
{
    internal class Program
    {
        static void Main(string[] args)
        {
            var cars = Repository.GetCars();
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
            var DefaultCar = new Car()
            {
                Id = 0,
                Make = "Unknown",
                Model = "Unknown",
                ManufactorYear = 0,
                VIN = "N/A",
                Color = "Unspecified",
                MaxSpeed = 0,
            };
            //var result = cars.FirstOrDefault(DefaultCar);
            //Console.WriteLine(result); // Do not Return Any Thing
            #endregion

            #region FourOVerLoad
            /*FirstOrDefault<TSource>(IEnumerable<TSource>, Func<TSource,Boolean>)	
Returns the first element of the sequence that satisfies a condition or a default value if no such element is found.*/
            //cars = [];
            //var result=cars.FirstOrDefault(c=>c.Make=="Test",DefaultCar);
            //Console.WriteLine(result);
            #endregion

            #endregion

            #region Last
            /*
Last<TSource>(IEnumerable<TSource>)	
Returns the last element of a sequence.
Last<TSource>(IEnumerable<TSource>, Func<TSource,Boolean>)	
Returns the last element of a sequence that satisfies a specified condition.
             */
            #region FirstOverLoad
            //var result = cars.Last();
            ////Console.WriteLine(result); 
            //cars = [];
            // result = cars.Last();
            //Console.WriteLine(result);//System.InvalidOperationException: 'Sequence contains no elements'
            //cars = null;
            //var result = cars.Last(); //System.ArgumentNullException: 'Value cannot be null. (Parameter 'source')'
            //Console.WriteLine(result);
            #endregion

            #region SecondOverLoad
            //var result = cars.Last(c => c.Color == "Red");
            //Console.WriteLine(result);
            //var result = cars.Last(c => c.Color == "Test");
            //Console.WriteLine(result);//System.InvalidOperationException: 'Sequence contains no matching element'

            #endregion
            /*
             Using Where with Last can cause a performance issue because Where starts filtering
            from the beginning of the list, while Last searches from the end. This means the whole 
            list may be scanned twice, which is slower than using Last with a condition directly.             
             */
            #endregion

            #region LastOrDefault
            /*
[1] => LastOrDefault<TSource>(IEnumerable<TSource>)	
Returns the last element of a sequence, or a default value if the sequence contains no elements.
[2] => LastOrDefault<TSource>(IEnumerable<TSource>, Func<TSource,Boolean>)	
Returns the last element of a sequence that satisfies a condition or a default value if no such element is found.
[3] => LastOrDefault<TSource>(IEnumerable<TSource>, TSource)	
Returns the last element of a sequence, or a specified default value if the sequence contains no elements.
[4] => LastOrDefault<TSource>(IEnumerable<TSource>, Func<TSource,Boolean>, TSource)	
Returns the last element of a sequence that satisfies a condition, or a specified default value if no such element is found.
             */
            #region FirstOverLoad
            // var result=cars.LastOrDefault();
            // cars = [];
            //result=cars.LastOrDefault();
            // Console.WriteLine(result); // Return null Default

            #endregion

            #region SecondOverLoad
            //var result = cars.LastOrDefault(c => c.Make == "Ford");
            //Console.WriteLine(result);
            //var result=cars.LastOrDefault(c=>c.Make == "Unknown");
            //Console.WriteLine(result);
            #endregion

            #region threeOverLoad
            //var result = cars.LastOrDefault(DefaultCar);
            //Console.WriteLine(result);
            //cars = [];
            //var result = cars.LastOrDefault(DefaultCar);
            //Console.WriteLine(result); //DefaultCar
            #endregion

            #region FourOveload
            //var result=cars.LastOrDefault(c=>c.Make=="Ford", DefaultCar);
            //Console.WriteLine(result);

            //var result = cars.LastOrDefault(c => c.Make == "Test", DefaultCar);
            //Console.WriteLine(result);//DefaultCar
            #endregion

            /*
Exceptions
ArgumentNullException
source is null.
            */

            #endregion


            #region Single

            #region FirstOverLoad
            /*
             Single<TSource>(IEnumerable<TSource>)	
             Returns the only element of a sequence, and throws an exception if there is 
             not exactly one element in the sequence.  
            The single element of the input sequence.

===>Exceptions
ArgumentNullException
source is null.
InvalidOperationException
The input sequence contains more than one element.
The input sequence is empty
             */

            //var result = cars.Single();
            //Console.WriteLine(result); //Sequence contains more than one element'
            //cars = [];
            //var result = cars.Single();
            //Console.WriteLine(result);// System.InvalidOperationException: 'Sequence contains no elements'

            #endregion

            #region SecondLoad
            /*
             Single<TSource>(IEnumerable<TSource>, Func<TSource,Boolean>)	
             Returns the only element of a sequence that satisfies a specified condition,
             and throws an exception if more than one such element exists.
             */
            //var result = cars.Single(c => c.Make == "Ford");
            //Console.WriteLine(result);//System.InvalidOperationException: 'Sequence contains more than one matching element'
            //var result = cars.Single(c => c.Make == "Test");
            //Console.WriteLine(result); //System.InvalidOperationException: 'Sequence contains no matching element'
            //var result = cars.Single(c => c.VIN == "WAUEH98E06A527409");
            //Console.WriteLine(result); // true
            #endregion

            #endregion

            #region SingleOrDefault
            //Returns a single, specific element of a sequence, or a default value
            //if that element is not found.
            #region First
            /*
             SingleOrDefault<TSource>(IEnumerable<TSource>)	
             Returns the only element of a sequence, or a default value if the sequence is 
             empty; this method throws an exception if there is more than one element in 
              the sequence. 
             */

            //var result = cars.SingleOrDefault();
            //Console.WriteLine(result);//Sequence contains more than one element'
            //cars = [];
            //var result = cars.SingleOrDefault();
            //Console.WriteLine(result); // Empty ==>Default
            #endregion

            #region Second
            /*
             SingleOrDefault<TSource>(IEnumerable<TSource>, Func<TSource,Boolean>)	
             Returns the only element of a sequence that satisfies a specified condition or a 
             default value if no such element exists; this method throws an exception if more
             than one element satisfies the condition.
             */
            //var result=cars.SingleOrDefault(c =>c.Make=="Ford");
            //Console.WriteLine(result);//System.InvalidOperationException: 'Sequence contains more than one matching element'
            //var result = cars.SingleOrDefault(c => c.VIN == "5J8TB1H27CA866118");
            //Console.WriteLine(result);

            //var result = cars.SingleOrDefault(c => c.VIN == "5J8TB1H27CA866118Q");
            //Console.WriteLine(result);// No Element Match Conditions return Default
            #endregion

            #region Three
            /*
             SingleOrDefault<TSource>(IEnumerable<TSource>, TSource)	
             Returns the only element of a sequence, or a specified default value if the 
             sequence is empty; this method throws an exception if there is more than one 
             element in the sequence
             */
            //var result=cars.SingleOrDefault(DefaultCar);
            //Console.WriteLine(result);//System.InvalidOperationException: 'Sequence contains more than one element'

            //cars = [];
            //var result=cars.SingleOrDefault(DefaultCar);
            //Console.WriteLine(result); // return Default
            #endregion

            #region Four
            /*
             SingleOrDefault<TSource>(IEnumerable<TSource>, Func<TSource,Boolean>, TSource)	
             Returns the only element of a sequence that satisfies a specified condition, or a
             specified default value if no such element exists; this method throws an exception
             if more than one element satisfies the condition. 
             */
            //var result = cars.SingleOrDefault(c => c.Make == "Ford", DefaultCar);
            //Console.WriteLine(result);//System.InvalidOperationException: 'Sequence contains more than one matching element'

            //var result = cars.SingleOrDefault(c => c.VIN == "5J8TB1H27CA866118", DefaultCar);
            //Console.WriteLine(result);

            //var result = cars.SingleOrDefault(c => c.VIN == "5J8TB1H27CA866118Q", DefaultCar);
            //Console.WriteLine(result);// No Element Match Conditions return DefaultCar

            #endregion


            #endregion

            #region Ording
            #region OrderBy
            #region FirstOverLoad
            //var res = cars.OrderBy(x => x.MaxSpeed);
            //Repository.PrintCars(res);
            //var res =
            //    from c in cars
            //    orderby c.MaxSpeed ascending // Default
            //    select c;
            //Repository.PrintCars(res);
            #endregion

            #region SecondOverLoad
            //var res = cars.OrderBy(c => c, new CarComparer());
            //Repository.PrintCars(res);
            #endregion


            #endregion

            #region OrderByDescending

            #region FirstOverLoad
            //var res = cars.OrderByDescending(c => c.MaxSpeed);
            ////Repository.PrintCars(res);
            //var res =
            //    from c in cars
            //    orderby c.MaxSpeed descending 
            //    select c;
            //Repository.PrintCars(res);
            #endregion

            #region SecondOverLoad
            //var res = cars.OrderByDescending(c => c.MaxSpeed, new MaxSpeedComparer());
            //Repository.PrintCars(res);
            #endregion

            #endregion

            #region ThenBy,ThenByDescending
            // ThenBy ==> Performs a subsequent ordering of the elements in a sequence in ascending order.
            //ThenByDescending ==>Performs a subsequent ordering of the elements in a sequence in descending order.
            //var res=from c in cars
            //        orderby c.Make ascending,c.Model,c.MaxSpeed descending
            //         select c;
            //var res = cars.OrderBy(c => c.Make).ThenBy(c => c.Model).ThenByDescending(c => c.MaxSpeed);
            //Repository.PrintCars(res);
            #endregion

            #region SecondOverLoad
            //var res = cars.OrderBy(c => c.MaxSpeed,new MaxSpeedComparer()).ThenBy(c => c.Model).ThenByDescending(c => c,new CarComparer());
            //Repository.PrintCars(res);
            #endregion



            #region Order
            //var res = cars.Order();//ArgumentException: At least one object must implement IComparable
            //Repository.PrintCars(res);
            //var arr = new int[] {1,-1,3,43,1,4,5};
            //var res = arr.Order(); // Array Implement IComparable
            //foreach (var item in res)
            //{
            //    Console.WriteLine(item);
            //}
            /*
             Order<T>(IEnumerable<T>, IComparer<T>)	
Sorts the elements of a sequence in ascending order.
             
             */

            //var res = cars.Order(new CarComparer());
            //Repository.PrintCars(res);


            #endregion

            #endregion

            #region Any
            // Determines whether a sequence contains any elements Or Specific Condition
            #region FirstOverLoad
            //var res = cars.Any();
            //Console.WriteLine(res);
            //cars = [];
            // res = cars.Any();
            //Console.WriteLine(res);
            #endregion

            #region SecondOverrload
            //var res = cars.Any(c=>c.Make=="Ford");
            //Console.WriteLine(res);

            // res = cars.Any(c => c.Make == "FordQ");
            //Console.WriteLine(res);
            #endregion
            #endregion

            #region All
            //Determines whether all the elements of a sequence satisfy a condition.
            //var res = cars.All(c => c.Color == "Black");
            //Console.WriteLine(res);
            #endregion


            #region Append,prepend
            // Append ==>Add new Element in the last IEmunerable collection
            // Prepend ==>Add new Element in the First IEmunerable collection
            #region Append
            //var newCar = new Car(1001, "TestCar", "Model", 1990, "fasf14124", "red", 3000);
            //var result = cars.Append(newCar);
            //Repository.PrintCars(result);
            #endregion

            #region Prepend
            //var newCar = new Car(1001, "TestCar", "Model", 1990, "fasf14124", "red", 3000);
            //var result = cars.Prepend(newCar);
            //Repository.PrintCars(result);
            #endregion
            #endregion

            #region Count,LongCount
            #region Count
            /*Exceptions
ArgumentNullException
source is null.

OverflowException
The number of elements in source is larger than Int32.MaxValue.*/
            #region FirstOverload
            //var nums =cars.Count();
            //Console.WriteLine($"Total Count : {nums}");
            //cars = [];
            //nums = cars.Count();
            //Console.WriteLine($"Total Count : {nums}");
            //Console.WriteLine(Int32.MaxValue);//2147483647
            #endregion

            #region SecondOverLoad
            /*Count<TSource>(IEnumerable<TSource>, Func<TSource,Boolean>)	
Returns a number that represents how many elements in the specified sequence satisfy a condition
            */
            //var count = cars.Count(c => c.Make == "Ford");
            //Console.WriteLine(count); //96
            // Use Any() to check if an element exists instead of Where(...).Count().
            // Any() stops at the first match, while Count() iterates through all elements.
            #endregion

            #endregion

            #region LongCount
            /*Returns an Int64 that represents the number of elements in a sequence.

Overloads
LongCount<TSource>(IEnumerable<TSource>, Func<TSource,Boolean>)	
Returns an Int64 that represents how many elements in a sequence satisfy a condition.

LongCount<TSource>(IEnumerable<TSource>)	
Returns an Int64 that represents the total number of elements in a sequence.*/
            //var count = cars.LongCount(c => c.Make == "Ford");
            //Console.WriteLine(count);
            //count=cars.LongCount();
            //Console.WriteLine(count);
            #endregion
            #endregion






        }

        private static IEnumerable<Car> Enumerable(List<Car> cars, Func<Car, bool> predicate)
        {
            return cars.Where(predicate);
        }
    }
}
