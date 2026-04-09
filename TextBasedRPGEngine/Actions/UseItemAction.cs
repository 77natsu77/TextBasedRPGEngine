public class UseItemAction : IAction
{
    private IConsumable _item;
   public TargetType SuggestedTarget => _item.SuggestedTarget;
    public string Name => $"Use {_item.Name} ({_item.Quantity})";

    public UseItemAction(IConsumable item)
    {
        _item = item;
    }

    public void Execute(IAttacker actor, IDamageable target)
    {
        // We assume the actor is the one using the item on themselves (target)
        _item.Use(target);
    }
}