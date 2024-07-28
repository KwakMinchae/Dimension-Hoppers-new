using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEditor;
using UnityEngine;

public class DeckControl : MonoBehaviour //generates player deck and enemy deck
{
    public List<CardData> cards;
    [SerializeField] public List<CardData> playerDeck = new List<CardData>();
    [SerializeField] public List<CardData> enemyDeck = new List<CardData>();
    int x = 0;

    void Start()
    {
        for (int i = 0; i < 30; i++) //generate a random list of 30 cards for the player's deck
        {
            x = Random.Range(0, 4);
            playerDeck[i] = cards[x];
        }
        for (int j = 0; j < 30; j++) //generate a random list of 30 cards for the enemy's deck
        {
            x = Random.Range(0, 4);
            enemyDeck[j] = cards[x];
        }
        
    }
}
