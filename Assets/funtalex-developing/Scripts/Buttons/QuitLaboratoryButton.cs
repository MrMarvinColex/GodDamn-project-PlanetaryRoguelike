using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class QuitLaboratoryButton : MonoBehaviour
{
    public Animator anim;
    void OnMouseUpAsButton()
    {
        Debug.Log("Quit Laboratory\n");
        
        anim.Play("QuitLabAnim");
    }
}
