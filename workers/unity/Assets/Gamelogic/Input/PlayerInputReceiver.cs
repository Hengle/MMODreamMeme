using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using Improbable;
using Improbable.Core;
using Improbable.Unity;
using Improbable.Unity.Visualizer;
using Improbable.Worker;
using Improbable.Player;

[WorkerType(WorkerPlatform.UnityWorker)]
public class PlayerInputReceiver : MonoBehaviour {

	// [Require] 
	[Require] PlayerRotation.Reader playerRotationReader;
	[Require] PlayerInput.Reader playerInputReader;
	[Require] Position.Writer playerPositionWriter;
	
	

	CharacterMovementController characterMovementController;

	void OnEnable()
	{
		playerInputReader.ComponentUpdated.Add(OnPlayerInputUpdated);
		playerRotationReader.ComponentUpdated.Add(OnRotationUpdate);
		
		characterMovementController = GetComponent<CharacterMovementController>();
	}

	void OnDisable()
	{
		playerInputReader.ComponentUpdated.Remove(OnPlayerInputUpdated);
		playerRotationReader.ComponentUpdated.Remove(OnRotationUpdate);
	}

	void OnPlayerInputUpdated(PlayerInput.Update update)
	{
		characterMovementController.local_HorizontalInput = update.joystick.Value.xAxis;
		characterMovementController.local_VerticalInput = update.joystick.Value.yAxis;
	}

	void OnRotationUpdate(PlayerRotation.Update update)
	{
		characterMovementController.local_rotationBearing = update.bearing.Value;
	}

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
