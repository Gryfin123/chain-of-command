using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "MultiplyPlayerDamage", menuName = "ScriptableObjects/CommandEffects/MultiplyPlayerDamage")]
public class MultiplyPlayerDamageEffectSO : BaseCommandEffectSO
{
    [SerializeField]
    private CommandValueEnumSO multiplyDamage;

    public override void Trigger(CommandEffectContext context)
    {
        float multiplierValue = context.SourceCommand.data.GetEffectValueByReference(multiplyDamage);
        string nameValue = context.SourceCommand.data.commandName;

        Debug.Log($"Command {nameValue} has triggered and increased all damage dealt by player by facto of {multiplierValue}");
    }

    public override string GetEffectSummary()
    {
        return "Multiplies all damage dealt by the player";
    }
}
