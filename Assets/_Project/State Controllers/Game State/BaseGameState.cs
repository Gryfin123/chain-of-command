using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class BaseGameState
{
    protected GameStateManager _ctx;

    public BaseGameState(GameStateManager context)
    { 
        _ctx = context;
    }

    public abstract void EnterState();
    public abstract void UpdateState();
    public abstract void ExitState();
    public abstract void RecieveInstruction(string instruction);
}