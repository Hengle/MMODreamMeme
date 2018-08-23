using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using AI;
public class Farm : MonoBehaviour {

	public AIBrain brain;

	void Start()
	{
		brain.AddNewFarm(this);
	}
}
