public class Hero : IAttacker, IDamageable
{
    public string Name { get; }
    public int Health { get; private set; }
    public int MaxHealth {get;}
    public int BaseDamage { get; }
    public bool IsAlive => Health > 0;
    private const int InventoryMaxWeight = 100; // Arbitrary limit for how much the hero can carry
    
    // The Hero's "Spellbook" or "Move Set"
    public List<IAction> CombatMoves { get; } = new List<IAction>();

    public Hero(string name, int health, int damage)
    {
        Name = name;
        Health = health;
        MaxHealth = health;
        BaseDamage = damage;
        
        // Every Hero starts with a basic punch
        CombatMoves.Add(new LightAttack());
    }

    public void TakeDamage(int amount) => Health -= amount;
    public void Heal(int amount) => Health = Math.Min(Health + amount, MaxHealth);
    public void Attack(IAction action, IDamageable target) => action.Execute(this, target);
    
    // The Hero doesn't decide HOW to attack anymore. 
    // They just provide the list of things they CAN do.
    public List<IAction> GetPossibleActions()
    {
        var allActions = new List<IAction>();

        allActions.AddRange(CombatMoves);

        foreach (var item in Inventory.Items)
        {
            if (item is IConsumable consumable && consumable.Quantity > 0)
            {
                allActions.Add(new UseItemAction(consumable));
            }
        }

        return allActions;
    }

    // Inventory for holding items
    public Inventory Inventory { get; } = new Inventory(InventoryMaxWeight);
}
