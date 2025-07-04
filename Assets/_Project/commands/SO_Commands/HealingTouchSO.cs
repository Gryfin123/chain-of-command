public class HealingTouchSO : CommandDataTemplateSO
{
    public override void TriggerCommand(CommandContext context)
    {
        ApplyHealing(context, CommandTarget.PLAYER);
    }
}