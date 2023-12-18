using System.Collections;
using System.Collections.Generic;
using Unity.AI.Navigation;
using UnityEngine;
using UnityEngine.UIElements;

public class nps : MonoBehaviour
{
    public Transform target;
    private UnityEngine.AI.NavMeshAgent agent;
    private Animator animController;
    public enum MoveState {Idle, Walking}
    public MoveState moveState;
 
    //public float speed = 5f;

    private int health = 100;

    private Vector3 start_position;

    public NavMeshSurface nav_mesh;
    // Start is called before the first frame update
    void Start()
    {
        animController = GetComponent<Animator>();
        
        agent = GetComponent<UnityEngine.AI.NavMeshAgent>();
        agent.speed = 5;
        agent.stoppingDistance = 5;

        agent.autoBraking = true;
        agent.acceleration = 50;

        start_position = transform.position;

        nav_mesh.BuildNavMesh();
    }

    // Update is called once per frame
    void Update()
    {
        float dist = 10000;
        if(agent.pathPending)
        {
            dist = Vector3.Distance(transform.position, target.position);
        }
        else
        {
            dist = agent.remainingDistance;
        }
        
        if(dist < 10)
            agent.destination = target.position;
        else
            agent.destination = start_position;

    }
}
