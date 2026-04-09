public class LightAttack : IAction
{
    public string Name => "Light Attack";
    public TargetType SuggestedTarget => TargetType.Enemy;
    public void Execute(IAttacker actor, IDamageable target)
    {
        Console.WriteLine($"{actor.Name} lunges quickly!");
        target.TakeDamage(actor.BaseDamage);
    }
}