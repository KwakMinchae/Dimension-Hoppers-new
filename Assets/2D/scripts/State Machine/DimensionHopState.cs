using UnityEngine;
using UnityEngine.SceneManagement;

public class DimensionHopState : GameState
{
    [SerializeField] GameObject dimensionHopCard;

    public override void EnterState(StateMachine game)
    {
        GameObject.Destroy(dimensionHopCard);
        SceneManager.LoadScene("3D");
    }

    public override void UpdateState(StateMachine game)
    {

    }
}
