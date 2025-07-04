public class FireStrike : BaseCommand
{
    public FireStrike(CommandDataTemplateSO source) : base(source)
    {
    }

    public override void Trigger(CommandContext context)
    {
        ApplyDamage(context, CommandTarget.OPPONENT);
    }
}