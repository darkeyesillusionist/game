using UnityEngine;

[CreateAssetMenu(fileName = "WeaponData", menuName = "ScriptableObjects/WeaponData", order = 1)]
public class WeaponData : ScriptableObject
{
        public string weaponName;
        public GameObject bulletPrefab;
        public Vector3 firePointOffset;
        public float fireRate;
        public float bulletSpeed;
        public float bulletRange; // Add this line
        public int damage; // Add this line for damage value
}
