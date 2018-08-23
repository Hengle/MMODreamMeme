using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using AI;

public class EnemyTargetVisable : Decision {

	public override bool Decide(AIStateController stateController)
	{
		bool TargetVisable = LookForClosestEnemy(stateController);
		return TargetVisable;
	}

	private bool LookForClosestEnemy(AIStateController stateController)
	{
		
		return false;
	}
}
