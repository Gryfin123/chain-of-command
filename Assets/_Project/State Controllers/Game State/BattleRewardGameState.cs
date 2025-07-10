using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BattleRewardGameState : BaseGameState
{
    private BaseCommand reward1;
    private BaseCommand reward2;
    private BaseCommand reward3;

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
            case "repair":
                RepairCommand();
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

        ScriptableObjectAccessControllerSingleton.Instance.CommonFlags.CanMoveCommandsBetweenSlots = true;
    }

    public override void ExitState()
    {
        BattleRewardControllerSingleton.Instance.rewardPhaseCanvas.gameObject.SetActive(false);

        ScriptableObjectAccessControllerSingleton.Instance.CommonFlags.CanMoveCommandsBetweenSlots = false;
    }

    public override void UpdateState()
    {
    }

    private void SelectedReward(BaseCommand pickedReward)
    {
        _ctx.playerProfileSO.CommandList.Add(pickedReward);
    }

    private void RepairCommand()
    {
        var command = BattleRewardControllerSingleton.Instance.RepairCommandSlot.GetCurrentCommand();

        if (BattleRewardControllerSingleton.Instance.isRepairValid(command))
        {
            command.data.Repair();
        }
    }
}