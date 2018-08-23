using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using Improbable.Player;
using Improbable.Unity.Visualizer;
using Improbable.Worker;

public class PlayerRotationReceiver : MonoBehaviour {

	[Require] private PlayerRotation.Reader PlayerRotationReader;

	void OnEnable()
	{
		transform.rotation = UnityEngine.Quaternion.Euler(Vector3.up * PlayerRotationReader.Data.bearing);
		PlayerRotationReader.ComponentUpdated.Add(OnComponentUpdated);

	}

	void OnDisable()
	{
		PlayerRotationReader.ComponentUpdated.Remove(OnComponentUpdated);

	}

	void OnComponentUpdated(PlayerRotation.Update update)
	{
		if (PlayerRotationReader.Authority == Authority.NotAuthoritative)
            {
				transform.rotation = UnityEngine.Quaternion.Euler(Vector3.up * PlayerRotationReader.Data.bearing);
			}
	}

}
