using System.Collections.Generic;

namespace Filter
{
    public abstract class FilterBase<T> : IFilter<T>
    {
        public abstract bool Filtrate(T item);

        /// <summary>
        /// 筛选器与运算，筛选器a的筛选目标类型可以是筛选器b的筛选目标类型的子类（此时不能交换顺序）。则会组合后的筛选器的目标类型只能是子类
        /// </summary>
        /// <param name="a">筛选器a</param>
        /// <param name="b">筛选器b</param>
        /// <returns></returns>
        public static FilterBase<T> operator &(FilterBase<T> a, IFilter<T> b)
        {
            return new AndFilter<T>(a, b);
        }
        
        /// <summary>
        /// 筛选器或运算，筛选器a的筛选目标类型可以是筛选器b的筛选目标类型的子类（此时不能交换顺序）。则会组合后的筛选器的目标类型只能是子类
        /// </summary>
        /// <param name="a">筛选器a</param>
        /// <param name="b">筛选器b</param>
        /// <returns></returns>
        public static FilterBase<T> operator |(FilterBase<T> a, IFilter<T> b)
        {
            return new OrFilter<T>(a, b);
        }
        
        
    }

        
}