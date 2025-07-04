public class HealingTouch : BaseCommand
{
    public HealingTouch(CommandDataTemplateSO source) : base(source)
    {
    }

    public override void Trigger(CommandContext context)
    {
        ApplyHealing(context, CommandTarget.PLAYER);
    }
}