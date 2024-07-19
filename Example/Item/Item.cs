using System;

namespace Example
{
    public class Item
    {
        public string name;
        public int level;
        public ItemQuality quality;
        public ItemType type;

        public Item(string name, int level, ItemQuality quality, ItemType type)
        {
            this.name = name;
            this.level = level;
            this.quality = quality;
            this.type = type;
        }

        public override string ToString()
        {
            return $"[name]: {name}, [level]: {level}, [type]: {type}, [quality]: {quality}";
        }
    }


    /// <summary>
    /// 物品类型
    /// </summary>
    [Flags]
    public enum ItemType
    {
        Consumable = 1,
        Equipment = 1 << 1,
        Ticket = 1 << 2,
    }

    /// <summary>
    /// 物品品质
    /// </summary>
    [Flags]
    public enum ItemQuality
    {
        Normal = 1,
        Rare = 1 << 1,
        Epic = 1 << 2,
        Legendary = 1 << 3,
    }
    
}