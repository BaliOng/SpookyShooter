using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class ShowScore : MonoBehaviour

{   
    public TMP_Text ScoreText = null;
    // Start is called before the first frame update
    void Awake()
    {
        ScoreText.text = "Final Score: " + GameController.Score.ToString();
    }
}
