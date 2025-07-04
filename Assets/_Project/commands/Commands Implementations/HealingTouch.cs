public class HealingTouch : Command
{
    public HealingTouch(CommandDataTemplateSO source) : base(source)
    {
    }

    public override void TriggerCommand(CommandContext context)
    {
        ApplyHealing(context, CommandTarget.PLAYER);
    }
}