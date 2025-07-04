using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Loadout", menuName = "ScriptableObjects/Loadout")]
public class LoadoutSO : ScriptableObject
{
    [SerializeField] private int credits;
    [SerializeField] private float maxHp;
    [SerializeField] private float fuel;
    [SerializeField] private int storageCapacity;
    [SerializeField] private int chainCapacity;

    [SerializeField]
    private List<CommandDataTemplateSO> commandList;

    public int Credits { get => credits; private set => credits = value; }
    public float MaxHp { get => maxHp; private set => maxHp = value; }
    public float Fuel { get => fuel; private set => fuel = value; }
    public int StorageCapacity { get => storageCapacity; set => storageCapacity = value; }
    public int ChainCapacity { get => chainCapacity; private set => chainCapacity = value; }

    public List<BaseCommand> GetCommandList()
    {
        var newList = new List<BaseCommand>();

        foreach (var data in commandList)
        {
            var newCommand = data.CreateInstanceCommand();
            newList.Add(newCommand);
        }

        return newList;
    }
}
