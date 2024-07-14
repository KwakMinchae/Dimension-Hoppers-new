using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CardDestroyer : MonoBehaviour
{
    public GameObject cardPrefab;

    public GameObject gameManager;
    public PlayerManager playerManager;
      
    public CardData cardData;

    private void Start()
    {
        gameManager = GameObject.Find("GameManager");
        playerManager = gameManager.GetComponent<PlayerManager>();
    }

    private void OnMouseDown()
    {
        if (cardData.CardHealorAttack == "Heal" && playerManager.manaAmmount >= cardData.CardCost)
        {
            playerManager.playerHealth += cardData.CardAttackHealingAmount;
            playerManager.manaAmmount -= cardData.CardCost;
            Destroy(cardPrefab);
        }
        else if (cardData.CardHealorAttack == "Attack" && playerManager.manaAmmount >= cardData.CardCost)
        {
            playerManager.enemyHealth -= cardData.CardAttackHealingAmount;
            playerManager.manaAmmount -= cardData.CardCost;
            Destroy(cardPrefab);
        }
        
        Debug.Log("Enemy health is " + playerManager.enemyHealth);
        Debug.Log("Player health is " + playerManager.playerHealth);
        
    }
}
