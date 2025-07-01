using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BattleRewardGameState : BaseGameState
{
    private Command reward1;
    private Command reward2;
    private Command reward3;

    public BattleRewardGameState(GameStateManager context, GameStateFactory factory) : base(context, factory) { }

    public override void RecieveInstruction(string instruction)
    {
        switch(instruction.ToLower())
        {
            case "skip":
                break;
            case "reward1":
                SelectedReward(reward1);
                break;
            case "reward2":
                SelectedReward(reward2);
                break;
            case "reward3":
                SelectedReward(reward3);
                break;
            default:
                Debug.Log("Undetermined instruction received: " + instruction);
                break;
        }

        SwitchState(_factory.Exploration());
    }

    public override void EnterState()
    {
        // Define rewards
        BattleRewardControllerSingleton.Instance.InitiatePhase(3);
        reward1 = BattleRewardControllerSingleton.Instance.PickedRewards[0];
        reward2 = BattleRewardControllerSingleton.Instance.PickedRewards[1];
        reward3 = BattleRewardControllerSingleton.Instance.PickedRewards[2];

        BattleRewardControllerSingleton.Instance.rewardPhaseCanvas.gameObject.SetActive(true);
    }

    public override void ExitState()
    {
        BattleRewardControllerSingleton.Instance.rewardPhaseCanvas.gameObject.SetActive(false);
    }

    public override void UpdateState()
    {
    }

    private void SelectedReward(Command pickedReward)
    {
        _ctx.playerProfileSO.CommandList.Add(pickedReward);
    }

    public override void CheckSwitchStates()
    {

    }

    public override void InitializeSubState()
    {

    }
}