using System.Collections.Generic;
using UnityEngine;

public class BulletPool : MonoBehaviour
{
        public static BulletPool Instance;

        public GameObject bulletPrefab;
        public int initialPoolSize = 50;

        private List<GameObject> bulletPool;

        private void Awake()
        {
                if (Instance == null)
                {
                        Instance = this;
                }
                else
                {
                        Destroy(gameObject);
                        return;
                }

                bulletPool = new List<GameObject>();

                for (int i = 0; i < initialPoolSize; i++)
                {
                        GameObject bullet = Instantiate(bulletPrefab);
                        bullet.SetActive(false);
                        bulletPool.Add(bullet);
                }
        }

        public GameObject GetBullet()
        {
                foreach (GameObject bullet in bulletPool)
                {
                        if (!bullet.activeInHierarchy)
                        {
                                return bullet;
                        }
                }

                // If no inactive bullets are available, create a new one and add it to the pool
                GameObject newBullet = Instantiate(bulletPrefab);
                newBullet.SetActive(false);
                bulletPool.Add(newBullet);

                return newBullet;
        }
}
