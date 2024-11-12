using System;
using System.Collections.Generic;
using System.Xml.Linq;

namespace AdventureGame
{
	class Program
	{
		static void Main(string[] args)
		{
			Entity user = new Entity();
			user.Name = args.Length > 0 ? args[0] : user.GetPlayerName();
			user.Health = 20;
			user.Level = 0;
			user.Experience = 0;

			Console.WriteLine($"Hello {user.Name}. Let's start your adventure. You start with two potions.");
			ClearScreen();

			Inventory inventory = new();
			inventory.AddItem("Potion", 2);

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
