using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// State Machine for game state
/// </summary>
public class BattleStateManager
{
    // States
    private BattleGameState _masterState;
    private BaseBattleState _currState;
    private BattleStateFactory _stateFactory;

    public BattleStateManager(BattleGameState battleGameState) 
    {
        _masterState = battleGameState;
    }

    public BattleGameState MasterState
    { 
        get { return _masterState; } 
    }

    public BaseBattleState CurrState
    {
        get { return _currState; }
        set { _currState = value; }
    }
    public BattleStateFactory StateFactory
    {
        get { return _stateFactory; }
        set { _stateFactory = value; }
    }

    public void Init()
    {
        _stateFactory = new BattleStateFactory(this);
        _currState = _stateFactory.SetupPhase();
        _currState.EnterState();
    }

    public void Update()
    {
        CurrState?.UpdateState();
    }

    public void PassInstruction(string instruction)
    {
        CurrState?.RecieveInstruction(instruction);
    }
}
