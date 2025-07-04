using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ExecutionPhaseState : BaseBattleState
{
    private OpponentDataSO _opponent;
    private List<BaseCommand> _copiedQueue;

    public ExecutionPhaseState(BattleStateManager context, BattleStateFactory factory) : base(context, factory)
    {
    }

    public override void EnterState()
    {
        Initialize();

        _ctx.MasterState.StartExecution(ProcessCurrentQueue());
    }

    public override void ExitState()
    {
    }

    public override void RecieveInstruction(string instruction) {}

    public override void UpdateState()
    {
    }

    // ==== Private Functions ==== //

    private void Initialize()
    {
        _copiedQueue = BattleControllerSingleton.Instance.GetChainStatus();
        _opponent = BattleControllerSingleton.Instance.OpponentProfile;
    }

    /// <summary>
    /// Function to be run by a Coroutine to execute the prepared commands.
    /// </summary>
    /// <returns></returns>
    private IEnumerator ProcessCurrentQueue()
    {
        // Process each command setup in the chain
        for (int i = 0; i < _copiedQueue.Count; i++)
        {
            var command = _copiedQueue[i];

            if (command != null)
            {
                var context = new CommandContext
                {
                    CurrentQueue = _copiedQueue,
                    SourceCommand = command
                };

                // Trigger command by deafult
                // and one time for each retrigger it has
                int amountTriggered = 0;

                do
                {
                    if (amountTriggered != 0)
                    {
                        yield return new WaitForSeconds(0.5f);
                    }

                    command.Trigger(context);
                    amountTriggered++;
                }
                while (amountTriggered <= command.properties[CommandPropertyID.RETRIGGER].EffectiveValue);

                yield return new WaitForSeconds(1.5f);
            }

            // Check if opponent Lost
            if (CheckOpponentStatus())
            {
                _ctx.MasterState.RecieveInstruction("victory");
                yield break;
            }
        }

        // If execution finished, move to next State
        SwitchState(_factory.OponnetPhase());
    }

    private bool CheckOpponentStatus()
    {
        if (_opponent.HpCurrent <= 0)
        {
            Debug.Log($"Opponent is dead ({_opponent.HpCurrent}/{_opponent.HpMax})");
            return true;
        }    
        else
        {
            Debug.Log($"Opponent is still alive ({_opponent.HpCurrent}/{_opponent.HpMax})");
            return false;
        }
    }
}