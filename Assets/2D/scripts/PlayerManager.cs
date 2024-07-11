using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
//this script will only be used for spawning cards afterwards 

public class PlayerManager : MonoBehaviour
{
    public int playerHealth = 500;
    public int manaAmmount = 10;
    public int maxMana = 10;
    public Vector3 nextPos = new Vector3(0f, 0f, 0f);
    public bool playerTurn = true;

    public DeckControl deckControl;
    int index = 0;

    

    void Start()
    {
        //GameObject cardStart = Resources.Load(deckControl.playerDeck[0].CardNickname) as GameObject;
        //Instantiate(cardStart);
        Debug.Log("AAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAA");
      
        playerTurn = true;
        
      

    }

    void Update()
    {
        if (playerHealth <= 0)
        {
            Debug.Log("GameOver");
        }
    //    if (Input.GetMouseButtonDown(0))
    //    {
    //        index = Random.Range(0, deckControl.playerDeck.Count - 1);
    //        playerHealth -= deckControl.playerDeck[index].CardAttackHealingAmount;
    //        Debug.Log("HP: " + playerHealth);
    //        Debug.Log(deckControl.playerDeck.Count);
    //        deckControl.playerDeck.RemoveAt(index);
            //DestroyImmediate(cardSpawn);
    //   }
        
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
        GameObject card = Instantiate(Resources.Load(deckControl.playerDeck[index].CardNickname, typeof(GameObject))) as GameObject;
        card.transform.position = new Vector3(-800,0,1000);

    }
}
