using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using BuildingCode;
using ItemCode;

public class Building_Wall : Building {

	public Building_Wall()
	{
		VulnerabilityDamage = DamageType.Crushing | DamageType.Blunt | DamageType.Fire;
        ProtectedDamageType = DamageType.Piercing | DamageType.Slashing | DamageType.Poison;
		Attributes = BuildingAttributes.Combustable;
	}
}
