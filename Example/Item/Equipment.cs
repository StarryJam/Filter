using System;

namespace Example
{
    public class Equipment : Item
    {
        public int ATK = 0;
        public int DEF = 0;
        public int CRIT = 0;
        public int SPD = 0;

        public Equipment(string name, int level, ItemQuality quality, ItemType type) : base(name, level, quality, type) { }

        public override string ToString()
        {
            var str = base.ToString();
            if (ATK > 0) str += $", [ATK]: {ATK}";
            if (DEF > 0) str += $", [DEF]: {DEF}";
            if (CRIT > 0) str += $", [CRIT]: {CRIT}";
            if (SPD > 0) str += $", [SPD]: {SPD}";

            return str;
        }
    }
    
    /// <summary>
    /// 装备词条分类
    /// </summary>
    [Flags]
    public enum ItemAttribute
    {
        ATK = 1,
        DEF = 1 << 1,
        CRIT = 1 << 2,
        SPD = 1 << 3,
    }
}