using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyBehaviour : MonoBehaviour
{
    public int enemyHealth = 500;
    public int enemymanaAmmount = 10;
    public int enemymaxMana = 10;

    public DeckControl deckControl;
    int index = 0;

    public PlayerManager playerManager;
    public int playerHealth;
    public bool playerTurn;

    // Start is called before the first frame update
    void Start()
    {
      playerHealth = playerManager.playerHealth;
      playerTurn = playerManager.playerTurn;
      Enemy();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

  void Enemy()
    {
        while (playerTurn == false && enemymaxMana>0)
        {
            index = Random.Range(0, deckControl.enemyDeck.Count-1);
            if (deckControl.enemyDeck[index].CardHealorAttack == "Attack" && deckControl.enemyDeck[index].CardCost <= enemymaxMana)
                {
                    playerHealth -= deckControl.enemyDeck[index].CardAttackHealingAmount;
                    Debug.Log("Player took damage");
                }
            else if (deckControl.enemyDeck[index].CardHealorAttack == "Heal" && deckControl.enemyDeck[index].CardCost <= enemymaxMana)
                {
                    enemyHealth += deckControl.enemyDeck[index].CardAttackHealingAmount;
                    Debug.Log("Enemy Healed");
                }
            enemymaxMana -= deckControl.enemyDeck[index].CardCost;
            Debug.Log("player health: " + playerHealth + "enemy health: " + enemyHealth + "mana: " + enemymaxMana);
            
        }
        enemymaxMana = 10;
        playerTurn = !playerTurn;
    }
}
