using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;
using UnityEngine.UI;

/// <summary>
/// Singleton instance of BattleController. 
/// It gives references to Battle Reward Game State.
/// </summary>
public class BattleRewardControllerSingleton : MonoBehaviour
{
    public static BattleRewardControllerSingleton Instance { get; private set; }
    private void Awake()
    {
        // If there is an instance, and it's not me, delete myself.
        if (Instance != null && Instance != this)
        {
            Destroy(this);
        }
        else
        {
            Instance = this;
        }
    }

    [SerializeField]
    public Canvas rewardPhaseCanvas;

    [SerializeField]
    private List<CommandDataTemplateSO> _rewardPool;
    [SerializeField]
    private PlayerProfileSO _playerProfile;

    [SerializeField]
    private List<CommandSlot> _playerStorageSlots;
    [SerializeField]
    private List<CommandSlot> _rewardCommandSlots;

    [SerializeField]
    private CommandSlot _repairCommandSlot;

    [SerializeField]
    private GameObject _commandPrefab;
    [SerializeField]
    private List<BaseCommand> _pickedRewards;

    public List<CommandDataTemplateSO> RewardPool { get => _rewardPool; }
    public List<CommandSlot> RewardCommandSlots { get => _rewardCommandSlots; }
    public GameObject CommandPrefab { get => _commandPrefab; }
    public List<BaseCommand> PickedRewards { get => _pickedRewards; }
    public CommandSlot RepairCommandSlot { get => _repairCommandSlot; set => _repairCommandSlot = value; }

    public void InitiatePhase(int amountRewardsToGenerate)
    {
        RefreshSlots();
        GenerateRewards(amountRewardsToGenerate);
    }

    private void Update()
    {

    }


    /// <summary>
    /// Generates rewards from the pool and inserts them into appropriate slots
    /// </summary>
    public void GenerateRewards(int amountRewardsToGenerate)
    {
        _pickedRewards = new List<BaseCommand>();

        for (int i = 0; i < amountRewardsToGenerate; i++)
        {
            // Pick rewards
            var currSource = _rewardPool[Random.Range(0, _rewardPool.Count)];
            var newReward = currSource.CreateInstanceCommand();

            // Fill list
            _pickedRewards.Add(newReward);

            // Fill Slots
            _rewardCommandSlots[i].InsertCommand(_commandPrefab, newReward);
        }
    }

    public void RefreshSlots()
    {

        // Remove Command Prefabs From Storage Slots.
        foreach (var slot in _playerStorageSlots)
        {
            slot.RemoveCommand();
        }

        // Load data from Player Profiole into Storage Display
        for (int i = 0; i < _playerProfile.CommandList.Count; i++)
        {
            // If there is no more space to put commands into, stop it.
            if (i > _playerProfile.StorageCapacity)
            {
                break;
            }

            _playerStorageSlots[i].InsertCommand(_commandPrefab, _playerProfile.CommandList[i]);
        }


        // Remove Command Prefabs From Rewards slots.
        foreach (var slot in _rewardCommandSlots)
        {
            slot.RemoveCommand();
        }
        _repairCommandSlot.RemoveCommand();
    }
    public bool isRepairValid(CommandDisplay cmd)
    {
        return (cmd != null && cmd.data.broken);
    }
}
