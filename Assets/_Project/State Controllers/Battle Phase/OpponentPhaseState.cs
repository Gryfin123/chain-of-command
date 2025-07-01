using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OpponentPhaseState : BaseGameState
{
    public OpponentPhaseState(GameStateManager context, GameStateFactory factory) : base(context, factory)
    {
    }

    public override void CheckSwitchStates()
    {

    }

    public override void EnterState()
    {

    }

    public override void ExitState()
    {

    }

    public override void InitializeSubState()
    {

    }

    public override void RecieveInstruction(string instruction)
    {
        switch (instruction)
        {
            case "complete":
                SwitchState(_factory.SetupPhase());
                break;
            default:
                throw new NotImplementedException();
        }
    }

    public override void UpdateState()
    {

    }
}