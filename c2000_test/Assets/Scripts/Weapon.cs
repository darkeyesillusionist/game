using UnityEngine;

public abstract class Weapon : MonoBehaviour
{
        public WeaponData weaponData;
        protected Transform firePoint;
        protected Transform playerTransform;
        protected float timeToFire = 0;

        protected abstract void Shoot();

        private void Start()
        {
                playerTransform = transform.parent.parent;

                GameObject firePointObject = new GameObject(name + " Fire Point");
                firePointObject.transform.parent = playerTransform;
                firePoint = firePointObject.transform;
        }

        protected virtual void Update()
        {
                // Set the firePoint position and rotation based on the firePointOffset
                firePoint.position = playerTransform.position + weaponData.firePointOffset;
                firePoint.rotation = playerTransform.rotation;
        }

        protected virtual void Fire()
        {
                GameObject bullet = Instantiate(weaponData.bulletPrefab, firePoint.position, firePoint.rotation * Quaternion.Euler(0, 0, 90));
                bullet.GetComponent<Rigidbody2D>().velocity = firePoint.up * weaponData.bulletSpeed;
                bullet.GetComponent<Bullet>().bulletRange = weaponData.bulletRange; // Set the bulletRange here
        }
}
