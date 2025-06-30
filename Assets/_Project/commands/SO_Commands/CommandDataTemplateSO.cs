using System;
using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEditor.Searcher;
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

    public abstract void TriggerCommand(CommandEffectContext context);


    // ======= Common Private Fucntions used in Command Effects ======== //
    protected void ApplyDamage(CommandEffectContext context, CommandTarget target)
    {
        Debug.Log($"Command {this.GetType().Name} has triggered and dealt {damage.EffectiveValue} damage to {target}.");
    }
    protected void ApplyHealing(CommandEffectContext context, CommandTarget target)
    {
        Debug.Log($"Command {this.GetType().Name} has triggered and healed {target}, by {healing.EffectiveValue}.");
    }


    protected void IncreaseCommandDamage(CommandEffectContext context, Command target)
    {
        target.properties[CommandPropertyID.DAMAGE].Modifier += damage_adj.EffectiveValue;
        Debug.Log($"Command {this.GetType().Name} has triggered and permanently increased {target.commandName} by {damage_adj.EffectiveValue}. {target.commandName} now deals {target.properties[CommandPropertyID.DAMAGE].EffectiveValue}.");
    }
    protected void IncreaseCommandDamageMultiplier(CommandEffectContext context, Command target)
    {
        target.properties[CommandPropertyID.DAMAGE].Modifier *= damage_adj.EffectiveValue;
        Debug.Log($"Command {this.GetType().Name} has triggered and permanently increased {target.commandName} times {damage_adj.EffectiveValue}. {target.commandName} now deals {target.properties[CommandPropertyID.DAMAGE].EffectiveValue}.");
    }
    protected void IncreaseCommandRetrigger(CommandEffectContext context, Command target)
    {
        target.properties[CommandPropertyID.RETRIGGER].Modifier += retrigger_adj.EffectiveValue;
        Debug.Log($"Command {this.GetType().Name} has triggered and permanently increased {target.commandName} retrigger to {retrigger_adj.EffectiveValue}. {target.commandName} now triggers {target.properties[CommandPropertyID.RETRIGGER].EffectiveValue} times.");
    }

    protected void BreakCommand(CommandEffectContext context, Command target)
    {
        target.broken = true;
    }


    protected void ApplyBuff(CommandEffectContext context, string buff)
    {
        Debug.Log($"Command {this.GetType().Name} has triggered and applied a buff: {buff}.");
    }
}


// ======== Other Used Classses / Enums / Etc. ======== //
public enum CommandTarget
{
    PLAYER,
    OPPONENT
}
