using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy_DecreaseHealth : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void DecreaseHealth() {
        gameObject.SetActive(false);
    }
}
