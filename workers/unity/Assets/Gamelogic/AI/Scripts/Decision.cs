using System.Collections;
using System.Collections.Generic;
using UnityEngine;


using AI;

public abstract class Decision : ScriptableObject
{

    public abstract bool Decide(AIStateController stateController);
}
