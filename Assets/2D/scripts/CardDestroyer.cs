using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CardDestroyer : MonoBehaviour
{
    public GameObject cardPrefab;

    public GameObject gameManager;
    public PlayerManager playerManager;
      
    public CardData cardData;

    public AudioClip popSoundEffect;
    public bool turnEnd = false;

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
            AudioManager.Instance.Play(popSoundEffect);
            playerManager.actionText.text = "Nice! A potion! You healed " + cardData.CardAttackHealingAmount + " health!";
            Destroy(cardPrefab);
        }
        else if (cardData.CardHealorAttack == "Attack" && playerManager.manaAmmount >= cardData.CardCost)
        {
            playerManager.enemyHealth -= cardData.CardAttackHealingAmount;
            playerManager.manaAmmount -= cardData.CardCost;
            AudioManager.Instance.Play(popSoundEffect);
            playerManager.actionText.text = "Great job! You swung your " + cardData.CardName + " at the enemy and dealt " + cardData.CardAttackHealingAmount + " damage to the enemy!";
            Destroy(cardPrefab);
        } else 
        {
            turnEnd = true;
        }
        
        Debug.Log("Enemy health is " + playerManager.enemyHealth);
        Debug.Log("Player health is " + playerManager.playerHealth);
        
    }

    public void EndTurn() 
    {
        playerManager.playerTurn = false;
    }
}
