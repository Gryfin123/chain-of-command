using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New Player Profile", menuName = "ScriptableObjects/PlayerProfile")]
public class PlayerProfileSO : ScriptableObject
{
    [SerializeField] private int _credits;
    [SerializeField] private float _hpMax;
    [SerializeField] private float _hpCurrent;
    [SerializeField] private float _fuel;
    [SerializeField] private int _storageCapacity;
    [SerializeField] private int _chainCapacity;
    private List<Command> _commandList;

    public float HpMax 
    { 
        get => _hpMax;
        private set
        {
            _hpCurrent = value;
            _hpMax = value;
        }
    }
    public float HpCurrent 
    { 
        get => _hpCurrent; 
        private set
        {
            _hpCurrent = value;
            _hpCurrent = Math.Clamp(_hpCurrent, 0, _hpMax);
        }
    }
    public int Credits { get => _credits; private set => _credits = value; }
    public float Fuel { get => _fuel; private set => _fuel = value; }
    public int StorageCapacity { get => _storageCapacity; private set => _storageCapacity = value; }
    public int ChainCapacity { get => _chainCapacity; private set => _chainCapacity = value; }
    public List<Command> CommandList { get => _commandList; private set => _commandList = value; }

    public void IncreaseMaxHealth(float val)
    {
        HpMax += val;
        HpCurrent += val;
    }

    public void Heal(float amount)
    {
        HpCurrent += amount;
    }

    public void TakeDamage(float amount)
    {
        HpCurrent -= amount;
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
