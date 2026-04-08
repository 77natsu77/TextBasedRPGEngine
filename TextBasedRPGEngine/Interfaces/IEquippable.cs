public interface IEquippable : IInventoryItem
{
    void Equip(Hero hero);
    void Unequip(Hero hero);
}