using System;
using System.Collections.Generic;
using System.Linq;

namespace ComfortWPF.Extensions
{
    public static class EnumerableExtension
    {
        public static T Next<T>(this IEnumerable<T> collection, Predicate<T> where)
        {
            if (collection == null && !collection.Any()) return default;
            var enumerator = collection.GetEnumerator();
            while (enumerator.MoveNext())
            {
                var item = enumerator.Current;
                if (where(item) && enumerator.MoveNext())
                {
                    return enumerator.Current;
                }
            }
            return collection.FirstOrDefault();
        }
    }
}
