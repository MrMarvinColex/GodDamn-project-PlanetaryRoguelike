using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MagazineSizeUpgrade : MonoBehaviour
{
    public int weaponIndex;
    private int maxLevel = 5;
    private int cost = 1;
    private int magazineSizeAmount = 5;
    public void OnMouseUpAsButton()
    {
        Debug.Log("Upgrade magazine size\n");

        if (SaveGame.item.guns[weaponIndex].magazineSizeLevel == maxLevel)
        {
            Debug.Log("Your magazine size level is max\n");
        }
        else if (SaveGame.item.crystals < cost)
        {
            Debug.Log("You do not have enough crystals\n");
        }
        else
        {
            ++SaveGame.item.guns[weaponIndex].magazineSizeLevel;
            SaveGame.item.guns[weaponIndex].magazineSize += magazineSizeAmount;
            SaveGame.item.crystals -= cost;

            Debug.Log("Successful\n");
        }
    }
}
