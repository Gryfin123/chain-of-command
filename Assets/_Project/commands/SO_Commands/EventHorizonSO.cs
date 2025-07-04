public class EventHorizonSO : CommandDataTemplateSO
{
    public override void TriggerCommand(CommandContext context)
    {
        IncreaseCommandDamageMultiplier(context, context.SourceCommand);
    }
}