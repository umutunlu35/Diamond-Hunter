using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GManager : MonoBehaviour
{
    public Text endGameScoreText;
    private int endGameScore;

    private void Start()
    {
        endGameScore = PlayerPrefs.GetInt("Score");
        if (SceneManager.GetActiveScene().buildIndex == 2)
        {
            endGameScoreText.text = "Score: " + endGameScore;
        }
    }
    public void PlayGame()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }

    public void FinishLevel()
    {
        SceneManager.LoadScene(2);
            
    }

    public void ExitGame()
    {
        PlayerPrefs.SetInt("Score", 0);
        Application.Quit();
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            PlayerPrefs.SetInt("Score", 0);
            Application.Quit();
        }
    }

    public void RestartGame()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex - 1);
        PlayerPrefs.SetInt("Score", 0);
    }
}
