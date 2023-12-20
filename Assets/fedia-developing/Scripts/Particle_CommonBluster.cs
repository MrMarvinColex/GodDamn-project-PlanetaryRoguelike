using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Particle_CommonBluster : MonoBehaviour
{
    // Logic Privates
    private bool alreadyTouched_ = false;

    // General Privates
    private string targetTag_ = "Enemy";
    private int damage_ = 1;

    void OnParticleCollision(GameObject other)
    {
        // Get information about the object that the particle collided with
        if (alreadyTouched_) {
            return ;
        }

        alreadyTouched_ = true;
        if (other.CompareTag(targetTag_)) {
            Debug.LogWarning("Damage is - " + damage_);
            other.SendMessage("DecreaseHealth", damage_);
        }
    }

    public void SetDamage (int d) {
        Debug.LogWarning("Set damage to - " + damage_);
        damage_ = d;
    }
}
