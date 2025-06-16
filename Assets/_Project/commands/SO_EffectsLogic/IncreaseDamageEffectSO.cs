using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "IncreaseDamageEffect", menuName = "ScriptableObjects/CommandEffects/IncreaseDamageEffect")]
public class IncreaseDamageEffectSO : BaseCommandEffectSO
{
    [SerializeField]
    private CommandValueEnumSO increaseDamageReference;
    [SerializeField]
    private CommandValueEnumSO damageReference;
    public override string GetEffectSummary()
    {
        return "Increases the base damage of command";
    }

    public override void Trigger(CommandEffectContext context)
    {
        float damageValue = context.SourceCommand.data.GetEffectValueByReference(damageReference);
        float old = damageValue;
        float increaseDamageValue = context.SourceCommand.data.GetEffectValueByReference(increaseDamageReference);
        string nameValue = context.SourceCommand.data.commandName;

        damageValue += increaseDamageValue;

        Debug.Log($"Command {nameValue} has triggered and increased damage by {increaseDamageValue} from {old} to {damageValue}");
    }
}
