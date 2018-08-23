using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using AttackLogic;

public class DEPRECIATEDComboManager : MonoBehaviour {

	public AttackData myAttackData;

	public bool CurrentlyAttacking = false;

	private PlayerInputManager2 playerInput;
	private CharacterMovementController playerCharacterController;



	

	// Use this for initialization
	void Start () {
		//AttackData2 myData = ScriptableObject.CreateInstance<AttackData2>();
	}

	void OnEnable()
	{
		playerInput = GetComponent<PlayerInputManager2>();
		playerCharacterController = GetComponent<CharacterMovementController>();
	}

	// Update is called once per frame
	void Update () {

		if (playerInput.AttackKeyDown && !CurrentlyAttacking)
		{
			StartAttackSequence(myAttackData);
		}

		if (CurrentlyAttacking)
		{
			SweepTransformOverTime(); // Process physics for attack
			CheckForNextAttack(); // Exit attack if player input is found
			CheckForRollCancle(); // Exit if the player attempts to roll
		}
		
	}

	// Weapon data stats
	float CurTime = 0;
	float maxTime = 0;
	float NextAttackPercentage = 0;
	AttackData currAttack;
	Vector3 attackStartingPosition;

	void StartAttackSequence(AttackData inputData)
	{
		// reset timer
		CurTime = 0;
		maxTime = inputData.AttackTime;
		NextAttackPercentage = inputData.NextAttackPercentage;
		currAttack = inputData;
		CurrentlyAttacking = true;
		attackStartingPosition = this.transform.position;
	}

	float AttackPercentage()
	{
		if (CurrentlyAttacking == true)
		{
			return CurTime / maxTime;
		}

		return -1f;
	}

	void SweepTransformOverTime()
	{
		CurTime += Time.deltaTime;


		Vector3 Offset = this.transform.rotation *  VectorFromCurves(currAttack.ForwardSweep, currAttack.RightSweep, AttackPercentage());


		//this.transform.position = startPos + Offset;

		//playerCharacterController.AttackMove(Offset, attackStartingPosition, VectorFromCurves(currAttack.ForwardSweep, currAttack.RightSweep, 1));
		playerCharacterController.AttackMove(Offset, attackStartingPosition);
	

		if (CurTime > maxTime)
		{
			ClearAttack();
		}

	}

	void CheckForNextAttack()
	{
		if (currAttack.NextAttack != null)
		{
			if (AttackPercentage()>NextAttackPercentage && playerInput.AttackKeyDown)
			{
				StartAttackSequence(currAttack.NextAttack);
			}
		}

	}

	void CheckForRollCancle()
	{

	}

	void ClearAttack()
	{
		CurrentlyAttacking = false;
		playerCharacterController.canRotate = true;

	}

	Vector3 VectorFromCurves(AnimationCurve Forward, AnimationCurve Right, float curTime)
	{
		return new Vector3(Right.Evaluate(curTime), 0, Forward.Evaluate(curTime));
	}

	IEnumerator AttackTimer(AttackData inputAttack) // Pass in the attack held on the item, or whatever
	{
		print("Playing Attack...");
		print("My attack name is: " + inputAttack.UIName);

		if (inputAttack.NextAttack != null) // If this attack has a follow up action
		{
			print("Found Next attack, queing");
			yield return new WaitForSeconds(inputAttack.AttackTime); // Start cooldown timer
			StartCoroutine(AttackTimer(inputAttack.NextAttack)); // Start next atatck sequence
			yield break; // Exit
		}

		else
		{
			print("Found no follow up attack, exiting.");
			yield break; // Exit
		}
	}
}
