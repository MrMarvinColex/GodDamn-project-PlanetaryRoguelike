using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Weapon_CommonSword : ClassWeapon
{

    // To collect touched GameObjects
    private List<GameObject> touchedObjects_;
    private List<GameObject> decreasedHealth_;

    // Configuration Privates
    private float damage_ = 27f;

    private int magazineSize_ = 0;
    private int bulletLeft_ = 0;
    
    private float timeBetweenShots_ = 2f;
    private float timeReload_ = 0;

    // Logic Privates
    private bool isReadyToShoot_ = true;
    private bool isShooting_ = false;

    // General Privates
    private string targetTag_ = "Enemy";

    // Start is called before the first frame update
    void Start() {
        touchedObjects_ = new List<GameObject>();
        decreasedHealth_ = new List<GameObject>();
    }

    // Update is called once per frame
    void Update() {
        
    }


    public override void Shoot() {
        Debug.Log("Set true for Shooting");
        if (isReadyToShoot_) {
            StartCoroutine("MakeShot");
        }
    }
    public override void Reload() {
        isShooting_ = false;
    }


    private void OnTriggerEnter (Collider col) {
        Debug.Log("Enter Collider with" + col.gameObject.name);
        var obj = col.gameObject;
        if (!isShooting_ || touchedObjects_.Contains(obj)) {
            return ;
        }

        touchedObjects_.Add(obj);
	}
    private void OnTriggerExit (Collider col) {
        Debug.Log("Exit Collider with" + col.gameObject.name);
        var obj = col.gameObject;
        if (!isShooting_ || decreasedHealth_.Contains(obj)) {
            return ;
        }

        Debug.Log("Push in decreased list");
        decreasedHealth_.Add(obj);
        if (obj.CompareTag(targetTag_)) {
            Debug.Log("Try to delete Obj");
            obj.GetComponent<Enemy_DecreaseHealth>().DecreaseHealth();
        }
	}

    private IEnumerator MakeShot() {
        isReadyToShoot_ = false;
        isShooting_ = true;

        yield return new WaitForSeconds(timeBetweenShots_ / 2);
        isShooting_ = false;
        FinishShot();

        yield return new WaitForSeconds(timeBetweenShots_ / 2);
        isReadyToShoot_ = true;
    }
    private void FinishShot() {
        foreach (var obj in touchedObjects_) {
            if (!decreasedHealth_.Contains(obj) && obj.CompareTag(targetTag_)) {
                obj.GetComponent<Enemy_DecreaseHealth>().DecreaseHealth();
            }
        }

        touchedObjects_.Clear();
        decreasedHealth_.Clear();
    }
}
