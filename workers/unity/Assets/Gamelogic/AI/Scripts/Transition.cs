using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using AI;

[System.Serializable]
public class Transition {


	public Decision decision;
	public State trueState;
	public State falseState;

	public bool Decide()
	{
		return false;
	}
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
