using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class QuitUpgradeWeapon : MonoBehaviour
{
    public GameObject quitLabButton;
    public GameObject upgradePlayerButton;
    public GameObject upgradeWeaponButton;
    public GameObject upgradeUI;
    public void OnMouseUpAsButton()
    {
        Debug.Log("Quit Weapon Upgrade");
        upgradeUI.SetActive(false);
        upgradePlayerButton.SetActive(true);
        quitLabButton.SetActive(true);
        upgradeWeaponButton.SetActive(true);
    }
}
