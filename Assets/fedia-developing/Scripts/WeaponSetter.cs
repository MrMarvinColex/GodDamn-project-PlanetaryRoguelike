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

    // void Update() {
    //     if (Input.GetKey(KeyCode.E)) {
    //         SetWeapon(0);
    //     }
    //     if (Input.GetKey(KeyCode.R)) {
    //         SetWeapon(1);
    //     }
    // }

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
