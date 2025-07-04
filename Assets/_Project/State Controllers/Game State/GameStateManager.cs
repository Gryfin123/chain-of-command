using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

/// <summary>
/// State Machine for game state
/// </summary>
public class GameStateManager : MonoBehaviour
{
    // States
    private BaseGameState _currState;
    private GameStateFactory _stateFactory;

    public BaseGameState CurrState
    {
        get { return _currState; }
        set { _currState = value; }
    }
    public GameStateFactory StateFactory
    {
        get { return _stateFactory; }
        set { _stateFactory = value; }
    }

    // Other Data
    public PlayerProfileSO playerProfileSO;

    private void Start()
    {
        _stateFactory = new GameStateFactory(this);
        _currState = _stateFactory.MainMenu();
        _currState.EnterState();
    }

    private void Update()
    {
        CurrState?.UpdateState();
    }

    public void PassInstruction(string instruction)
    {
        CurrState?.RecieveInstruction(instruction);
    }

    public void LaunchCoroutine(IEnumerator routine)
    {
        StartCoroutine(routine);
    }
}
