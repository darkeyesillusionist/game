using UnityEngine;

public class WeaponManager : MonoBehaviour
{
        public GameObject[] weapons;
        private int currentWeaponIndex;

        private void Start()
        {
                currentWeaponIndex = 0;
                ActivateWeapon();
        }

        private void Update()
        {
                if (Input.GetAxis("Mouse ScrollWheel") > 0)
                {
                        currentWeaponIndex++;
                        if (currentWeaponIndex > weapons.Length - 1) currentWeaponIndex = 0;
                        ActivateWeapon();
                }
                else if (Input.GetAxis("Mouse ScrollWheel") < 0)
                {
                        currentWeaponIndex--;
                        if (currentWeaponIndex < 0) currentWeaponIndex = weapons.Length - 1;
                        ActivateWeapon();
                }
        }

        private void ActivateWeapon()
        {
                for (int i = 0; i < weapons.Length; i++)
                {
                        weapons[i].SetActive(i == currentWeaponIndex);
                }
        }
}
