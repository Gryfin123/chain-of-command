using System;
using UnityEngine;

[Serializable]
public class MainMenuGameState : BaseGameState
{
    public MainMenuGameState(GameStateManager context) : base(context) { }

    public override void RecieveInstruction(string instruction)
    {
        switch(instruction.ToLower())
        {
            // Start the Run
            case "tostartingrun":
                _ctx.CurrGameState = _ctx.startingRunGameState;
                break;
            default:
                Debug.Log("Undetermined instruction received: " + instruction);
                break;
        }
    }

    public override void EnterState()
    {
        GameControllerSingleton.Instance.ShowMainMenuCanvas();
    }

    public override void ExitState()
    {
        GameControllerSingleton.Instance.HideMainMenuCanvas();
    }

    public override void UpdateState()
    {
    }
}