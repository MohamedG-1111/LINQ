using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LINQ.CustomLinqMethod
{
    public static class Extensions
    {
        private static Random random = new Random();
        public static IEnumerable<TSource> Paginate<TSource>(this IEnumerable<TSource> source,
            int Page = 1,
            int PageSize = 10)  
        {
            if (source == null)
                throw new ArgumentNullException(nameof(source));
            if (PageSize <= 0)
                PageSize = 10;
            if(Page < 0)
                Page = 1;

            return Enumerable.Skip(source, (Page-1)*PageSize).Take(PageSize);
        }

        public static IEnumerable<TSource> PaginateV02<TSource>(this IEnumerable<TSource> source,
        int? Page,
        int ?PageSize)
        {
            if (source == null)
                throw new ArgumentNullException(nameof(source));
            if (!PageSize.HasValue)
                PageSize = 10;
            if (!Page.HasValue)
                Page = 1;

            return Enumerable.Skip(source, (Page.Value - 1) * PageSize.Value).Take(PageSize.Value);
        }
        public static IEnumerable<TSource> PaginateWithWhere<TSource>(this IEnumerable<TSource> source,
       Func<TSource, bool> predicate,
       int? Page,
       int? PageSize)
        {
            if(source == null)
                throw new ArgumentNullException(nameof(source));
            var result = Enumerable.Where(source,predicate);
          return  result.PaginateV02(Page,PageSize);
        }
        public static TSource RandomElement<TSource>(this IEnumerable<TSource> source,
              Func<TSource, bool> predicate)
        {
            if (source == null)
                throw new ArgumentNullException(nameof(source));
            if(predicate == null)
                throw new ArgumentNullException(nameof(predicate));
            var res = source.Where(predicate);
            return res.ElementAt(random.Next(0,res.Count()));

        }




        public static void print<TSource>(this IEnumerable<TSource> source)
        {
            foreach(TSource item in source)
            {
                Console.WriteLine(item);
            }
            Thread.Sleep(1000);
        }
    }
}
