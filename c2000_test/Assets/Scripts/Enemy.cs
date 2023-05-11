using UnityEngine;

public class Enemy : MonoBehaviour
{
        public EnemyData enemyData;
        private int currentHealth;

        void Start()
        {
                if (enemyData == null)
                {
                        Debug.LogError("No enemy data assigned to the enemy object.");
                        return;
                }

                currentHealth = enemyData.health;
        }

        public void TakeDamage(int damageAmount)
        {
                currentHealth -= damageAmount;
                if (currentHealth <= 0)
                {
                        Die();
                }
        }

        public void ApplyKnockback(Vector2 direction, float knockbackStrength)
        {
                // Apply knockback to the enemy based on the given direction and strength
                // You can use Rigidbody2D.AddForce to apply a force in the direction of the knockback

        }

        public void TakeMeleeDamage(int damageAmount, Vector2 knockbackDirection, float knockbackStrength)
        {
                TakeDamage(damageAmount);
                ApplyKnockback(knockbackDirection, knockbackStrength);
        }

        private void Die()
        {
                // Implement death behavior, such as playing a death animation, dropping loot, etc.
                Destroy(gameObject);
        }
}
