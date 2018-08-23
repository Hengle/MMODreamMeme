using UnityEngine;
using Improbable.Unity;
using Improbable.Unity.Visualizer;
using Improbable.Player;


[WorkerType(WorkerPlatform.UnityClient)]
public class PlayerInputSender : MonoBehaviour
{

    [Require] private PlayerInput.Writer PlayerInputWriter;
    [Require] private PlayerRotation.Writer PlayerRotationWriter;

    private PlayerInputManager2 playerInput;

    // Use this for initialization
    void Start()
    {
        playerInput = GetComponent<PlayerInputManager2>();

    }

	

    
	uint currentInputID = 0;
    // Update is called once per frame
    void FixedUpdate()
    {
		currentInputID++;
		//print(currentInputID);

  

        var joystickUpdateData = new PlayerInput.Update();
        joystickUpdateData.SetJoystick(new Joystick(playerInput.InputRightAxis, playerInput.InputForwardAxis));
        joystickUpdateData.SetInputId(new InputId(currentInputID));
        PlayerInputWriter.Send(joystickUpdateData);

        var rotationUpdateData = new PlayerRotation.Update();
        rotationUpdateData.SetBearing(playerInput.PlayerViewRotation.eulerAngles.y);
        PlayerRotationWriter.Send(rotationUpdateData);
    }


}
