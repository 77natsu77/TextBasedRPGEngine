public interface IAction
{
    string Name { get; }
    TargetType SuggestedTarget { get; }
    void Execute(IAttacker actor, IDamageable target);
}