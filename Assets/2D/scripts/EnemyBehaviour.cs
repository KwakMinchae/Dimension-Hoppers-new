using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class EnemyBehaviour : MonoBehaviour //controls how enemy acts
{
    

    public CardData cardData;
    [SerializeField] private List<CardData> miniDeck = new List<CardData>();

    public DeckControl deckControl;
    int index = 0;
    
    public PlayerManager playerManager;
    public int playerHealth;
    public bool playerTurn;

    public int roundDamageToPlayer;
    public int roundHealToEnemy;

    void Start()
    {
        playerHealth = playerManager.playerHealth;
        roundDamageToPlayer = 0; //variable to calculate cumulative damage dealt in one round
        roundHealToEnemy = 0; //variable to calculate cumulative healing done in one round
    }

    void Update()
    {
        if (playerManager.playerTurn == false) 
        {
           Enemy();
        }
    }

  void Enemy()
    {

        while (playerManager.enemymaxMana>0 && deckControl.enemyDeck.Count > 0)
        {
            
                index = Random.Range(0, deckControl.enemyDeck.Count - 1); //get a random card from the enemy deck
                if (deckControl.enemyDeck[index].CardHealorAttack == "Attack" && deckControl.enemyDeck[index].CardCost <= playerManager.enemymaxMana)
                {
                    playerManager.playerHealth -= deckControl.enemyDeck[index].CardAttackHealingAmount; //directly reduce playerHealth
                    roundDamageToPlayer += deckControl.enemyDeck[index].CardAttackHealingAmount;  //log the amount of damage dealt this round
                    

            }
                else if (deckControl.enemyDeck[index].CardHealorAttack == "Heal" && deckControl.enemyDeck[index].CardCost <= playerManager.enemymaxMana)
                {
                    playerManager.enemyHealth += deckControl.enemyDeck[index].CardAttackHealingAmount; //directly increase enemyHealth
                    roundHealToEnemy += deckControl.enemyDeck[index].CardAttackHealingAmount; //log the amount of healing done this round                    

            }
                playerManager.enemymaxMana -= deckControl.enemyDeck[index].CardCost; //reduce mana after card effects have been finished
                deckControl.enemyDeck.RemoveAt(index); //remove card from enemy deck
            
           

            
        }
        playerManager.actionText.text = "Oh no! The enemy did " + roundDamageToPlayer + " damage to you and " + roundHealToEnemy + " health has been recovered by the enemy!"; //show turn total health lost or healed
        playerManager.enemymaxMana = 10; //reset enemyMana for next turn
        playerManager.playerTurn = true;
        playerManager.Spawned = false;
        Debug.Log(playerManager.playerTurn);

    }
}
