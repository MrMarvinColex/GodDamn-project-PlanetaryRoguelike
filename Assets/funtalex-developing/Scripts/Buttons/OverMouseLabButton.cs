using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OverMouseLabButton : MonoBehaviour
{
    private float rotateSpeed = 30f;
    private Vector3 rotateDirection = new Vector3(0f, 1f, 0f);
    private Vector3 defaultRotation = new Vector3(0f, 0f, 0f);

    private void OnMouseOver() 
    {
        transform.Rotate(rotateDirection * rotateSpeed * Time.deltaTime);
    }

    private void OnMouseExit() 
    {
        transform.eulerAngles = defaultRotation;
    }
}
