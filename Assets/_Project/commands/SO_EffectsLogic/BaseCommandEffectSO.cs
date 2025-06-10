using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class BaseCommandEffectSO : ScriptableObject
{
    public abstract void Trigger(CommandEffectContext context);

    public abstract string GetEffectSummary();
}
