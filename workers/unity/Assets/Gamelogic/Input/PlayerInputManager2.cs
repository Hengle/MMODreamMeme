using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using Improbable.Unity;
using Improbable.Core;
using Improbable.Unity.Visualizer;

using Improbable.Player;


[WorkerType(WorkerPlatform.UnityClient)]
public class PlayerInputManager2 : MonoBehaviour
{

    [Require] private ClientAuthorityCheck.Writer ClientAuthorityCheckWriter;


    // Input keys
    public bool AttackKeyDown = false;
    public bool BlockKeyDown = false;

    // Movement keys
    public string moveForwardAxis = "Vertical";
	public string moveRightAxis = "Horizontal";

    public float InputRightAxis = 0f;
    public float InputForwardAxis = 0f;

    public bool InputJumpHeld = false;
    public bool InputJumpPressed = false;

    public CombatManager _combatManager;

    // Mouse
    public UnityEngine.Quaternion PlayerViewRotation;

    public bool MouseHidden = false;

    void Start()
    {
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
        MouseHidden = Cursor.visible;
        _combatManager = GetComponent<CombatManager>();
    }

    void Update()
    {
        // Get movement
        InputRightAxis =  Input.GetAxis(moveRightAxis);
        InputForwardAxis =  Input.GetAxis(moveForwardAxis);
        InputJumpHeld = Input.GetKey(KeyCode.Space);
        InputJumpPressed = Input.GetKeyDown(KeyCode.Space);
        
        // Get combat keys
        AttackKeyDown = Input.GetMouseButton(0);
        
        BlockKeyDown = Input.GetMouseButton(1);

        // Get desired player camera orientation
        PlayerViewRotation = BuildCameraRotation();

        // Issue an attack if we're attakcking
        if (AttackKeyDown)
        {  
            _combatManager.StartAttackSequence(PlayerViewRotation.eulerAngles.y);
            //GetComponent<CombatManager>().StartAttackSequence(PlayerViewRotation.eulerAngles.y);
        }

        // Send a copy of all the inputs locally to the player controller
        SendInputsToLocalController();
    }

    void SendInputsToLocalController()
    {
        GetComponent<CharacterMovementController>().local_HorizontalInput = InputRightAxis;
        GetComponent<CharacterMovementController>().local_VerticalInput = InputForwardAxis;
        GetComponent<CharacterMovementController>().local_rotationBearing = PlayerViewRotation.eulerAngles.y;
    }

    private float xRotMain = 0;
    private float yRotMain = 0;

    public float CameraRotationRate = 5;
    //public Vector3 playerCameraVector;
    UnityEngine.Quaternion BuildCameraRotation()
    {
        xRotMain += Input.GetAxis("Mouse X") * CameraRotationRate;
        yRotMain += Input.GetAxis("Mouse Y") * CameraRotationRate;
        yRotMain = Mathf.Clamp(yRotMain, -90, 90); // Prevent user looking straight up/down
        xRotMain = xRotMain % 360; // prevent number getting too big

		Vector3 badCameraVector = new Vector3(-yRotMain, xRotMain, 0);
		UnityEngine.Quaternion CameraQuaternion = UnityEngine.Quaternion.Euler(badCameraVector);

        //print("Returning camera quat: " + CameraQuaternion);
        
        return CameraQuaternion;
    }


}
