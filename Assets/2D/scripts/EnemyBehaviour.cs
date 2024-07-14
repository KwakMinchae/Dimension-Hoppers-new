using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class EnemyBehaviour : MonoBehaviour
{
    

    public CardData cardData;
    [SerializeField] private List<CardData> miniDeck = new List<CardData>(5);

    public DeckControl deckControl;
    int index = 0;
    
    public PlayerManager playerManager;
    public int playerHealth;
    public bool playerTurn;

    // Start is called before the first frame update
    void Start()
    {
      playerHealth = playerManager.playerHealth;
      
        for (int i = 0; i < 5; i++)
        {
            miniDeck[i] = deckControl.enemyDeck[0];
            deckControl.enemyDeck.RemoveAt(0);
        }

        

    }

    // Update is called once per frame
    void Update()
    {
        if (playerManager.playerTurn == false && playerManager.gameCycle % 2 == 0 && playerManager.gameCycle > 0) 
        {
            Enemy();
        }
    }

  void Enemy()
    {
        while (playerManager.playerTurn == false && playerManager.enemymaxMana>0 && miniDeck.Count > 0)
        {
            index = Random.Range(0, miniDeck.Count-1);
            if (miniDeck[index].CardHealorAttack == "Attack" && miniDeck[index].CardCost <= playerManager.enemymaxMana)
                {
                playerManager.playerHealth -= miniDeck[index].CardAttackHealingAmount;
                    Debug.Log("Player took damage");
                }
            else if (miniDeck[index].CardHealorAttack == "Heal" && miniDeck[index].CardCost <= playerManager.enemymaxMana)
                {
                playerManager.enemyHealth += miniDeck[index].CardAttackHealingAmount;
                    Debug.Log("Enemy Healed");
                }
            playerManager.enemymaxMana -= miniDeck[index].CardCost;
            miniDeck.RemoveAt(index);
            Debug.Log("player health: " + playerHealth + "enemy health: " + playerManager.enemyHealth + "mana: " + playerManager.enemymaxMana);
            
        }
        playerManager.enemymaxMana = 10;
        playerManager.playerTurn = true;
        Debug.Log(playerManager.playerTurn);
    }
}
