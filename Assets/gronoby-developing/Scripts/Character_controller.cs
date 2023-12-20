using System.Collections;
using System.Collections.Generic;
using UnityEngine;

class Player
{
    int max_health = 100;
    public int get_max_health()
    {
        return max_health;
    }
    public void set_max_health(int new_health)
    {
        max_health = new_health;
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
    float movespeed = 10f;
    public float get_movespeed()
    {
        return movespeed;
    }
    public void set_movespeed(float speed)
    {
        movespeed = speed;
    }
    int bonus_dmg;
    public int get_bonus_dmg()
    {
        return bonus_dmg;
    }
    public void set_bonus_dmg(int new_bonus_dmg)
    {
        bonus_dmg = new_bonus_dmg;
    }
    int armor;
    public int get_armor()
    {
        return armor;
    }
    public void set_armor(int new_armor)
    {
        armor = new_armor;
    }
    int exp_income = 0;
    public int get_exp_income()
    {
        return exp_income;
    }
    public void exp_getting(int exp)
    {
        exp_income += exp;
    }
    bool crystall = false;
    public bool crystall_found()
    {
        return crystall;
    }
    public void set_crystall_found(bool found_crystall)
    {
        crystall = found_crystall;
    }
    public bool is_damaged = false;

    public void get_dmg(int dmg)
    {
        
        current_health -= (Mathf.Max(dmg - armor, 0));
        is_damaged = true;
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
    private bool touching_crystall = false;
    GameObject crystall = null;

    void Start()
    {
        Speed = player.get_movespeed();
        _rb = GetComponent<Rigidbody>();
        _anim = GetComponent<Animator>();
    }

    void FixedUpdate()
    {
        if (player.get_current_health() > 0)
        {
            MovementLogic();
            LookingLogic();
        }
        DamageLogic();
        CrystallLogic();
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
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        float hitdist = 0;
        if (playerPlane.Raycast(ray, out hitdist))
        {
            Vector3 targetPoint = ray.GetPoint(hitdist);
            Quaternion targetRotation = Quaternion.LookRotation(transform.position - targetPoint);
            transform.rotation = Quaternion.Slerp(transform.rotation, targetRotation, Speed);
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

    private void CrystallLogic()
    {
        if (Input.GetKey(KeyCode.F) && touching_crystall)
        {
            crystall.SetActive(false);
            player.set_crystall_found(true);
            _anim.SetBool(taking_smth, true);
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.collider.CompareTag("Crystall"))
        {
            touching_crystall = true;
            crystall = collision.gameObject;
        }
    }
    private void OnCollisionExit(Collision collision)
    {
        if (collision.collider.CompareTag("Crystall"))
        {
            touching_crystall = false;
            crystall = null;
            _anim.SetBool(taking_smth, false);
        }
    }
}
