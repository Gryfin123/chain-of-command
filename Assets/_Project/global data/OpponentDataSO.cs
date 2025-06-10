using System.Collections;
using System.Collections.Generic;
using System.Windows.Input;
using UnityEngine;

[CreateAssetMenu(fileName = "New RunData", menuName = "ScriptableObjects/Opponent Data")]
public class OpponentDataSO : ScriptableObject
{
    [SerializeField] private int attack;
    [SerializeField] private float hpMax;
    [SerializeField] private float hpCurrent;

    public float HpMax { get => hpMax; private set => hpMax = value; }
    public float HpCurrent { get => hpCurrent; private set => hpCurrent = value; }

    public void Init()
    {
        HpCurrent = HpMax;
    }
    public void TakeDamage(float amount)
    {
        HpCurrent -= amount;
    }
    public void Heal(float amount)
    {
        HpCurrent += amount;
    }

    public void Attack(float amount)
    {
        // Deal damage to player
    }
}
