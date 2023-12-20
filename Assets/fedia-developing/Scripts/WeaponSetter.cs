using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponSetter : MonoBehaviour
{
    // Should be saved
    public int start_weapon;

    // 
    public GameObject[] weapons;
    public Transform weapon_pivot;

    private GameObject current_weapon = null;

    void Start() {
        start_weapon = 0;
        SetWeapon(start_weapon);
    }

    void Update() {
        if (Input.GetKey(KeyCode.Keypad0)) {
            SetWeapon(0);
        }
        if (Input.GetKey(KeyCode.Keypad1)) {
            SetWeapon(1);
        }
        if (Input.GetKey(KeyCode.Keypad2)) {
            SetWeapon(2);
        }
        if (Input.GetKey(KeyCode.Keypad3)) {
            SetWeapon(3);
        }

        if (Input.GetKey(KeyCode.Mouse0)) {
            current_weapon.SendMessage("Shoot");
        }
    }

    void SetWeapon(int index) {
        GameObject weapon = weapons[index];
        if (weapon == current_weapon) {
            return ;
        }

        if (current_weapon != null) {
            Destroy(current_weapon);       
        }

        current_weapon = Instantiate(weapon, weapon_pivot.position, weapon_pivot.rotation);
        current_weapon.GetComponent<Transform>().SetParent(weapon_pivot);
    }
}
