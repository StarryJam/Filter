using System.Collections.Generic;

namespace Filter
{
    public interface IFilter<in T>
    {
        bool Filtrate(T item);
        
    }

    public static class FilterExpansion
    {
        public static List<T> Filtrate<T>(this IFilter<T> filter, IEnumerable<T> items)
        {
            List<T> result = new List<T>();
            foreach (var item in items)
            {
                if(filter.Filtrate(item)) result.Add(item);
            }

            return result;
        }
    }
}