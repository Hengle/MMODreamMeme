using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using AI;



[CreateAssetMenu(menuName="AI/Actions/FindLocationAwayFromTarget")]
public class FindLocationAwayFromTarget : AIAction {

    override public void Act(AIStateController stateController)
    {
        

        if (stateController.TargetGameObject == null) // Entities may be killed before this is accessed
        {
            CompleteAction(stateController);
        }

        if (stateController.TargetGameObject != null)
        {
            //Debug.Log("Finding location away from enemy");
            Vector3 headingVector = stateController.transform.position - stateController.TargetGameObject.gameObject.transform.position;
            headingVector.Normalize();

            stateController.TargetLocation = (headingVector * 10) + stateController.transform.position;
            stateController.navMeshAgent.isStopped = true;

            
            CompleteAction(stateController);
        }
    }

}
