using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

[CreateAssetMenu(fileName = "New Command", menuName = "ScriptableObjects/Command")]
public class CommandDataTemplateSO : ScriptableObject
{
    public string commandName;
    public string description;
    public int cost;
    public int tier;
    public List<string> tags;

    public List<CommandValueEnumSO> effectValueEnums;
    public List<float> effectValue;
    public List<BaseCommandEffectSO> effects;

    public string GetProcessedDescription()
    {
        string processedDescription = description;

        for (int i = 0; i < effectValueEnums.Count; i++)
        {
            processedDescription = processedDescription.Replace($"[{i}]", $"{effectValue[i]}");
            Debug.Log($"{commandName} - description iteration {i + 1}. Current Description: {processedDescription}");
        }

        return processedDescription;
    }

    public float GetEffectValueByReference(CommandValueEnumSO reference)
    {
        for(int i = 0; i < effectValueEnums.Count; i++)
        {
            if (effectValueEnums[i] == reference)
            {
                return effectValue[i];
            }
        }

        throw new KeyNotFoundException();
    }
}
