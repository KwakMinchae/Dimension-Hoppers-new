using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CardDisplay : MonoBehaviour
{
    public CardData cardData;

    public Text cardNameText;
    public Text cardDescriptionText;

    public Image cardArtImage;
    public Text cardManaText;
    public Text cardHealOrAttackText;
    public Text cardAmount;
    // Start is called before the first frame update
    void Start()
    {
        cardNameText.text = cardData.CardName;
        cardArtImage.sprite = cardData.CardArt;
        cardDescriptionText.text = cardData.CardDescription;
        cardManaText.text = cardData.CardCost.ToString();
        cardAmount.text = cardData.CardAttackHealingAmount.ToString();
        cardHealOrAttackText.text = cardData.CardHealorAttack;
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
