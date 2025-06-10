using System;
using System.Collections;
using System.Collections.Generic;
using System.Windows.Input;
using UnityEngine;

[CreateAssetMenu(fileName = "New RunData", menuName = "ScriptableObjects/Run Data")]
public class RunDataSO : ScriptableObject
{
    [SerializeField] private int credits;
    [SerializeField] private float hpMax;
    [SerializeField] private float hpCurrent;
    //private List<ICommand> commandList;

    public float HpMax { get => hpMax; private set => hpMax = value; }
    public float HpCurrent { get => hpCurrent; private set => hpCurrent = value; }


    public void Init()
    {
        HpCurrent = HpMax;
    }
    public void AddCredits(int amount)
    {
        credits += amount;
    }
    public void SubstractCredits(int amount)
    {
        credits -= amount;
    }

    public void TakeDamage(float amount)
    {
        hpCurrent -= amount;
    }
    public void Heal(float amount)
    {
        hpCurrent += amount;
    }

    public void AddCommand(ICommand newCommand)
    {
        // Not Implemented
        // commandList.Add(newCommand);
    }
    public void RemoveCommand(ICommand targetCommand)
    {
        // Not Implemented
        // commandList.Remove(newCommand);
    }
}
