using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BattleGameState : BaseGameState
{
    public BattleGameState(GameStateManager context, GameStateFactory factory) : base(context, factory) 
    {
        InitializeSubState();
    }

    public override void RecieveInstruction(string instruction)
    {
        switch (instruction.ToLower())
        {
            case "victory":
                SwitchState(_factory.BattleReward());
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
        CheckSwitchStates();
    }

    public override void CheckSwitchStates() { }

    public override void InitializeSubState()
    {
        _currSubState = _factory.SetupPhase();
    }
}