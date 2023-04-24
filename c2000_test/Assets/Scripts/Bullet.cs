using UnityEngine;

public class Bullet : MonoBehaviour
{
        public float bulletRange;
        private Rigidbody2D rb;
        private float timeToLive;

        void Start()
        {
                rb = GetComponent<Rigidbody2D>();
                float bulletSpeed = rb.velocity.magnitude;
                timeToLive = bulletRange / bulletSpeed;
                Destroy(gameObject, timeToLive);
        }
}
