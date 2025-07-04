using System;
using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEditor.Searcher;
using UnityEditor.U2D.Common;
using UnityEngine;

[CreateAssetMenu(fileName = "New Command", menuName = "ScriptableObjects/Command")]
public abstract class CommandDataTemplateSO : ScriptableObject
{
    public Sprite banner;
    public Sprite splashart;
    public string commandName;
    public string description;
    public int tier;

    public CommandTypeSO commandType;
    public List<CommandTagsSO> tags;

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

    public void Awake()
    {
        cost.AssociatedEnum = CommandPropertyID.COST;
        damage.AssociatedEnum = CommandPropertyID.DAMAGE;
        healing.AssociatedEnum = CommandPropertyID.HEALING;
        barrier.AssociatedEnum = CommandPropertyID.BARRIER;
        retrigger.AssociatedEnum = CommandPropertyID.RETRIGGER;

        poison.AssociatedEnum = CommandPropertyID.POISON;
        vulnerabilty.AssociatedEnum = CommandPropertyID.VULNERABILITY;
        weakness.AssociatedEnum = CommandPropertyID.WEAKNESS;

        cost_adj.AssociatedEnum = CommandPropertyID.COST_ADJ;
        damage_adj.AssociatedEnum = CommandPropertyID.DAMAGE_ADJ;
        healing_adj.AssociatedEnum = CommandPropertyID.HEALING_ADJ;
        barrier_adj.AssociatedEnum = CommandPropertyID.BARRIER_ADJ;
        retrigger_adj.AssociatedEnum = CommandPropertyID.RETRIGGER_ADJ;

        poison_adj.AssociatedEnum = CommandPropertyID.POISON_ADJ;
        vulnerabilty_adj.AssociatedEnum = CommandPropertyID.VULNERABILITY_ADJ;
        weakness_adj.AssociatedEnum = CommandPropertyID.WEAKNESS_ADJ;
    }

    public abstract Command CreateInstanceCommand();
}
