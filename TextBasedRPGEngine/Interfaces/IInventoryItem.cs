public interface IInventoryItem
{
    string Name { get; }
    string Description { get; }
    int Weight { get; }      // Weight of a single unit
    int Quantity { get; set; }
    
    // Calculated property: Weight * Quantity
    int TotalWeight => Weight * Quantity; 
}