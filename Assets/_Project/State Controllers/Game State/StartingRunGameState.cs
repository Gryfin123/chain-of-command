/// <summary>
/// Phase of the game where player, after leaving Main Menu selects setting that will be tied to the run,
/// like starting character, loadout and modifiers.
/// </summary>
public class StartingRunGameState : BaseGameState
{
    public StartingRunGameState(GameStateManager context, GameStateFactory factory) : base(context, factory) { }

    public override void RecieveInstruction(string instruction)
    {
    }

    public override void EnterState()
    {
        // Right now, just pass to next state
        RunControllerSingleton.Instance.InitializeRun();
        SwitchState(_factory.Exploration());
    }

    public override void ExitState()
    {
    }

    public override void UpdateState()
    {
    }

    public override void CheckSwitchStates()
    {

    }

    public override void InitializeSubState()
    {

    }
}