using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Escape : MonoBehaviour
{

    void Update()
    {
        if(Input.GetKeyDown(KeyCode.Escape)){
            Application.Quit();
            Debug.Log("Quit game");
            }
    }

    public void OnPress()
    {
        Application.Quit();
        Debug.Log("Quit game");
    }
}
