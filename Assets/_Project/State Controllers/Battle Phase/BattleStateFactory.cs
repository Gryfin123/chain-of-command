public class BattleStateFactory
{
    BattleStateManager _ctx;

    public BattleStateFactory(BattleStateManager context)
    {
        _ctx = context;
    }

    public BaseBattleState ExecutionPhase()
    {
        return new ExecutionPhaseState(_ctx, this);
    }
    public BaseBattleState OponnetPhase()
    {
        return new OpponentPhaseState(_ctx, this);
    }
    public BaseBattleState SetupPhase()
    {
        return new SetupPhaseState(_ctx, this);
    }
}