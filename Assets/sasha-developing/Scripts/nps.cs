using System.Collections;
using System.Collections.Generic;
using Unity.AI.Navigation;
using UnityEngine;
using UnityEngine.UIElements;

public class Nps : MonoBehaviour
{
    public Transform target;
    private UnityEngine.AI.NavMeshAgent agent;
    private Animator animController;
    public enum MoveState {Idle, Walking}
    public MoveState moveState;

    private bool to_player = false;

 
    private float speed = 5;

    private int health = 100;

    private Vector3 start_position;

    public NavMeshSurface nav_mesh;
    // Start is called before the first frame update

    public void set_nav_mesh(NavMeshSurface new_nav_mesh)
    {
        this.nav_mesh = new_nav_mesh;
    }

    public void set_target(Transform new_target)
    {
        this.target = new_target;
    }
    void Start()
    {
        animController = GetComponent<Animator>();
        
        agent = GetComponent<UnityEngine.AI.NavMeshAgent>();
        agent.speed = speed;
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
        {
            agent.destination = target.position;
            to_player = true;
        }
            
        else
        {
            agent.destination = start_position;
            to_player = false;
        }

        if(agent.remainingDistance > agent.stoppingDistance)
            animController.SetInteger("state", 1);
        else if(to_player)
            animController.SetInteger("state", 2);
        else
            animController.SetInteger("state", 0);

    }
}
