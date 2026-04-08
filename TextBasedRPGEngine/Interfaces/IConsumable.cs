public interface IConsumable : IInventoryItem
{
    void Use(IDamageable target);
}