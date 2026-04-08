public interface IDamageable
{
    string Name { get; }
    int Health { get; }
    int MaxHealth { get; }
    bool IsAlive { get; }
    
    void TakeDamage(int amount);
    void Heal(int amount);
}