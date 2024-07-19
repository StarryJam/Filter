using System;
using System.Collections.Generic;
using Filter;

namespace Example
{
    public class ItemLevelFilter : FilterBase<Item>
    {
        private RangeFilter<int> _rangeFilter = new RangeFilter<int>(0, 0);

        public int Max
        {
            set => _rangeFilter.Max = value;
            get => _rangeFilter.Max;
        }
        
        public int Min
        {
            set => _rangeFilter.Min = value;
            get => _rangeFilter.Min;
        }
        public ItemLevelFilter(int min = 0, int max = Int32.MaxValue)
        {
            Max = max;
            Min = min;
        }
        public override bool Filtrate(Item item)
        {
            return _rangeFilter.Filtrate(item.level);
        }
    }

    public class ItemTypeFilter : FilterBase<Item>
    {
        private FlagFilter<ItemType> _typeFilter = new FlagFilter<ItemType>();
        public LogicOperator Operator
        {
            set => _typeFilter.@operator = value;
            get => _typeFilter.@operator;
        }

        public ItemType FlagSet
        {
            get => (ItemType)_typeFilter.Filter;
            set => _typeFilter.Filter = value;
        }
        
        public override bool Filtrate(Item item)
        {
            return _typeFilter.Filtrate(item.type);
        }
    }
    
    
    public class ItemQualityFilter : FilterBase<Item>
    {
        private FlagFilter<ItemQuality> _qualityFilter = new FlagFilter<ItemQuality>();
        public LogicOperator Operator
        {
            set => _qualityFilter.@operator = value;
            get => _qualityFilter.@operator;
        }

        public ItemQuality FlagSet
        {
            get => (ItemQuality)_qualityFilter.Filter;
            set => _qualityFilter.Filter = value;
        }
        
        public override bool Filtrate(Item item)
        {
            return _qualityFilter.Filtrate(item.quality);
        }
    }

    public class EquipmentAttributeFilter : FilterBase<Equipment>
    {
        private FlagFilter<ItemAttribute> _attributeFilter = new FlagFilter<ItemAttribute>();
        
        public LogicOperator Operator
        {
            set => _attributeFilter.@operator = value;
            get => _attributeFilter.@operator;
        }

        public ItemAttribute FlagSet
        {
            get => (ItemAttribute)_attributeFilter.Filter;
            set => _attributeFilter.Filter = value;
        }
        
        private ItemAttribute GetAttributes(Equipment equp)
        {
            ItemAttribute attrs = 0;
            if (equp.ATK > 0)
            {
                attrs |= ItemAttribute.ATK;
            }

            if (equp.DEF > 0)
            {
                attrs |= ItemAttribute.DEF;
            }
            
            if (equp.CRIT > 0)
            {
                attrs |= ItemAttribute.CRIT;
            }
            
            if (equp.SPD > 0)
            {
                attrs |= ItemAttribute.SPD;
            }

            return attrs;
        }

        public override bool Filtrate(Equipment item)
        {
            return _attributeFilter.Filtrate(GetAttributes(item));
        }
    }
}