using System;
using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEditor.Searcher;
using UnityEngine;

[CreateAssetMenu(fileName = "New Command", menuName = "ScriptableObjects/Command")]
public class CommandDataTemplateSO : ScriptableObject
{
    public Sprite banner;
    public Sprite splashart;
    public string commandName;
    public string description;
    public int tier;

    public CommandTypeSO commandType;
    public List<CommandTagsSO> tags;
    public List<BaseCommandEffectSO> effects;

    [Header("Default Properties")]
    public CommandProperty cost;
    public CommandProperty damage;
    public CommandProperty healing;
    public CommandProperty barrier;
    public CommandProperty retrigger;

    public CommandProperty poison;
    public CommandProperty vulnerabilty;
    public CommandProperty weakness;

    [Header("Adjustment Properties")]
    public CommandProperty cost_adj;
    public CommandProperty damage_adj;
    public CommandProperty healing_adj;
    public CommandProperty barrier_adj;
    public CommandProperty retrigger_adj;

    public CommandProperty poison_adj;
    public CommandProperty vulnerabilty_adj;
    public CommandProperty weakness_adj;
}
