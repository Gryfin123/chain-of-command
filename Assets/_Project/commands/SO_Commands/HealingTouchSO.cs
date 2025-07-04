public class HealingTouchSO : CommandDataTemplateSO
{
    public override BaseCommand CreateInstanceCommand()
    {
        return new HealingTouch(this);
    }
}