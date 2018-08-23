using System.Collections;
using System.Collections.Generic;
using UnityEngine;


using System.Diagnostics;

using AI;

[CreateAssetMenu(menuName = "AI/Decision_EnemyClose")]
public class Decision_EnemyClose : Decision {


	override public bool Decide(AIStateController stateController)
	{
		//int i = 10;

		//Collider[] hitColliders = Physics.OverlapSphere(stateController.transform.position, stateController.AwarenessDistance, 9);



		
		return EnemyClose(stateController);
	}

	private bool EnemyClose(AIStateController stateController)
	{
		//Stopwatch watch = new Stopwatch();

		Collider[] hitColliders = Physics.OverlapSphere(stateController.transform.position, stateController.AwarenessDistance, 1 << 9);

		//UnityEngine.Debug.Log("Found: " + hitColliders.Length + ", time: " + watch.Elapsed );
		if (hitColliders.Length != 0)
		{
			foreach(Collider col in hitColliders)
			{
				int coliderTeam = col.GetComponent<AIStateController>().Team;

				if (coliderTeam != stateController.Team)
				{
					//UnityEngine.Debug.Log(col.name);
					stateController.TargetGameObject = col.gameObject; //HACK -  Set the Current target as this new enemy - this shouldnt be here
					return true;
				}
			}

			return false;
		}
		
		return false;
	}
}
