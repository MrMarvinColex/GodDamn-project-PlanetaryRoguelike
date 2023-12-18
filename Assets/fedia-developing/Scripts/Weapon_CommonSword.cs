using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Weapon_CommonSword : ClassWeapon
{
    // Start is called before the first frame update
    void Start() {
        
    }

    // Update is called once per frame
    void Update() {
        
    }

    void OnTriggerEnter (Collider col) {
        Debug.Log("Enter with" + col.gameObject.name);
	}
    void OnTriggerExit (Collider col) {
        Debug.Log("Exit with" + col.gameObject.name);
	}

    public override void Shoot() {

    }
    public override void Reload() {

    }
}
