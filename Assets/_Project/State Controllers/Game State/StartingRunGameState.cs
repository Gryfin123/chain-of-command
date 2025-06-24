/// <summary>
/// Phase of the game where player, after leaving Main Menu selects setting that will be tied to the run,
/// like starting character, loadout and modifiers.
/// </summary>
public class StartingRunGameState : BaseGameState
{
    public StartingRunGameState(GameStateManager context) : base(context) { }

    public override void RecieveInstruction(string instruction)
    {
    }

    public override void EnterState()
    {
        // Right now, just pass to next state
        RunControllerSingleton.Instance.InitializeRun();
        _ctx.CurrGameState = _ctx.explorationGameState;
    }

    public override void ExitState()
    {
    }

    public override void UpdateState()
    {
    }
}