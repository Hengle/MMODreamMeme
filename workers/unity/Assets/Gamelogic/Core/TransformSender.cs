using System.Collections;
using System.Collections.Generic;

using Assets.Gamelogic.Utils;
using Assets.Gamelogic.Player;
using Improbable;
using Improbable.Core;
using Improbable.Unity;
using Improbable.Unity.Visualizer;
using UnityEngine;

using Unity;

[WorkerType(WorkerPlatform.UnityWorker)]
public class TransformSender : MonoBehaviour
{

    [Require] private Position.Writer PositionWriter;
    [Require] private Rotation.Writer RotationWriter;
    // Use this for initialization
    void Start()
    {

    }

    int transformCount = 0;




    // Update is called once per frame
    void FixedUpdate()
    {

        // Get simulation pos
        var pos = transform.position;

        // Store the pos into an update for the writer
        var positionUpdate = new Position.Update()
        .SetCoords(new Coordinates(pos.x, pos.y, pos.z));

        // Send the update to the writing server
        PositionWriter.Send(positionUpdate);

        var rotationUpdate = new Rotation.Update()
         .SetRotation(MathUtils.ToNativeQuaternion(transform.rotation));

        RotationWriter.Send(rotationUpdate);

		

    }


}
