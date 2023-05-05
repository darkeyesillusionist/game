using UnityEngine;

public class TestDummy : MonoBehaviour
{
        [SerializeField] private Health health;
        [SerializeField] private Rigidbody2D rb;

        private void Start()
        {
                health.OnHealthChanged += HandleHealthChanged;
        }

        private void HandleHealthChanged(int currentHealth)
        {
                if (currentHealth <= 0)
                {
                        Destroy(gameObject, 5f); // Destroy the Test Dummy game object after 5 seconds
                        rb.velocity = Vector2.zero; // Stop the Test Dummy from being pushed around
                        GetComponent<Collider2D>().enabled = false; // Disable the Test Dummy's collider so it can't be interacted with
                }
        }
}
