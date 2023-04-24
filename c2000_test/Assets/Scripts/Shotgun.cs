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
                        float spread = Random.Range(-spreadAngle / 2, spreadAngle / 2);
                        GameObject bullet = Instantiate(weaponData.bulletPrefab, firePoint.position, firePoint.rotation * Quaternion.Euler(0, 0, 90 + spread));
                        bullet.GetComponent<Rigidbody2D>().velocity = Quaternion.Euler(0, 0, spread) * firePoint.up * weaponData.bulletSpeed;
                }
        }
}
