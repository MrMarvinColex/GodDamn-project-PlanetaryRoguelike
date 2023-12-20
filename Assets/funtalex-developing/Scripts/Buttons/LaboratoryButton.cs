using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LaboratoryButton : MonoBehaviour
{
    public Animator anim;

    private void OnMouseUpAsButton() {
        Debug.Log("Go to Laboratory\n");
        
        anim.Play("GoLabAnim");

    }
}
