using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CardManager : MonoBehaviour
{
    public PlayerManager playerManager;
    public DeckControl deckControl;
    //int index = 0;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        //if (Input.GetMouseButtonDown(0))
        {
            //index = Random.Range(0, deckControl.deck.Count-1);
            //playerManager.playerHealth -= deckControl.deck[index].CardAttackHealingAmount;
            //Debug.Log("HP: " + playerManager.playerHealth);
            //Debug.Log(deckControl.deck.Count);
            //deckControl.deck.RemoveAt(index);
        }
    }
}
