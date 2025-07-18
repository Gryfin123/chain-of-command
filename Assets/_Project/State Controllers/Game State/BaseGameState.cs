public abstract class BaseGameState
{
    protected GameStateManager _ctx;
    protected GameStateFactory _factory;

    public BaseGameState(GameStateManager context, GameStateFactory factory)
    {
        _ctx = context;
        _factory = factory;
    }

    public abstract void EnterState();
    public abstract void UpdateState();
    public abstract void ExitState();
    public abstract void RecieveInstruction(string instruction);

    protected void SwitchState(BaseGameState newState)
    {
        ExitState();
        _ctx.CurrState = newState;
        _ctx.CurrState.EnterState();
    }
}