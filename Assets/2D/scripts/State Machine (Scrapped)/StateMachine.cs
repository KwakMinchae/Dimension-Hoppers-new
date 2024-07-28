using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public abstract class StateMachine : MonoBehaviour
{
    GameState currentState;
    public GameState PlayerTurnState = new PlayerTurnState();
    public GameState EnemyTurnState = new EnemyTurnState();
    public GameState DimensionHopState = new DimensionHopState();

    private void Start()
    {
        currentState = PlayerTurnState; //initial state of 2D card game must start with a player's turn
        currentState.EnterState(this);
    }

    private void Update()
    {
        currentState.UpdateState(this);
    }

    public void SwitchState(GameState state) 
    {
        currentState = state;
        state.EnterState(this);
    }
}
