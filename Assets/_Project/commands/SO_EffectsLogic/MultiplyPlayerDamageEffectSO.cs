using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "BreakAllCommandsInChain", menuName = "ScriptableObjects/CommandEffects/BreakAllCommandsInChain")]
public class BreakAllCommandsInChainEffectSO : BaseCommandEffectSO
{
    public override void Trigger(CommandEffectContext context)
    {
        string nameValue = context.SourceCommand.data.commandName;
        Debug.Log($"Command {nameValue} has triggered and all commands will break at the end of the chain execution");
    }

    public override string GetEffectSummary()
    {
        return "Breaks all commands in chain";
    }
}
