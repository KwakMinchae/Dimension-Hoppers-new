using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class EnemyBehaviour : MonoBehaviour
{
    

    public CardData cardData;
    [SerializeField] private List<CardData> miniDeck = new List<CardData>();

    public DeckControl deckControl;
    int index = 0;
    
    public PlayerManager playerManager;
    public int playerHealth;
    public bool playerTurn;

    public int cardsPlayed = 0;
    public int roundDamageToPlayer;
    public int roundHealToEnemy;

    // Start is called before the first frame update
    void Start()
    {
        playerHealth = playerManager.playerHealth;
        roundDamageToPlayer = 0;
        roundHealToEnemy = 0;
    }

    // Update is called once per frame
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
            
                index = Random.Range(0, deckControl.enemyDeck.Count - 1);
                if (deckControl.enemyDeck[index].CardHealorAttack == "Attack" && deckControl.enemyDeck[index].CardCost <= playerManager.enemymaxMana)
                {
                    playerManager.playerHealth -= deckControl.enemyDeck[index].CardAttackHealingAmount;
                    roundDamageToPlayer += deckControl.enemyDeck[index].CardAttackHealingAmount; 
                    cardsPlayed++;
                    

            }
                else if (deckControl.enemyDeck[index].CardHealorAttack == "Heal" && deckControl.enemyDeck[index].CardCost <= playerManager.enemymaxMana)
                {
                    playerManager.enemyHealth += deckControl.enemyDeck[index].CardAttackHealingAmount;
                    roundHealToEnemy += deckControl.enemyDeck[index].CardAttackHealingAmount;
                    cardsPlayed++;
                    

            }
                playerManager.enemymaxMana -= deckControl.enemyDeck[index].CardCost;
                deckControl.enemyDeck.RemoveAt(index);
            
           

            
        }
        playerManager.actionText.text = "Oh no! The enemy did " + roundDamageToPlayer + " damage to you and " + roundHealToEnemy + " health has been recovered by the enemy!";
        playerManager.enemymaxMana = 10;
        playerManager.playerTurn = true;
        playerManager.Spawned = false;
        Debug.Log(playerManager.playerTurn);

    }
}
