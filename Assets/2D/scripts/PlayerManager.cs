using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;
//this script will only be used for spawning cards afterwards 

public class PlayerManager : MonoBehaviour
{
    public int playerHealth = 500;
    public int manaAmmount = 10;
    public int maxMana = 10;

    public int enemyHealth = 500;
    public int enemymanaAmmount = 10;
    public int enemymaxMana = 10;

    public bool playerTurn = false;
    public int gameCycle = 0;
    public bool gameover = false;
    public int lastSpawn = 0;

    public Vector3[] nextPos = new Vector3[5];
    public int posAvailable = 0; //index for nextPos

    public DeckControl deckControl;
    int index = 0;

    public TextMeshProUGUI manaText;
    public TextMeshProUGUI playerHealthText;
    public TextMeshProUGUI enemyHealthText;
 

    void Start()
    {
        playerTurn = true;   
        LoadHealth();
    }

    void Update()
    {
        manaText.text = manaAmmount.ToString();
        playerHealthText.text = playerHealth.ToString(); 
        enemyHealthText.text = enemyHealth.ToString();

        if (playerHealth <= 0 && gameover != false)
        {
            Debug.Log("Game Over, enemy wins");
            gameover = true;
        }
        else if (enemyHealth <= 0 && gameover != false)
        {
            Debug.Log("Game Over, player wins");
            gameover = true;
        }

        if (Input.GetKeyDown(KeyCode.Space)) 
        {
            playerTurn = !playerTurn;
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
        PlayerPrefs.Save();
    }

    void LoadHealth()
    {
        playerHealth = PlayerPrefs.GetInt("PlayerHealth", 500); 
    }
// Playerpref for Health (ended)

    private void FixedUpdate()
    {if (playerTurn == true && gameCycle == 0)
        {
            for (int i = 0; i < 5; i++)
            {
                CardSpawn();
            }
            gameCycle++;
        }
        else if (playerTurn == true && gameCycle%2 == 0 )
        {
            CardSpawn();
            gameCycle++;
            manaAmmount = 10;
        }

    if (lastSpawn % 3 == 0)
        {
            DimensionHopCardSpawn();
            lastSpawn++;
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
