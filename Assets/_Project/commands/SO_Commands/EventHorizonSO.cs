public class EventHorizonSO : CommandDataTemplateSO
{
    public override Command CreateInstanceCommand()
    {
        return new EventHorizon(this);
    }
}