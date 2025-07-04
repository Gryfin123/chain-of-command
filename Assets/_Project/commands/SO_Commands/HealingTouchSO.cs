public class HealingTouchSO : CommandDataTemplateSO
{
    public override Command CreateInstanceCommand()
    {
        return new HealingTouch(this);
    }
}