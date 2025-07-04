using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BattleGameState : BaseGameState
{
    private BattleStateManager _battleCtx;

    public BattleGameState(GameStateManager context, GameStateFactory factory) : base(context, factory) 
    {
        _battleCtx = new BattleStateManager(this);
    }

    public override void RecieveInstruction(string instruction)
    {
        // Check self for instruction
        switch (instruction.ToLower())
        {
            case "victory":
                SwitchState(_factory.BattleReward());
                break;
            case "defeat":
                SwitchState(_factory.MainMenu());
                break;
            default:
                Debug.Log("Undetermined instruction received: " + instruction);
                break;
        }

        // Check if instruction is meant for the substate.
        _battleCtx.PassInstruction(instruction);
    }

    public override void EnterState()
    {
        // Sets up UI to allow for battle
        BattleControllerSingleton.Instance.OpponentProfile.Init();
        BattleControllerSingleton.Instance.InitiateBattle();

        _battleCtx.Init();
    }

    public override void ExitState()
    {
        BattleControllerSingleton.Instance.battlePhaseCanvas.gameObject.SetActive(false);
        _battleCtx.CurrState.ExitState();
    }

    public override void UpdateState()
    {
        _battleCtx.Update();
    }
}