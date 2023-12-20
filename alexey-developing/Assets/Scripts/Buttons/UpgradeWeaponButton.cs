using System.Collections;
using System.Collections.Generic;
using JetBrains.Annotations;
using UnityEngine;

public class UpgradeWeaponButton : MonoBehaviour
{
    //private int cost_crystals = 1;
    private void OnMouseUpAsButton()
    {
        Debug.Log("Upgrade weapon\n");

        /*if (SaveGame.item.crystals >= cost_crystals)
        {
            Debug.Log("Successful upgrade\n");
            SaveGame.item.crystals -= cost_crystals;
            SaveGame.item.guns[0].damage += 1;
        }
        else
        {
            Debug.Log("Not enough coins to upgrade\n");
        }*/
    }
}
