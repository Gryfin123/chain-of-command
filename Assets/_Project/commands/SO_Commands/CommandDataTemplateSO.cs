using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEditor.Searcher;
using UnityEngine;

[CreateAssetMenu(fileName = "New Command", menuName = "ScriptableObjects/Command")]
public class CommandDataTemplateSO : ScriptableObject
{
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
}
