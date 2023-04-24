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
}
