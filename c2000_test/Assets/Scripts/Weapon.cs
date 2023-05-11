using UnityEngine;

public abstract class Weapon : MonoBehaviour
{
        public WeaponData weaponData;
        public FiringPoint firingPoint; // Add this line
        protected Transform playerTransform;
        protected float timeToFire = 0;

        protected abstract void Shoot();
        protected abstract void DealDamage(Collider2D target);

        protected virtual void Start()
        {
                playerTransform = transform.parent.parent;
        }

        protected virtual void Update() // Add this method
        {
                Vector3 mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
                mousePosition.z = 0f;
                Quaternion targetRotation = Quaternion.LookRotation(Vector3.forward, mousePosition - playerTransform.position);
                transform.rotation = targetRotation;

                // Set the firingPoint's position and rotation
                firingPoint.transform.position = firingPoint.GetPosition(playerTransform, transform.rotation);
                firingPoint.transform.rotation = firingPoint.GetRotation(playerTransform, transform.rotation);
        }

        protected virtual void Fire()
        {
                GameObject bullet = Instantiate(weaponData.bulletPrefab, firingPoint.transform.position, firingPoint.transform.rotation * Quaternion.Euler(0, 0, 90));
                bullet.GetComponent<Rigidbody2D>().velocity = firingPoint.transform.up * weaponData.bulletSpeed;
                bullet.GetComponent<Bullet>().bulletRange = weaponData.bulletRange;
        }
}
