using UnityEngine;

public class AssaultRifle : Weapon
{
        protected override void Update()
        {
                base.Update();

                Vector3 mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
                mousePosition.z = 0f;
                Quaternion targetRotation = Quaternion.LookRotation(Vector3.forward, mousePosition - playerTransform.position);
                transform.rotation = targetRotation;

                // Update fire point object's position and rotation relative to the player character based on weapon's rotation
                firePoint.position = playerTransform.position + targetRotation * weaponData.firePointOffset;
                firePoint.rotation = targetRotation;

                if (Input.GetMouseButton(0) && Time.time >= timeToFire)
                {
                        timeToFire = Time.time + 1 / weaponData.fireRate;
                        Shoot();
                }
        }

        protected override void Shoot()
        {
                base.Fire(); // Call the base.Fire() method here
        }

        protected override void DealDamage(Collider2D target)
        {
                // Implement the damage logic for the assault rifle here.
                // For example, if you have a Health component on the target object:
                Health targetHealth = target.GetComponent<Health>();
                if (targetHealth != null)
                {
                        int damageAmount = 10; // Set the desired damage amount for the assault rifle
                        targetHealth.TakeDamage(damageAmount);
                }
        }
}
