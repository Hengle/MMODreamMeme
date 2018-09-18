using UnityEngine;

using System.Collections;
using System.Collections.Generic;

using ItemCode;

[CreateAssetMenu(menuName = "Items/Item")]
    public class SOItem : ScriptableObject
    {
        public string Name;
        public string Description;
        public short m_CurrentStackCount = 1;
        public short m_Volume = 15;
        public bool m_MaintainsState = false;

        [EnumFlags]
        public ItemType itemType;
    }