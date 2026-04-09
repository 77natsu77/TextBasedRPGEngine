public interface IConsumable : IInventoryItem
{
    TargetType SuggestedTarget { get; }
    void Use(IDamageable target);
}