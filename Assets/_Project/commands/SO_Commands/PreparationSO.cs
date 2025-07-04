using UnityEngine;

public class PreparationSO : CommandDataTemplateSO
{
    public override Command CreateInstanceCommand()
    {
        return new Preparation(this);
    }
}