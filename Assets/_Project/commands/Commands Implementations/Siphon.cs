public class Siphon : BaseCommand
{
    public Siphon(CommandDataTemplateSO source) : base(source)
    {
    }

    public override void Trigger(CommandContext context)
    {
        ApplyDamage(context, CommandTarget.OPPONENT);
        ApplyHealing(context, CommandTarget.PLAYER);
    }
}