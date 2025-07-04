using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SetupPhaseState : BaseBattleState
{
    public SetupPhaseState(BattleStateManager context, BattleStateFactory factory) : base(context, factory)
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