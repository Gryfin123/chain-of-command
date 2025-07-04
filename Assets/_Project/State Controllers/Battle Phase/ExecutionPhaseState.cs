using System;
using System.Collections;
using System.Collections.Generic;
using UnityEditor.Experimental.GraphView;
using UnityEditor.Searcher;
using UnityEngine;

public class ExecutionPhaseState : BaseGameState
{
    private OpponentDataSO _opponent;
    private List<Command> _copiedQueue;

    public ExecutionPhaseState(GameStateManager context, GameStateFactory factory) : base(context, factory)
    {
    }

    public override void CheckSwitchStates()
    {

    }

    public override void EnterState()
    {
        Initialize();

    }

    public override void ExitState()
    {
    }

    public override void InitializeSubState()
    {

    }

    public override void RecieveInstruction(string instruction) {}

    public override void UpdateState()
    {
        ProcessCurrentQueue();
    }

    // ==== Private Functions ==== //

    private void Initialize()
    {
        _copiedQueue = BattleControllerSingleton.Instance.GetChainStatus(true);
        _opponent = BattleControllerSingleton.Instance.OpponentProfile;
    }


    private void ProcessCurrentQueue()
    {
        // Process each command setup in the chain
        foreach (var command in _copiedQueue)
        {
            if (command != null)
            {
                var context = new CommandContext
                {
                    SourceCommand = command,
                    SourceGameState = this
                };
                command.Trigger(context);
            }
            else
            {
                Debug.Log("Processed Empty Slot");
            }

            // Check if opponent Lost
            CheckOpponentStatus();
        }

        // If execution finished, move to next State
        SwitchState(_factory.OponnetPhase());
    }

    private void CheckOpponentStatus()
    {
        if (_opponent.HpCurrent <= 0)
        {
            Debug.Log($"Opponent is dead ({_opponent.HpCurrent}/{_opponent.HpMax})");
            _currSuperState.RecieveInstruction("victory");
        }    
        else
        {
            Debug.Log($"Opponent is still alive ({_opponent.HpCurrent}/{_opponent.HpMax})");
        }
    }
}