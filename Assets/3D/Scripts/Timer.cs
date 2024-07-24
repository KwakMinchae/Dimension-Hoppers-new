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

    // Update is called once per frame
    void Update()
    {
        //int playerHealth = PlayerReceive.playerHealth; 
        if (remainingTime <= 0) //|| (playerHealth == 0))
        {
            SceneManager.LoadScene( sceneName );
            Destroy(thisscene);
        }

        remainingTime -= Time.deltaTime;
        int minutes = Mathf.FloorToInt(remainingTime / 60);
        int seconds = Mathf.FloorToInt(remainingTime % 60);
        timerText.text = remainingTime.ToString("f0");
        //timerText.text = string.Format("{0:00}:{1:00}", minutes, seconds);

        transform.rotation = camera.transform.rotation;
    }
}
