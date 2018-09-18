using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using AI;



[CreateAssetMenu(menuName="AI/Actions/Action_FindClosestEnemy")]
public class Action_FindClosestEnemy : AIAction {

    override public void Act(AIStateController stateController)
    {
        // Add all coliders to a list of enemies
        Collider[] hitColliders = Physics.OverlapSphere(stateController.transform.position, stateController.AwarenessDistance, 1 << 9);

        // Make a new list to store the components
        List<LivingEntity> listOfEnemyEntities = new List<LivingEntity>();

        // Collect the enemy units
        foreach(Collider col in hitColliders)
        {
            LivingEntity livingEntity = col.GetComponent<LivingEntity>();

            if (livingEntity != null && livingEntity.team != stateController.livingEntity.team)
            {
                listOfEnemyEntities.Add(livingEntity);
            }
        }


        //new array to store sqr mag distances
        float[] distances = new float[listOfEnemyEntities.Count];
        LivingEntity[] entities = listOfEnemyEntities.ToArray();

        Vector3 currentAgentLocation = stateController.transform.position;


        for (int i=0; i < entities.Length; i++)
        {
            float dist = Vector3.SqrMagnitude(currentAgentLocation - entities[i].transform.position);


            //Debug.Log("Distance: " + dist + ", Name: " + entities[i].gameObject.name);

            distances[i] = dist;
        }


        float minValue = Mathf.Min(distances);

        //Debug.Log("Min value was: " + minValue);

        for (int i=0; i< distances.Length; i++)
        {
            if (distances[i] == minValue)
            {
                stateController.TargetGameObject = entities[i].gameObject;
                break;
                
                //break;
                //CompleteAction();
            }
        }

        CompleteAction(stateController);
    }

}
