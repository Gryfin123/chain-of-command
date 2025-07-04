using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

/// <summary>
/// A class used as a playable implementation of CommandDataTemplateSO
/// </summary>
public class Command
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

    public Command(CommandDataTemplateSO source)
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

        properties.Add(_dataSource.cost.AssociatedEnum, _dataSource.cost);
        properties.Add(_dataSource.damage.AssociatedEnum, _dataSource.damage);
        properties.Add(_dataSource.healing.AssociatedEnum, _dataSource.healing);
        properties.Add(_dataSource.barrier.AssociatedEnum, _dataSource.barrier);
        properties.Add(_dataSource.retrigger.AssociatedEnum, _dataSource.retrigger);

        properties.Add(_dataSource.poison.AssociatedEnum, _dataSource.poison);
        properties.Add(_dataSource.weakness.AssociatedEnum, _dataSource.weakness);
        properties.Add(_dataSource.vulnerabilty.AssociatedEnum, _dataSource.vulnerabilty);

        properties.Add(_dataSource.cost_adj.AssociatedEnum, _dataSource.cost_adj);
        properties.Add(_dataSource.damage_adj.AssociatedEnum, _dataSource.damage_adj);
        properties.Add(_dataSource.healing_adj.AssociatedEnum, _dataSource.healing_adj);
        properties.Add(_dataSource.barrier_adj.AssociatedEnum, _dataSource.barrier_adj);
        properties.Add(_dataSource.retrigger_adj.AssociatedEnum, _dataSource.retrigger_adj);

        properties.Add(_dataSource.poison_adj.AssociatedEnum, _dataSource.poison_adj);
        properties.Add(_dataSource.weakness_adj.AssociatedEnum, _dataSource.weakness_adj);
        properties.Add(_dataSource.vulnerabilty_adj.AssociatedEnum, _dataSource.vulnerabilty_adj);
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

    public void Trigger(CommandContext context)
    {
        _dataSource.TriggerCommand(context);
    }
}

[Serializable]
public class CommandProperty
{
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


