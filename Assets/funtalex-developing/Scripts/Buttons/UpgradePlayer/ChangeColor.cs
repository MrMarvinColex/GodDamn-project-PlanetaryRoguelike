using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChangeColor : MonoBehaviour
{
    public Material material_;
    public GameObject[] levels;
    private Renderer renderer_;    
    
    void Start()
    {
        renderer_ = GetComponent<Renderer>();
        //renderer_.enabled
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
