using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DefaultButton : MonoBehaviour
{

    public Outline borderScript;

    void Awake() 
    {
        borderScript = GetComponent<Outline>();
        borderScript.enabled = false;
    }

    private void OnMouseOver() 
    {
        borderScript.enabled = true;
    }

    private void OnMouseExit() 
    {
        borderScript.enabled = false;
    }
}
