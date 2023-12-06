using System.Collections;
using System.Collections.Generic;
using Unity.AI.Navigation;
using UnityEngine;

public class nps : MonoBehaviour
{
    public Transform target;
    private UnityEngine.AI.NavMeshAgent agent;
    public float speed = 10f;

    public NavMeshSurface nav_mesh;
    // Start is called before the first frame update
    void Start()
    {
        agent = GetComponent<UnityEngine.AI.NavMeshAgent>();
        agent.speed = speed;
        agent.stoppingDistance = 5;

        nav_mesh.BuildNavMesh();
    }

    // Update is called once per frame
    void Update()
    {
        agent.destination = target.position;
    }
}
