public class PreparationSO : CommandDataTemplateSO
{
    public override void TriggerCommand(CommandEffectContext context)
    {
        IncreaseCommandRetrigger(context, context.SourceCommand.data);
    }
}