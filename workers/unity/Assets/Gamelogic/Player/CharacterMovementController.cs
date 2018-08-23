using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using Improbable;
using Improbable.Player;
//using Improbable.Core;
using Improbable.Worker;
using Improbable.Unity.Visualizer;


public class CharacterMovementController : MonoBehaviour
{

    [Require] private PlayerRotation.Reader PlayerRotationReader;

    [Require] private PlayerInput.Reader PlayerInputReader;


	public float local_HorizontalInput;
	public float local_VerticalInput;
	public float local_rotationBearing;



    //Rigidbody playerRigidBody;
    CharacterController unityCharacterController;

    public float moveSpeed = 180;

    // Use this for initialization
    void Start()
    {
        transform.position = Vector3.up * 10;

    }

    void OnEnable()
    {
        unityCharacterController = GetComponent<CharacterController>();
        //playerRigidBody = GetComponent<Rigidbody>();
    }



    void Update()
    {
        MoveClientAndServer(); // Move this pawn on server and locally
        RotateTowardMovement();
    }

	// Called per frame 
	// Simulates player input locally AND on the server
    public void MoveClientAndServer() 
    {
		// Move entity locally
		//MoveAndStrafe(PlayerInputReader.Data.joystick.yAxis, PlayerInputReader.Data.joystick.xAxis);
		MoveAndStrafe(local_VerticalInput, local_HorizontalInput, local_rotationBearing);

		// Move entity on the worker who can write to its position
		//MoveAndStrafe(PlayerInputReader.Data.joystick.yAxis, PlayerInputReader.Data.joystick.xAxis);
    }


    public void MoveAndStrafe(float forwardInput, float rightInput, float rotationBearing)
    {
            //transform.position.x = PlayerRotationReader.Data.bearing * Vector3.right;
            Quaternion PlayerCameraQuaternion = UnityEngine.Quaternion.Euler(Vector3.up * rotationBearing);



            //PlayerRotationReader.Data.bearing;


            Vector3 rightVector = (PlayerCameraQuaternion * Vector3.right) * rightInput * moveSpeed * Time.deltaTime;

            Vector3 forwardVector = (PlayerCameraQuaternion * Vector3.forward) * forwardInput * moveSpeed * Time.deltaTime;

            Vector3 gravityVector = new Vector3();
            bool _isGrounded = false;
            //Gizmos.DrawSphere(unityCharacterController.height/2 * Vector3.up, 1);
            //_isGrounded = Physics.CheckSphere(transform.position + ((unityCharacterController.height/2) * -Vector3.up), groundCheckDistance, LayerMask.NameToLayer("Default"), QueryTriggerInteraction.Ignore);
            LayerMask layermask = 0 << 1;
            _isGrounded = Physics.CheckSphere(transform.position, 1, 1 << 8, QueryTriggerInteraction.Ignore);

            // If they are grounded AND moving downward 
            if (_isGrounded && unityCharacterController.velocity.y < 0)
            {
                gravityVector.y = 0;
            }

            else
            {
                gravityVector.y = Physics.gravity.y;
            }

            unityCharacterController.Move(rightVector + forwardVector + gravityVector * Time.deltaTime); // Add the input velocities, and gravity together

    }

    // void SendPositionToServer()
    // {
    //     //Send the position to the server
    //     var positionUpdate = new Position.Update()
    //     .SetCoords(new Coordinates(transform.position.x, transform.position.y, transform.position.z));

    //     PositionWriter.Send(positionUpdate);
    // }

