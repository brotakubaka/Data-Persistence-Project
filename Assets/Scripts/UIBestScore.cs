using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIBestScore : MonoBehaviour
{
    public Text bestScoreText;
    // Start is called before the first frame update
    void Start()
    {
        MainManager.Instance.LoadHighScore();

        Debug.Log("High Score: " + MainManager.Instance.highScore);

        if (MainManager.Instance != null)
        {
            if (MainManager.Instance.highScore != 0)
            {
                DisplayHighScore();
            }
            
        }
        else
        {
            bestScoreText.text = "";
        }
    }

    void DisplayHighScore()
    {
        bestScoreText.text = $"High Score: {MainManager.Instance.highScoreName} : {MainManager.Instance.highScore}";
    }

    
    
}
