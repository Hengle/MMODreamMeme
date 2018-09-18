using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using AttackLogic;

public class CombatManager : MonoBehaviour
{

    public AttackData selectedAttackData;

    public SOWeapon MainHand;

    public bool CurrentlyAttacking = false;
    public float AttackOriginHeight = 0.0f;
    //private PlayerInputManager2 playerInput;
    private CharacterMovementController playerCharacterController;
    private LivingEntity thisEntity;
    private Inventory myInventory;






    void OnEnable()
    {
        //playerInput = GetComponent<PlayerInputManager2>();
        //playerCharacterController = GetComponent<CharacterMovementController>();
        thisEntity = GetComponent<LivingEntity>();
        myInventory = GetComponent<Inventory>();
        
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
    List<LivingEntity> hitCharacters2 = new List<LivingEntity>();

    // This is called once at the start of the sweep sequence
    public void StartAttackSequence(float attackBearing)
    {
        if (!CurrentlyAttacking)
        {
            // Set up the attack directions
            _AttackDirection = UnityEngine.Quaternion.Euler(Vector3.up * attackBearing); // quaternion to vector 3 is a bit janky right? refactor?
            _AttackBearing = attackBearing;

            // Set the attacks time data
            CurTime = 0;

            // Set our selectedAttack to what is in our main hand
            selectedAttackData = MainHand.LightAttack;

            // Set the attack time and percentage data;
            maxTime = selectedAttackData.AttackTime;
            NextAttackPercentage = selectedAttackData.NextAttackPercentage;


            currAttack = selectedAttackData;
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

    // All damage shoudl go through here
    void DealCombatDamageToEntity(LivingEntity entity)
    {
        
        entity.DecrimentHealth(MainHand.GetDamage());
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
            LivingEntity entity = hit.collider.gameObject.GetComponent<LivingEntity>();

            if (entity != null)
            {
                Debug.Log((entity == null) + ", " + (thisEntity == null));
                if (entity.team != thisEntity.team)
                {
                    if (hitCharacters2.Contains(entity) == false)
                    {
                        hitCharacters2.Add(entity);
                        DealCombatDamageToEntity(entity);
                    }
                }
            }

            else

            {

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
                currAttack = currAttack.NextAttack;
				//currAttack = currAttack.NextAttack;
                StartAttackSequence(_AttackBearing);
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
