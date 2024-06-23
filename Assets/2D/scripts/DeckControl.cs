using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class DeckControl : MonoBehaviour
{
    public List<CardData> cards;
    public List<CardData> deck = new List<CardData>();
    int x = 0;

    // Start is called before the first frame update
    void Start()
    {
        for (int i = 0; i < 30; i++)
        {
            x = Random.Range(0, 4);
            deck[i] = cards[x];
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
