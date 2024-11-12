using System;
using System.Collections.Generic;
using System.Xml.Linq;

namespace AdventureGame
{
	class Program
	{
		static void Main(string[] args)
		{
			Entity user = new Entity
			{
				Name = args.Length > 0 ? args[0] : GetPlayerName(),
				MaxHealth = 120,
				Health = 120,
				Level = 0,
				Experience = 0
			};
			

			Console.WriteLine($"Hello {user.Name}. Let's start your adventure. You start with two potions.");
			Functions.ClearScreen();

			// Initialize inventory and items
			Inventory inventory = new Inventory();
			inventory.AddItem("Potion", 2);
			inventory.SortByName();

			// First battle: Orc Zug Zug
			Entity orc = new() { Name = "Zug Zug the Orc", Health = 25, MaxHealth = 25, Level = 0 };
			inventory.SortByName();
			Functions.BattleEntity(user, orc, inventory);
			Functions.ClearScreen();

			// The player finds a mysterious path to the forest
			Console.WriteLine("You have successfully defeated Zug Zug the Orc. A mysterious path lies ahead. Do you wish to explore it?");
			string pathChoice = Console.ReadLine().ToLower();

			if (pathChoice == "yes")
			{
				// The player enters the forest
				Console.WriteLine("You venture into the dense forest...");
				Functions.ClearScreen();

				// Encounter with the Elven King
				inventory.AddItem("Potion", 5);
				inventory.SortByName();

				Entity elf = new Entity { Name = "Elven King", MaxHealth = 25, Health = 25, Level = 0 };
				Functions.BattleEntity(user, elf, inventory);
				Functions.ClearScreen();
			}
			else
			{
				// If the player doesn't explore the forest
				Console.WriteLine("You choose not to explore the forest and head towards the town.");
				Functions.ClearScreen();
			}

			// Reward system and healing
			Console.WriteLine($"You earned {10} experience for defeating {elf.Name}.");
			user.Experience += 10;
			user.LevelUp();  // Level up the player if enough experience is gained
			Console.WriteLine($"{user.Name} is now level {user.Level + 1}!");
			Functions.ClearScreen();

			// Adding new powerful item: Greater Potion
			inventory.AddItem("Greater Potion", 10);
			inventory.SortByName();

			// Battle with an Ent in the forest
			Entity ent = new Entity { Name = "Ent", MaxHealth = 30, Health = 30, Level = 1 };
			Functions.BattleEntity(user, ent, inventory);
			Functions.ClearScreen();

			// Player earns a magical sword after the battle
			Console.WriteLine("You find a magical sword after defeating the Ent. This powerful weapon will help you in future battles.");
			inventory.AddItem("Magic Sword", 1);

			// Encounter with the final boss
			Console.WriteLine("You reach the deepest part of the forest where the ancient dragon awaits...");
			Entity dragon = new Entity { Name = "Ancient Dragon", MaxHealth = 100, Health = 100, Level = 2 };
			Functions.BattleEntity(user, dragon, inventory);
			Functions.ClearScreen();

			// Final message and congratulations
			Console.WriteLine("Congratulations! You have defeated the Ancient Dragon and saved the kingdom.");
			Console.WriteLine("Your adventure ends here, but many more await you!");
			Functions.ClearScreen();
		}

		// Helper method to get player name
		static string GetPlayerName()
		{
			Console.Write("Enter your character's name: ");
			return Console.ReadLine();
		}
	}
}
