using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro; 
using UnityEngine.SceneManagement;

public class Timer : MonoBehaviour
{
    [SerializeField] TextMeshProUGUI timerText; 
    [SerializeField] float remainingTime; 
    [SerializeField] string sceneName = "2D";
    [SerializeField] private Camera camera;
    [SerializeField] GameObject thisscene;

    void Update()
    {
        if (remainingTime <= 0) 
        {
            SceneManager.LoadScene( sceneName ); 
            Destroy(thisscene);
        }

        remainingTime -= Time.deltaTime; //countdown timer
        int minutes = Mathf.FloorToInt(remainingTime / 60);
        int seconds = Mathf.FloorToInt(remainingTime % 60);
        timerText.text = remainingTime.ToString("f0");

        transform.rotation = camera.transform.rotation; //timer text always shows on screen
    }
}
