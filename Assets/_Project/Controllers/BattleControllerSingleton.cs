using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Singleton instance of BattleController. It should persist between scenes.
/// It holds references to all necessary instances of objects from the scenes related to Battle Phase.
/// </summary>
public class BattleControllerSingleton : MonoBehaviour
{
    public static BattleControllerSingleton Instance { get; private set; }
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


    [SerializeField] public Canvas battlePhaseCanvas;

    [SerializeField] private OpponentDataSO _opponentProfile;
    [SerializeField] private PlayerProfileSO _playerProfile;

    [SerializeField] private GameObject _opponentDisplay;
    [SerializeField] private GameObject _playerDisplay;
    [SerializeField] private GameObject _chainDisplay;

    [SerializeField] private GameObject _commandPrefab;
    [SerializeField] private List<CommandSlot> _playerStorageSlots;
    [SerializeField] private List<CommandSlot> _playerChainSlots;

    public OpponentDataSO OpponentProfile { get => _opponentProfile; }
    public PlayerProfileSO PlayerProfile { get => _playerProfile; }

    public void InitiateBattle()
    {
        // Load Commands Into Storage UI
        RefreshCommandSlots();
        // Show Battle UI
        battlePhaseCanvas.gameObject.SetActive(true);
    }

    /// <summary>
    /// Returns a list of current Commands in Storage. Doesn't influence the original.
    /// </summary>
    /// <param name="includeNull">If true, will also include empty spaces in the storage as null</param>
    /// <returns></returns>
    public List<CommandDisplay> GetStorageStatus(bool includeNull = false)
    {
        var returnList = new List<CommandDisplay>();

        foreach (var slot in _playerStorageSlots)
        {
            var foundCommand = slot.GetCurrentCommand();

            if (foundCommand == null && includeNull || foundCommand != null)
            {
                returnList.Add(foundCommand);
            }
        }

        return returnList;
    }

    /// <summary>
    /// Returns a list of current Commands in Chain. Doesn't influence the original.
    /// </summary>
    /// <param name="includeNull">If true, will also include empty spaces in the storage as null</param>
    /// <returns></returns>
    public List<CommandDisplay> GetChainStatus()
    {
        var returnList = new List<CommandDisplay>();

        foreach (var slot in _playerChainSlots)
        {
            var foundCommand = slot.GetCurrentCommand();
            returnList.Add(foundCommand);
        }

        return returnList;
    }

    /// <summary>
    /// Makes sure that all commands return to storage and will be properly shown when battle is concluded.
    /// </summary>
    private void RefreshCommandSlots()
    {
        // Remove Command Prefabs From Storage Slots.
        foreach (var slot in _playerStorageSlots)
        {
            slot.RemoveCommand();
        }

        // Load data from Player Profiole into Storage Display
        for (int i = 0; i < PlayerProfile.CommandList.Count; i++)
        {
            // If there is no more space to put commands into, stop it.
            if (i > PlayerProfile.StorageCapacity)
            {
                break;
            }

            _playerStorageSlots[i].InsertCommand(_commandPrefab, PlayerProfile.CommandList[i]);
        }


        // Remove Command Prefabs From Chain Slots.
        foreach (var slot in _playerChainSlots)
        {
            slot.RemoveCommand();
        }
    }

}
