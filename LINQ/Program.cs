using System;
using System.Reflection;
using System.Security.Cryptography.X509Certificates;
using System.Text.RegularExpressions;
using LINQ;
using Newtonsoft.Json.Linq;
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

            //var res = cars.Select((car,Index) => new {Id=Index+1,car.Make,Model=$"{car.Model} - {car.Color}",car.ManufactorYear});

            //foreach ( var i in res)
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
            var employees = new List<Employee>
{
    new Employee("Ahmed", "IT", 8000),
    new Employee("Sara", "HR", 7000),
    new Employee("Omar", "IT", 9000),
    new Employee("Laila", "Finance", 7500),
    new Employee("Hassan", "HR", 7200)
};


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


        }

        private static IEnumerable<Car> Enumerable(List<Car> cars, Func<Car, bool> predicate)
        {
            return cars.Where(predicate);
        }
    }
}
