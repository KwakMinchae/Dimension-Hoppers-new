using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenuGameManager : MonoBehaviour
{
    public void gameStart()
    {
        SceneManager.LoadScene("2D");
    }

    public void quitGame()
    {
        Application.Quit();
    }
}
