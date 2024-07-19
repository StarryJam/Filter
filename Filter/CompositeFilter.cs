using System.Collections.Generic;

namespace Filter
{
    // **组合模式**
    public class AndFilter<T> : FilterBase<T>
    {
        public IFilter<T> filter1;
        public IFilter<T> filter2;
        public AndFilter(IFilter<T> filter1, IFilter<T> filter2)
        {
            this.filter1 = filter1;
            this.filter2 = filter2;
        }
        public override bool Filtrate(T item)
        {
            return filter1.Filtrate(item) && filter2.Filtrate(item);
        }
    }
    
    public class OrFilter<T> : FilterBase<T>
    {
        public IFilter<T> filter1;
        public IFilter<T> filter2;
        public OrFilter(IFilter<T> filter1, IFilter<T> filter2)
        {
            this.filter1 = filter1;
            this.filter2 = filter2;
        }
        public override bool Filtrate(T item)
        {
            return filter1.Filtrate(item) || filter2.Filtrate(item);
        }
    }

}