using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New Player Profile", menuName = "ScriptableObjects/PlayerProfile")]
public class PlayerProfileSO : ScriptableObject
{
    [SerializeField] private int credits;
    [SerializeField] private float hpMax;
    [SerializeField] private float hpCurrent;
    [SerializeField] private float fuel;
    [SerializeField] private int storageCapacity;
    [SerializeField] private int chainCapacity;
    private List<Command> commandList;

    public float HpMax 
    { 
        get => hpMax;
        private set
        {
            hpCurrent = value;
            hpMax = value;
        }
    }
    public float HpCurrent { get => hpCurrent; private set => hpCurrent = value; }
    public int Credits { get => credits; private set => credits = value; }
    public float Fuel { get => fuel; private set => fuel = value; }
    public int StorageCapacity { get => storageCapacity; private set => storageCapacity = value; }
    public int ChainCapacity { get => chainCapacity; private set => chainCapacity = value; }
    public List<Command> CommandList { get => commandList; private set => commandList = value; }

    public void IncreaseMaxHealth(float val)
    {
        hpMax += val;
        hpCurrent += val;
    }

    public void TakeDamage(float amount)
    {
        hpCurrent -= amount;
    }

    public void AddCommand(Command newCommand)
    {
        // Not Implemented
        // commandList.Add(newCommand);
    }
    public void RemoveCommand(Command targetCommand)
    {
        // Not Implemented
        // commandList.Remove(newCommand);
    }

    public void LoadLoadout(LoadoutSO loadout)
    {
        HpMax = loadout.MaxHp;
        Credits = loadout.Credits;
        Fuel = loadout.Fuel;
        StorageCapacity = loadout.StorageCapacity;
        ChainCapacity = loadout.ChainCapacity;
        CommandList = loadout.GetCommandList();
    }
}
