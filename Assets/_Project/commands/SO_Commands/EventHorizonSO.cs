public class EventHorizonSO : CommandDataTemplateSO
{
    public override BaseCommand CreateInstanceCommand()
    {
        return new EventHorizon(this);
    }
}