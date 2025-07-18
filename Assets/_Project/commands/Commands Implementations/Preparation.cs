using UnityEngine;

public class Preparation : BaseCommand
{
    public Preparation(CommandDataTemplateSO source) : base(source)
    {
    }

    public override void Trigger(CommandContext context)
    {
        var queue = context.CurrentQueue;
        var originator = context.SourceCommand;

        var nextCommand = FindNextCommandInQueue(queue, originator);

        // Check if something was found
        if (nextCommand != null)
        {
            IncreaseCommandRetrigger(context, nextCommand.data);
            BreakCommand(context, originator.data);
        }
        else
        {
            // If fitting command wasn't found
            Debug.Log("No command have been found to increase retrigger to.");
        }
    }
}