public class SiphonSO : CommandDataTemplateSO
{
    public override BaseCommand CreateInstanceCommand()
    {
        return new Siphon(this);
    }
}