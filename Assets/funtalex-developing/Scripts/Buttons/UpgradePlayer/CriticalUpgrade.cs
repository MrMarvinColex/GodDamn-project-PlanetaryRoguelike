using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CriticalUpgrade : MonoBehaviour
{
    private int maxLevel = 5;
    private int criticalCostXP = 1;
    private float criticalAmount = 0.1f;
    public void OnMouseUpAsButton()
    {
        Debug.Log("Upgrade critical chance\n");

        if (SaveGame.item.criticalChanceLevel == maxLevel)
        {
            Debug.Log("Your critical level is max\n");
        }
        else if (SaveGame.item.xp < criticalCostXP)
        {
            Debug.Log("You do not have enough xp\n");
        }
        else
        {
            ++SaveGame.item.criticalChanceLevel;
            SaveGame.item.criticalChance += criticalAmount;
            SaveGame.item.xp -= criticalCostXP;

            Debug.Log("Successful\n");
        }
    }
}
