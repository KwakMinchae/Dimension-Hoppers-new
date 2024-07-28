using System;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;

public class PlayerTurnState : GameState
{
    public PlayerManager playerManager;
    public DeckControl deckControl;
    public CardDestroyer cardDestroyer;

    GameObject dimensionHopCard = GameObject.Instantiate(Resources.Load("Dimension Hop", typeof(GameObject))) as GameObject;
    public override void EnterState(StateMachine game) 
    {
        
        if (dimensionHopCard != null) 
        {
            dimensionHopCard.SetActive(false);
        } else {
            GameObject dimensionHopCard = GameObject.Instantiate(Resources.Load("Dimension Hop", typeof(GameObject))) as GameObject;
            dimensionHopCard.SetActive(false);
        }

        if (playerManager.gameCycle == 0)
        {
            for (int i = 0; i < 10; i++)
            {
                CardSpawn();
            }
            DimensionHopCardSpawn();
        }
        else
        {
            CardSpawn();
        }
    }

    public override void UpdateState(StateMachine game)
    {
        if (dimensionHopCard == null) 
        {
            game.SwitchState(game.DimensionHopState);
        }
        else if (cardDestroyer.turnEnd == true)
        {
             game.SwitchState(game.EnemyTurnState);
        }
    }

    void CardSpawn()
    {
        GameObject card = GameObject.Instantiate(Resources.Load(deckControl.playerDeck[playerManager.index].CardNickname, typeof(GameObject))) as GameObject;
        card.transform.position = playerManager.nextPos[playerManager.posAvailable];
        playerManager.posAvailable++;
        playerManager.index++;
        if (playerManager.posAvailable > 4)
        {
            playerManager.posAvailable = 0;
        }
        if (playerManager.index >= 30)
        {
            playerManager.index = 0;
        }
    }

    void DimensionHopCardSpawn()
    {
        dimensionHopCard.SetActive(true);
        dimensionHopCard.transform.position = new Vector3(700, 0, 1000);
    }
}
