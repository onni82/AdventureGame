using System;
using System.Collections.Generic;

namespace AdventureGame
{
	class Program
	{
		static void Main(string[] args)
		{
			Entity user = new Entity { Name = args.Length > 0 ? args[0] : GetPlayerName() };
			user.Health = 20;
			user.Level = 0;
			user.Experience = 0;

			Console.WriteLine($"Hello {user.Name}. Let's start your adventure. You start with two potions.");
			ClearScreen();

			List<Item> inventory = new() { new Item { Name = "Potion", Amount = 2 } };

			Entity orc = new() { Name = "Zug Zug the Orc", Health = 25, Level = 0 };
			inventory.Sort();
			BattleEntity(user, orc, inventory);
			ClearScreen();

			AddItem(inventory, "Potion", 5);
			inventory.Sort();

			Entity elf = new() { Name = "Elven King", Health = 25, Level = 0 };
			inventory.Sort();
			BattleEntity(user, elf, inventory);
			ClearScreen();

			AddItem(inventory, "Greater Potion", 10);
			inventory.Sort();
			ClearScreen();

			Entity ent = new() { Name = "Ent", Health = 30, Level = 1 };
			inventory.Sort();
			BattleEntity(user, ent, inventory);
			ClearScreen();

			Console.WriteLine("Congratulations! You finished the game.");
			ClearScreen();
		}
	}
}
