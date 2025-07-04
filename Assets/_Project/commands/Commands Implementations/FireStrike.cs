public class FireStrike : Command
{
    public FireStrike(CommandDataTemplateSO source) : base(source)
    {
    }

    public override void TriggerCommand(CommandContext context)
    {
        ApplyDamage(context, CommandTarget.OPPONENT);
    }
}