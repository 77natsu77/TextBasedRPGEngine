public class HealthPotion : IConsumable
{
    public string Name => "Health Potion";
    public string Description => "Heals 20 HP.";
    public int Weight => 1;
    public int Quantity { get; set; }
    private int _healValue = 20;

    public void Use(IDamageable target)
    {
        if (Quantity > 0)
        {
            target.Heal(_healValue);
            Quantity--;
        }
    }
    
    // This allows the Hero class to turn this item into a selectable Battle Action
    public IAction GetAction() => new HealAction($"Drink {Name}", _healValue);
}