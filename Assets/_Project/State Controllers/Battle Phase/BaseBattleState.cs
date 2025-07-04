public abstract class BaseBattleState
{
    protected BattleStateManager _ctx;
    protected BattleStateFactory _factory;

    public BaseBattleState(BattleStateManager context, BattleStateFactory factory)
    {
        _ctx = context;
        _factory = factory;
    }

    public abstract void EnterState();
    public abstract void UpdateState();
    public abstract void ExitState();
    public abstract void RecieveInstruction(string instruction);

    protected void SwitchState(BaseBattleState newState)
    {
        ExitState();
        _ctx.CurrState = newState;
        _ctx.CurrState.EnterState();
    }
}