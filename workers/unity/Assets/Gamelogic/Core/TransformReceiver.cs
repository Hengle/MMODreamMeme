using Improbable;
using Improbable.Core;
using Improbable.Unity.Visualizer;
using Improbable.Worker;

using Improbable.Player;


using UnityEngine;


namespace Assets.Gamelogic.Core
{
    public class TransformReceiver : MonoBehaviour
    {
        [Require] private Position.Reader PositionReader;
        [Require] private Rotation.Reader RotationReader;

        void OnEnable()
        {
            transform.position = PositionReader.Data.coords.ToUnityVector();
            transform.rotation = UnityEngine.Quaternion.Euler(RotationReader.Data.rotation.ToUnityQuaternion() * Vector3.up);

            // Add to callback
            PositionReader.ComponentUpdated.Add(OnPositionUpdated);
            RotationReader.ComponentUpdated.Add(OnRotationUpdated);
        }

        void OnDisable()
        {
            // Remove from callback
            PositionReader.ComponentUpdated.Remove(OnPositionUpdated);
            RotationReader.ComponentUpdated.Remove(OnRotationUpdated);
            //Vector3.up * .ComponentUpdated.Remove(OnRotationUpdated);

        }

        void Update()
        {


        }

        void OnPositionUpdated(Position.Update update)
        {
            if (PositionReader.Authority == Authority.NotAuthoritative)
            {
                if (update.coords.HasValue)
                {
                    transform.position = update.coords.Value.ToUnityVector();
                }
            }
        }

        void OnRotationUpdated(Rotation.Update update)
        {
            if (RotationReader.Authority == Authority.NotAuthoritative)
            {
                //float myFloat = update.bearing.
                transform.rotation = update.rotation.Value.ToUnityQuaternion();

                if (update.rotation.HasValue)
                {
                    //transform.rotation = UnityEngine.Quaternion.Euler(Vector3.up * update.bearing);
                }
            }


        }
    }
}