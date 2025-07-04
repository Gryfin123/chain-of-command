public class PreparationSO : CommandDataTemplateSO
{
    public override void TriggerCommand(CommandContext context)
    {
        IncreaseCommandRetrigger(context, context.SourceCommand);
    }
}