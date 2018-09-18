using System;
using System.Collections.Generic;
using System.Collections;
//using ItemAttributes;

using Unity;
using UnityEngine;

//using ItemAttributes;

using ItemCode;



namespace ItemCode
{

    [System.Serializable]
    public struct RealItem
    {
        public ItemType m_ItemType;
        public float m_ItemVolume;
        public short m_stackCount;
        //public WeaponType m_WeapoNType;
        //public DamageType m_DamageType;

        public IAPair[] m_AttributesAndValues;


        public RealItem(ItemType itemType, short stackCount, float itemVolume, IAPair[] attributeArray)
        {
            m_stackCount = stackCount;
            m_ItemVolume = itemVolume;
            m_ItemType = itemType;
            //m_WeapoNType = wepaonType;
            //m_DamageType = damageType;
            m_AttributesAndValues = attributeArray;
        }

    }


    //[CreateAssetMenu(menuName = "Items/Item")]
    public class BaseItemClass : ScriptableObject
    {
        public short m_Volume = 15;
        public ItemType itemType;
        public bool m_MaintainsState = false;
        public short m_stackCount = 1;
    }
    
    //[CreateAssetMenu(menuName = "Items/CraftingGood")]
    public class CraftingMaterial : BaseItemClass
    {
        public TradeGoodType m_TradeGood;
        public CraftingMaterial(ItemType a_ItemType, short a_VolumeM3, bool a_MaintainsState, short a_StackCount, TradeGoodType a_TradeGoodType)
        {
            m_MaintainsState = a_MaintainsState;
            m_stackCount = a_StackCount;
            itemType = a_ItemType;
            m_TradeGood = a_TradeGoodType;
        }
    }

    public class WeaponItemClass : BaseItemClass
    {
        public WeaponType m_weaponType;
        public ItemStats modifier;

        public Dictionary<ItemStats, short> weaponState = new Dictionary<ItemStats, short>();
        //public IAPair[] m_Modifiers;
        //public IAPair asd;
        public WeaponItemClass(WeaponType a_WeaponType, short a_VolumeM3, short a_StackCount, bool a_HasState, Dictionary<ItemStats, short> a_wepaonAttributes)
        {
            m_weaponType = a_WeaponType;
            m_Volume = a_VolumeM3;
            m_stackCount = a_StackCount;
            m_MaintainsState = a_HasState;
            weaponState = a_wepaonAttributes;
        }
    }

    public class ArmorItemClass : BaseItemClass
    {
        public ArmorType m_ArmorType;

        public Dictionary<ItemStats, short> armorState = new Dictionary<ItemStats, short>();
    }


    
}