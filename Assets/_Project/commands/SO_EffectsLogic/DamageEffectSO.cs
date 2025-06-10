using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "DamageEffect", menuName = "ScriptableObjects/CommandEffects/DamageEffect")]
public class DamageEffectSO : BaseCommandEffectSO
{
    [SerializeField]
    private CommandValueEnumSO damageReference;
    public override string GetEffectSummary()
    {
        return "Damages opponent for a specific amount of health";
    }

    public override void Trigger(CommandEffectContext context)
    {
        float damageValue = context.SourceCommand.data.GetEffectValueByReference(damageReference);
        string nameValue = context.SourceCommand.data.commandName;
        Debug.Log($"Command {nameValue} has triggered and dealth {damageValue} damage to the target");
    }
}
