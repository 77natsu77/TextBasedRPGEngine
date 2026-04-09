public class Slash : IAction
{
    public string Name => "Slash";
    private int _weaponDamage;
    public TargetType SuggestedTarget => TargetType.Enemy;
    // Constructor captures the sword's damage
    public Slash(int weaponDamage) 
    {
        _weaponDamage = weaponDamage;
    }

    public void Execute(IAttacker actor, IDamageable target)
    {
        // Add Hero base damage and Sword damage together (or just use weapon damage)
        int totalDamage = actor.BaseDamage + _weaponDamage; 
        Console.WriteLine($"{actor.Name} slashes for {totalDamage}!");
        target.TakeDamage(totalDamage);
    }
}