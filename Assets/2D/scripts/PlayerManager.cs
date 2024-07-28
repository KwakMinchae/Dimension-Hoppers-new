using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;


public class PlayerManager : MonoBehaviour //this script will only be used for spawning cards and store variables for the whole game
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

    public TextMeshProUGUI manaText; //text to show current player mana
    public TextMeshProUGUI playerHealthText; //text to show player's health
    public TextMeshProUGUI enemyHealthText; //text to show enemy's health
    public TextMeshProUGUI actionText; //text to show action taken
    public TextMeshProUGUI turnNumberText; //text to show current turn number


    void Start()
    {
        playerTurn = true;   
        LoadHealth(); //Get player's and enemy's health from playerprefs
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
            turnNumberText.text = "Dimension Hopping!"; //gameCycle == 4 will dimension hop automatically
        }
        

        if (Input.GetKeyDown(KeyCode.Space)) { //to switch playerTurn
            playerTurn = false;
        }
 
        if (playerHealth <= 0 ) //gameover scenario where enemy wins
        {
            SceneManager.LoadScene("GameOver");
            gameover = true;
        }
        else if (enemyHealth <= 0) //gameover scenario where player wins
        {
            SceneManager.LoadScene("YouWin");
            gameover = true;
        }


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
        if (playerTurn == true && gameCycle == 0) //check if it is player's turn
        {
            for (int i = 0; i < 5; i++) //initial spawn five cards
            {
                CardSpawn();
            }
            DimensionHopCardSpawn(); //spawn the DimensionHopCard if it is a new load of 2D
            gameCycle++;
            Debug.Log("Initialize Gamecycle: " + gameCycle);
            Spawned = true;
        }
        else if (playerTurn == true && Spawned == false)
        {
            for (int i = 0; i < 5; i++) //spawn five cards at once to "refresh" the board of cards
            {
                CardSpawn();
            }

            gameCycle++;
            manaAmmount = 10; //reseting player mana amount 
            Spawned = true;
            Debug.Log("Gamecycle: " + gameCycle);
        }

        if (gameCycle == 4) //dimensionhop scenario reached
        {
            Debug.Log("Gamecycle: " + gameCycle);
            SceneManager.LoadScene("3D");
        }
    }

    void CardSpawn()
    {
        GameObject card = Instantiate(Resources.Load(deckControl.playerDeck[index].CardNickname, typeof(GameObject))) as GameObject; //spawn card as a game object into the game
        card.transform.position = nextPos[posAvailable];
        posAvailable++;
        index++;
        if (posAvailable > 4)
        {
            posAvailable = 0; //loop through the five existing positions to do a full "refresh" of cards on hand each turn
        }
        if (index >= 30)
        {
            index = 0; //ensure there will not be out of range of index
        }
    }

    void DimensionHopCardSpawn()
    {
        GameObject dimensionHopCard = Instantiate(Resources.Load("Dimension Hop", typeof(GameObject))) as GameObject; //spawn dimensionHop card as a game object into the game
        dimensionHopCard.transform.position = new Vector3(700, 0, 1000); //fixed position for dimensionHop card as it can only spawn once each load of 2D
    }
}
