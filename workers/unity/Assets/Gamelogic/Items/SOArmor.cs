using System.Collections;
using System.Collections.Generic;
using UnityEngine;


using ItemCode;
[System.Serializable]
[CreateAssetMenu(menuName = "Items/Armor")]
public class SOArmor : SOItem {

        

        //[EnumFlags]
        public ArmorType m_ArmorType;

        public ItemStatPairClass[] m_ItemStats;

}
