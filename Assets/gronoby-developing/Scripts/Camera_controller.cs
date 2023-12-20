using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Camera_controller : MonoBehaviour
{
    
    public Transform target;
    public Vector3 offset = new Vector3(0, 15, -15);
    public float smoothTime = 0.25f;
    Vector3 currentVelocity;
    private void LateUpdate()
    {
        transform.position = Vector3.SmoothDamp(
            transform.position,
            target.position + offset,
            ref currentVelocity,
            smoothTime
            );
        /*if (Input.GetKey(KeyCode.E))
        {
            transform.RotateAround(target.transform.position, Vector3.up, 20 * Time.deltaTime);
        }
        if (Input.GetKey(KeyCode.Q))
        {
            transform.RotateAround(target.transform.position, Vector3.up, -20 * Time.deltaTime);
        }*/
    }
}
