using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using AI;


[CreateAssetMenu(menuName = "AI/DecideTrue")]
public class DecideTrue : Decision {


	override public bool Decide(AIStateController stateController)
	{
		return true;
	}
}
