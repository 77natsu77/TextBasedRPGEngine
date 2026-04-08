public class Battle
{
    public void Start(Hero hero, IDamageable enemy)
    {
        Console.WriteLine($"A wild {enemy.Name} appears!");
        
        while (hero.IsAlive && enemy.IsAlive)
        {
            Console.WriteLine($"\n{hero.Name}'s Health: {hero.Health}/{hero.MaxHealth}");
            Console.WriteLine($"{enemy.Name}'s Health: {enemy.Health}/{enemy.MaxHealth}");
            
            
            // Show possible actions
            var actions = hero.GetPossibleActions();
            Console.WriteLine("\nChoose an action:");
            for (int i = 0; i < actions.Count; i++)
            {
                Console.WriteLine($"{i + 1}. {actions[i].Name}");
            }
            
            int choice = int.Parse(Console.ReadLine() ?? "1") - 1;
            if (choice >= 0 && choice < actions.Count)
            {
                hero.Attack(actions[choice], enemy);
                
                if (enemy.IsAlive)
                {
                    // Enemy's turn to attack (simplified)
                    Console.WriteLine($"{enemy.Name} strikes back!");
                    hero.TakeDamage(10); // Enemy does fixed damage for demo
                }
            }
        }

        if (hero.IsAlive)
            Console.WriteLine($"{hero.Name} has defeated {enemy.Name}!");
        else
            Console.WriteLine($"{hero.Name} has been defeated by {enemy.Name}...");
    }
}