using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
//this script will only be used for spawning cards afterwards 

public class PlayerManager : MonoBehaviour
{
    public int playerHealth;
    public int manaAmmount = 10;
    public int maxMana = 10;

    public int enemyHealth;
    public int enemymanaAmmount = 10;
    public int enemymaxMana = 10;

    public bool playerTurn;
    public int gameCycle;
    public bool gameover = false;
    public bool Spawned = false;

    public Vector3[] nextPos = new Vector3[5];
    public int posAvailable = 0; //index for nextPos

    public DeckControl deckControl;
    public int index = 0;

    public TextMeshProUGUI manaText;
    public TextMeshProUGUI playerHealthText;
    public TextMeshProUGUI enemyHealthText;
    public TextMeshProUGUI actionText;
    public TextMeshProUGUI turnNumberText;


    void Start()
    {
        Debug.Log("Before loadhealth: " + playerHealth);
        playerTurn = true;   
        LoadHealth();
        Debug.Log("After loadhealth: " + playerHealth);
        gameCycle = 0;

    }

    void Update()
    {
        manaText.text = manaAmmount.ToString();
        playerHealthText.text = playerHealth.ToString(); 
        enemyHealthText.text = enemyHealth.ToString();
        if (gameCycle != 4)
        {
            turnNumberText.text = "Turn: " + gameCycle.ToString();
        } else
        {
            turnNumberText.text = "Dimension Hopping!"; 
        }
        

        if (Input.GetKeyDown(KeyCode.Space)) {
            playerTurn = false;
            Debug.Log("Space: " + playerTurn);
        }
//Commented out? 
        if (playerHealth <= 0 )
        {
            SceneManager.LoadScene("GameOver");
            gameover = true;
        }
        else if (enemyHealth <= 0)
        {
            SceneManager.LoadScene("YouWin");
            gameover = true;
        }
//Commented out?

// Playerpref for Health
        if (Time.timeSinceLevelLoad >= 29)
        {
            SaveHealth();
        }
    }

    void SaveHealth()
    {
        PlayerPrefs.SetInt("PlayerHealth", playerHealth);
        PlayerPrefs.SetInt("EnemyHealth", enemyHealth); 
        PlayerPrefs.Save();
    }

    void LoadHealth()
    {
        playerHealth = PlayerPrefs.GetInt("PlayerHealth", 500); 
        enemyHealth = PlayerPrefs.GetInt("EnemyHealth", 500); 
    }
// Playerpref for Health (ended)

    private void FixedUpdate()
    {
        if (playerTurn == true && gameCycle == 0)
        {
            for (int i = 0; i < 5; i++)
            {
                CardSpawn();
            }
            DimensionHopCardSpawn();
            gameCycle++;
            Debug.Log("Initialize Gamecycle: " + gameCycle);
            Spawned = true;
        }
        else if (playerTurn == true && Spawned == false)
        {
            for (int i = 0; i < 5; i++)
            {
                CardSpawn();
            }

            gameCycle++;
            manaAmmount = 10;
            Spawned = true;
            Debug.Log("Gamecycle: " + gameCycle);
        }

        if (gameCycle == 4)
        {
            Debug.Log("Gamecycle: " + gameCycle);
            SceneManager.LoadScene("3D");
        }
    }

    void CardSpawn()
    {
        GameObject card = Instantiate(Resources.Load(deckControl.playerDeck[index].CardNickname, typeof(GameObject))) as GameObject;
        card.transform.position = nextPos[posAvailable];
        posAvailable++;
        index++;
        if (posAvailable > 4)
        {
            posAvailable = 0;
        }
        if (index >= 30)
        {
            index = 0;
        }
    }

    void DimensionHopCardSpawn()
    {
        GameObject dimensionHopCard = Instantiate(Resources.Load("Dimension Hop", typeof(GameObject))) as GameObject;
        dimensionHopCard.transform.position = new Vector3(700, 0, 1000);
    }
}
