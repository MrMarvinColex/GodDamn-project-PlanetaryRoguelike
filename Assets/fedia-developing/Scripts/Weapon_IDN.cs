using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Weapon_IDN : ClassWeapon
{
    // TODO: Another class for Damage values
    public GameObject gunPoint;
    private Transform gunPointTransform;
    public GameObject aimSphere;
    private Transform aimSphereTransform;

    // private Ray gunRay;
    private float shotDistance = 25f;

    private float damage_ = 5f;
    private int magazineSize_ = 31;
    private int bulletLeft_ = 0;
    private float timeBetweenShots_ = 0.16f;
    private float timeReload_ = 2f;

    private bool isReadyToShoot_ = true;
    private bool isRealoading_ = false;

    // Start is called before the first frame update
    void Start() {  
        bulletLeft_ = magazineSize_;
        gunPointTransform = gunPoint.GetComponent<Transform>();
        aimSphereTransform = aimSphere.GetComponent<Transform>();
    }

    // Update is called once per frame
    void Update() {
        Ray gunRay = new Ray(gunPointTransform.position, gunPointTransform.forward);
        // Debug.DrawRay(gunPointTransform.position, gunPointTransform.forward * shotDistance, Color.black);
        RaycastHit raycastOut;
        if (Physics.Raycast(gunRay, out raycastOut)) {
            // Debug.Log(raycastOut.point);
            aimSphere.SetActive(true);
            aimSphereTransform.position = raycastOut.point;
        } else {
            aimSphere.SetActive(false);
            // Debug.Log("Nope");
        }
    }

    public override void Shoot() {
        isReadyToShoot_ = false;
    
        Invoke("ResetShot", timeBetweenShots_);
    }
    public override void Reload() {
        isRealoading_ = true;
    
        Invoke("Finish", timeReload_);
    }

    private void ResetShot() {
        isReadyToShoot_ = true;
    } 
    private void FinishReload() {
        isRealoading_ = false;
    }
}
