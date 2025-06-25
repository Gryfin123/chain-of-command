using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BattleGameState : BaseGameState
{
    public BattleGameState(GameStateManager context) : base(context) { }

    public override void RecieveInstruction(string instruction)
    {
        switch (instruction.ToLower())
        {
            case "battlewon":
                _ctx.CurrGameState = _ctx.battleRewardGameState;
                break;
            default:
                Debug.Log("Undetermined instruction received: " + instruction);
                break;
        }
    }

    public override void EnterState()
    {
        // Sets up UI to allow for battle
        BattleControllerSingleton.Instance.InitiateBattle();
    }

    public override void ExitState()
    {
        BattleControllerSingleton.Instance.battlePhaseCanvas.gameObject.SetActive(false);
    }

    public override void UpdateState()
    {
    }
}