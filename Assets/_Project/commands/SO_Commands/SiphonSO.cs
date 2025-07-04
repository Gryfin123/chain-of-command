public class SiphonSO : CommandDataTemplateSO
{
    public override Command CreateInstanceCommand()
    {
        return new Siphon(this);
    }
}