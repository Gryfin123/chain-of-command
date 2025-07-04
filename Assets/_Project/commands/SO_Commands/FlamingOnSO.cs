public class FlamingOnSO : CommandDataTemplateSO
{
    public override BaseCommand CreateInstanceCommand()
    {
        return new FlamingOn(this);
    }
} 