public interface IAction
{
    string Name { get; }
    void Execute(IAttacker actor, IDamageable target);
}