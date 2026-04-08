class Program
{
    static void Main()
    {
        // Setup the Hero
        Hero player = new Hero("Arin the Brave", 100, 10);

        // Setup Equipment & Items
        Sword rustySword = new Sword();
        HealthPotion potion = new HealthPotion(); 

        // Give them to the Hero
        player.Inventory.AddItem(potion);
        rustySword.Equip(player); // This adds 'Slash' to player.CombatMoves

        // Setup an Enemy (Any IDamageable)
        // For now, let's just use another Hero instance as a "Training Dummy"
        Hero trainingDummy = new Hero("Wooden Dummy", 50, 0);

        // Start the Battle
        Battle arena = new Battle();
        arena.Start(player, trainingDummy);
    }
}