using UnityEngine;

public class Shotgun : Weapon
{
        public int pelletCount = 8;
        public float spreadAngle = 45f;

        protected override void Update()
        {
                base.Update();

                Vector3 mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
                mousePosition.z = 0f;
                Quaternion targetRotation = Quaternion.LookRotation(Vector3.forward, mousePosition - playerTransform.position);
                transform.rotation = targetRotation;

                // Update firePoint position using firePointOffset
                firePoint.position = playerTransform.position + targetRotation * weaponData.firePointOffset;

                // Update firePoint rotation to match playerTransform rotation
                firePoint.rotation = targetRotation;

                if (Input.GetMouseButton(0) && Time.time >= timeToFire)
                {
                        timeToFire = Time.time + 1 / weaponData.fireRate;
                        Shoot();
                }
        }

        protected override void Shoot()
        {
                for (int i = 0; i < pelletCount; i++)
                {
                        // Calculate the spread angle for each bullet evenly across the defined angle
                        float spread = -spreadAngle / 2 + (spreadAngle / (pelletCount - 1)) * i;
                        GameObject bullet = Instantiate(weaponData.bulletPrefab, firePoint.position, firePoint.rotation * Quaternion.Euler(0, 0, 90 + spread));
                        bullet.GetComponent<Rigidbody2D>().velocity = Quaternion.Euler(0, 0, spread) * firePoint.up * weaponData.bulletSpeed;
                        bullet.GetComponent<Bullet>().bulletRange = weaponData.bulletRange;
                }
        }

        protected override void DealDamage(Collider2D target)
        {
                // Implement the damage logic for the shotgun here.
                // For example, if you have a Health component on the target object:
                Health targetHealth = target.GetComponent<Health>();
                if (targetHealth != null)
                {
                        int damageAmount = 20; // Set the desired damage amount for the shotgun
                        targetHealth.TakeDamage(damageAmount);
                }
        }
}
