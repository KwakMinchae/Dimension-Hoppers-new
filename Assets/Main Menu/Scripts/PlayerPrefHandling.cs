using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerPrefHandling : MonoBehaviour
{
    int playerHealth = 500;
    int enemyHealth = 500;

    private void Start()
    {
        LoadScene();
    }
    void LoadScene()
    {
        PlayerPrefs.SetInt("PlayerHealth", playerHealth);
        PlayerPrefs.SetInt("EnemyHealth", enemyHealth);
        PlayerPrefs.Save();
    }
    

}
