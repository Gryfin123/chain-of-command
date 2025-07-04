using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.UIElements.Experimental;

/// <summary>
/// A class used as a playable implementation of CommandDataTemplateSO
/// </summary>
public abstract class BaseCommand
{
    [SerializeField]
    private CommandDataTemplateSO _dataSource;

    public Sprite banner;
    public Sprite splashart;
    public string commandName;
    public string description;
    public int tier;

    public CommandTypeSO commandType;
    public List<CommandTagsSO> tags = new List<CommandTagsSO>();

    public Dictionary<CommandPropertyID, CommandProperty> properties = new Dictionary<CommandPropertyID, CommandProperty>();

    public bool broken = false;

    public Color BannerColor
    {
        get
        {
            return commandType.associatedColor;
        }
    }

    public BaseCommand(CommandDataTemplateSO source)
    {
        LoadDataFromSource(source);
    }
    private void LoadDataFromSource(CommandDataTemplateSO source)
    { 
        _dataSource = source;

        banner = _dataSource.banner;
        splashart = _dataSource.splashart;
        commandName = _dataSource.commandName;
        description = _dataSource.description;

        commandType = _dataSource.commandType;
        tags = new List<CommandTagsSO>(_dataSource.tags);

        properties.Add(_dataSource.cost.AssociatedEnum, new CommandProperty(_dataSource.cost));
        properties.Add(_dataSource.damage.AssociatedEnum, new CommandProperty(_dataSource.damage));
        properties.Add(_dataSource.healing.AssociatedEnum, new CommandProperty(_dataSource.healing));
        properties.Add(_dataSource.barrier.AssociatedEnum, new CommandProperty(_dataSource.barrier));
        properties.Add(_dataSource.retrigger.AssociatedEnum, new CommandProperty(_dataSource.retrigger));

        properties.Add(_dataSource.poison.AssociatedEnum, new CommandProperty(_dataSource.poison));
        properties.Add(_dataSource.weakness.AssociatedEnum, new CommandProperty(_dataSource.weakness));
        properties.Add(_dataSource.vulnerabilty.AssociatedEnum, new CommandProperty(_dataSource.vulnerabilty));

        properties.Add(_dataSource.cost_adj.AssociatedEnum, new CommandProperty(_dataSource.cost_adj));
        properties.Add(_dataSource.damage_adj.AssociatedEnum, new CommandProperty(_dataSource.damage_adj));
        properties.Add(_dataSource.healing_adj.AssociatedEnum, new CommandProperty(_dataSource.healing_adj));
        properties.Add(_dataSource.barrier_adj.AssociatedEnum, new CommandProperty(_dataSource.barrier_adj));
        properties.Add(_dataSource.retrigger_adj.AssociatedEnum, new CommandProperty(_dataSource.retrigger_adj));

        properties.Add(_dataSource.poison_adj.AssociatedEnum, new CommandProperty(_dataSource.poison_adj));
        properties.Add(_dataSource.weakness_adj.AssociatedEnum, new CommandProperty(_dataSource.weakness_adj));
        properties.Add(_dataSource.vulnerabilty_adj.AssociatedEnum, new CommandProperty(_dataSource.vulnerabilty_adj));
    }

    public string GetProcessedDescription()
    {
        string processedDescription = description;
        
        foreach(var property in properties) 
        { 
            processedDescription = processedDescription.Replace($"[{property.Key.ToString().ToLower()}]", $"{property.Value.EffectiveValue}");
        }

        return processedDescription;
    }


    // ===== Function for Command Trigger Functionality ===== //
    public abstract void Trigger(CommandContext context);
    // ======= Common Private Fucntions used in Command Effects ======== //
    protected void ApplyDamage(CommandContext context, CommandTarget target)
    {
        var damage = properties[CommandPropertyID.DAMAGE];

        switch (target)
        {
            case CommandTarget.PLAYER:
                BattleControllerSingleton.Instance.PlayerProfile.TakeDamage(damage.EffectiveValue);
                break;
            case CommandTarget.OPPONENT:
                BattleControllerSingleton.Instance.OpponentProfile.TakeDamage(damage.EffectiveValue);
                break;
        }
        Debug.Log($"Command {this.GetType().Name} has triggered and dealt {damage.EffectiveValue} damage to {target}.");
    }
    protected void ApplyHealing(CommandContext context, CommandTarget target)
    {
        var healing = properties[CommandPropertyID.HEALING];

        switch (target)
        {
            case CommandTarget.PLAYER:
                BattleControllerSingleton.Instance.PlayerProfile.Heal(healing.EffectiveValue);
                break;
            case CommandTarget.OPPONENT:
                BattleControllerSingleton.Instance.OpponentProfile.Heal(healing.EffectiveValue);
                break;
        }
        Debug.Log($"Command {this.GetType().Name} has triggered and healed {target}, by {healing.EffectiveValue}.");
    }


