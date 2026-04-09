//heal spell for allies
public class HealSpell : IAction
{
    private int _healAmount;
    public TargetType SuggestedTarget => TargetType.Ally;
    public string Name => $"Heal Spell (Heals {_healAmount} HP)";

    public HealSpell(int healAmount)
    {
        _healAmount = healAmount;
    }

    public void Execute(IAttacker attacker, IDamageable target)
    {
        if (target is Hero hero)
        {
            hero.Heal(_healAmount);
            Console.WriteLine($"{hero.Name} is healed for {_healAmount} HP!");
        }
        else
        {
            Console.WriteLine("Invalid target for Heal Spell.");
        }
    }
}