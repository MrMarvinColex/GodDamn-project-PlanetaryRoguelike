using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UpgradePlayerButton : MonoBehaviour
{
    public GameObject quitLabButton;
    public GameObject upgradePlayerButton;
    public GameObject upgradeWeaponButton;
    public GameObject upgradeUI;
    private Vector3 defaultRotation = new Vector3(0f, 0f, 0f);

    private void OnMouseUpAsButton()
    {
        Debug.Log("Upgrade player menu\n");

        transform.eulerAngles = defaultRotation;

        quitLabButton.SetActive(false);
        upgradePlayerButton.SetActive(false);
        upgradeWeaponButton.SetActive(false);
        upgradeUI.SetActive(true);


    }
}
