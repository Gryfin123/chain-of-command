using System;
using UnityEngine;

[Serializable]
public class MainMenuGameState : BaseGameState
{
    public MainMenuGameState(GameStateManager context, GameStateFactory factory) : base(context, factory) { }

    public override void RecieveInstruction(string instruction)
    {
        switch(instruction.ToLower())
        {
            // Start the Run
            case "tostartingrun":
                SwitchState(_factory.StartingRun());
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