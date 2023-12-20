using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class UpdateXpText : MonoBehaviour
{
    void Update()
    {
        GetComponent<TMP_Text>().text = "XP: " + SaveGame.item.xp;
    }
}
