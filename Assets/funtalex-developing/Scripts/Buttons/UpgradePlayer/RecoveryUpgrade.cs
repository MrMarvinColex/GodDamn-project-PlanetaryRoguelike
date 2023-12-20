using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RecoveryUpgrade : MonoBehaviour
{
    private int maxLevel = 5;
    private int recoveryCostXP = 1;
    private float recoveryAmount = 1f;
    public void OnMouseUpAsButton()
    {
        Debug.Log("Upgrade recovery\n");

        if (SaveGame.item.healthRecoveryLevel == maxLevel)
        {
            Debug.Log("Your recovery level is max\n");
        }
        else if (SaveGame.item.xp < recoveryCostXP)
        {
            Debug.Log("You do not have enough xp\n");
        }
        else
        {
            ++SaveGame.item.healthRecoveryLevel;
            SaveGame.item.healthRecovery += recoveryAmount;
            SaveGame.item.xp -= recoveryCostXP;

            Debug.Log("Successful\n");
        }
    }
}
