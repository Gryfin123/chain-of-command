public class FlamingOnSO : CommandDataTemplateSO
{
    public override Command CreateInstanceCommand()
    {
        return new FlamingOn(this);
    }
} 