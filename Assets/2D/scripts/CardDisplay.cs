using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CardDisplay : MonoBehaviour //display information of a certain card with cardData onto a card template 
{
    public CardData cardData;

    public Text cardNameText;
    public Text cardDescriptionText;

    public Image cardArtImage;
    public Text cardManaText;
    public Text cardHealOrAttackText;
    public Text cardAmount;

    void Start()
    {
        cardNameText.text = cardData.CardName;
        cardArtImage.sprite = cardData.CardArt;
        cardDescriptionText.text = cardData.CardDescription;
        cardManaText.text = cardData.CardCost.ToString();
        cardAmount.text = cardData.CardAttackHealingAmount.ToString();
        cardHealOrAttackText.text = cardData.CardHealorAttack;
        
    }
}
