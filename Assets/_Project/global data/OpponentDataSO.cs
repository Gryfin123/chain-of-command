using System.Collections;
using System.Collections.Generic;
using System.Windows.Input;
using UnityEngine;

[CreateAssetMenu(fileName = "New RunData", menuName = "ScriptableObjects/Opponent Data")]
public class OpponentDataSO : ScriptableObject
{
    [SerializeField] private PlayerProfileSO _playerProfile;

    [SerializeField] private int _attack;
    [SerializeField] private float _hpMax;
    [SerializeField] private float _hpCurrent;

    public float HpMax { get => _hpMax; private set => _hpMax = value; }
    public float HpCurrent { get => _hpCurrent; private set => _hpCurrent = value; }

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

    public void AttackPlayer()
    {
        _playerProfile.TakeDamage(_attack);
        Debug.Log($"Player has been attacked for {_attack}! Only {_playerProfile.HpCurrent} remaining.");
    }
}
