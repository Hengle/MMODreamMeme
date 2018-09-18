using System.Collections;
using System.Collections.Generic;
using UnityEngine;


using ItemCode;
using AttackLogic;


[System.Serializable]
[CreateAssetMenu(menuName = "Items/Weapon")]
public class SOWeapon : SOItem {

        public short Durability;
        public AttackData LightAttack;
        public AttackData HeavyAttack;

        [EnumFlags]
        public WeaponType m_weaponType;

        public ItemStatPairClass[] m_ItemStats;

        public float GetDamage()
        {
                
                return 0;
        }

}
