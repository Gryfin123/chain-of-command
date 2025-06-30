using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "HealEffect", menuName = "ScriptableObjects/CommandEffects/HealEffect")]
public class HealEffectSO : BaseCommandEffectSO
{
    [SerializeField]
    private CommandAttributeSO healReference;
    public override string GetEffectSummary()
    {
        return $"Restores health to the player";
    }

    public override void Trigger(CommandEffectContext context)
    {
        float healValue = context.SourceCommand.data.properties[CommandPropertyID.HEALING].EffectiveValue;
        string nameValue = context.SourceCommand.data.commandName;
        Debug.Log($"Command {nameValue} has triggered and healed player for {healValue} points");
    }
}
