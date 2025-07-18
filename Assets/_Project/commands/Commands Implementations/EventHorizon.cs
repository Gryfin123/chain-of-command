using UnityEngine;

public class EventHorizon : BaseCommand
{
    public EventHorizon(CommandDataTemplateSO source) : base(source)
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
            IncreaseCommandDamageMultiplier(context, nextCommand.data);
            BreakCommand(context, context.SourceCommand.data);
        }
        else
        {
            // If fitting command wasn't found
            Debug.Log("No command have been found to increase multiplier to.");
        }

    }
}