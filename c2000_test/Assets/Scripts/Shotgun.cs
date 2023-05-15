using UnityEngine;

public class Shotgun : Weapon
{
        public int pelletCount = 8;
        public float spreadAngle = 45f;
        private AudioSource audioSource;
        private bool isFiring; // New flag

        protected override void Start()
        {
                base.Start();
                audioSource = GetComponent<AudioSource>();
        }

        protected override void Update()
        {
                base.Update();

                if (Input.GetMouseButton(0) && Time.time >= timeToFire)
                {
                        timeToFire = Time.time + 1 / weaponData.fireRate;
                        isFiring = true; // Set the flag to true
                        Shoot();
                }
        }

        protected override void Shoot()
        {
                if (isFiring) // Check the flag
                {
                        audioSource.Play();
                        isFiring = false; // Reset the flag
                }

                float interval = spreadAngle / (pelletCount - 1);
                Quaternion initialFirePointRotation = firingPoint.transform.rotation;

                for (int i = 0; i < pelletCount; i++)
                {
                        // Reset the firePoint rotation to its initial state before calculating the spread
                        firingPoint.transform.rotation = initialFirePointRotation;

                        // Calculate the spread angle for each bullet evenly across the defined angle
                        float spread = -spreadAngle / 2 + interval * i;
                        Quaternion bulletRotation = firingPoint.transform.rotation * Quaternion.Euler(0, 0, 90 + spread);
                        GameObject bullet = Instantiate(weaponData.bulletPrefab, firingPoint.transform.position, bulletRotation);
                        bullet.GetComponent<Rigidbody2D>().velocity = bulletRotation * Vector3.right * weaponData.bulletSpeed;
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
                        targetHealth.TakeDamage(weaponData.damage); // Use the damage value from the WeaponData scriptable object
                }
        }
}
