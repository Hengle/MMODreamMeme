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

    //public int Team;
    public float AwarenessDistance = 30;


     public Vector3 TargetLocation;
     public GameObject TargetGameObject;
    [HideInInspector] public Vector3 HomeLocation;
    [HideInInspector] public Transform LastKnownTarget;
    [HideInInspector] public NavMeshAgent navMeshAgent;

    [HideInInspector] public int CurrentActionIndex = 0;
    [HideInInspector] public CombatManager _combatManager;
    [HideInInspector] public LivingEntity livingEntity;
    
    void Start()
    {
        Debug.Log("Calling AI start");

        // Store agent
        navMeshAgent = GetComponent<NavMeshAgent>();

        // Store living entity
        livingEntity = GetComponent<LivingEntity>();
        
        // Get our combat manager
        _combatManager = GetComponent<CombatManager>();

        // Enabling Ai agent here? Probably don't wanna do this
        HomeLocation = transform.position;
        TargetLocation = HomeLocation;
        
        // Initialize the AI?
        SetupAI();



        
    }

    void Update()
    {
        //Debug.Log("dicks");
    }

    public bool aiActive = false;

    // Use this for initialization
    void Awake()
    {

    }

    

    public void SetupAI()
    {
        aiActive = true;
        navMeshAgent.enabled = aiActive;

        // Begin the slow update invoke
        InvokeRepeating("SlowUpdate", 0, 0.4f);
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


        //Debug.Log(currentState == null);


    }


    public float SearchDiameter = 300;
    

    

}
