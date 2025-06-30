public class FlamingOnSO : CommandDataTemplateSO
{
    public override void TriggerCommand(CommandEffectContext context)
    {
        ApplyDamage(context, CommandTarget.OPPONENT);
        IncreaseCommandDamage(context, context.SourceCommand.data);
    }
} 