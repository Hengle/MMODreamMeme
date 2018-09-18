using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimationStateController : StateMachineBehaviour {

	public float Speed;

	public Animator anim;

	public CharacterController m_controller;
	public CombatManager m_CombatMnaager;


    // OnStateEnter is called before OnStateEnter is called on any state inside this state machine
	override public void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex) {

		m_controller = animator.gameObject.GetComponentInParent<CharacterController>();
		m_CombatMnaager = animator.gameObject.GetComponentInParent<CombatManager>();
		

		if (m_controller == null)
		{
			Debug.Log("ANIMATING PAWN DOES NOT HAVE A CHARACTER CONTROLLER");
		}

		if (m_CombatMnaager == null)
		{
			Debug.Log("ANIMATING PAWN HAS FAILED TO GET COMBAT MANAGER.");
		}
	
	}


	// OnStateUpdate is called before OnStateUpdate is called on any state inside this state machine
	//override public void OnStateUpdate(Animator animator, AnimatorStateInfo stateInfo, int layerIndex) {
	//
	//}

	override public void OnStateUpdate(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
	{
		animator.SetFloat("Speed", Vector3.Magnitude(m_controller.velocity));

		Debug.Log(m_controller.velocity);
		Debug.Log("animStateIsUpdating" + (m_controller == null));


		// Just do a bunch of random inptus to get this framework first

		if (Input.GetMouseButtonDown(0))
		{
			Debug.Log("Leftclicked from anim controller");
		}
	}

	// OnStateExit is called before OnStateExit is called on any state inside this state machine
	//override public void OnStateExit(Animator animator, AnimatorStateInfo stateInfo, int layerIndex) {
	//
	//}

	// OnStateMove is called before OnStateMove is called on any state inside this state machine
	//override public void OnStateMove(Animator animator, AnimatorStateInfo stateInfo, int layerIndex) {
	//
	//}

	// OnStateIK is called before OnStateIK is called on any state inside this state machine
	//override public void OnStateIK(Animator animator, AnimatorStateInfo stateInfo, int layerIndex) {
	//
	//}

	// OnStateMachineEnter is called when entering a statemachine via its Entry Node
	//override public void OnStateMachineEnter(Animator animator, int stateMachinePathHash){
	//
	//}

	// OnStateMachineExit is called when exiting a statemachine via its Exit Node
	//override public void OnStateMachineExit(Animator animator, int stateMachinePathHash) {
	//
	//}
}
