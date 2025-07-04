public class FlamingOn : Command
{
    public FlamingOn(CommandDataTemplateSO source) : base(source)
    {
    }

    public override void TriggerCommand(CommandContext context)
    {
        ApplyDamage(context, CommandTarget.OPPONENT);
        IncreaseCommandDamage(context, context.SourceCommand);
    }
}