using System.Collections;
using System.Collections.Generic;
using Unity.AI.Navigation;
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
    public GameObject shotParticleObj;

    // private Ray gunRay;
    private float shotDistance = 25f;

    private float damage_ = 5f;
    private int magazineSize_ = 31;
    private int bulletLeft_ = 0;
    private float timeBetweenShots_ = 0.08f;
    private float timeReload_ = 2f;

    private bool isReadyToShoot_ = true;
    private bool isRealoading_ = false;

    // FOR ANIMATION
    private float timeParticklAnimation_ = 1f;

    // FOR DEBUG
    private int counter_ = 0;
    public NavMeshSurface nav;
    // public GameObject sphere;

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
        if (Input.GetKey(KeyCode.B)) {
            nav.BuildNavMesh();
        }
    }

    public override void Shoot() {
        if (isReadyToShoot_) {
            StartCoroutine("MakeShot");
        }
    }
    public override void Reload() {
        isRealoading_ = true;
    
        Invoke("Finish", timeReload_);
    }

    private IEnumerator MakeShot() {
        isReadyToShoot_ = false;

        // Debug.Log("Make shoot " + counter_);
        GameObject obj = Instantiate(shotParticleObj, gunPointTransform.position, gunPointTransform.rotation);
        Destroy(obj, 1f);

        // Debug.Log(counter_ + " Ready to wait " + Time.time);
        yield return new WaitForSeconds(timeBetweenShots_);
        // Debug.Log(counter_ + " Ready to new shot " + Time.time);
        // ++counter_;
        isReadyToShoot_ = true;
    }
    private void FinishReload() {
        isRealoading_ = false;
    }
}
