using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ExitButton : MonoBehaviour
{
    private void OnMouseUpAsButton() {
        Debug.Log("Exit Game\n");
        Application.Quit();
    }
}
