using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public int playerHealth = 500;
    public int manaAmmount = 10;
    public int maxMana = 10;
    
    public DeckControl deckControl;
    int index = 0;

    [SerializeField] GameObject[] spawnPoints;

    // Start is called before the first frame update
    void Start()
    {
        Instantiate(deckControl.playerDeck[index].CardArt, spawnPoints[Random.Range(0,spawnPoints.Length - 1)].transform.position, Quaternion.identity);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
