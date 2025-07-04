public class SiphonSO : CommandDataTemplateSO
{
    public override void TriggerCommand(CommandContext context)
    {
        ApplyDamage(context, CommandTarget.OPPONENT);
        ApplyHealing(context, CommandTarget.PLAYER);
    }
}