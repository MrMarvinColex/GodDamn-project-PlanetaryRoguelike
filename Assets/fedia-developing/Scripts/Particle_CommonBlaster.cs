using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Particle_CommonBlaster : MonoBehaviour
{
    // Logic Privates
    private bool alreadyTouched_ = false;

    // General Privates
    private string targetTag_ = "Enemy";

    void OnParticleCollision(GameObject other)
    {
        // Get information about the object that the particle collided with
        if (alreadyTouched_) {
            return ;
        }

        alreadyTouched_ = true;
        if (other.CompareTag(targetTag_)) {
            other.GetComponent<Enemy_DecreaseHealth>().DecreaseHealth();
        }
    }

}
