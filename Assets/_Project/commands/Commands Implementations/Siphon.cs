public class Siphon : Command
{
    public Siphon(CommandDataTemplateSO source) : base(source)
    {
    }

    public override void TriggerCommand(CommandContext context)
    {
        ApplyDamage(context, CommandTarget.OPPONENT);
        ApplyHealing(context, CommandTarget.PLAYER);
    }
}