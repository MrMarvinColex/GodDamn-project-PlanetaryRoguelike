using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpeedUpgrade : MonoBehaviour
{
    private int maxLevel = 5;
    private int speedCostXP = 1;
    private float speedAmount = 0.2f;
    public void OnMouseUpAsButton()
    {
        Debug.Log("Upgrade speed\n");

        if (SaveGame.item.speedBoostLevel == maxLevel)
        {
            Debug.Log("Your speed level is max\n");
        }
        else if (SaveGame.item.xp < speedCostXP)
        {
            Debug.Log("You do not have enough xp\n");
        }
        else
        {
            ++SaveGame.item.speedBoostLevel;
            SaveGame.item.speedBoost += speedAmount;
            SaveGame.item.xp -= speedCostXP;

            Debug.Log("Successful\n");
        }
    }
}
