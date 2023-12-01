using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Weapon_CommonBlaster : ClassWeapon
{
    public bool isAimNeeded;

    // TODO: Another class for Damage values
    public GameObject gunPoint;
    private Transform gunPointTransform;
    public GameObject aimSphere;
    private Transform aimSphereTransform;
    public ParticleSystem shotParticle;
    public ParticleSystem shotParticleObj;

    // private Ray gunRay;
    private float shotDistance = 25f;

    private float damage_ = 5f;
    private int magazineSize_ = 31;
    private int bulletLeft_ = 0;
    public float timeBetweenShots_ = 0.16f;
    private float timeReload_ = 2f;

    private bool isReadyToShoot_ = true;
    private bool isRealoading_ = false;

    // FOR DEBUG
    private int counter_ = 0;

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
        bool isRaycasted = Physics.Raycast(gunRay, out raycastOut);

        // TODO: think about more practise logic
        if (isAimNeeded && isRaycasted) {
            // Debug.Log(raycastOut.point);
            aimSphere.SetActive(true);
            aimSphereTransform.position = raycastOut.point;
        } else {
            aimSphere.SetActive(false);
            // Debug.Log("Nope");
        }


        ///// PERS SECTION /////
        if (Input.GetKey(KeyCode.Q)) {
            Shoot();
        }
    }

    public override void Shoot() {
        if (!isReadyToShoot_) {
            return ;
        }

        isReadyToShoot_ = false;

        Debug.Log("Make shoot " + counter_++);
        Instantiate(shotParticleObj, gunPointTransform.position, gunPointTransform.rotation);
        // shotParticle.Play();

        Invoke("ResetShot", timeBetweenShots_);
    }
    public override void Reload() {
        isRealoading_ = true;
    
        Invoke("Finish", timeReload_);
    }

    private void ResetShot() {
        Debug.Log("Reset shoot");
        isReadyToShoot_ = true;
    } 
    private void FinishReload() {
        isRealoading_ = false;
    }
}
