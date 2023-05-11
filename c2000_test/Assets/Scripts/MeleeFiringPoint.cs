using UnityEngine;

public class MeleeFiringPoint : MonoBehaviour
{
        public Vector3 offset;

        private Transform playerTransform;

        private void Awake()
        {
                playerTransform = transform.parent.parent; // Assumes MeleeFiringPoint is a child of MeleeManager which is a child of Player
        }

        public Vector3 GetPosition()
        {
                return playerTransform.position + offset;
        }
}
