public class FireStrikeSO : CommandDataTemplateSO
{
    public override void TriggerCommand(CommandEffectContext context)
    {
        ApplyDamage(context, CommandTarget.OPPONENT);
    }
}