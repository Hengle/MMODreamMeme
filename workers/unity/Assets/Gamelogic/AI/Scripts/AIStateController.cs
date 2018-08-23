using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using UnityEngine.AI;
using AI;

public class AIStateController : MonoBehaviour
{

    // AI brain - without this most of it doesnt work
    public AIBrain brain;
    public State currentState;
    public State remainState;

    public int Team;
    public float AwarenessDistance = 30;


    [HideInInspector] public Vector3 HomeLocation;
     public Vector3 TargetLocation;
     public GameObject TargetGameObject;
    [HideInInspector] public Transform LastKnownTarget;
    [HideInInspector] public NavMeshAgent navMeshAgent;

    [HideInInspector] public int CurrentActionIndex = 0;
    [HideInInspector] public CombatManager _combatManager;
    

    private bool aiActive = false;

    // Use this for initialization
    void Awake()
    {
        navMeshAgent = GetComponent<NavMeshAgent>();

        // Enabling Ai agent here? Probably don't wanna do this
        HomeLocation = transform.position;
        TargetLocation = HomeLocation;

        // Delay the start of the AI as seen below
        int startFrame = Random.Range(1, 100);
        startRoutine =  StartCoroutine(TestEnumer(startFrame));

        // Set our combat manager value;
        _combatManager = GetComponent<CombatManager>();
    }

    // This is dumb bullshit to stagger all AI across random frames when they update
    // This should be formally handled
    Coroutine startRoutine;
    IEnumerator TestEnumer(int frameStart)
    {
        while(true)
        {            
            //Debug.Log(Time.frameCount);
            if(frameStart <= Time.frameCount)
            {
                SetupAI();
                InvokeRepeating("SlowUpdate", 0, 0.25f); //HACK - update AI slowly
                StopCoroutine(startRoutine);
                yield return null; // Someone rewrite this for the love of god.
            }

            else 
            {
                yield return 0;
            }
        }
    }
    

    public void SetupAI()
    {
        // Se tthe AI to true by default
        aiActive = true;
        
        // Set the navmesh to be enabled if the ai is enabled
        navMeshAgent.enabled = aiActive;

        // Upload this agent to thebrain
        //brain.AddNewAgent(this);

        // Pick a random team to join
        Team = Random.Range(1,5);
    }

    public void TransitionToState(State nextState)
    {
        //Debug.Log("Performing state transition");
        if (nextState != remainState)
        {
            CurrentActionIndex = 0; // Make sure we set the action index to 0 to resume Ai on new states
            currentState = nextState;
        }

    }



    //Update is called once per frame


    void SlowUpdate()
    {
        if (!aiActive)
        {
            return;
        }

        else
        {
            if (currentState != null)
            {
                //Debug.Log("AIStateController: Updating state..");
                currentState.UpdateState(this);
            }


            else
            {
                //Debug.Log("WARNING - AI is active, and current state is null");
            }
        }

        if (Input.GetKeyDown(KeyCode.F))
        {
            print(brain.listOfFarms.Count);
        }

        //Debug.Log(currentState == null);


    }


    public float SearchDiameter = 300;
    

    

}
