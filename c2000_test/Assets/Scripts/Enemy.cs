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
                // Initialize other properties based on enemyData
        }

        // Implement other enemy behavior using enemyData properties
}
