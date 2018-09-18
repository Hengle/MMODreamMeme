using System;
namespace ItemCode
{
    [Flags]
    public enum ItemType
    {
        None = 1,
        TradeGood = 1 << 1,
        Ammo = 1 << 2,
        Craftable = 1 << 3,
        Recycleable = 1 << 4,
        Weapon = 1 << 5,
        Armor = 1 << 6,
        Currency = 1 << 7,

    }

    public enum TradeGoodType
    {
        Ore = 1,
        Plank = 1 << 1,
        Ingot = 1 << 2,
        Wood = 1 << 3,
        Stone = 1 << 4,
        Iron = 1  << 5,
        Gold = 1 << 6, 
        Silver = 1 << 7,
        Steel = 1 << 8,
  
    }

    [System.Serializable]
    public struct IAPair
    {
        ItemStats m_attr;
        int m_value;

        public IAPair(ItemStats attr, int value)
        {
            m_attr = attr;
            m_value = value;
        }
    }

    [System.Serializable]
    public class ItemStatPairClass
    {
        public ItemStats m_ItemStats;
        public int m_value;

        public ItemStatPairClass(ItemStats a_ItemStats, int a_Value)
        {
            m_ItemStats = a_ItemStats;
            m_value = a_Value;
        }

    }

    [Flags]
    public enum WeaponType
    {
        None = 1,
        Sword = 1 << 1,
        Axe = 1 << 2,
        PoleArm = 1 << 3,
        OneHand = 1 << 4,
        TwoHand = 1 << 5,
        Bow = 1 << 6,
        Shield = 1 << 7,
        Missile = 1 << 8
    }

    public enum ArmorType
    {
        None,
        Helm,
        legs,
        Chest
    }

    [Flags]
    public enum DamageType
    {
        None = 0,
        Slashing = 1 << 0,
        Piercing = 1 << 1,
        Crushing = 1 << 2,
        Blunt = 1 << 3,
        Fire = 1 << 4,
        Poison = 1 << 5
    }

    [Flags]
    public enum ItemStats
    {
        None = 0,
        Durability = 1 << 0,
        Damage = 1 << 1,
        Speed = 1 << 2,
        Dexterity = 1 << 3,
        Strength = 1 << 4,
        Agility = 1 << 5,
        Armor = 1 << 6,
        Weight = 1 << 7,
    }
}


