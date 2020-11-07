using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement; 

public class StartButton : MonoBehaviour
{
   public string NextScene;
   public void OnPress()
    {
        GameController.Score = 0;
        Debug.Log("Start clicked.");
        SceneManager.LoadScene(NextScene);
            
    }
}
