using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;

namespace ComfortWPF.Extensions
{
    public static class ListExtension
    {
        public static ObservableCollection<T> ToObservableCollection<T>(this List<T> list)
        {
            return new ObservableCollection<T>(list);
        }

        public static ObservableCollection<T> ToObservableCollection<T>(this IQueryable<T> query)
        {
            return new ObservableCollection<T>(query.ToList());
        }
    }
}
