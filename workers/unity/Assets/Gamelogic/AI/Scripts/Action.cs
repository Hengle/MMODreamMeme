using System.Collections;
using System.Collections.Generic;
using UnityEngine;


namespace AI
{
    public abstract class AIAction : ScriptableObject {
        public abstract void Act (AIStateController stateController);
        public void CompleteAction(AIStateController stateController)
        {
            stateController.CurrentActionIndex++;
            //Debug.Log("Action completed: " + stateController.CurrentActionIndex);
        }
    }
}
