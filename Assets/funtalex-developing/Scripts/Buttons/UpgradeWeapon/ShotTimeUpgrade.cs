using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShotTimeUpgrade : MonoBehaviour
{
    public int weaponIndex;
    private int maxLevel = 5;
    private int cost = 1;
    private float shotTimeAmount = -0.1f;
    public void OnMouseUpAsButton()
    {
        Debug.Log("Upgrade shot time\n");

        if (SaveGame.item.guns[weaponIndex].shotTimeLevel == maxLevel)
        {
            Debug.Log("Your shot time level is max\n");
        }
        else if (SaveGame.item.crystals < cost)
        {
            Debug.Log("You do not have enough crystals\n");
        }
        else
        {
            ++SaveGame.item.guns[weaponIndex].shotTimeLevel;
            SaveGame.item.guns[weaponIndex].shotTime += shotTimeAmount;
            SaveGame.item.crystals -= cost;

            Debug.Log("Successful\n");
        }
    }
}
