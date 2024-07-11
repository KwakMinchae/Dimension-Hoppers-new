using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CardDestroyer : MonoBehaviour
{
    public GameObject cardPrefab;

    public PlayerManager playerManager;
    public int playerHealth;

    public CardData cardData;


    private void OnMouseDown()
    {
        if (cardData.CardHealorAttack == "Heal")
        {
            playerHealth += cardData.CardAttackHealingAmount;
            Destroy(cardPrefab);
        } else
        {
            playerHealth -= cardData.CardAttackHealingAmount;
            Destroy(cardPrefab);
        }
        Debug.Log(playerHealth);
        
    }
}
