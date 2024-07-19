using System;

namespace Filter
{
    public class FlagFilter<T> : FilterBase<T> where T : Enum
    {
        public T Filter { get; set; }
        public LogicOperator @operator = LogicOperator.Or;

        public FlagFilter(){}

        public FlagFilter(T filter)
        {
            this.Filter = filter;
        }

        public override bool Filtrate(T item)
        {
            // 将传入的元素与筛选码做位与运算，然后根据运算结果和运算符类型返回筛选结果
            var result = Convert.ToInt32(item) & Convert.ToInt32(Filter);
            if (@operator == LogicOperator.And)
            {
                return result == Convert.ToInt32(Filter);
            }
            else
            {
                return result != 0;
            }
        }
    }

    /// <summary>
    /// 逻辑运算符，决定不同筛选标签之间是与还是或的关系
    /// </summary>
    public enum LogicOperator
    {
        And,
        Or
    }
}