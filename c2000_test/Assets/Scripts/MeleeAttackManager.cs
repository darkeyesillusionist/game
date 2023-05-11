using UnityEngine;

public class MeleeAttackManager : MonoBehaviour
{
        public GameObject meleeEffectPrefab;
        public MeleeFiringPoint meleeFiringPoint; // Use MeleeFiringPoint instead of FiringPoint
        public float meleeDuration = 0.2f; // You can adjust this value
        public int meleeDamage = 20; // You can adjust this value

        private void Update()
        {
                if (Input.GetMouseButtonDown(1)) // Right mouse button
                {
                        // Get the mouse position
                        Vector3 mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
                        mousePosition.z = 0;

                        // Calculate the direction to the mouse
                        Vector2 directionToMouse = (mousePosition - transform.position).normalized;

                        // Calculate the rotation to the mouse
                        Quaternion rotationToMouse = Quaternion.FromToRotation(Vector3.up, directionToMouse);

                        // Instantiate the melee effect at the melee firing point position and rotation to the mouse
                        GameObject meleeEffect = Instantiate(meleeEffectPrefab, meleeFiringPoint.GetPosition(), rotationToMouse);

                        // Destroy the melee effect after the duration
                        Destroy(meleeEffect, meleeDuration);

                        // Get all colliders within the melee range
                        Collider2D[] hitEnemies = Physics2D.OverlapCircleAll(transform.position, meleeDuration);

                        // Deal damage to the enemies
                        foreach (Collider2D enemy in hitEnemies)
                        {
                                // You need to replace Enemy with your enemy's tag
                                if (enemy.tag == "Enemy")
                                {
                                        enemy.GetComponent<Health>().TakeDamage(meleeDamage);
                                }
                        }
                }
        }
}
