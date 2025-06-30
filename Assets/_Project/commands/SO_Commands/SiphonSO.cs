public class SiphonSO : CommandDataTemplateSO
{
    public override void TriggerCommand(CommandEffectContext context)
    {
        ApplyDamage(context, CommandTarget.OPPONENT);
        ApplyHealing(context, CommandTarget.PLAYER);
    }
}