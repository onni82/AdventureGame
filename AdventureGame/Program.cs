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
			Functions.ClearScreen();

			Inventory inventory = new();
			inventory.AddItem("Potion", 2);

			Entity orc = new() { Name = "Zug Zug the Orc", Health = 25, Level = 0 };
			inventory.SortByName();
			BattleEntity(user, orc, inventory);
			Functions.ClearScreen();

			inventory.AddItem("Potion", 5);
			inventory.SortByName();

			Entity elf = new() { Name = "Elven King", Health = 25, Level = 0 };
			inventory.SortByName();
			BattleEntity(user, elf, inventory);
			Functions.ClearScreen();

			inventory.AddItem("Greater Potion", 10);
			inventory.SortByName();
			Functions.ClearScreen();

			Entity ent = new() { Name = "Ent", Health = 30, Level = 1 };
			inventory.SortByName();
			BattleEntity(user, ent, inventory);
			Functions.ClearScreen();

			Console.WriteLine("Congratulations! You finished the game.");
			Functions.ClearScreen();
		}
	}
}
