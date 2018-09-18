	using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Unity;

using AI;

[CreateAssetMenu(menuName = "AI/WalkAroundRandomly")]
public class WalkAroundRandomly : AIAction {
	override public void Act(AIStateController stateController)
	{
		MoveToRandomLocation(stateController);
	}

	private Vector3 startPos;
	//public float searchDiameter = 3000;


	private void MoveToRandomLocation(AIStateController stateController)
	{
		stateController.navMeshAgent.destination = stateController.TargetLocation;
		stateController.navMeshAgent.isStopped = false;


		if (stateController.navMeshAgent.hasPath) // if the AI doesnt have a path
		{
			//Debug.Log("I have a path");	
		}

		else
		{
			//Debug.Log("I do not have a path");
		}

		if (stateController.navMeshAgent.remainingDistance <= stateController.navMeshAgent.stoppingDistance && !stateController.navMeshAgent.pathPending)
		{
			Debug.Log("ArrivedAtLocation");

			CompleteAction(stateController);
			
			//Debug.Log("Arrived at Location, finding new location");
			stateController.TargetLocation = GetRandomPoint() + stateController.transform.position;
			Debug.Log("Found new pos: " + stateController.TargetLocation);
		}
	}

	private float searchDiameter = 500;
	private Vector3 GetRandomPoint()
	{
		//return new Vector3();
		return new Vector3((Random.value - 0.5f) * searchDiameter,0,(Random.value - 0.5f) * searchDiameter);
	}

}
