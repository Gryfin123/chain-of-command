public class FlamingOnSO : CommandDataTemplateSO
{
    public override void TriggerCommand(CommandContext context)
    {
        ApplyDamage(context, CommandTarget.OPPONENT);
        IncreaseCommandDamage(context, context.SourceCommand);
    }
} 