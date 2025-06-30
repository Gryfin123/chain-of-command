public class HealingTouchSO : CommandDataTemplateSO
{
    public override void TriggerCommand(CommandEffectContext context)
    {
        ApplyHealing(context, CommandTarget.PLAYER);
    }
}