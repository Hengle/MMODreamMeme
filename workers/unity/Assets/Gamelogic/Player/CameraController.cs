using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using Improbable.Core;
using Improbable.Unity.Visualizer;

public class CameraController : MonoBehaviour
{

    [Require] private ClientAuthorityCheck.Writer ClientAuthorityCheckWriter;


	public float CameraDistanceOffset = 4;
	public float CameraMinZoomDistance = 1f;
	public float CameraMaxZoomDistance = 5f;

    //private CharacterMovementController playerController;
	private PlayerInputManager2 playerInput;
    Camera cameraMain;

    void OnEnable()
    {
        cameraMain = Camera.main;
        //playerController = GetComponent<CharacterMovementController>();
		playerInput = GetComponent<PlayerInputManager2>();
    }

    void Update()
    {
        SetCameraRotationFromInputManager();
    }

    void SetCameraRotationFromInputManager()
    {
		// Set camera rotation
		cameraMain.transform.rotation = playerInput.PlayerViewRotation;
        //print(playerInput.PlayerViewRotation);
		// Set camera location
		cameraMain.transform.position = this.transform.position + ((playerInput.PlayerViewRotation * Vector3.forward) * -CameraDistanceOffset);
    }


    float angle = 0;


}
