using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using AttackLogic;

public class CombatManager : MonoBehaviour
{

    public AttackData selectedAttackData;

    public bool CurrentlyAttacking = false;

    public float AttackOriginHeight = 0.0f;

    //private PlayerInputManager2 playerInput;
    private CharacterMovementController playerCharacterController;




    void OnEnable()
    {
        //playerInput = GetComponent<PlayerInputManager2>();
        //playerCharacterController = GetComponent<CharacterMovementController>();
    }

    // Update is called once per frame
    void Update()
    {

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

    // Attack direction
    Quaternion _AttackDirection;
    float _AttackBearing;
    LivingCharacter[] hitCharacters;
    List<EntityWithHealth> hitCharacters2 = new List<EntityWithHealth>();

    // This is called once at the start of the sweep sequence
    public void StartAttackSequence(float attackBearing, AttackData inputAttackData)
    {
        if (!CurrentlyAttacking)
        {
            // Set up the attack directions
            _AttackDirection = UnityEngine.Quaternion.Euler(Vector3.up * attackBearing); // quaternion to vector 3 is a bit janky right? refactor?
            _AttackBearing = attackBearing;

            // Set the attacks time data
            CurTime = 0;
            maxTime = selectedAttackData.AttackTime;
            NextAttackPercentage = selectedAttackData.NextAttackPercentage;


            currAttack = inputAttackData;
            CurrentlyAttacking = true; // This will be hit in Update to actually process the attack sweeping
            attackStartingPosition = this.transform.position;

            // Clear any hit targets
            hitCharacters2.Clear();
        }
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
        // Incriment current time through attack to get values from curve
        CurTime += Time.deltaTime;

        // Get value from curve and modify based on range
        Vector3 CastEnd = (_AttackDirection * VectorFromCurves(currAttack.ForwardSweep, currAttack.RightSweep, AttackPercentage())) * currAttack.AttackRange;
        CastEnd += transform.position + (Vector3.up * AttackOriginHeight);
        Vector3 CastStart = transform.position + (Vector3.up*AttackOriginHeight);

        


        //playerCharacterController.AttackMove(Offset, attackStartingPosition, VectorFromCurves(currAttack.ForwardSweep, currAttack.RightSweep, 1));
        //playerCharacterController.AttackMove(Offset, attackStartingPosition); // Keep this here 
    
        // Draw the sweep just for debug
        Debug.DrawLine(CastStart, CastEnd, Color.red);


        //Perform the trace
        RaycastHit hit;
        if (Physics.Linecast(CastStart, CastEnd, out hit, 1<<9))
        {
            EntityWithHealth entity = hit.collider.gameObject.GetComponent<EntityWithHealth>();

            if (entity != null)
            {
                if (hitCharacters2.Contains(entity) == false)
                {
                    hitCharacters2.Add(entity);
                    entity.DecrimentHealth(currAttack.AttackDamage);
                }
            }
            
            //hitCharacters2.Add(hit.transform.gameObject.GetComponent<LivingCharacter>())   
            //Debug.Log("I hit something");
        }


        if (CurTime > maxTime)
        {
            ClearAttack();
        }

    }

    void CheckForNextAttack()
    {
        if (currAttack.NextAttack != null)
        {
            //if (AttackPercentage() > NextAttackPercentage && playerInput.AttackKeyDown) // This is supposed to assume you can hold the mouse down
            if (AttackPercentage() > NextAttackPercentage)
            {
				//currAttack = currAttack.NextAttack;
                StartAttackSequence(_AttackBearing, currAttack.NextAttack);
            }
        }
    }

    void CheckForRollCancle()
    {

    }

    void ClearAttack()
    {
        CurrentlyAttacking = false;
        //playerCharacterController.canRotate = true;

    }

    Vector3 VectorFromCurves(AnimationCurve Forward, AnimationCurve Right, float curTime)
    {
        return new Vector3(Right.Evaluate(curTime), 0, Forward.Evaluate(curTime));
    }

    void OnDrawGizmos()
    {

    }


}
