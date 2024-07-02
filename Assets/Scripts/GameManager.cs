using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    int score;
    public static GameManager inst;

    public TextMeshProUGUI scoreText;

    private CarControl carControl;
    private void Awake()
    {
        if (inst == null)
        {
            inst = this;
        }
        else
        {
            Destroy(gameObject);
        }
    }
    public void IncrementScore()
    {
        score++;
        scoreText.text = "Score: " + score.ToString();
    }

    public void QuitGame()
    {
        Debug.Log("Quit!");
        Application.Quit();
    }
}