    protected void IncreaseCommandDamage(CommandContext context, BaseCommand target)
    {
        var damage_adj = properties[CommandPropertyID.DAMAGE_ADJ];

        target.properties[CommandPropertyID.DAMAGE].Modifier += damage_adj.EffectiveValue;
        Debug.Log($"Command {this.GetType().Name} has triggered and permanently increased {target.commandName} by {damage_adj.EffectiveValue}. {target.commandName} now deals {target.properties[CommandPropertyID.DAMAGE].EffectiveValue}.");
    }
    protected void IncreaseCommandDamageMultiplier(CommandContext context, BaseCommand target)
    {
        var damage_adj = properties[CommandPropertyID.DAMAGE_ADJ];

        target.properties[CommandPropertyID.DAMAGE].Modifier *= damage_adj.EffectiveValue;
        Debug.Log($"Command {this.GetType().Name} has triggered and permanently increased {target.commandName} times {damage_adj.EffectiveValue}. {target.commandName} now deals {target.properties[CommandPropertyID.DAMAGE].EffectiveValue}.");
    }
    protected void IncreaseCommandRetrigger(CommandContext context, BaseCommand target)
    {
        var retrigger_adj = properties[CommandPropertyID.RETRIGGER_ADJ];

        target.properties[CommandPropertyID.RETRIGGER].Modifier += retrigger_adj.EffectiveValue;
        Debug.Log($"Command {this.GetType().Name} has triggered and permanently increased {target.commandName} retrigger to {retrigger_adj.EffectiveValue}. {target.commandName} now triggers {target.properties[CommandPropertyID.RETRIGGER].EffectiveValue} times.");
    }

    protected void BreakCommand(CommandContext context, BaseCommand target)
    {
        target.broken = true;
    }

    protected void ApplyBuff(CommandContext context, string buff)
    {
        Debug.Log($"Command {GetType().Name} has triggered and applied a buff: {buff}.");
    }

    /// <summary>
    /// Search given queue and find a command next in line after originator
    /// </summary>
    /// <param name="context">Queue that will be searched through</param>
    /// <param name="originator">Original command that. Return value will be next in queue, after this one</param>
    /// <param name="includeNull">When true, result may include null from empty slot. Otherwise it will check for next command that is not null</param>
    /// <returns></returns>
    protected BaseCommand FindNextCommandInQueue(List<BaseCommand> queue, BaseCommand originator, bool includeNull = false)
    {
        var getNextOne = false;
        for (int i = 0; i < queue.Count; i++)
        {
            if (getNextOne)
            {
                if (queue[i] == null && includeNull ||
                    queue[i] != null)
                {
                    return queue[i];
                }
            }
            else if (queue[i]?.Equals(originator) == true)
            {
                getNextOne = true;
            }
        }

        return null;
    }
}

[Serializable]
public class CommandProperty
{
    public CommandProperty() { }
    /// <summary>
    /// Constructor used to copy data from different property, to create seperate instance. 
    /// </summary>
    /// <param name="original"></param>
    public CommandProperty(CommandProperty original)
    {
        _base = original._base;
        _modifier = original._modifier;
        _multiplier = original._multiplier;
        _override = original._override;
        _overrideBase = original._overrideBase;
        _associatedEnum = original._associatedEnum;
    }
    public int EffectiveValue 
    {
        get
        {
            if (Override != -1)
            {
                return Override;
            }

            var effectiveBase = OverrideBase != -1 ? OverrideBase : Base;

            return (effectiveBase + Modifier) * Multiplier;
        }
    }

    [SerializeField] private int _base = 0;
    [SerializeField] private int _modifier = 0;
    [SerializeField] private int _multiplier = 1;
    [SerializeField] private int _override = -1;
    [SerializeField] private int _overrideBase = -1;
    [SerializeField] private CommandPropertyID _associatedEnum;
    public CommandPropertyID AssociatedEnum
    {
        get { return _associatedEnum; }
        set { _associatedEnum = value; }
    }

    public int Base { get => _base; set => _base = value; }
    public int Modifier { get => _modifier; set => _modifier = value; }
    public int Multiplier { get => _multiplier; set => _multiplier = value; }
    public int Override { get => _override; set => _override = value; }
    public int OverrideBase { get => _overrideBase; set => _overrideBase = value; }
}

[Serializable]
public class CommandTags
{
    public List<CommandTagsSO> All
    {
        get
        {
            var combined = Base.Union(Added).ToList();
            return combined;
        }
    }

    [SerializeField] private List<CommandTagsSO> _base = new List<CommandTagsSO>();
    [SerializeField] private List<CommandTagsSO> _added = new List<CommandTagsSO>();
    public List<CommandTagsSO> Base { get => _base; set => _base = value; }
    public List<CommandTagsSO> Added { get => _added; set => _added = value; }
}

public enum CommandPropertyID
{
    COST,
    DAMAGE,
    HEALING,
    BARRIER,
    RETRIGGER,

    POISON,
    VULNERABILITY,
    WEAKNESS,

    // Adjustment Properties (It is used to increase or decrease the base properties.)
    COST_ADJ,
    DAMAGE_ADJ,
    HEALING_ADJ,
    BARRIER_ADJ,
    RETRIGGER_ADJ,

    POISON_ADJ,
    VULNERABILITY_ADJ,
    WEAKNESS_ADJ

}

public enum CommandTarget
{
    PLAYER,
    OPPONENT
}
