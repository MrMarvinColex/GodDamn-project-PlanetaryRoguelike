using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class UpdateCrystalsText : MonoBehaviour
{
     void Update()
    {
        GetComponent<TMP_Text>().text = "Crystals: " + SaveGame.item.crystals;
    }
}
