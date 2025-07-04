public class FireStrikeSO : CommandDataTemplateSO
{
    public override void TriggerCommand(CommandContext context)
    {
        ApplyDamage(context, CommandTarget.OPPONENT);
    }
}