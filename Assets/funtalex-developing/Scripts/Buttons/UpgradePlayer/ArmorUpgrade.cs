using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ArmorUpgrade : MonoBehaviour
{
    private int maxLevel = 5;
    private int armorCostXP = 1;
    private int armorAmount = 2;
    public void OnMouseUpAsButton()
    {
        Debug.Log("Upgrade armor\n");

        if (SaveGame.item.armorLevel == maxLevel)
        {
            Debug.Log("Your armor level is max\n");
        }
        else if (SaveGame.item.xp < armorCostXP)
        {
            Debug.Log("You do not have enough xp\n");
        }
        else
        {
            ++SaveGame.item.armorLevel;
            SaveGame.item.armor += armorAmount;
            SaveGame.item.xp -= armorCostXP;

            Debug.Log("Successful\n");
        }
    }

}
