public class HeavyAttack : IAction
{
    public string Name => "Heavy Attack";
    public TargetType SuggestedTarget => TargetType.Enemy;
    public void Execute(IAttacker actor, IDamageable target)
    {
        Console.WriteLine($"{actor.Name} winds up a massive blow!");
        target.TakeDamage(actor.BaseDamage * 2);
    }
}