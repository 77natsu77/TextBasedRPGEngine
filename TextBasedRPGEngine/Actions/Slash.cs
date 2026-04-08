public class Slash : IAction
{
    public string Name => "Slash";
    public void Execute(IAttacker actor, IDamageable target)
    {
        Console.WriteLine($"{actor.Name} slashes with the sword!");
        target.TakeDamage(actor.BaseDamage);
    }
}