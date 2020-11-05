using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;

public class GameController : MonoBehaviour
{
    public static GameController ThisInstance = null;
    public static int Score;
    public string ScorePrefix = string.Empty;
    public string HealthPrefix = string.Empty;
    public TMP_Text ScoreText = null;
    public TMP_Text HealthText = null;
    public GameObject player;
    
    void Awake()
    {
        ThisInstance = this;
        
    }

    // Update is called once per frame
    void Update()
    {
        Health H = player.GetComponent<Health>();
        if(ScoreText!= null)
        {
            ScoreText.text = ScorePrefix + Score.ToString();
        }

        if(HealthText!= null)
        {
            HealthText.text = HealthPrefix + H.HealthPoints.ToString();
        }
    }
    public static void GameOver()
    {
        SceneManager.LoadScene("EndScene");
    }
}
