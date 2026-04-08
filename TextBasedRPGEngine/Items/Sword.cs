public class Sword : IEquippable, IAttacker
{
    // IInventoryItem properties
    public string Name => "Rusty Longsword";
    public string Description => "It's seen better days, but it's sharp enough.";
    public int Weight => 5;
    public int Quantity { get; set; } = 1; // Default to 1 sword when added to inventory

    // IAttacker properties
    public int BaseDamage => 15;

    public void Equip(Hero hero)
    {
        Console.WriteLine($"{hero.Name} equips the {Name}.");
        hero.CombatMoves.Add(new Slash());
    }

    public void Unequip(Hero hero)
    {
        Console.WriteLine($"{hero.Name} unequips the {Name}.");
        hero.CombatMoves.RemoveAll(move => move is Slash);
    }
}
