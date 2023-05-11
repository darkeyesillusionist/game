using UnityEngine;

public class FiringPoint : MonoBehaviour
{
        public Vector3 offset;

        private Transform playerTransform;

        private void Awake()
        {
                playerTransform = transform.parent; // Assumes FiringPoint is a child of the player
        }

        private void Update()
        {
                Vector3 mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
                mousePosition.z = 0f;
                Quaternion targetRotation = Quaternion.LookRotation(Vector3.forward, mousePosition - playerTransform.position);
                transform.position = playerTransform.position + targetRotation * offset;
                transform.rotation = targetRotation;
        }

        public Vector3 GetPosition(Transform playerTransform, Quaternion weaponRotation)
        {
                return playerTransform.position + (weaponRotation * offset);
        }

        public Quaternion GetRotation(Transform playerTransform, Quaternion weaponRotation)
        {
                return weaponRotation;
        }
}
