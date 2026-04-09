public class HealthPotion : IConsumable
{
    public string Name => "Health Potion";
    public string Description => "Heals 20 HP.";
    public TargetType SuggestedTarget => TargetType.Self;
    public int Weight => 1;
    public int Quantity { get; set; } = 1;
    private int _healValue = 20;

    public void Use(IDamageable target)
    {
        if (Quantity > 0)
        {
            target.Heal(_healValue);
            Quantity--;
        }
    }
}