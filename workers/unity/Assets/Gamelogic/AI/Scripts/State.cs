using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using AI;




[CreateAssetMenu(menuName = "AI/State")]
public class State : ScriptableObject {

	public AIAction[] actions;
	public Transition[] transitions;

	public void UpdateState(AIStateController stateController)
	{
		DoActions(stateController);
		CheckTransitions(stateController);
	}

	private void DoActions(AIStateController stateController)
	{
		if (stateController.currentState.actions.Length == 0)
		{
			return;
		}
		int actionIndex = stateController.CurrentActionIndex % actions.Length;
		//Debug.Log("Current Index: " + stateController.CurrentActionIndex + ", mod op: " + actionIndex);


		if (actions[actionIndex] != null) //HACK - this is sometimes null and i dont know why
		{
			actions[actionIndex].Act(stateController);
		}
	}

	private void CheckTransitions(AIStateController stateController)
	{
		// Unity sometimes clears decions out of states?
		// So this needs to be null checked
		for(int i = 0; i < transitions.Length; i++)
		{
			if (transitions[i].decision != null)
			{
				bool decisionSucceeded = transitions[i].decision.Decide(stateController);
				if (decisionSucceeded)
				{
					stateController.TransitionToState(transitions[i].trueState);
				}

				else
				{
					stateController.TransitionToState (transitions[i].falseState);
				}
			}
		}
	}
	

}
