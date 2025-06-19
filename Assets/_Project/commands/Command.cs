using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static Unity.VisualScripting.Member;

/// <summary>
/// A class used as a playable implementation of CommandDataTemplateSO
/// </summary>
public class Command
{
    [SerializeField]
    private CommandDataTemplateSO dataSource;

    public string commandName;
    public string description;
    public int cost;
    public int tier;
    public CommandTypeSO commandType;
    public Sprite banner;
    public Sprite splashart;
    public List<CommandTagsSO> tags;

    public List<CommandAttributeSO> effectAttributes;
    public List<float> effectValue;
    public List<BaseCommandEffectSO> effects;

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
        dataSource = source;
        commandName = dataSource.commandName;
        description = dataSource.description;
        cost = dataSource.cost;
        tier = dataSource.tier;
        commandType = dataSource.commandType;
        banner = dataSource.banner;
        splashart = dataSource.splashart;
        tags = new List<CommandTagsSO>(dataSource.tags);

        effectAttributes = new List<CommandAttributeSO>(dataSource.effectAttributes);
        effectValue = new List<float>(dataSource.effectValue);
        effects = new List<BaseCommandEffectSO>(dataSource.effects);
    }

    public string GetProcessedDescription()
    {
        string processedDescription = description;

        for (int i = 0; i < effectAttributes.Count; i++)
        {
            processedDescription = processedDescription.Replace($"[{i}]", $"{effectValue[i]}");
        }

        return processedDescription;
    }

    public float GetEffectValueByReference(CommandAttributeSO reference)
    {
        for (int i = 0; i < effectAttributes.Count; i++)
        {
            if (effectAttributes[i] == reference)
            {
                return effectValue[i];
            }
        }

        throw new KeyNotFoundException();
    }

}
