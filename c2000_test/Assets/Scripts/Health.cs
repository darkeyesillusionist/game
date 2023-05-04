using UnityEngine;

public class Health : MonoBehaviour
{
        [SerializeField] private int maxHealth = 100;
        private int currentHealth;
        private bool isDead = false;

        public delegate void HealthChangedDelegate(int currentHealth);
        public event HealthChangedDelegate OnHealthChanged;

        private void Start()
        {
                currentHealth = maxHealth;
        }

        public void TakeDamage(int damageAmount)
        {
                if (isDead)
                {
                        return;
                }

                currentHealth -= damageAmount;
                if (currentHealth <= 0)
                {
                        Die();
                }
                else
                {
                        OnHealthChanged?.Invoke(currentHealth);
                }
        }

        public void Heal(int healAmount)
        {
                if (isDead)
                {
                        return;
                }

                currentHealth += healAmount;
                if (currentHealth > maxHealth)
                {
                        currentHealth = maxHealth;
                }
                OnHealthChanged?.Invoke(currentHealth);
        }

        private void Die()
        {
                isDead = true;
                // Disable the object to prevent it from moving or taking any further damage
                gameObject.SetActive(false);
                // Respawn the object after a delay (e.g. 5 seconds)
                Invoke("Respawn", 5f);
        }

        private void Respawn()
        {
                // Reset the currentHealth to maxHealth and enable the object
                currentHealth = maxHealth;
                gameObject.SetActive(true);
                isDead = false;
        }
}
