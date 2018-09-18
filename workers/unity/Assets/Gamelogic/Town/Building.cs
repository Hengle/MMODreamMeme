using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using BuildingCode;

using ItemCode;

namespace BuildingCode
{

    public class Building : MonoBehaviour, IBuildingInterface
    {

        public Town owningTown;

        [HideInInspector] public DamageType VulnerabilityDamage;
        [HideInInspector] public DamageType ProtectedDamageType;
        [HideInInspector] public BuildingAttributes Attributes;

        
        
        public Building()
        {
        }

        void OnAwake()
        {
        }

        public bool AmABuilding()
        {
            return true;
        }
    }


    [Flags] public enum BuildingAttributes
    {
        None = 0,
        Repairable = 1 << 0,
        Combustable = 1 << 1,
    }



}