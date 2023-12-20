using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.SceneManagement;

public class StartButton : MonoBehaviour
{
    private void OnMouseUpAsButton() {
        Debug.Log("Start Game\n");
        // Set variables from SaveGame.item to player and weapons:

        //Player.Set(SaveGame.item.armor, SaveGame.item.speedBoost, SaveGame.item.dodgeChance, SaveGame.item.criticalChance,
        //SaveGame.item.healthRecovery, SaveGame.item.crystals, SaveGame.item.xp);

        //Weapon.Set(SaveGame.item.guns)

        //Weapon.Enable(SaveGame.item.enabled_gun)
        
        SceneManager.LoadScene("Main1");
    }

}
