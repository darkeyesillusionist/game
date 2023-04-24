using UnityEngine;

public class CameraFollow : MonoBehaviour
{
        [SerializeField] private Transform target;
        [SerializeField] private float smoothSpeed = 0.125f;
        [SerializeField] private Vector3 offset;

        [Header("Clamping Settings")]
        [SerializeField] private bool enableClamping = false;
        [SerializeField] private float minX = -Mathf.Infinity;
        [SerializeField] private float maxX = Mathf.Infinity;
        [SerializeField] private float minY = -Mathf.Infinity;
        [SerializeField] private float maxY = Mathf.Infinity;

        private void FixedUpdate()
        {
                Vector3 desiredPosition = target.position + offset;

                // clamp the camera position
                if (enableClamping)
                {
                        desiredPosition = new Vector3(Mathf.Clamp(desiredPosition.x, minX, maxX), Mathf.Clamp(desiredPosition.y, minY, maxY), desiredPosition.z);
                }

                Vector3 smoothedPosition = Vector3.Lerp(transform.position, desiredPosition, smoothSpeed);
                transform.position = smoothedPosition;
        }
}
