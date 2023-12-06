using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Particle_CommonBlaster : MonoBehaviour
{
    private bool alreadyTouched_ = false;

    void OnParticleCollision(GameObject other)
    {
        // Get information about the object that the particle collided with
        if (alreadyTouched_) {
            return ;
        }

        alreadyTouched_ = true;
        if (other.tag == "Enemy") {
            other.GetComponent<Enemy_DecreaseHealth>().DecreaseHealth();
        }
    }

}
