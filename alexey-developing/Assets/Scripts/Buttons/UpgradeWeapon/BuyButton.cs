using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BuyButton : MonoBehaviour
{
    private int costBuy = 10;
    public int weaponIndex;
    public GameObject characteristics;
    public GameObject selectButton;

    void Start()
    {
        if (SaveGame.item.guns[weaponIndex].is_available)
        {
            gameObject.SetActive(false);
        }
        else
        {
            characteristics.SetActive(false);
            selectButton.SetActive(false);
        }
    }

    public void BuyWeapon()
    {
        Debug.Log("BuyWeapon");

        if (SaveGame.item.crystals >= costBuy)
        {
            Debug.Log("Successful");

            SaveGame.item.crystals -= costBuy;
            SaveGame.item.guns[weaponIndex].is_available = true;

            characteristics.SetActive(true);
            selectButton.SetActive(true);
            gameObject.SetActive(false);
        }
        else {
            Debug.Log("You do not have enough crystals");
        }
    }
}
