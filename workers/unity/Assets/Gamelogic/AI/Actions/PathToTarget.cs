using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Unity;

using AI;

[CreateAssetMenu(menuName = "AI/Actions/PathToTarget")]
public class PathToTarget : AIAction {
	override public void Act(AIStateController stateController)
	{
		ApproachTargetLocation(stateController);
	}

	private void ApproachTargetLocation(AIStateController stateController)
	{
		//Debug.Log("Pathing");
		//Debug.Log("Pathing to target");
		stateController.navMeshAgent.destination = stateController.TargetLocation;
		stateController.navMeshAgent.isStopped = false;

		if (stateController.navMeshAgent.hasPath) // if the AI doesnt have a path
		{	
		}


		// if (stateController.navMeshAgent.remainingDistance <= stateController.navMeshAgent.stoppingDistance && !stateController.navMeshAgent.pathPending)
		// {
		// 	Debug.Log("ArrivedAtLocation");
		// 	CompleteAction(stateController);
		// }

		if (stateController.navMeshAgent.remainingDistance <= stateController.navMeshAgent.stoppingDistance && !stateController.navMeshAgent.pathPending)
		{
			stateController.navMeshAgent.isStopped = true;
			
			//Debug.Log("ArrivedAtLocation");
			CompleteAction(stateController);
		}


	}

}
