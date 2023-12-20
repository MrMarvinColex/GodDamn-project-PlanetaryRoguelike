using System.Collections;
using System.Collections.Generic;
using Unity.AI.Navigation;
using UnityEngine;
using UnityEngine.UIElements;

public class Prod_Nps : MonoBehaviour
{
    public Transform target;
    public NavMeshSurface nav_mesh;
    public enum MoveState {Idle, Walking}
    public MoveState moveState;

    public GameObject LFist;
    public GameObject RFist;

    private UnityEngine.AI.NavMeshAgent agent;
    private Animator animController;

    private bool to_player = false;
    private static readonly int state_ = Animator.StringToHash("state");
    private static readonly int isDied_ = Animator.StringToHash("idDied");
 
    private float speed = 5;
    private int health = 100;
    private bool died_ = false;

    private Vector3 start_position;

    void Start() {
        animController = GetComponent<Animator>();
        
        agent = GetComponent<UnityEngine.AI.NavMeshAgent>();
        agent.speed = speed;
        agent.stoppingDistance = 3;

        agent.autoBraking = true;
        agent.acceleration = 50;

        start_position = transform.position;

        nav_mesh.BuildNavMesh();
    }

    // Update is called once per frame
    void Update() {
        if (health < 0 && !died_) {
            died_ = true;
            // animController.SetBool(isDied_, true);
            animController.SetInteger(state_, 3);
            target.gameObject.SendMessage("exp_getting", 7);
            Destroy(this.gameObject, 10f);
        }

        if (died_) {
            return;
        }
        float dist = 10000;
        dist = Vector3.Distance(transform.position, target.position);
        
        if(dist < 10) {
            agent.destination = target.position;
            to_player = true;
        } else {
            agent.destination = start_position;
            to_player = false;
        }

        if (agent.remainingDistance > agent.stoppingDistance) {
            animController.SetInteger(state_, 1);
        }
        else if (to_player) {
            animController.SetInteger(state_, 2);
            LFist.SendMessage("Shoot");
            RFist.SendMessage("Shoot");
        }
        else {
            animController.SetInteger(state_, 0);
        }
    }

    public void set_nav_mesh(NavMeshSurface new_nav_mesh) {
        this.nav_mesh = new_nav_mesh;
    }
    public void set_target(Transform new_target) {
        this.target = new_target;
    }

    public void DecreaseHealth(int decrease_damage) {
        health -= decrease_damage;
    }
}
