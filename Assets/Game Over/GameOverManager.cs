using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameOverManager : MonoBehaviour
{
    public void gameRestart()
    {
        SceneManager.LoadScene("2D");
    }

    public void backToMain()
    {
        SceneManager.LoadScene("Main Menu");
    }

    public void quitGame()
    {
        Application.Quit();
    }
}
