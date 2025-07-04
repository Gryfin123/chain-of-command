public class FireStrikeSO : CommandDataTemplateSO
{
    public override Command CreateInstanceCommand()
    {
        return new FireStrike(this);
    }
}