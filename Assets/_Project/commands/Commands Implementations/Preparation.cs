using UnityEngine;

public class Preparation : Command
{
    public Preparation(CommandDataTemplateSO source) : base(source)
    {
    }

    public override void TriggerCommand(CommandContext context)
    {
        var queue = context.CurrentQueue;
        var originator = context.SourceCommand;

        var nextCommand = FindNextCommandInQueue(queue, originator);

        // Check if something was found
        if (nextCommand != null)
        {
            IncreaseCommandRetrigger(context, nextCommand);
        }
        else
        {
            // If fitting command wasn't found
            Debug.Log("No command have been found to increase retrigger to.");
        }
    }
}