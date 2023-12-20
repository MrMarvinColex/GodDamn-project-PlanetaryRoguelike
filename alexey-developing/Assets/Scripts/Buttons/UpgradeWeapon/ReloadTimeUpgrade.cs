using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ReloadTimeUpgrade : MonoBehaviour
{
    public int weaponIndex;
    private int maxLevel = 5;
    private int cost = 1;
    private float reloadTimeAmount = -0.2f;
    public void OnMouseUpAsButton()
    {
        Debug.Log("Upgrade reload time\n");

        if (SaveGame.item.guns[weaponIndex].reloadTimeLevel == maxLevel)
        {
            Debug.Log("Your reload time level is max\n");
        }
        else if (SaveGame.item.crystals < cost)
        {
            Debug.Log("You do not have enough crystals\n");
        }
        else
        {
            ++SaveGame.item.guns[weaponIndex].reloadTimeLevel;
            SaveGame.item.guns[weaponIndex].reloadTime += reloadTimeAmount;
            SaveGame.item.crystals -= cost;

            Debug.Log("Successful\n");
        }
    }
}
