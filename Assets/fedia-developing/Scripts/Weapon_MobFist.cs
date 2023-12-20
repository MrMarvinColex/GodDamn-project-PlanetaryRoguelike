using System.Collections;
using System.Collections.Generic;
using System.Threading.Tasks;
using UnityEngine;

public class Weapon_MobFist : ClassWeapon
{

    // To collect touched GameObjects
    private List<GameObject> touchedObjects_;
    private List<GameObject> decreasedHealth_;

    // Objects Publics
    public Transform particlePosition;
    public GameObject shotParticleObj;
    public MeshRenderer cubeMesh;

    // Configuration Privates
    private float damage_ = 7f;

    private int magazineSize_ = 0;
    private int bulletLeft_ = 0;
    
    private float timeBetweenShots_ = 2f;
    private float timeReload_ = 0;

    // Logic Privates
    private bool isReadyToShoot_ = true;
    private bool isShooting_ = false;

    // General Privates
    private string targetTag_ = "Player";

    // Start is called before the first frame update
    void Start() {
        touchedObjects_ = new List<GameObject>();
        decreasedHealth_ = new List<GameObject>();
        // cubeMesh.enabled = false;
    }

    // Update is called once per frame
    void Update() {
        
    }


    public override void Shoot() {
        // Debug.Log("Set true for Shooting");
        if (isReadyToShoot_) {
            StartCoroutine("MakeShot");
        }
    }
    public override void Reload() {
        isShooting_ = false;
    }


    private void OnTriggerEnter (Collider col) {
        // Debug.Log("Enter Collider with" + col.gameObject.name);
        var obj = col.gameObject;
        if (!isShooting_ || touchedObjects_.Contains(obj)) {
            return ;
        }

        GameObject particle = Instantiate(shotParticleObj, particlePosition.position, particlePosition.rotation);
        Destroy(particle, 1f);
        touchedObjects_.Add(obj);
	}
    private void OnTriggerExit (Collider col) {
        var t = col.GetComponent<Transform>();
        // Debug.Log("Exit Collider with" + col.gameObject.name);
        var obj = col.gameObject;
        if (!isShooting_ || decreasedHealth_.Contains(obj)) {
            return ;
        }

        // Debug.Log(obj.tag);
        decreasedHealth_.Add(obj);
        if (obj.CompareTag(targetTag_)) {
            // Debug.Log("Try to delete Obj");
            obj.BroadcastMessage("get_dmg", damage_);

            GameObject particle = Instantiate(shotParticleObj, particlePosition.position, particlePosition.rotation);
            Destroy(particle, 1f);
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
                obj.BroadcastMessage("get_dmg", damage_);
            }
        }

        touchedObjects_.Clear();
        decreasedHealth_.Clear();
    }
}
