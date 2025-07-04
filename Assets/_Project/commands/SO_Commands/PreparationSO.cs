using UnityEngine;

public class PreparationSO : CommandDataTemplateSO
{
    public override BaseCommand CreateInstanceCommand()
    {
        return new Preparation(this);
    }
}