public class HealAction : IAction
{
    private int _amount;
    public string Name { get; }
    public TargetType SuggestedTarget => TargetType.Ally;
    public HealAction(string name, int amount)
    {
        Name = name;
        _amount = amount;
    }

    public void Execute(IAttacker actor, IDamageable target)
    {
        // Now it doesn't matter WHO the target is. 
        // If the player selects themselves, they get the heal.
        target.Heal(_amount);
    }
}