public class Battle
{
    private static readonly Random _random = new Random(); 
    public BattleResult Start(List<Hero> party, List<IDamageable> enemies)
    {
        while (party.Any(h => h.IsAlive) && enemies.Any(e => e.IsAlive))
        {
            foreach (var hero in party.Where(h => h.IsAlive))
            {
                Console.WriteLine($"\n--- {hero.Name}'s Turn ---");
                Console.WriteLine($"\n{hero.Name}'s Health: {hero.Health}/{hero.MaxHealth}");

                var actions = hero.GetPossibleActions();

                Console.WriteLine("\nChoose an action:");
                for (int i = 0; i < actions.Count; i++)
                {
                    Console.WriteLine($"{i + 1}. {actions[i].Name}");
                }

                if (!int.TryParse(Console.ReadLine(), out int raw)) raw = 1;
                int choice = raw - 1;

                 if (choice >= 0 && choice < actions.Count)
                {
                    IAction selectedAction = actions[choice];

                    List<IDamageable> validTargets;

                    if (selectedAction.SuggestedTarget == TargetType.Self)
                    {
                        validTargets = new List<IDamageable> { hero };
                    }
                    else if (selectedAction.SuggestedTarget == TargetType.Enemy)
                    {
                        // Filter out the heros, only show others
                        validTargets = enemies.ToList();
                    }
                    else if (selectedAction.SuggestedTarget == TargetType.Ally)
                    {
                        //select every hero except the current one
                        validTargets = party.Where(h => h != hero).Cast<IDamageable>().ToList();
                    }
                    else
                    {//anyone could be a target
                        validTargets = party.Cast<IDamageable>().Concat(enemies).ToList();
                    }

                    // Now show the filtered list to the player
                    for (int i = 0; i < validTargets.Count; i++)
                    {
                        Console.WriteLine($"{i + 1}. {validTargets[i].Name}");
                    }
                    if (!int.TryParse(Console.ReadLine(), out int targetRaw)) targetRaw = 1;
                    int targetChoice = targetRaw - 1;
                    if (targetChoice >= 0 && targetChoice < validTargets.Count)
                    {
                        IDamageable selectedTarget = validTargets[targetChoice];
                        selectedAction.Execute(hero, selectedTarget);
                    }
                    else
                    {
                        Console.WriteLine("Invalid target choice. Skipping turn.");
                    }
                }
                else
                {
                    Console.WriteLine("Invalid action choice. Skipping turn.");
                }
            }

            foreach (var enemy in enemies.Where(e => e.IsAlive))
            {
                 Console.WriteLine($"\n--- {enemy.Name}'s Turn ---");
                 Console.WriteLine($"{enemy.Name}'s Health: {enemy.Health}/{enemy.MaxHealth}");

                // Simple AI: Pick a random living hero and attack
                var livingHeroes = party.Where(h => h.IsAlive).ToList();
                if (livingHeroes.Any())
                {
                    var targetHero = livingHeroes[_random.Next(livingHeroes.Count)];
                    Console.WriteLine($"{enemy.Name} attacks {targetHero.Name}!");
                    targetHero.TakeDamage(10); // Enemy does fixed damage for demo
                }
            }
            
            //display who is alive or dead
            Console.WriteLine("\n--- End of Round ---");
            Console.WriteLine("Party Status:");
            foreach (var hero in party)            {
                Console.WriteLine($"{hero.Name}: {(hero.IsAlive ? "Alive" : "Dead")} (Health: {hero.Health}/{hero.MaxHealth})");
            }
            Console.WriteLine("\nEnemy Status:");
            foreach (var enemy in enemies)            {
                Console.WriteLine($"{enemy.Name}: {(enemy.IsAlive ? "Alive" : "Dead")} (Health: {enemy.Health}/{enemy.MaxHealth})");
            }
        }
        
        if (!party.Any(h => h.IsAlive)) return BattleResult.Defeat;
        if (!enemies.Any(e => e.IsAlive)) return BattleResult.Victory;
        //havent implemented fleeing logic yet
        return BattleResult.Fled;
    }
}