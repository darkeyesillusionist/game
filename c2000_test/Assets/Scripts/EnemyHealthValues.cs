using UnityEngine;

public class EnemyHealthValues : MonoBehaviour
{
        [SerializeField] private int maxHealth = 100;
        [SerializeField] private int maxArmor = 50;
        [SerializeField] private int maxShield = 50;

        private int currentHealth;
        private int currentArmor;
        private int currentShield;

        private void Start()
        {
                currentHealth = maxHealth;
                currentArmor = maxArmor;
                currentShield = maxShield;
        }

        public void TakeDamage(int damageAmount)
        {
                if (currentShield > 0)
                {
                        currentShield -= damageAmount;
                        if (currentShield < 0)
                        {
                                damageAmount = Mathf.Abs(currentShield);
                                currentShield = 0;
                        }
                        else
                        {
                                return;
                        }
                }

                if (currentArmor > 0)
                {
                        currentArmor -= damageAmount;
                        if (currentArmor < 0)
                        {
                                damageAmount = Mathf.Abs(currentArmor);
                                currentArmor = 0;
                        }
                        else
                        {
                                return;
                        }
                }

                currentHealth -= damageAmount;

                if (currentHealth <= 0)
                {
                        Die();
                }
        }

        public int GetCurrentHealth()
        {
                return currentHealth;
        }

        public int GetMaxHealth()
        {
                return maxHealth;
        }

        public int GetCurrentArmor()
        {
                return currentArmor;
        }

        public int GetMaxArmor()
        {
                return maxArmor;
        }

        public int GetCurrentShield()
        {
                return currentShield;
        }

        public int GetMaxShield()
        {
                return maxShield;
        }

        public void SetCurrentHealth(int health)
        {
                currentHealth = health;
        }

        public void SetMaxHealth(int health)
        {
                maxHealth = health;
        }

        public void SetCurrentArmor(int armor)
        {
                currentArmor = armor;
        }

        public void SetMaxArmor(int armor)
        {
                maxArmor = armor;
        }

        public void SetCurrentShield(int shield)
        {
                currentShield = shield;
        }

        public void SetMaxShield(int shield)
        {
                maxShield = shield;
        }

        private void Die()
        {
                // Handle the death logic here (e.g., play animation, remove object, etc.)
                Debug.Log(gameObject.name + " has died.");
        }
}
