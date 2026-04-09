public interface IEquippable : IInventoryItem
{
    void Equip(IAttacker attacker);
    void Unequip(IAttacker attacker);
}