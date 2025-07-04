using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class OpponentPhaseState : BaseBattleState
{
    public OpponentPhaseState(BattleStateManager context, BattleStateFactory factory) : base(context, factory)
    {
    }

    public override void EnterState()
    {
        AttackPlayer();


        CheckPlayerStatus();
    }

    public override void ExitState()
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

    private void AttackPlayer()
    {
        var opponent = BattleControllerSingleton.Instance.OpponentProfile;
        opponent.AttackPlayer();
    }

    private void CheckPlayerStatus()
    {
        var player = BattleControllerSingleton.Instance.PlayerProfile;
        
        if (player.HpCurrent > 0)
        {
            Debug.Log("Player Survived, moving onto hist turn...");
            SwitchState(_factory.SetupPhase());
        }
        else
        {
            Debug.Log("Player is dead :<. Returning To Main Menu.");
            _ctx.MasterState.RecieveInstruction("defeat");
        }
    }
}