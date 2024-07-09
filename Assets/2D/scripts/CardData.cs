using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New Card", menuName = "Card")]
public class CardData : ScriptableObject
{
    public string CardName;
    public string CardDescription;
    public int CardCost;
    public int CardAttackHealingAmount;
    public string CardHealorAttack;
    public Sprite CardArt;
    public string CardNickname;
}
    

