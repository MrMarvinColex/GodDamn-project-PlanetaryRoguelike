using System.Collections;
using System.Collections.Generic;
using UnityEngine;

class Weapon 
{
    public void shoot(int bonus_dmg) { }
    // Weapon.SetBonusDamage(damage, seconds) {}
}
class Player
{
    int max_health = 100;
    public int get_max_health()
    {
        return max_health;
    }
    int current_health = 100;
    public void set_current_health(int health)
    {
        this.current_health = Mathf.Min(max_health, health);
    }
    public int get_current_health()
    {
        return current_health;
    }
    Weapon weapon;
    float movespeed = 10f;
    public float get_movespeed()
    {
        return movespeed;
    }
    int bonus_dmg;
    int armor;
    public bool is_damaged = false;
    public Player() { }

    public void get_dmg(int dmg)
    {
        current_health -= (dmg - armor);
        is_damaged = true;
    }

    public void shoot()
    {
        this.weapon.shoot(bonus_dmg);
    }
}

public class Character_controller : MonoBehaviour
{
    Player player = new Player();
    public float Speed = 10f;
    private Animator _anim;
    private static readonly int walking = Animator.StringToHash("Walking");
    private static readonly int taking_smth = Animator.StringToHash("Taking_smth");
    private static readonly int damage_taking = Animator.StringToHash("Damage_taking");
    private static readonly int alive = Animator.StringToHash("Alive");
    private Rigidbody _rb;

    void Start()
    {
        Speed = player.get_movespeed();
        _rb = GetComponent<Rigidbody>();
        _anim = GetComponent<Animator>();
    }

    // �������� �������� ��� ��� �������� � ������� 
    // ���������� ������������ � FixedUpdate, � �� � Update
    void FixedUpdate()
    {
        /*if (player.get_current_health() > 0)
        {
            MovementLogic();
            LookingLogic();
        }*/
        //DamageLogic();
        MovementLogic();
        LookingLogic();
    }

    private void MovementLogic()
    {
        float moveHorizontal = Input.GetAxis("Horizontal");

        float moveVertical = Input.GetAxis("Vertical");

        Vector3 movement = new Vector3(moveHorizontal, 0.0f, moveVertical);
        _rb.velocity = new Vector3(0f, _rb.velocity.y, 0f);
        _rb.AddForce(movement * Speed, ForceMode.VelocityChange);
        if (movement.magnitude > 0)
        {
            _anim.SetBool(walking, true);
        }
        else
        {
            _anim.SetBool(walking, false);
        }
    }

    private void LookingLogic()
    {       
        Plane playerPlane = new Plane(Vector3.up, transform.position);
        Ray ray = Camera.main.ScreenPointToRay (Input.mousePosition);
        float hitdist = 0;
        if (playerPlane.Raycast (ray, out hitdist)) 
        { 			
            Vector3 targetPoint = ray.GetPoint (hitdist);
            Quaternion targetRotation = Quaternion.LookRotation (transform.position - targetPoint);
            transform.rotation = Quaternion.Slerp (transform.rotation, targetRotation, Speed);
        } 	
    }

    private void DamageLogic()
    {
        if (player.is_damaged)
        {
            _anim.SetBool(damage_taking, true);
            if (player.get_current_health() <= 0)
            {
                _anim.SetBool(alive, false);
            }
            player.is_damaged = false;
        }
        else
        {
            _anim.SetBool(damage_taking, false);
        }
    }
    }
