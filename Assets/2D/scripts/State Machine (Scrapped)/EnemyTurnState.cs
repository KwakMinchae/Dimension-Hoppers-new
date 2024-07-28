using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyTurnState : GameState
{
    public CardData cardData;
    [SerializeField] private List<CardData> miniDeck = new List<CardData>(5);

    public DeckControl deckControl;
    int index = 0;

    public PlayerManager playerManager;
    public int playerHealth;

    public override void EnterState(StateMachine game)
    {
        playerHealth = playerManager.playerHealth;

        for (int i = 0; i < 5; i++)
        {
            miniDeck[i] = deckControl.enemyDeck[0];
            deckControl.enemyDeck.RemoveAt(0);
        }
    }

    public override void UpdateState(StateMachine game)
    {       
        Enemy();
        game.SwitchState(game.PlayerTurnState);
    }


    void Enemy()
    {
        while (playerManager.enemymaxMana > 0 && miniDeck.Count > 0)
        {
            index = Random.Range(0, miniDeck.Count - 1);
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
    }
}
