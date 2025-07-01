public abstract class BaseGameState
{
    protected GameStateManager _ctx;
    protected GameStateFactory _factory;

    protected BaseGameState _currSuperState;
    protected BaseGameState _currSubState;

    public BaseGameState(GameStateManager context, GameStateFactory factory)
    {
        _ctx = context;
        _factory = factory;
    }

    public abstract void EnterState();
    public abstract void UpdateState();
    public abstract void ExitState();
    public abstract void CheckSwitchStates();
    public abstract void InitializeSubState();
    public abstract void RecieveInstruction(string instruction);

    public void UpdateStates() 
    {
        UpdateState();
        _currSubState?.UpdateStates();
    }

    protected void SwitchState(BaseGameState newState)
    {
        ExitState();
        _ctx.CurrState = newState;
        _ctx.CurrState.EnterState();
    }
    protected void SetSuperState(BaseGameState newSuperState) 
    {
        _currSuperState = newSuperState;
    }
    protected void SetSubState(BaseGameState newSubState) 
    {
        _currSubState = newSubState;
        newSubState.SetSuperState(this);
    }
}