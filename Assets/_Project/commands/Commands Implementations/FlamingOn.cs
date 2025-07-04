public class FlamingOn : BaseCommand
{
    public FlamingOn(CommandDataTemplateSO source) : base(source)
    {
    }

    public override void Trigger(CommandContext context)
    {
        ApplyDamage(context, CommandTarget.OPPONENT);
        IncreaseCommandDamage(context, context.SourceCommand);
    }
}