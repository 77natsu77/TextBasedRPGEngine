using System.Linq; // Useful for calculating weight sums easily

public class Inventory
{
    private List<IInventoryItem> _items = new List<IInventoryItem>();
    public int MaxWeight { get; }

    // This allows other classes to SEE the items but not MODIFY the list directly
    // Also, we clean up any items with 0 quantity before showing the list
    public IReadOnlyList<IInventoryItem> Items 
    {
        get 
        {
            _items.RemoveAll(i => i.Quantity <= 0);
            return _items.AsReadOnly();
        }
    }

    public int CurrentWeight => _items.Sum(item => item.TotalWeight);

    public Inventory(int maxWeight)
    {
        MaxWeight = maxWeight;
    }

    public bool AddItem(IInventoryItem newItem)
    {
        if (CurrentWeight + newItem.TotalWeight > MaxWeight)
        {
            Console.WriteLine($"Too heavy! Cannot add {newItem.Name}.");
            return false;
        }

        // Check if we already have this item to stack the quantity
        var existing = _items.FirstOrDefault(i => i.Name == newItem.Name);
        if (existing != null)
        {
            existing.Quantity += newItem.Quantity;
        }
        else
        {
            _items.Add(newItem);
        }
        return true;
    }

}