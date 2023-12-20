using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.SceneManagement;

public class StartButton : MonoBehaviour
{
    public GameObject player;
    public GameObject weapon;
    private int maxHealth = 100;
    private float speed = 10f;
    private int damage = 0;
    private void OnMouseUpAsButton() {
        Debug.Log("Start Game\n");
        
        // SetEssentials();

        SceneManager.LoadScene("Main1");
    }

    private void SetEssentials()
    {
        player.SendMessage("set_max_health", maxHealth + SaveGame.item.armor);
        player.SendMessage("set_current_health", maxHealth + SaveGame.item.armor);
        player.SendMessage("set_movespeed", speed * SaveGame.item.speedBoost);

        player.SendMessage("SetWeapon", SaveGame.item.enabled_gun);
    }

}
