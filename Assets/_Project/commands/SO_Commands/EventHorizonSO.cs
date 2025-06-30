public class EventHorizonSO : CommandDataTemplateSO
{
    public override void TriggerCommand(CommandEffectContext context)
    {
        IncreaseCommandDamageMultiplier(context, context.SourceCommand.data);
    }
}