using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// State Machine for game state
/// </summary>
public class GameStateManager : MonoBehaviour
{
    // States
    private BaseGameState currGameState;

    public MainMenuGameState mainMenuGameState;
    public StartingRunGameState startingRunGameState;
    public ExplorationGameState explorationGameState;
    public BattleGameState battleGameState;
    public BattleRewardGameState battleRewardGameState;
    public EventsGameState eventsGameState;

    // Other Data
    public PlayerProfileSO playerProfileSO;

    public BaseGameState CurrGameState
    {
        get => currGameState;
        set
        {
            if (currGameState != null)
            {
                currGameState.ExitState();
            }
            currGameState = value;
            currGameState.EnterState();
        }
    }

    private void Start()
    {
        mainMenuGameState = new MainMenuGameState(this);
        startingRunGameState = new StartingRunGameState(this);
        explorationGameState = new ExplorationGameState(this);
        battleGameState = new BattleGameState(this);
        battleRewardGameState = new BattleRewardGameState(this);
        eventsGameState = new EventsGameState(this);

        CurrGameState = mainMenuGameState;
    }

    private void Update()
    {
        CurrGameState.UpdateState();
    }

    public void PassInstruction(string instruction)
    {
        CurrGameState?.RecieveInstruction(instruction);
    }
}
