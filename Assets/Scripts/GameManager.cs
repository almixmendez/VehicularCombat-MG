using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{    
    //[SerializeField] private TextMeshProUGUI scoreText; //sacar
    private static GameManager inst;
    private CarControl carControl;
    static GameManager instance;
    private Vector3 respawnPosition;
    private bool gamePaused = false;
    [SerializeField] WinCondition winCondition;
    [SerializeField] LooseCondition looseCondition;

    void Start()
    {
        winCondition = FindObjectOfType<WinCondition>();
        looseCondition = FindObjectOfType<LooseCondition>();

        gamePaused = false;
        int isGamePaused = PlayerPrefs.GetInt("IsGamePaused", 0);

        if (isGamePaused == 1)
        {
            GameManager.instance.PauseGame();
        }
        else
        {
            GameManager.instance.UnpauseGame();
        }

        ////Cursor.lockState = CursorLockMode.Locked;
        //respawnPosition = carControl.instance.transform.position;
    }

    private void Awake()
    {
        instance = this;

        if (inst == null)
        {
            inst = this;
        }
        else
        {
            Destroy(gameObject);
        }
    }

    // Buttons.
    public void PlayGame()
    {
        Debug.Log("Cambio");
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }

    public void RestartGame()
    {
        Time.timeScale = 1;
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        winCondition.winScreen.SetActive(false);
        looseCondition.loosePanel.SetActive(false);
        gamePaused = false;
    }

    public void GoToMainMenu()
    {
        SceneManager.LoadScene("MainMenu");
        winCondition.winScreen.SetActive(false);
        looseCondition.loosePanel.SetActive(false);
        gamePaused = false;
    }

    public void Respawn()
    {
        carControl.instance.transform.position = respawnPosition;
        carControl.instance.gameObject.SetActive(true);
    }
    public void PauseGame()
    {
        Time.timeScale = 0;
        gamePaused = true;
    }

    private void ResumeGame()
    {
        Time.timeScale = 1;
        gamePaused = false;
    }

    public void UnpauseGame()
    {
        Time.timeScale = 1;
        gamePaused = false;
        PlayerPrefs.SetInt("IsGamePaused", gamePaused ? 1 : 0);
    }

    public void QuitGame()
    {
        Debug.Log("Quit!");
        Application.Quit();
    }
}
