using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SetupPhaseState : BaseGameState
{
    public SetupPhaseState(GameStateManager context, GameStateFactory factory) : base(context, factory)
    {
    }

    public override void CheckSwitchStates()
    {

    }

    public override void EnterState()
    {
        ScriptableObjectAccessControllerSingleton.Instance.CommonFlags.CanMoveCommandsBetweenSlots = true;
    }

    public override void ExitState()
    {
        ScriptableObjectAccessControllerSingleton.Instance.CommonFlags.CanMoveCommandsBetweenSlots = false;
    }

    public override void InitializeSubState()
    {

    }

    public override void RecieveInstruction(string instruction)
    {
        switch(instruction)
        {
            case "execute":
                SwitchState(_factory.ExecutionPhase());
                break;
        }
    }

    public override void UpdateState()
    {

    }
}