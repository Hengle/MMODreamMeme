using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Unity;

using AI;

[CreateAssetMenu(menuName = "AI/Actions/ChooseRandomPoint")]
public class ChooseRandomPoint : AIAction {
	override public void Act(AIStateController stateController)
	{
		stateController.TargetLocation = RandomLocationAroundAgent(stateController);
		CompleteAction(stateController);
		//MoveToRandomLocation(stateController);
	}

	private Vector3 RandomLocationAroundAgent(AIStateController stateController)
	{
		//return new Vector3();
		Vector3 agentLocation = stateController.transform.position;
		
		Vector3 randomLoc = new Vector3((Random.value - 0.5f) * stateController.SearchDiameter,0,(Random.value - 0.5f) * stateController.SearchDiameter);
		
		return agentLocation + randomLoc; 
	}

}
