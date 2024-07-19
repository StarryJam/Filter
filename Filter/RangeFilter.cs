using System;

namespace Filter
{
    public class RangeFilter<T> : FilterBase<T> where T : IComparable
    {
        public T Max { get; set; }
        public T Min { get; set; }
        public RangeFilter(){}

        public RangeFilter(T min, T max)
        {
            Max = max;
            Min = min;
        }

        public override bool Filtrate(T item)
        {
            return item.CompareTo(Min) >= 0 && item.CompareTo(Max) <= 0;
        }
    }
    
    
}