    private void MoveStrafeOld(float forwardInput, float rightInput)
    {
        UnityEngine.Quaternion.Euler(Vector3.up * PlayerRotationReader.Data.bearing);
        //PlayerRotationReader.Data.bearing;


        Vector3 rightVector = Camera.main.transform.right * rightInput * moveSpeed * Time.deltaTime;

        Vector3 CameraForwardVector = Camera.main.transform.forward;
        //Vector3 FlattenVector = new Vector3(1,0,1);


        //CameraForwardVector.x = 0;
        CameraForwardVector.y = 0;
        CameraForwardVector.Normalize();

        //CameraForwardVector.z = 0;


        Vector3 forwardVector = CameraForwardVector * forwardInput * moveSpeed * Time.deltaTime;

        // Abstract this?
        //Camera.main.transform.right

        // Adding gravity velocity
        //Check if the user is grounded
        Vector3 gravityVector = new Vector3();
        bool _isGrounded = false;
        //Gizmos.DrawSphere(unityCharacterController.height/2 * Vector3.up, 1);
        //_isGrounded = Physics.CheckSphere(transform.position + ((unityCharacterController.height/2) * -Vector3.up), groundCheckDistance, LayerMask.NameToLayer("Default"), QueryTriggerInteraction.Ignore);
        LayerMask layermask = 0 << 1;
        _isGrounded = Physics.CheckSphere(transform.position, 1, 1 << 8, QueryTriggerInteraction.Ignore);

        // If they are grounded AND moving downward 
        if (_isGrounded && unityCharacterController.velocity.y < 0)
        {
            gravityVector.y = 0;
        }

        else
        {
            gravityVector.y = Physics.gravity.y;
        }

        unityCharacterController.Move(rightVector + forwardVector + gravityVector * Time.deltaTime); // Add the input velocities, and gravity together

        //print (_isGrounded);
    }

    private void MoveInDirection(float forwardInput, float rightInput)
    {
        Vector3 rightVector = Vector3.right * rightInput * moveSpeed * Time.deltaTime;
        Vector3 forwardVector = Vector3.forward * forwardInput * moveSpeed * Time.deltaTime;

        // Adding gravity velocity
        //Check if the user is grounded
        Vector3 gravityVector = new Vector3();
        bool _isGrounded = false;
        //Gizmos.DrawSphere(unityCharacterController.height/2 * Vector3.up, 1);
        //_isGrounded = Physics.CheckSphere(transform.position + ((unityCharacterController.height/2) * -Vector3.up), groundCheckDistance, LayerMask.NameToLayer("Default"), QueryTriggerInteraction.Ignore);
        LayerMask layermask = 0 << 1;
        _isGrounded = Physics.CheckSphere(transform.position, 1, 1 << 8, QueryTriggerInteraction.Ignore);

        // If they are grounded AND moving downward 
        if (_isGrounded && unityCharacterController.velocity.y < 0)
        {
            gravityVector.y = 0;
        }

        else
        {
            gravityVector.y = Physics.gravity.y;
        }

        unityCharacterController.Move(rightVector + forwardVector + gravityVector * Time.deltaTime); // Add the input velocities, and gravity together

        //print (_isGrounded);
    }

    public bool canRotate = true;
    public void RotatePawn(Quaternion rotation)
    {
        if (canRotate)
            this.gameObject.transform.rotation = rotation;
    }

    public void RotateTowardMovement()
    {
        if (unityCharacterController.velocity.magnitude <= 0.1)
        {
        }

        else
        {
            Vector3 horizontalVelocity = new Vector3(unityCharacterController.velocity.x, 0, unityCharacterController.velocity.z);
            Quaternion fromQuat = Quaternion.LookRotation(transform.forward, Vector3.up);
            Quaternion toQuat = Quaternion.LookRotation(horizontalVelocity, Vector3.up);
            transform.rotation = Quaternion.Lerp(fromQuat, toQuat, 0.1f);
        }
    }

    public void AttackMove(Vector3 MoveDir, Vector3 startpos)
    {
        canRotate = false;
        // Establish if the player is grounded or not
        Vector3 gravityVector = new Vector3();
        bool _isGrounded = false;
        LayerMask layermask = 0 << 1;
        _isGrounded = Physics.CheckSphere(transform.position, 1, 1 << 8, QueryTriggerInteraction.Ignore);

        // Set gravity constant if they are
        if (_isGrounded && unityCharacterController.velocity.y < 0)
        {
            gravityVector.y = 0;
        }

        else
        {
            gravityVector.y = Physics.gravity.y;
        }


        //this.transform.position = startpos + MoveDir;
        Vector3 offset = (startpos + MoveDir) - this.transform.position;

        offset *= 30;
        unityCharacterController.SimpleMove(offset);

        //this.transform.rotation = Quaternion.Euler((FinalPos-startpos).normalized);


    }




}
