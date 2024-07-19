using System;
using System.Collections.Generic;
using Filter;

namespace Example
{
    internal class Program
    {
        public static void Main(string[] args)
        {
            // 物品定义
            Item item1 = new Item("item1", 1, ItemQuality.Normal, ItemType.Equipment);
            Item item2 = new Item("item2", 2, ItemQuality.Epic, ItemType.Equipment);
            Item item3 = new Item("item3", 3, ItemQuality.Normal, ItemType.Consumable);
            Item item4 = new Item("item4", 4, ItemQuality.Legendary, ItemType.Ticket);
            Item item5 = new Item("item5", 5, ItemQuality.Legendary, ItemType.Consumable);

            Item[] items = { item1, item2, item3, item4, item5 };

            
            // 装备定义
            Equipment equp1 = new Equipment("equpment1", 1, ItemQuality.Normal, ItemType.Equipment);
            equp1.ATK = 10;
            Equipment equp2 = new Equipment("equpment2", 2, ItemQuality.Rare, ItemType.Equipment);
            equp2.ATK = 10;
            equp2.DEF = 10;
            Equipment equp3 = new Equipment("equpment3", 3, ItemQuality.Rare, ItemType.Equipment);
            equp3.ATK = 5;
            equp3.SPD = 10;
            Equipment equp4 = new Equipment("equpment4", 4, ItemQuality.Legendary, ItemType.Equipment);
            equp4.ATK = 5;
            equp4.CRIT = 10;
            equp4.DEF = 10;
            
            Equipment[] equipments = { equp1, equp2, equp3, equp4 };
            
            
            // 等级筛选器 筛选2-4级物品
            ItemLevelFilter levelFilter = new ItemLevelFilter(2, 4);
            
            // 类型筛选器 筛选消耗品和门票类型
            ItemTypeFilter typeFilter = new ItemTypeFilter();
            typeFilter.Operator = LogicOperator.Or;
            typeFilter.FlagSet = ItemType.Consumable | ItemType.Ticket;
            
            // 品质筛选器 筛选史诗和传奇品质
            ItemQualityFilter qualityFilter = new ItemQualityFilter();
            qualityFilter.Operator = LogicOperator.Or;
            qualityFilter.FlagSet = ItemQuality.Epic | ItemQuality.Legendary;
            
            // 装备词条筛选器 筛选攻击力和暴击词条
            EquipmentAttributeFilter equipAttriFilter = new EquipmentAttributeFilter();
            equipAttriFilter.Operator = LogicOperator.And;
            equipAttriFilter.FlagSet = ItemAttribute.ATK | ItemAttribute.CRIT;
            
            // **解释器模式**
            // 复合筛选 2-4级的消耗品和门票
            var compositeFilter1 = levelFilter & typeFilter;
            // 复合筛选 2-4级的物品 或 史诗、传说品质的消耗品和门票
            var compositeFilter2 = levelFilter | (typeFilter & qualityFilter);
            // 复合筛选 史诗、传说且拥有攻击力、暴击词条的装备
            var compositeFilter3 = equipAttriFilter & qualityFilter;

            // var compositeFilter = new OrFilter<Item>(levelFilter, new AndFilter<Item>(typeFilter, qualityFilter));
            
            
            // 测试
            Console.WriteLine("============================= result 1 2-4级物品 =============================");
            IEnumerable<Item> result = levelFilter.Filtrate(items);
            LogItems(result);
            
            Console.WriteLine("============================= result 2 消耗品和门票 =============================");
            result = typeFilter.Filtrate(items);
            LogItems(result);
            
            
            Console.WriteLine("============================= result 3 2-4级的消耗品和门票 =============================");
            result = compositeFilter1.Filtrate(items);
            LogItems(result);
            
            
            Console.WriteLine("============================= result 4 2-4级的物品 或 史诗级、传奇品质的消耗品和门票 =============================");
            result = compositeFilter2.Filtrate(items);
            LogItems(result);
            
            
            Console.WriteLine("============================= result 5 史诗、传说且拥有攻击力、暴击词条的装备 =============================");
            result = compositeFilter3.Filtrate(equipments);
            LogItems(result);
        }

        public static void LogItems(IEnumerable<Item> items)
        {
            foreach (var item in items)
            {
                Console.WriteLine(item);
            }
        }
    }
}