using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class PlayerManager : MonoBehaviour
{
    public int playerHealth = 500;
    public int manaAmmount = 10;
    public int maxMana = 10;
    public Vector3 nextPos = new Vector3(0f, 0f, 0f);
    public bool playerTurn = false;

    public DeckControl deckControl;
    int index = 0;

    [SerializeField] GameObject cardSpawn;
    // Start is called before the first frame update
    void Start()
    {
        Instantiate(cardSpawn, new Vector3(-100, 0f, 0f), Quaternion.identity);
        Instantiate(cardSpawn, new Vector3(100, 0f, 0f), Quaternion.identity);
        //playerTurn = true;

    }

    // Update is called once per frame
    void Update()
    {
        if (playerHealth <= 0)
        {
            Debug.Log("GameOver");
        }
        if (Input.GetMouseButtonDown(0))
        {
            index = Random.Range(0, deckControl.deck.Count - 1);
            playerHealth -= deckControl.deck[index].CardAttackHealingAmount;
            Debug.Log("HP: " + playerHealth);
            Debug.Log(deckControl.deck.Count);
            deckControl.deck.RemoveAt(index);
            DestroyImmediate(cardSpawn);
        }
        if (Input.GetKeyDown(KeyCode.Space)) 
        {
            playerTurn = !playerTurn;
        }
    }

    private void FixedUpdate()
    {if (playerTurn == true)
        {
            CardSpawn();
            playerTurn = false;
        }
    }

    void CardSpawn()
    {
        GameObject card = Instantiate(cardSpawn, nextPos, Quaternion.identity);
        
        
    }
}
