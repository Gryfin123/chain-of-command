using UnityEngine;

/// <summary>
/// Game State where player has already started. Exploration refers to Game Phase where player choses next step. 
/// From here it can go to shop state, battle phase or event phase.
/// </summary>
public class ExplorationGameState : BaseGameState
{
    public ExplorationGameState(GameStateManager context, GameStateFactory factory) : base(context, factory) { }

    public override void RecieveInstruction(string instruction)
    {
        switch(instruction.ToLower())
        {
            case "tobattle":
                SwitchState(_factory.Battle());
                break;
            default:
                Debug.Log("Undetermined instruction received: " + instruction);
                break;
        }
    }

    public override void EnterState()
    {
        // Show proper state
        RunControllerSingleton.Instance.explorationPhaseCanvas.gameObject.SetActive(true);
    }

    public override void ExitState()
    {
        // Show proper state
        RunControllerSingleton.Instance.explorationPhaseCanvas.gameObject.SetActive(false);
    }

    public override void UpdateState()
    {
    }
}