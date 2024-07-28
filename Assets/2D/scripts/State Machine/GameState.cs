using UnityEngine;
using System;

public abstract class GameState //Base State of state machine for 2D
{
    public abstract void EnterState(StateMachine game);

    public abstract void UpdateState(StateMachine game);


}
