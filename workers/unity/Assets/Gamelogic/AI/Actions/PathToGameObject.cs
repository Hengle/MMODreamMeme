using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Unity;

using AI;

[CreateAssetMenu(menuName = "AI/Actions/PathToGameObject")]
public class PathToGameObject : AIAction {

	public float attackRange = 100f;
	override public void Act(AIStateController stateController)
	{
		ApproachGameObject(stateController);
	}

	private void ApproachGameObject(AIStateController stateController)
	{
		// Our target might be null by the time this executes
		if (stateController.TargetGameObject != null)
		{
			// Store location
			Vector3 targetLocation = stateController.TargetGameObject.transform.position;

			//Set destination
			stateController.navMeshAgent.destination = targetLocation;

			// Start agent
			stateController.navMeshAgent.isStopped = false;

			//if (stateController.navMeshAgent.remainingDistance <= (stateController.navMeshAgent.stoppingDistance * attackRange) && !stateController.navMeshAgent.pathPending)
			if (stateController.navMeshAgent.remainingDistance <= (3.5f) && !stateController.navMeshAgent.pathPending)
			{
				stateController.navMeshAgent.isStopped = true;
				
				//Debug.Log("ArrivedAtLocation");
				CompleteAction(stateController);
			}

		}

		else
		{
			CompleteAction(stateController); // finish the action if the game object is null?
		}

	}

}
