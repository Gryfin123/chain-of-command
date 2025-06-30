using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "RetriggerNextEffect", menuName = "ScriptableObjects/CommandEffects/RetriggerNextEffect")]
public class RetriggerNextEffectSO : BaseCommandEffectSO
{
    [SerializeField]
    private CommandAttributeSO retriggerReference;
    public override string GetEffectSummary() 
    {
        return "Next command will be triggered multiple times";
    }

    public override void Trigger(CommandEffectContext context)
    {
        float retriggerValue = context.SourceCommand.data.properties[CommandPropertyID.RETRIGGER].EffectiveValue;
        string nameValue = context.SourceCommand.data.commandName;
        Debug.Log($"Command {nameValue} will make the next command trigger {retriggerValue} times");
    }
}
