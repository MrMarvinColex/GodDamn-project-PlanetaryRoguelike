using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class SelectButton : MonoBehaviour
{
    public int weaponIndex = 0;
    private string selected = "SELECTED";
    private string notSelected = "SELECT";

    void Update()
    {
        if (weaponIndex == SaveGame.item.enabled_gun)
        {
            GetComponentInChildren<TMP_Text>().text = selected;
        }
        else
        {
            GetComponentInChildren<TMP_Text>().text = notSelected;
        }
    }

    public void SelectWeapon()
    {
        SaveGame.item.enabled_gun = weaponIndex;
    }
}
