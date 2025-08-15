using System;
using System.Collections;
using System.ComponentModel;
using System.Linq;
using System.Reflection;
using System.Security.Cryptography.X509Certificates;
using System.Text.RegularExpressions;
using LINQ;
using LINQ.JoinTraning;
using Newtonsoft.Json.Linq;
using ReJoin = LINQ.JoinTraning.Repository;
using static System.Formats.Asn1.AsnWriter;
using System.Net;
using System.Transactions;
using System.Net.WebSockets;

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
            //var DefaultCar = new Car()
            //{
            //    Id = 0,
            //    Make = "Unknown",
            //    Model = "Unknown",
            //    ManufactorYear = 0,
            //    VIN = "N/A",
            //    Color = "Unspecified",
            //    MaxSpeed = 0,
            //};
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
            //var nums = cars.Count();
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

            #region CountBy
            // return ==>An enumerable containing the frequencies of each key occurrence in source.
            /*Parameters
source
IEnumerable<TSource>
A sequence that contains elements to be counted.

keySelector
Func<TSource,TKey>
A function to extract the key for each element.

keyComparer
IEqualityComparer<TKey>
An IEqualityComparer<T> to compare keys wit*/
            //Returns the count of elements in the source sequence grouped by key.
            //var MakerCars = cars.CountBy(c => c.Make).OrderByDescending(c=>c.Value);
            //var MakerCars = cars.CountBy(c => $"{c.Make}-{c.Color}").OrderByDescending(c => c.Key);
            //foreach ( var makerCar in MakerCars)
            //{
            //    Console.WriteLine($"Maker : {makerCar.Key}-> Count : {makerCar.Value}");
            //}
            #endregion

            #region Sum
            //List<int> ls = new List<int>() { 1, 3, 4, 5 };
            //var sum = ls.Sum();
            //Console.WriteLine(sum);
            //var totalSpeed = cars.Where(c => c.Make == "Ford").Sum(c => c.MaxSpeed);
            //Console.WriteLine($"totalSpeed : {totalSpeed}");
            #endregion

            #region Average
            //var lst=new List<int>() { 1,2,3,4,6};
            //var avg = lst.Average();
            //Console.WriteLine(avg);
            //lst = [];
            //avg=lst.Average();//System.InvalidOperationException: 'Sequence contains no elements'
            //Console.WriteLine(avg);

            //var avgSpped = cars.Average(c => c.MaxSpeed);
            //Console.WriteLine(avgSpped);

            //var avgFord=cars.Where(c=>c.Make=="Ford").Average(c=>c.MaxSpeed);
            //Console.WriteLine(avgFord);

            //string[] num = ["1","32213","3242623626262"];
            //var avg = num.Average(n =>long.Parse(n));
            //Console.WriteLine(avg);
            #endregion

            #region Max
            //Returns the maximum value in a sequence of values.
            //int[] arr = [11, 3, 4, 0, 6, 7];
            //var MaxValue = arr.Max();
            //Console.WriteLine(MaxValue);

            //var res = cars.Max(c => c.MaxSpeed);
            //Console.WriteLine(res);

            /*Exceptions
ArgumentNullException
source is null.*/
            #endregion

            #region MaxBy
            // Returns
            // TSource
            // The value with the maximum key in the sequence.
            #region FirstOverLoad
            // Before .net6
            //var car=cars.OrderByDescending(c=>c.MaxSpeed).FirstOrDefault();
            // Console.WriteLine(car);
            // After .net6
            //var car=cars.MaxBy(c=>c.MaxSpeed);
            // Console.WriteLine(car);
            #endregion

            #region SecondOverLoad
            //var res = cars.MaxBy(c => c.MaxSpeed, new MaxSpeedComparer());
            //Console.WriteLine(res);
            #endregion


            #endregion

            #region Min
            //Returns the minimum value in a sequence of values.
            #region First
            //var car=cars.Min(c=>c.MaxSpeed);
            //Console.WriteLine(car);
            #endregion

            #region Second
            //var car=cars.Min(c=>c.MaxSpeed);
            //Console.WriteLine(car);
            #endregion

            #endregion

            #region MinBy
            /*Exceptions
ArgumentNullException
source is null.

ArgumentException
No key extracted from source implements the IComparable or IComparable<T> interface.

InvalidOperationException
TSource is a primitive type and the source sequence is empty.*/

            /*Returns
                TSource
                The value with the minimum key in the sequence.
            */
            //var car=cars.MinBy(c=>c.MaxSpeed);
            //Console.WriteLine(car);

            //var res = cars.MinBy(c => c.MaxSpeed, new MaxSpeedComparer());
            //Console.WriteLine(res);
            #endregion

            #region Aggregate
            #region firstOverLoad
            /*
             Aggregate<TSource>(IEnumerable<TSource>, Func<TSource,TSource,TSource>)	
             Applies an accumulator function over a sequence.
             */
            int[] arr = [2, 4, 2, 16, 8];
            // Using Sum
            //var TotalSum = arr.Sum();
            //Console.WriteLine(TotalSum);
            // ----------------------------------------
            //                      Using Aggregate
            //       Returns
            //         TSource
            //         The final accumulator value.
            //var res = arr.Aggregate((acc, nxt) =>
            //{
            //    Console.WriteLine($"Acc : {acc},next : {nxt}");
            //    return acc + nxt;
            //});
            //Console.WriteLine(res);

            //------------------------------
            // Using Max
            //var max = arr.Max();
            //Console.WriteLine(max);
            // ------------------------------
            //Using Aggragate
            //var res=arr.Aggregate((acc,nxt)=> {
            //Console.WriteLine($"acc : {acc} , nxt : {nxt}");
            //    return acc > nxt ? acc : nxt;
            //    });
            //Console.WriteLine(res);

            //var res=cars.Max(c=>c.MaxSpeed);
            //Console.WriteLine(res);
            //var res01=cars.Aggregate((acc,nxt)=>acc.MaxSpeed>nxt.MaxSpeed?acc:nxt); // Return Car
            //Console.WriteLine(res01.MaxSpeed);

            // Min Length of Maker

            //var res=cars.Min(c=>c.Make.Length);
            //Console.WriteLine(res);
            //var res = cars.MinBy(c => c.Make.Length);
            //Console.WriteLine(res);
            //cars = cars.Slice(0, 5);
            //var res = cars.Aggregate((acc, nxt) =>
            //{
            //    Console.WriteLine($"acc : {acc.Make} , next : {nxt.Make}");
            //    return acc.Make.Length < nxt.Make.Length ? acc : nxt;
            //});
            //Console.WriteLine("---------------------------");
            //Console.WriteLine(res.Make.Length);


            #endregion

            #region SecondOverLoad
            //int[] arr = [2, 4, 2, 16, 8];
            // var res = arr.Aggregate((acc, nxt) =>
            //{
            //    Console.WriteLine($"Acc : {acc},next : {nxt}");
            //    return acc + nxt;
            //});
            //Console.WriteLine(res);//32 first value for acc is 2
            //Console.WriteLine("--------------------------");
            //res = arr.Aggregate(10, (acc, nxt)=>{
            //    Console.WriteLine($"Acc : {acc},next : {nxt}");
            //    return acc + nxt;
            //});
            //Console.WriteLine(res);//42 first value for acc is 10
            #endregion


            #region ThreeOverLoad
            /*Aggregate<TSource,TAccumulate,TResult>(IEnumerable<TSource>, 
             TAccumulate, Func<TAccumulate,TSource,TAccumulate>, Func<TAccumulate,TResult>)	
             Applies an accumulator function over a sequence. The specified seed value is used as 
            the initial accumulator value, and the specified function is used to select the result value.
            */
            //string[] fruits = { "apple", "mango", "orange", "passionfruit", "grape" };

            //// Determine whether any string in the array is longer than "banana".
            //string longestName =
            //    fruits.Aggregate("banana",
            //                    (longest, next) =>
            //                        next.Length > longest.Length ? next : longest,
            //                    // Return the final result as an upper case string.
            //                    fruit => fruit.ToUpper());

            //Console.WriteLine(
            //    "The fruit with the longest name is {0}.",
            //    longestName);
            // ----------------------------------------
            //var res01 = cars.Aggregate(new Car(),(acc, nxt) => acc.MaxSpeed > nxt.MaxSpeed ? acc : nxt,c=>c.MaxSpeed);
            //Console.WriteLine(res01);
            // ------------------------------------------------------ 

            //var res = arr.Aggregate(-1, (acc, nxt) => acc > nxt ? acc : nxt, result => result * 1000);
            //Console.WriteLine(res); // Max*1000 = 16000

            #endregion
            #endregion

            #region Query-Select
            //var res=from c in cars
            //        where c.Make=="Ford"
            //        select c;

            // ==> Select With Mapping 

            //var res = from c in cars
            //          select new CarDto(c.Id, c.Make, c.Model, c.ManufactorYear);
            // ---------------------------------------------------------
            //var res = from c in cars
            //          select new CarDto(c.Id, c.Make,$"{c.Model} - {c.Color}", c.ManufactorYear);


            //  ==> Select With ansymouns type
            //var res = from c in cars
            //          select new { c.Id, c.Make, Model = $"{c.Model} - {c.Color}", Year = c.ManufactorYear };

            //foreach (var c in res)
            //{
            //    Console.WriteLine(c);
            //}
            #endregion


            #region Method-Select
            //var res = cars.Select(car => new CarDto(car.Id, car.Make, car.Model, car.ManufactorYear));

            //var res = cars.Select((car,index) => new CarDto(car.Id=index, car.Make, $"{car.Model} - {car.Color}", car.ManufactorYear));

            //var res = cars.Select((car, Index) => new { Id = Index + 1, car.Make, Model = $"{car.Model} - {car.Color}", car.ManufactorYear });

            //foreach (var i in res)
            //{
            //    Console.WriteLine(i);
            //}

            #endregion


            #region selectMany
            var students = new[]
{
    new { Name = "Ahmed",  Subjects = new[] { "Math", "Science" } },
    new { Name = "Sara",   Subjects = new[] { "History", "Art" } },
    new { Name = "Omar",   Subjects = new[] { "Physics", "Chemistry" } },
    new { Name = "Mona",   Subjects = new[] { "Biology", "Math" } },
    new { Name = "Khaled", Subjects = new[] { "Computer", "English" } },
    new { Name = "Laila",  Subjects = new[] { "Geography", "History" } }
};
            #region First&&Second-OverLoad-SelectMany
            // Reach for all Subjects 

            // 1] Using Foreach
            //List<string> Subjects = new List<string>();
            //foreach( var student in students)
            //{
            //    foreach( var i in student.Subjects)
            //    {
            //        Subjects.Add(i);
            //    }

            //}
            //foreach(var Sub in Subjects)
            //{
            //    Console.WriteLine(Sub);
            //}
            //var res = students.Select(st => st.Subjects);
            //foreach (var Sub in res)
            //{
            //    Console.WriteLine($"{Sub[0]} - {Sub[1]}");
            //}
            //var res01 = students.SelectMany(st => st.Subjects);
            //var res01 = students.SelectMany((st, i) => st.Subjects.Select(sb => $"{i} : {sb}"));
            //var res01 = students.Select(st => st.Subjects.Aggregate((acc, nxt) => acc + " , " + nxt));
            //var res01 = students.Select(st => $"{st.Name}-->{string.Join(',', st.Subjects)}");
            //foreach (var Sub in res01)
            //{
            //    Console.WriteLine(Sub);
            //}

            #endregion

            #region Three-OverLoad
            /*SelectMany<TSource, TCollection, TResult>(
    IQueryable<TSource> source,
    Expression<Func<TSource, int, IEnumerable<TCollection>>> collectionSelector,
    Expression<Func<TSource, TCollection, TResult>> resultSelector)
*/
            //var res = students.SelectMany((st, i) => st.Subjects, (st, Subjectname) =>
            //new
            //{
            //    StudentName = st.Name,
            //    SubjectName = Subjectname
            //});


            //foreach( var student in res)
            //{
            //    Console.WriteLine($"{student.StudentName} - {student.SubjectName}");
            //}
            #endregion


            #endregion

            #region Distinct
            //  Returns distinct elements from a sequence.
            // Source should Implement IEqualitable or based on Default Reference
            //int[]arrr = [1, 3, 4, 21, 1, 3];
            ////var result = arrr.Distinct();
            //var result=students.SelectMany(st=>st.Subjects).Distinct();
            //foreach ( var item in result)
            //{
            //    Console.WriteLine(item);
            //}
            //Person[] persons =
            //{
            //    new Person() { Name="Mohamed",Age=15},
            //    new Person() { Name = "Mohamed", Age = 15 }
            //};
            //var result = persons.Distinct();
            //foreach ( var item in result)
            //{
            //    Console.WriteLine(item);
            //}
            // Output will Be Two Object , Must use second Overload and Implement IEqualtabl Interface
            //var result = persons.Distinct(new PersonIEqualtabl());
            //foreach (var item in result)
            //{
            //    Console.WriteLine(item);
            //}//Name : Mohamed , Age : 15 Only
            #endregion

            #region DistinctBy
            /*DistinctBy<TSource,TKey>(IEnumerable<TSource>, Func<TSource,TKey>)	
Returns distinct elements from a sequence according to a specified key selector function.*/
            //Person[] peoples=
            //{
            //    new Person(){Name="Mohamed",Age=12},
            //    new Person(){Name="Ali",Age=12},
            //    new Person(){Name="Amr",Age=20},
            //    new Person(){Name="Mona",Age=70}
            //};
            //var res = peoples.DistinctBy(p=>p.Age);
            //foreach (var item in res)
            //{
            //    Console.WriteLine(item);
            //}


            /*DistinctBy<TSource,TKey>(IEnumerable<TSource>, Func<TSource,TKey>, IEqualityComparer<TKey>)	
Returns distinct elements from a sequence according to a specified key selector function and using a specified comparer to compare keys.*/

            //            var carsD = new[]
            //{
            //    new Car { Make = "BMW", Id = 1 },
            //    new Car { Make = "bmw", Id = 2 },
            //    new Car { Make = "Audi", Id = 3 }
            //};

            //            var result = carsD.DistinctBy(
            //                c => c.Make,                  
            //                StringComparer.OrdinalIgnoreCase 
            //            );

            //            foreach (var car in result)
            //                Console.WriteLine($"{car.Make} - {car.Id}");
            #endregion

            #region GroupBy
            //var groups = from c in cars
            //             group c by new { c.Make ,c.Color};
            //foreach(var items in groups )
            //{
            //    Console.WriteLine($"Group : {items.Key} , Count : {items.Count()}");

            //        Repository.PrintCars(items);

            //}
            // var group = cars.GroupBy(c => new { c.Model ,c.Make});
            //foreach( var item in group )
            // {
            //     Console.WriteLine($"Group : {item.Key} , Count : {item.Count()}");
            //     //Repository.PrintCars(item);
            // }

            //var res = from c in cars
            //          group c by new { c.Make, c.Color }
            //        into g
            //          select new
            //          {
            //             g.Key,
            //             CarsOfGroup=g,
            //             Count=g.Count(),
            //          };
            // -------------------------------------------------
            //var res = cars.GroupBy(c => new { c.Make})
            //     .Select(g => new
            //     {
            //         g.Key,
            //         CarsOfGroup = g,
            //         Count = g.Count()

            //     });
            // ---------------------------------------

            //var res = cars.GroupBy(c => c.Make, (key, g) => new
            //{
            //    Key=key,
            //    CarsOfGroup=g,
            //    Count=g.Count()
            //});
            //var res = cars.GroupBy(c => Math.Abs(c.MaxSpeed / 100), (key, g) => new
            //{
            //    Key = key,
            //    CarsOfGroup = g,
            //    Count = g.Count()
            //});
            //foreach (var item in res)
            //{
            //    Console.WriteLine($"Key : {item.Key}, Count : {item.Count}");
            //    Repository.PrintCars(item.CarsOfGroup);

            // }
            #endregion


            #region AggragateBy
            //            var employees = new List<Worker>
            //{
            //    new Employee("Ahmed", "IT", 8000),
            //    new Employee("Sara", "HR", 7000),
            //    new Employee("Omar", "IT", 9000),
            //    new Employee("Laila", "Finance", 7500),
            //    new Employee("Hassan", "HR", 7200)
            //};


            // Using GroupBy
            //var res = employees.GroupBy(e => e.Department, (key, employeesGroup) => new
            //{
            //    Department= key,
            //    TotalSalary= employeesGroup.Sum(e=>e.Salary)
            //});

            //Using AggragateBy

            // IEnumerable<KeyValuePair<TKey,TAccumulate>>

            //var res = employees.AggregateBy(
            //    e => e.Department,
            //    seed: 0.0,
            //    (Total, currentEmployee) => Total + currentEmployee.Salary
            //    );
            //var res = cars.AggregateBy
            //    (
            //       c=>c.Make,
            //       seed:new List<string>(),
            //       (acc, val) => [..acc,val.Model]
            //    );
            //foreach(var car in res)
            //{
            //    Console.WriteLine($"Maker : {car.Key} ");
            //    foreach(var model in car.Value.Distinct())
            //    {
            //        Console.WriteLine($"\t\t{model}");
            //    }
            //}

            #endregion


            #region ToLookup
            /*
           ToLookup` creates an in-memory, immutable lookup table from a sequence,
            executing immediately and grouping elements by a specified key for fast key-based access.
           */


            //var res = cars.ToLookup(c => c.Make);

            //var res = cars.ToLookup(c => c.Make, c => new CarDto(c.Id, c.Make, c.Model, c.ManufactorYear));


            //foreach( var car in res)
            //{
            //    Console.WriteLine(" ---------------------------");
            //    Console.WriteLine($"Key : {car.Key}");

            //    foreach( var cardto in car)
            //    {
            //        Console.WriteLine($"{cardto.ID} - {cardto.Maker} - {cardto.Model} - {cardto.Year}");
            //    }
            //}

            #endregion

            #region Chunk
            /*Splits the elements of a sequence into chunks of size at most size.*/
            //var splits = cars.Chunk(100);
            //foreach(var item in splits)
            //{
            //    Repository.PrintCars(item);
            //}
            #endregion

            #region Take
            /*
Take<TSource>(IQueryable<TSource>, Int32)
Source:
Queryable.cs
Returns a specified number of contiguous elements from the start of a sequence.
            */
            //var TenMaxSpeed = cars.OrderByDescending(c=>c.MaxSpeed).Take(10);
            //Repository.PrintCars(TenMaxSpeed);
            /*
Take<TSource>(IQueryable<TSource>, Range)
Source:
Queryable.cs
Returns a specified range of contiguous elements from a sequence.*/
            //var res=cars.OrderByDescending(c=>c.MaxSpeed).Take(new Range(0,10));
            //Repository.PrintCars(res);  

            #endregion

            #region TakeLast
            /*IQueryable<TSource> TakeLast<TSource>(this System.Linq.IQueryable<TSource> source, int count)
             * Returns a new queryable sequence that contains the last count elements from source.
             */
            //var res = cars.OrderByDescending(c=>c.MaxSpeed).TakeLast(10);
            //Repository.PrintCars(res);
            #endregion

            #region TakeWhile
            /*Returns elements from a sequence as long as a specified condition is true,
             and then skips the remaining elements*/
            #region FirstOverLoad
            /*
        TakeWhile<TSource>(IQueryable<TSource>, Expression<Func<TSource,Boolean>>)	
        Returns elements from a sequence as long as a specified condition is true.
             */
            //var res = cars.TakeWhile(c => c.MaxSpeed>200);// First False end
            // Repository.PrintCars(res);
            /*
         TakeWhile<TSource>(IQueryable<TSource>, Expression<Func<TSource,Int32,Boolean>>)	
         Returns elements from a sequence as long as a specified condition is true. 
         The element's index is used in the logic of the predicate function.
             */
            //var res = cars.TakeWhile((c,i)=>i<100);
            //Repository.PrintCars(res);
            #endregion


            #endregion

            #region Skip
            /*Bypasses a specified number of elements in a sequence and then returns
        the remaining elements.
        IQueryable<TSource> Skip<TSource>(this System.Linq.IQueryable<TSource> source, int count);
             */
            //var res = cars.Skip(10);
            //Repository.PrintCars(res);
            #endregion

            #region SkipLast
            /*Returns a new queryable sequence that contains the elements from source 
            with the last count elements of the source queryable sequence omitted.*/
            //var res = cars.SkipLast(10);
            //Repository.PrintCars(res);
            #endregion

            #region Empty
            /*
             Returns
IEnumerable<TResult>
An empty IEnumerable<T> whose type argument is TResult.
             */
            //var emptyList = Enumerable.Empty<string>();
            //Console.WriteLine(emptyList.Any());
            //emptyList= emptyList.Append("1");
            //Console.WriteLine(emptyList.Any());
            #endregion

            #region DefaultifEmpty
            //var result = cars.DefaultIfEmpty();
            //Repository.PrintCars(result); // sequence
            //int[] array = [];
            //var res = array.DefaultIfEmpty(1000);
            //foreach(var item in res)
            //{
            //    Console.WriteLine(item);
            //}
            //var carsempty = Enumerable.Empty<Car>();
            //var car= carsempty.DefaultIfEmpty(DefaultCar);
            //Repository.PrintCars(car);


            #endregion

            #region ElementAt
            /*ElementAt<TSource>(IEnumerable<TSource>, Index)	
              Returns the element at a specified index in a sequence.*/
            //var car01=cars.ElementAt(4);
            //Console.WriteLine(car01);
            //var car02 =cars.ElementAt(new Index(4));
            //Console.WriteLine(car02);
            //var car03 = cars.ElementAt(new Index(996, true)); //Index start from 1[end] ex : [end(1) - front(1000)]
            //Console.WriteLine(car03);
            #endregion

            #region ElementAtOrDefault
            /*Returns the element at a specified index in a sequence or 
             * a default value if the index is out of range*/
            //var car=cars.ElementAtOrDefault(1000); // Return Default
            //Console.WriteLine(car);
            //var car02 = cars.ElementAtOrDefault(10); // ID: 11, Make: Merkur, Model: XR4Ti, Year: 1985, VIN: WAUFFAFL3AN312699, Color: Fuscia, Max Speed: 754 km/h
            //Console.WriteLine(car02);
            //var car03 = cars.ElementAtOrDefault(new Index(1000, true));
            //Console.WriteLine(car03);
            //var car04 = cars.ElementAtOrDefault(new Index(1001, true));// Return Default
            //Console.WriteLine(car04);
            #endregion

            #region Index
            /*Returns an enumerable that incorporates the element's index into a tuple*/
            //var res = cars.Index();
            //foreach(var car in res)
            //{
            //    Console.WriteLine($"Index : {car.Index} , Car : {car.Item}");
            //}
            #endregion

            #region Concate
            /*Concatenates two sequences without Distinct*/
            //int[] arr01 = [1, 2, 3];
            //int[] arr02 = [4,5,6];
            //int[] arr03 = [6,7,9];
            //var res=arr01.Concat(arr02).Concat(arr03);
            //foreach(var ele in res)
            //{
            //    Console.WriteLine($"{ele}");
            //}
            #endregion

            #region Union
            /*
            Union<TSource>(IEnumerable<TSource>, IEnumerable<TSource>)	
            Produces the set union of two sequences by using the default equality comparer.
            */
            //Produces the set union of two sequences.


            //    var list1 = new List<Employee>
            //{
            //    new Employee("Ali", "IT", 8000),
            //    new Employee("Sara", "HR", 6000),
            //    new Employee("Omar", "IT", 7500),
            //    new Employee("Ali", "IT", 8000), 
            //    new Employee("Mona", "Finance", 7000)
            //};

            //    var list2 = new List<Employee>
            //{
            //    new Employee("Yasser", "IT", 8500),
            //    new Employee("Sara", "HR", 6000),
            //    new Employee("Omar", "IT", 7500),
            //    new Employee("Nora", "Marketing", 7200),
            //    new Employee("Ali", "IT", 8000)
            //};
            //    var res=list1.Union(list2);
            //    // It Record this Implement IEqualtabl Interface
            //    foreach(var item in res)
            //    {
            //        Console.WriteLine(item);
            //    }

            // -------------------------------------
            //    var list1 = new List<Person>
            //{
            //    new Person { Name = "Ali", Age = 25 },
            //    new Person { Name = "Sara", Age = 30 },
            //    new Person { Name = "Omar", Age = 28 },
            //    new Person { Name = "Ali", Age = 25 }, 
            //    new Person { Name = "Mona", Age = 22 }
            //};

            //    var list2 = new List<Person>
            //{
            //    new Person { Name = "Hana", Age = 27 },
            //    new Person { Name = "Sara", Age = 30 }, 
            //    new Person { Name = "Khaled", Age = 35 },
            //    new Person { Name = "Ali", Age = 25 }, 
            //    new Person { Name = "Omar", Age = 28 } 
            //};
            //var res=list1.Union(list2);
            /*Since Person does not implement IEquatable<Person> or override Equals 
             * and GetHashCode, LINQ methods like Distinct or Except will treat each
             * object as different even if the property values are identical,
             * resulting in duplicates.*/
            //var res=list1.Union(list2,new PersonIEqualtabl());
            // foreach (var item in res)
            // {
            //     Console.WriteLine(item);
            // }



            #endregion

            #region UnionBy
            /*
             Produces the set union of two sequences according to a specified 
             key selector function.
             */
            //            var list1 = new List<Person>
            //{
            //    new Person { Name = "Mohamed", Age = 1500 },
            //    new Person { Name = "Ali", Age = 20 }
            //};

            //            var list2 = new List<Person>
            //{
            //    new Person { Name = "mohamed", Age = 25 },
            //    new Person { Name = "Mona", Age = 50 }
            //};
            //var res = list1.UnionBy(list2, p => p.Name);
            //foreach (var person in res)
            //{
            //    Console.WriteLine(person);
            //}

            // ---------------------------
            //var res = list1.UnionBy(list2, p => p.Name,StringComparer.OrdinalIgnoreCase);
            //foreach (var person in res)
            //{
            //    Console.WriteLine(person);
            //}


            #endregion

            #region Zip

            #region FirstOverLoad
            /*Zip<TFirst,TSecond>(IEnumerable<TFirst>, IEnumerable<TSecond>)	
          Produces a sequence of tuples with elements from the two specified sequences.*/
            int[] arr01 = [1, 2, 3, 4];
            string[] arr02 = ["One", "Two", "Thress", "Four"];
            //var res=arr01.Zip(arr02);
            //foreach( var item in res)
            //{
            //    Console.WriteLine($"{item.First} - {item.Second}");
            //}
            #endregion

            #region SecondOverLoad
            /*Zip<TFirst,TSecond,TThird>(IEnumerable<TFirst>, IEnumerable<TSecond>, IEnumerable<TThird>)	
           Produces a sequence of tuples with elements from the three specified sequences.*/
            //DateTime[] arr03 = { DateTime.Now.AddDays(1), DateTime.Now.AddDays(2), DateTime.Now.AddDays(3) };
            //var res=arr01.Zip(arr02,arr03);
            //foreach(var (first,second,three)in res)
            //{
            //    Console.WriteLine($"{first} - {second} - {three}");
            //}
            #endregion

            #region ThreeOverload
            /*Zip<TFirst,TSecond,TResult>(IEnumerable<TFirst>, IEnumerable<TSecond>, Func<TFirst,TSecond,TResult>)	
  Applies a specified function to the corresponding elements of two sequences, producing a sequence of the results.*/
            //var res=arr01.Zip(arr02,(number,word)=>new {Number=number,Word=word});
            //var res=arr01.Zip(arr02,(number,word)=>$"{number} -- {word}");
            //foreach (var item in res)
            //{
            //    Console.WriteLine($"{item}");
            //}
            #endregion

            #endregion

            #region ToArray
            //method forces immediate query evaluation and returns an array that contains the query results.
            //var res=cars.ToArray();
            //Console.WriteLine(res[0]);
            //Console.WriteLine(cars.ElementAt(0)); // Same output
            //Console.WriteLine(cars[0]);//Cannot apply indexing with [] to an expression of type 'IEnumerable<Car>'

            #endregion

            #region ToDictionary
            /*ToDictionary<TSource,TKey,TElement>(IEnumerable<TSource>, Func<TSource,TKey>, Func<TSource,TElement>, IEqualityComparer<TKey>)	
            Creates a Dictionary<TKey,TValue> from an IEnumerable<T> according to a 
            specified key selector function, a comparer,
            and an element selector function.*/
            //var res = cars.ToDictionary(c => c.Id, c => new { c.Make, c.VIN });
            //foreach (var item in res)
            //{
            //    Console.WriteLine(item.Key);
            //    Console.WriteLine($"\t\t{item.Value}");
            //}
            #endregion

            #region Hashset
            /*HashSet<TSource>
A HashSet<T> that contains values of type TSource selected from the input sequence.*/
            //var res = cars.ToHashSet();
            //foreach(var item in res)
            //{
            //    Console.WriteLine(item);
            //}
            #endregion

            #region Tolist
            /*List<TSource>
A List<T> that contains elements from the input sequence.*/
            //var res=cars.Where(c=>c.MaxSpeed > 500).ToList();
            //Console.WriteLine(res.Count());
            //foreach(var item in res)
            //{
            //    Console.WriteLine(item);
            //}


            // Tolist,ToDictionary,ToArray == > Immediate Excution
            #endregion

            #region Join
            var Worker = ReJoin.LoadEmployees();
            var Departments = ReJoin.LoadDepartments();
            var Projects = ReJoin.LoadProjects();
            var EmpProject = ReJoin.LoadEmployeeProjects();
            var taskItems = ReJoin.LoadTasks();

            #region Q1
            /*
              Display the names of employees along with the names of their departments.
              (Employee Name + Department Name)
           */
            //var q1 = from dept in Departments
            //         join emp in Worker
            //         on dept.Id equals emp.DepartmentId
            //         select new
            //         {
            //             DepartmentName = dept.Name,
            //             EmployeeName = emp.Name,
            //         };

            //var q1 = Departments.
            //    Join(Worker,
            //    d => d.Id,
            //    e => e.DepartmentId,
            //    (dept, emp) =>new
            //    {
            //        DepartmentName=dept.Name,
            //        EmployeeName= emp.Name
            //    });
            #endregion


            #region q2
            /*
          Display the names of employees along with the names of the projects
            they are working on.
          (Employee Name + Project Name)*/
            //var q2 = from emp in Worker
            //         join empproject in EmpProject
            //         on emp.Id equals empproject.EmployeeId
            //         join project in Projects
            //         on empproject.ProjectId equals project.Id
            //         select new
            //         {
            //             EmployeeName = emp.Name,
            //             ProjectName = project.Name,
            //         };
            //var q2 = Worker.Join(EmpProject
            //    , emp => emp.Id,
            //    empp => empp.EmployeeId,
            //    (emp, emppro) => new
            //    {
            //        emp,
            //        emppro
            //    }).Join(Projects,
            //    wp => wp.emppro.ProjectId,
            //    project => project.Id,
            //    (wp, project) => new
            //    {
            //        EmployeeName = wp.emp.Name,
            //        ProjectName=project.Name,
            //    }
            //   );

            #endregion

            #region q3
            /*
             *Display the names of departments and the number of employees 
              in each department.
             (Department Name + Count of Employees)
            */
            // Group By
            // var q3 = from dept in Departments
            //         join emp in Worker
            //         on dept.Id equals emp.DepartmentId
            //         group dept by dept.Name into EmpDept
            //         select new
            //         {
            //             EmployeeName = EmpDept.Key,
            //             CountOfEmp = EmpDept.Count(),
            //         };
            ////Group Join(join...into)
            //var result1 = from dept in Departments
            //              join emp in Worker
            //              on dept.Id equals emp.DepartmentId into EmpDept
            //              select new
            //              {
            //                  DepartmentName = dept.Name,
            //                  CountOfEmployees = EmpDept.Count()
            //              };
            //var q3 = Worker.Join(Departments,
            //    worker => worker.DepartmentId,
            //    dept => dept.Id,
            //    (worker, dept) => new
            //    {
            //        worker,
            //        dept
            //    }).GroupBy(res => res.dept.Name, (key, g) => new
            //    {
            //        DepartmentName = key,
            //        CountOfEmployee = g.Count()
            //    });


            #endregion

            #region q4
            /*Display employees, their departments,
             * and the projects they are working on all in one table.
             (Employee Name + Department Name + Project Name)*/
            //var q4 = from dept in Departments
            //         join emp in Worker
            //         on dept.Id equals emp.DepartmentId
            //         join EmpPro in EmpProject
            //         on emp.Id equals EmpPro.EmployeeId
            //         join pro in Projects
            //         on EmpPro.ProjectId equals pro.Id
            //         select new
            //         {
            //             EmployeeName = emp.Name,
            //             DepartmentName = dept.Name,
            //             ProjectName = pro.Name,
            //         };
            //var q4 = Worker.Join(Departments,
            //    emp => emp.DepartmentId,
            //    dept => dept.Id,
            //    (emp, dept) => new
            //    {
            //        empId = emp.Id,
            //        empName = emp.Name,
            //        deptName = dept.Name,
            //    }).Join(EmpProject,
            //    ed => ed.empId,
            //    emppro => emppro.EmployeeId,
            //    (ed, emppro) => new
            //    {
            //        ed.empName,
            //        ed.deptName,
            //        emppro.ProjectId
            //    }).Join(Projects,
            //     edp => edp.ProjectId,
            //     p => p.Id,
            //     (edp, p) => new
            //     {
            //         EmployeeName = edp.empName,
            //         DepartmentName = edp.deptName,
            //         ProjectName = p.Name,
            //     });


            #endregion

            #region q5
            /*
             * Display the names of projects and the number of employees
             * assigned to each project.
              (Project Name + Count of Employees)
            */
            //var q5 = from emp in Worker
            //         join empro in EmpProject
            //         on emp.Id equals empro.EmployeeId
            //         join pro in Projects
            //         on empro.ProjectId equals pro.Id
            //         group pro by pro.Name into empProjects
            //         select new
            //         {
            //             ProjectName= empProjects.Key,
            //             CountOfEmployees=empProjects.Count(),
            //         };
            //var q5 =from p in Projects
            //         join ep in EmpProject
            //         on p.Id equals ep.ProjectId into empProjs
            //         select new
            //         {
            //             ProjectName = p.Name,
            //             EmployeeCount = empProjs.Count()
            //         };
            //var q5 = Worker.Join(EmpProject,
            //    w => w.Id,
            //    empro => empro.EmployeeId,
            //    (w, empro) => new
            //    {
            //        w,
            //        empro
            //    }).Join(Projects,
            //    empro => empro.empro.ProjectId,
            //    p => p.Id,
            //    (empro, p) => new
            //    {
            //        ProjectName = p.Name,
            //        empro
            //    }).GroupBy(source => source.ProjectName,
            //    (key, g) => new
            //    {
            //        key,
            //        CountOfEmployee=g.Count()
            //    });

            #endregion





            //foreach (var item in q2)
            //{
            //    Console.WriteLine(item);
            //}
            //Console.WriteLine();

            #endregion

            #region GroupJoin

            #region ex01
            //var result = from dept in Departments
            //             join emp in Worker
            //             on dept.Id equals emp.DepartmentId
            //             into empGroup
            //             where empGroup.Any()
            //             select new
            //             {
            //                 DepartmentName = dept.Name,
            //                 Employees = empGroup
            //             };
            //var result1 = from emp in Worker
            //join dept in Departments
            //on  emp.DepartmentId equals dept.Id 
            //into deptGroup
            //where deptGroup.Any()
            //             select new
            //             {
            //                 EmployeName=emp.Name,
            //                 departments = deptGroup
            //             };
            //foreach (var item in result)
            //{
            //    Console.WriteLine($"{item.DepartmentName}");
            //    Console.WriteLine($"\t{string.Join(',', item.Employees.Select(e => new { e.Id, e.Name }))}");
            //}
            //Console.WriteLine();
            //foreach (var item in result1)
            //{
            //    Console.WriteLine($"{item.EmployeName}");
            //    Console.WriteLine($"\t{string.Join(',', item.departments.Select(e => new { e.Id, e.Name }))}");
            //}
            #endregion

            #region ex02
            //var res = from dept in Departments
            //          join emp in Worker
            //          on dept.Id equals emp.DepartmentId
            //          select new
            //          {
            //              DepartmentName = dept.Name,
            //              EmployeeName = emp.Name,
            //              EmployeeProjects = String.Join(", ",
            //                                  (from ep in EmpProject
            //                                   where ep.EmployeeId == emp.Id
            //                                   join p in Projects
            //                                   on ep.ProjectId equals p.Id
            //                                   select p.Name))
            //          };

            //foreach (var item in res)
            //{
            //    Console.WriteLine($"{item.DepartmentName} - {item.EmployeeName} - {item.EmployeeProjects}");
            //}


            #endregion

            #region ex03
            /*
You have the EmployeeProject table where each record contains EmployeeId and ProjectId.
Task:

Group projects by EmployeeId

Count the number of projects for each employee

Display the employee name and the number of projects they are assigned to*/
            //var res = from emp in Worker
            //          join pro in EmpProject
            //          on emp.Id equals pro.EmployeeId
            //          into EmpProjects
            //          select new
            //          {
            //              EmployeeName = emp.Name,
            //              ///ProjectCount = EmpProjects.Count()
            //              ProjectCount = EmpProjects.CountBy(e => e.EmployeeId).First().Value
            //          };
            //var res01 = Worker.GroupJoin(EmpProject,
            //    emp => emp.Id,
            //    empPro => empPro.EmployeeId,
            //    (emp, empPro) => new
            //    {
            //        EmployeeName = emp.Name,
            //        ProjectCount = empPro.Count()

            //    });
            //foreach (var emp in res01)
            //{
            //    Console.WriteLine($"{emp.EmployeeName} - {emp.ProjectCount}");
            //}
            #endregion

            #region ex04
            /*
Question using Group Join + Into
You have Departments and Workers tables.
Task:
Use a Group Join to link each department with its employees
Display the department name along with the list of employees in it
Exclude departments that have no employees*/
            //var res = from dept in Departments
            //          join emp in Worker
            //          on dept.Id equals emp.DepartmentId
            //          into DeptEmployee
            //          where DeptEmployee.Any()
            //          select new
            //          {
            //              DepartmentName=dept.Name,
            //              EmployeeList=DeptEmployee
            //          };
            //var res01 = Departments.GroupJoin(Worker,
            //    dept => dept.Id,
            //    emp => emp.DepartmentId,
            //    (dept, emp) => new
            //    {
            //        DepartmentName = dept.Name,
            //        EmployeeList = emp,

            //    }).Where(e => e.EmployeeList.Any());
            //foreach (var item in res01)
            //{
            //    Console.WriteLine($"Department Name : {item.DepartmentName}");
            //    foreach (var item2 in item.EmployeeList)
            //    {
            //        Console.WriteLine($"\t\t\t{item2.Name}");
            //    }
            //}

            #endregion

            #region ex05
            /*Question using Method Syntax

You have EmployeeProject and Projects tables.
Task:

Use Method Syntax to group projects by Project.Name

Count the number of employees assigned to each project

Display the project name and the number of employees for each project*/
            //var res = from p in Projects
            //          join empPro in EmpProject
            //          on p.Id equals empPro.ProjectId
            //          into empProjects
            //          where empProjects.Any()
            //          select new
            //          {
            //              ProjectName = p.Name,
            //              CountOfEmployee = empProjects.Select(e=>e.EmployeeId).Distinct().Count(),
            //          };
            //var res = Projects.GroupJoin(EmpProject,
            //    p => p.Id,
            //    emp => emp.ProjectId,
            //    (p, emp) => new
            //    {
            //        ProjectName=p.Name,
            //        CountOfEmployee=emp.Select(e=>e.EmployeeId).Count()
            //    }).Where(emp=> emp.CountOfEmployee != 0);
            //var res = Projects.Join(EmpProject,
            //    pro => pro.Id,
            //    empPro => empPro.ProjectId,
            //    (pro, empPro) => new
            //    {
            //        pro.Name,
            //        empPro.EmployeeId
            //    }).GroupBy(pro => pro.Name, (key,res) =>new
            //    {
            //        ProjectName = key,
            //        CountOfEmployee = res.Select(x => x.EmployeeId).Distinct().Count()
            //    });

            //foreach( var emp in res)
            //{
            //    Console.WriteLine($"{emp.ProjectName} - {emp.CountOfEmployee}");
            //}


            #endregion

            #region ex06
            /*,
make a LINQ query that shows for each employee:

The department name

The employee name

The project name

How many tasks they have in that project

The names of these task*/
            //var res = from emp in Worker
            //          join dept in Departments
            //          on emp.DepartmentId equals dept.Id
            //          join empPro in EmpProject
            //          on emp.Id equals empPro.EmployeeId
            //          join project in Projects
            //          on empPro.ProjectId equals project.Id
            //          join task in taskItems
            //          on new { empPro.ProjectId, empPro.EmployeeId }
            //          equals new { task.ProjectId, task.EmployeeId }
            //          into EmpTasks
            //          select new
            //          {
            //              DepartmentName=dept.Name,
            //              EmployeeName=emp.Name,
            //              ProjectName=project.Name,
            //              CountOfTask= EmpTasks.Count(),
            //              NameOfTasks=String.Join(',', EmpTasks.Select(t => t.Name)),
            //          };
            //var res = Worker
            // .Join(Departments,
            //     emp => emp.DepartmentId,
            //     dept => dept.Id,
            //     (emp, dept) => new
            //     {
            //         emp.Id,
            //         emp.Name,
            //         DepartmentName = dept.Name
            //     })
            // .Join(EmpProject,
            //     emp => emp.Id,
            //     empPro => empPro.EmployeeId,
            //     (emp, empPro) => new
            //     {
            //         emp.DepartmentName,
            //         emp.Name,
            //         empPro.ProjectId,
            //         EmployeeId = emp.Id
            //     })
            // .Join(Projects,
            //     empPro => empPro.ProjectId,
            //     project => project.Id,
            //     (empPro, project) => new
            //     {
            //         empPro.DepartmentName,
            //         empPro.Name,
            //         ProjectName = project.Name,
            //         empPro.ProjectId,
            //         empPro.EmployeeId
            //     })
            // .GroupJoin(taskItems,
            //     empPro => new { empPro.ProjectId, empPro.EmployeeId },
            //     task => new { task.ProjectId, task.EmployeeId },
            //     (empPro, EmpTasks) => new
            //     {
            //         empPro.DepartmentName,
            //         EmployeeName = empPro.Name,
            //         empPro.ProjectName,
            //         CountOfTask = EmpTasks.Count(),
            //         NameOfTasks = string.Join(",", EmpTasks.Select(t => t.Name))
            //     });


            //Console.WriteLine($"{"Department",-15} {"Employee",-15} {"Project",-20} {"#Tasks",-8} {"Tasks"}");
            //Console.WriteLine(new string('-', 80));

            //foreach (var item in res)
            //{
            //    Console.WriteLine($"{item.DepartmentName,-15} {item.EmployeeName,-15} {item.ProjectName,-20} {item.CountOfTask,-8} {item.NameOfTasks}");
            //}
            #endregion


            #endregion


            #region LeftJoin
            //var res = from emp in Worker
            //          join dept in Departments
            //          on emp.DepartmentId equals  dept.Id
            //          select new
            //          {
            //              EmployeeName=emp.Name,
            //              DepartmentName = dept.Name,
            //          };  // Inner Join

            // Using Query
            //var res = from emp in Worker
            //          join dept in Departments
            //          on emp.DepartmentId equals dept.Id
            //          into EmployeeDept
            //          from DEPT in EmployeeDept.DefaultIfEmpty()
            //          select new
            //          {
            //              EmployeeName = emp.Name,
            //              DepartmentName = DEPT?.Name ?? "No Department", // If DEPT is Null return "No Department"
            //          };

            // Using Method Before C .Net10

            //var res = Worker.GroupJoin(Departments,
            //    emp => emp.DepartmentId,
            //    dept => dept.Id,
            //    (emp, dept) => new
            //    {
            //        EmployeeName = emp.Name,
            //        DepartmentName = dept
            //    }).SelectMany(x => x.DepartmentName.DefaultIfEmpty(), (x, dept) => new
            //    {
            //        x.EmployeeName,
            //        DepartmentName = dept?.Name,
            //    });

            // Using Method After C .Net10



            //foreach (var item in res)
            //{
            //    Console.WriteLine($"{item.EmployeeName} - {item.DepartmentName}");
            //}

            #endregion


            #region Contain
            /*
             * Contains<TSource>(IEnumerable<TSource>, TSource)	
              Determines whether a sequence contains a specified element 
              by using the default equality comparer.*/

            //int[] arrr = [12, 3, 4, 5, 6, 4, 2];
            //Console.WriteLine(arrr.Contains(3));
            //var car = new Car()
            //{
            //    Id = 1,
            //    Make = "Kia",
            //    Model = "Sportage",
            //    ManufactorYear = 1996,
            //    VIN = "WAUEH98E06A527409",
            //    Color = "Mauv",
            //    MaxSpeed = 669
            //};
            //var IsExist = cars.Contains(car);
            //Console.WriteLine(IsExist); // False Compare by reference to Compare by value Implement IEquatable or Implement IEquality Comparer

            // After Implement IEquatable
            //var IsExist = cars.Contains(car);
            //Console.WriteLine(IsExist);

            //int[] indexs = [1, 5, 9, 800, 45];
            //var res=cars.Where(c=> indexs.Contains(c.Id));
            //Repository.PrintCars(res);
            #endregion

            #region Intersect
            /* IEnumerable<TSource>)	
Produces the set intersection of two sequences by 
            using the default equality comparer to compare values.*/



            //int[] arr09 = [1, 3, 4, 5, 60,5,3,2,4,52];
            //int[] arr08 = [5,3,2,6,9,32,545,21];
            //var res=arr09.Intersect(arr08);
            //foreach(var item in res)
            //{
            //    Console.WriteLine(item);
            //}
            List<Car> cars1 = new()
{
    new Car(1, "Ford", "GT", 2005, "WAU3FAFR0BA781507", "Mauv", 298),
    new Car(2, "Mercury", "Mystique", 2000, "1FTEW1C89AK439924", "Turquoise", 224),
    new Car(3, "Volvo", "S40", 2001, "JTHBH1GGXF2728528", "Red", 214),
    new Car(4, "Nissan", "Maxima", 2010, "TRU2D38J191265484", "Fuscia", 182),
    new Car(5, "Ford", "Bravada", 1994, "WAUDH48H19K669503", "Yellow", 240),
    new Car(6, "Mercury", "Mariner", 2005, "5N1AA0NE4N089552", "Puce", 222)
};

            List<Car> cars2 = new()
{ 
         new Car(6, "Mercury", "Mariner", 2005, "5N1AA0NE4N089552", "Puce", 222),
    new Car(7, "Geo", "Tracker", 1995, "3GYFK66N15G436658", "Puce", 259),
    new Car(90, "Ford", "Tracker", 1995, "3GYFK66N15G436658", "Puce", 259),
    new Car(8, "Mitsubishi", "GTO", 1991, "1VWAP7A39EC013320", "Aquamarine", 230),
         new Car(3, "Ford", "S40", 2001, "JTHBH1GGXF2728528", "Orange", 214)
};
            //var res=cars1.Intersect(cars2);
            //    Repository.PrintCars(res);
            // Use IEqualityComparer
            //var res = cars1.Intersect(cars2, new carIEqualityComparer());
            //Repository.PrintCars(res);

            //var res = cars1.Intersect(cars2, new carMakeIEqualityComparer());
            //Repository.PrintCars(res);
            //// ==
            //Console.WriteLine();
            //var res01 = cars1.IntersectBy(cars2.Select(c=>c.Make), c=>c.Make);
            //Repository.PrintCars(res01);

            #region IntersectBy
            /*
             * IntersectBy<TSource,TKey>(IEnumerable<TSource>, IEnumerable<TKey>, Func<TSource,TKey>)	
    Produces the set intersection of two sequences according to a 
            specified key selector function.*/
            //var res = cars1.IntersectBy(cars2.Select(c => c.Make), c => c.Make/*from car1*/);
            //var res = cars1.IntersectBy(cars2.Select(c => new { c.Id,c.Make}), c => new{ c.Id,c.Make});
            //Repository.PrintCars(res);

            #endregion





            #endregion

            #region SequenceEqual
            /*
              SequenceEqual<TSource>(IEnumerable<TSource>, IEnumerable<TSource>)	
              Determines whether two sequences are equal by comparing the elements by
              using the default equality comparer for their type.
            */
            //int[] r1 = { 1, 2, 3, 4, 5 };
            //int[] r2 = { 1, 2, 3, 4, 5 };
            //int[] r3 = { 1, 2, 3, 5, 4 };
            //Console.WriteLine(r1.SequenceEqual(r2));// true
            //Console.WriteLine(r1.SequenceEqual(r3));// false
            // -----------------------------------------------------
            /*
             SequenceEqual<TSource>(IEnumerable<TSource>, IEnumerable<TSource>, 
             IEqualityComparer<TSource>)	
             Determines whether two sequences are equal by comparing their elements
             by using a specified IEqualityComparer<T>.
             */
            //pet pet1 = new pet { Name = "Turbo", Age = 2 };
            //pet pet3 = new pet { Name = "Peanut", Age = 8 };
            //pet pet2 = new pet { Name = "Turbo", Age = 2 };
            //pet pet4 = new pet { Name = "Peanut", Age = 8 };

            // Create two lists of pets.
            //List<pet> pets1 = new List<pet> { pet1, pet3 };
            //List<pet> pets2 = new List<pet> { pet2, pet4 };

            //bool equal = pets1.SequenceEqual(pets2);// false
            //Console.WriteLine(equal);
            //bool equal = pets1.SequenceEqual(pets2,new PetIequaltableComparer());// True
            //Console.WriteLine(equal);

            #endregion

            #region Except
            /*Except<TSource>(IEnumerable<TSource>, IEnumerable<TSource>)	
             Produces the set difference of two sequences by using the default 
            equality comparer to compare values.*/
            //int[] r1 = [1, 2, 3, 4, 5, 6, 7];
            //int[] r2 = [ 5, 6, 7];
            //var res=r1.Except(r2);  
            //foreach(int i in res)
            //    Console.WriteLine(i);
            //var pets1 = new[]
            //            {
            //                new pet { Name = "Turbo", Age = 2 },
            //                new pet { Name = "Peanut", Age = 8 }
            //            };

            // var pets2 = new[]
            //            {
            //                new pet { Name = "Turbo", Age = 2 },
            //                 new pet { Name = "Peanut", Age = 9 }
            //            };
            //var res = pets1.Except(pets2,new PetIequaltableComparer());
            //foreach(var pet in res)
            //    Console.WriteLine(pet);
            // Using ExecptBy
            //var res = pets1.ExceptBy(pets2.Select(p=>new { p.Name,p.Age}),p=> new { p.Name, p.Age });
            //foreach (var pet in res)
            //    Console.WriteLine(pet);


            #endregion

            #region OfType
            /*Filters the elements of an IEnumerable based on a specified type.*/
            //ArrayList fruits = new()
            //                          {
            //                              "Mango",
            //                              "Orange",
            //                              null,
            //                              "Apple",
            //                              3.0,
            //                              "Banana",
            //                              new pet(){Name="mohamed",Age=12},
            //                              new Person(1,"Mohamed")
            //                          };
            //var res = from object item in fruits
            //          where item is string
            //          select (string)item;

            //var res01 = fruits.OfType<Person>();
            //var res02 = fruits.OfType<string>();
            //var res03 = fruits.OfType<pet>();

            // foreach(var item in res03)
            //    Console.WriteLine(item);


            #endregion
        }

        //private static IEnumerable<Car> Enumerable(List<Car> cars, Func<Car, bool> predicate)
        //{
        //    return cars.Where(predicate);
        //}
    }
}
