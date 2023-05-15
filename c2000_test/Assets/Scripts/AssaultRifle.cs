using UnityEngine;

public class AssaultRifle : Weapon
{
        public AudioSource gunFireAudioSource;
        private bool isFiring; // New flag

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
                base.Fire();

                if (isFiring && gunFireAudioSource != null) // Check the flag
                {
                        gunFireAudioSource.Play();
                        isFiring = false; // Reset the flag
                }
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
