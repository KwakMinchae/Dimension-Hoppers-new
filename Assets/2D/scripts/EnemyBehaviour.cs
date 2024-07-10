using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyBehaviour : MonoBehaviour
{
    public int enemyHealth = 500;
    public int enemymanaAmmount = 10;
    public int enemymaxMana = 10;

    public CardData cardData;
    [SerializeField] private List<CardData> miniDeck = new List<CardData>(5);

    public DeckControl deckControl;
    int index = 0;
    
    public PlayerManager playerManager;
    public int playerHealth;
    public bool playerTurn;

    // Start is called before the first frame update
    void Start()
    {
      playerHealth = playerManager.playerHealth;
      playerTurn = playerManager.playerTurn;
        for (int i = 0; i < 5; i++)
        {
            miniDeck[i] = deckControl.enemyDeck[0];
            deckControl.enemyDeck.RemoveAt(0);
        }

        

    }

    // Update is called once per frame
    void Update()
    {
        if (playerTurn == false) 
        {
            Enemy();
        }
    }

  void Enemy()
    {
        while (playerTurn == false && enemymaxMana>0 && miniDeck.Count > 0)
        {
            index = Random.Range(0, miniDeck.Count-1);
            if (miniDeck[index].CardHealorAttack == "Attack" && miniDeck[index].CardCost <= enemymaxMana)
                {
                    playerHealth -= miniDeck[index].CardAttackHealingAmount;
                    Debug.Log("Player took damage");
                }
            else if (miniDeck[index].CardHealorAttack == "Heal" && miniDeck[index].CardCost <= enemymaxMana)
                {
                    enemyHealth += miniDeck[index].CardAttackHealingAmount;
                    Debug.Log("Enemy Healed");
                }
            enemymaxMana -= miniDeck[index].CardCost;
            miniDeck.RemoveAt(index);
            Debug.Log("player health: " + playerHealth + "enemy health: " + enemyHealth + "mana: " + enemymaxMana);
            
        }
        enemymaxMana = 10;
        playerTurn = true;
    }
}
