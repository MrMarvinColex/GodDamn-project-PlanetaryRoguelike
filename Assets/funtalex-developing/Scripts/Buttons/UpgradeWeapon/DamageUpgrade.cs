using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DamageUpgrade : MonoBehaviour
{
    public int weaponIndex;
    private int maxLevel = 5;
    private int cost = 1;
    private int damageAmount = 10;
    public void OnMouseUpAsButton()
    {
        Debug.Log("Upgrade damage\n");

        if (SaveGame.item.guns[weaponIndex].damageLevel == maxLevel)
        {
            Debug.Log("Your damage level is max\n");
        }
        else if (SaveGame.item.crystals < cost)
        {
            Debug.Log("You do not have enough crystals\n");
        }
        else
        {
            ++SaveGame.item.guns[weaponIndex].damageLevel;
            SaveGame.item.guns[weaponIndex].damage += damageAmount;
            SaveGame.item.crystals -= cost;

            Debug.Log("Successful\n");
        }
    }
}
