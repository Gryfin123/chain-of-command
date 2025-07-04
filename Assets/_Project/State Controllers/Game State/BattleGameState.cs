using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BattleGameState : BaseGameState
{
    public BattleGameState(GameStateManager context, GameStateFactory factory) : base(context, factory) 
    {
    }

    public override void RecieveInstruction(string instruction)
    {
        // Check self for instruction
        switch (instruction.ToLower())
        {
            case "victory":
                SwitchState(_factory.BattleReward());
                break;
            case "failure":
                SwitchState(_factory.MainMenu());
                break;
            default:
                Debug.Log("Undetermined instruction received: " + instruction);
                break;
        }
        
        // Check if instruction is meant for the substate.
        _currSubState.RecieveInstruction(instruction);
    }

    public override void EnterState()
    {
        // Sets up UI to allow for battle
        BattleControllerSingleton.Instance.OpponentProfile.Init();
        BattleControllerSingleton.Instance.InitiateBattle();
        InitializeSubState();
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
        SetSubState(_factory.SetupPhase());
        _currSubState.EnterState();
    }
}