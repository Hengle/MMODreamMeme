using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using AI;



[CreateAssetMenu(menuName="AI/Actions/GetTargetsLocation")]
public class GetTargetsLocation : AIAction {

    override public void Act(AIStateController stateController)
    {

        if (stateController.TargetGameObject == null) // Entities may be killed before this is accessed
        {
            CompleteAction(stateController);
        }

        if (stateController.TargetGameObject != null)
        {
            
            Vector3 headingVector = stateController.TargetGameObject.gameObject.transform.position;
            stateController.TargetLocation = headingVector;
            stateController.navMeshAgent.isStopped = true;

            
            CompleteAction(stateController);
        }
    }

}
