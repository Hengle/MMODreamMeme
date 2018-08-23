using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using AI;

[CreateAssetMenu(menuName="AI/Actions/Action_Attack")]
public class Action_Attack : AIAction {

	override public void Act(AIStateController stateController)
	{
		IssueAttack(stateController);
	}

	void IssueAttack(AIStateController stateController)
	{
		stateController._combatManager.StartAttackSequence(stateController.transform.rotation.eulerAngles.y, stateController._combatManager.selectedAttackData);
		CompleteAction(stateController);
	}
}
