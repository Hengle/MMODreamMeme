using System.Collections;
using System.Collections.Generic;
using UnityEngine;


namespace AttackLogic
{

	[CreateAssetMenu]
	public class AttackData : ScriptableObject
	{
		public float AttackTime;
		public float NextAttackPercentage = 0.5f;
		public string UIName = "Ingame rendered Name";

		public float CritMultiplier = 1.0f;
		public float AttackDamage = 4.0f;
		public float AttackRange = 1.0f;
		public AttackData NextAttack;
		public AnimationCurve MaxDamageCurve;
		public int MaxTargets = 4;

		public AnimationCurve ForwardSweep;
		public AnimationCurve RightSweep;

		//public AnimationCurv
	}
}

