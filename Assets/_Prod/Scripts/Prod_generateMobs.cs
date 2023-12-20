using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Unity.AI.Navigation;

public class Prod_GenerateMobs : MonoBehaviour
{
    public int n_enemies = 1;

    public float delta_pos = 10f;

    public Transform enemy_target;

    public NavMeshSurface nav_mesh_enemy;

    public GameObject enemy;
    // Start is called before the first frame update
    void Start()
    {
        for(int x = 0; x < n_enemies; ++x)
        {
            Vector3 pos = new Vector3(transform.position.x + UnityEngine.Random.Range(-delta_pos, delta_pos), transform.position.y, transform.position.z + UnityEngine.Random.Range(-delta_pos, delta_pos));

            var obj = Instantiate(enemy, pos, transform.rotation);

            //UnityEngine.AI.NavMeshAgent agent = GetComponent<UnityEngine.AI.NavMeshAgent>();
            //agent.target = enemy_target;
            obj.SendMessage("set_nav_mesh", nav_mesh_enemy);
            obj.SendMessage("set_target", enemy_target);

            //enemy.SendMessage("set_nav_mesh", nav_mesh_enemy);
        }
    }

    // Update is called once per frame
    void Update()
    {
    }
}
