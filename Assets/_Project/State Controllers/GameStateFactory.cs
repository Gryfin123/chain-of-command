public class GameStateFactory
{
    GameStateManager _ctx;

    public GameStateFactory(GameStateManager context)
    {
        _ctx = context;
    }

    public BaseGameState MainMenu()
    {
        return new MainMenuGameState(_ctx, this);
    }
    public BaseGameState StartingRun()
    {
        return new StartingRunGameState(_ctx, this);
    }
    public BaseGameState Exploration()
    {
        return new ExplorationGameState(_ctx, this);
    }
    public BaseGameState Store()
    {
        return new StoreGameState(_ctx, this);
    }
    public BaseGameState Event()
    {
        return new EventsGameState(_ctx, this);
    }
    public BaseGameState Battle()
    {
        return new BattleGameState(_ctx, this);
    }
    public BaseGameState BattleReward()
    {
        return new BattleRewardGameState(_ctx, this);
    }

    // Battle State SubStates
    public BaseGameState ExecutionPhase()
    {
        return new ExecutionPhaseState(_ctx, this);
    }
    public BaseGameState OponnetPhase()
    {
        return new OpponentPhaseState(_ctx, this);
    }
    public BaseGameState SetupPhase()
    {
        return new SetupPhaseState(_ctx, this);
    }
}