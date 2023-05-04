using System.Collections.Generic;
using UnityEngine;

public class WeaponInventory : MonoBehaviour
{
        public List<WeaponData> weapons;
        public int currentWeaponIndex = 0;

        // UI elements for weapon wheel
        public GameObject weaponWheelUI;
        public GameObject weaponIconPrefab;

        private void Start()
        {
                InitializeWeaponWheelUI();
        }

        private void Update()
        {
                // Handle input for opening/closing weapon wheel and selecting weapons
        }

        public void AddWeapon(WeaponData weapon)
        {
                // Add the weapon to the inventory and update the UI
        }

        public void RemoveWeapon(WeaponData weapon)
        {
                // Remove the weapon from the inventory and update the UI
        }

        public void SelectWeapon(int index)
        {
                // Switch the player's active weapon to the chosen weapon
        }

        private void InitializeWeaponWheelUI()
        {
                // Create UI elements for each weapon in the inventory
        }

        private void UpdateWeaponWheelUI()
        {
                // Update the UI when the inventory changes
        }
}
