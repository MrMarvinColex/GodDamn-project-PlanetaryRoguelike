using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DodgeUpgrade : MonoBehaviour
{
    private int maxLevel = 5;
    private int dodgeCostXP = 1;
    private float dodgeAmount = 0.1f;
    public void OnMouseUpAsButton()
    {
        Debug.Log("Upgrade dodge\n");

        if (SaveGame.item.dodgeChanceLevel == maxLevel)
        {
            Debug.Log("Your dodge level is max\n");
        }
        else if (SaveGame.item.xp < dodgeCostXP)
        {
            Debug.Log("You do not have enough xp\n");
        }
        else
        {
            ++SaveGame.item.dodgeChanceLevel;
            SaveGame.item.dodgeChance += dodgeAmount;
            SaveGame.item.xp -= dodgeCostXP;

            Debug.Log("Successful\n");
        }
    }
}
