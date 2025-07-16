using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class CommandSlotGroup : MonoBehaviour
{
    [SerializeField] CommandSlotGroupType _csgType;
    [SerializeField] TMP_Text _title;

    public CommandSlotGroupType CsgType
    {
        get => _csgType;
        set => _csgType = value;
    }

    private void Start()
    {
        _title.text = _csgType.ToString();
    }
}

public enum CommandSlotGroupType
{
    NONE,
    OTHER,
    CHAIN,
    STORAGE,
    REWARD,
    REPAIR,
    SHOP
}
