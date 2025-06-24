using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class BaseBattlePhaseState
{
    public abstract void EnterState(GameStateManager context);
    public abstract void UpdateState(GameStateManager context);
    public abstract void ExitState(GameStateManager context);

}