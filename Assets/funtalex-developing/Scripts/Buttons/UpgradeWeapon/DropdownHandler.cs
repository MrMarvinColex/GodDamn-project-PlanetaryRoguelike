using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DropdownHandler : MonoBehaviour
{
    public GameObject[] weaponUI;
    void Start()
    {
        Debug.Log("Start dropdown\n");
        TMPro.TMP_Dropdown dropdown = GetComponent<TMPro.TMP_Dropdown>();
        dropdown.options.Clear();
        foreach (SaveGame.GunData gunData in SaveGame.item.guns)
        {
            dropdown.options.Add(new TMPro.TMP_Dropdown.OptionData() { text = gunData.name });
        }

        dropdown.value = 0;
        
        DropdownItemSelected(dropdown);

        dropdown.onValueChanged.AddListener(delegate { DropdownItemSelected(dropdown); });
    }

    void DropdownItemSelected(TMPro.TMP_Dropdown dropdown)
    {
        Debug.Log("Change dropdown to "+ dropdown.value);
        int currentOption = dropdown.value;
        for (int index = 0; index < weaponUI.Length; ++index)
        {
            weaponUI[index].SetActive(index == currentOption);
        }
    }
}
