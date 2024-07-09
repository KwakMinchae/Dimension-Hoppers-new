using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEditor;
using UnityEngine;

public class DeckControl : MonoBehaviour
{
    public List<CardData> cards;
    [SerializeField] public List<CardData> playerDeck = new List<CardData>();
    [SerializeField] public List<CardData> enemyDeck = new List<CardData>();
    int x = 0;

    

    // Start is called before the first frame update
    void Start()
    {
        for (int i = 0; i < 30; i++)
        {
            x = Random.Range(0, 4);
            playerDeck[i] = cards[x];
        }
        for (int j = 0; j < 30; j++)
        {
            x = Random.Range(0, 4);
            enemyDeck[j] = cards[x];
        }
        GameObject instance = Instantiate(Resources.Load(playerDeck[0].CardNickname, typeof(GameObject))) as GameObject;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
