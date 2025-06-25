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


    public void InitiateBattle()
    {
        // Load Commands Into Storage UI
        RefreshCommandSlots();
        // Show Battle UI
        battlePhaseCanvas.gameObject.SetActive(true);
    }

    /// <summary>
    /// Function that starts to resolve the execution
    /// </summary>
    /// <exception cref="NotImplementedException"></exception>
    public void InitiateExecution()
    {
        throw new NotImplementedException();
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
        for (int i = 0; i < _playerProfile.CommandList.Count; i++)
        {
            // If there is no more space to put commands into, stop it.
            if (i > _playerProfile.StorageCapacity)
            {
                break;
            }

            _playerStorageSlots[i].InsertCommand(_commandPrefab, _playerProfile.CommandList[i]);
        }


        // Remove Command Prefabs From Chain Slots.
        foreach (var slot in _playerChainSlots)
        {
            slot.RemoveCommand();
        }
    }

}
