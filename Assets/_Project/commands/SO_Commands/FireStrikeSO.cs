public class FireStrikeSO : CommandDataTemplateSO
{
    public override BaseCommand CreateInstanceCommand()
    {
        return new FireStrike(this);
    }
}