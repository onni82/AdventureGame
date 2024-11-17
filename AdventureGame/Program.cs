﻿using System;
using System.Collections.Generic;
using System.Xml.Linq;

namespace AdventureGame
{
	class Program
	{
		static void Main(string[] args)
		{
			// Helper method to create a new player
			Entity CreateNewPlayer()
			{
				Entity newPlayer = new Entity
				{
					Name = args.Length > 0 ? args[0] : GetPlayerName(),
					Health = 100,
					Level = 1,
					Experience = 0
				};
				return newPlayer;
			}

			// Helper method to get player name
			static string GetPlayerName()
			{
				Console.Write("Enter your character's name: ");
				return Console.ReadLine();
			}

			Entity user;
			Inventory inventory = new Inventory();
			int storyStage = 0; // Track the story stage

			Console.WriteLine("Welcome to the Adventure Game!");
			Console.WriteLine("Would you like to load a previous game? (Y/N): ");
			string loadChoice = Console.ReadLine().ToLower();

			if (loadChoice == "y")
			{
				if (SaveGame.Load(out user, out inventory, out storyStage))
				{
					// Game successfully loaded
					Console.WriteLine(value: $"Welcome back, {user.Name}!");
				}
				else
				{
					// No save found or error during loading
					user = CreateNewPlayer();
					Console.WriteLine($"New player created: {user.Name}.");
				}
			}
			else
			{
				user = CreateNewPlayer();
				Console.WriteLine($"New player created: {user.Name}.");
			}

			// Jump to the story stage where the player left off
			switch (storyStage)
			{
				case 0:
					Console.WriteLine($"Hello {user.Name}. Let's start your adventure. You start with two potions.");
					Functions.ClearScreen();
					inventory.AddItem("Potion", 2);
					inventory.SortByName();
					storyStage = 1;
					SaveGame.Save(user, inventory, storyStage);
					goto case 1;

				case 1:
					Entity orc = new() { Name = "Zug Zug the Orc", Health = 25, Level = 0 };
					Functions.BattleEntity(user, orc, inventory);
					Functions.ClearScreen();
					inventory.AddItem("Potion", 5);
					storyStage = 2;
					SaveGame.Save(user, inventory, storyStage);
					goto case 2;

				case 2:
					Entity elf = new() { Name = "Elven King", Health = 25, Level = 0 };
					Functions.BattleEntity(user, elf, inventory);
					Functions.ClearScreen();
					inventory.AddItem("Greater Potion", 10);
					storyStage = 3;
					SaveGame.Save(user, inventory, storyStage);
					goto case 3;

				case 3:
					Entity ent = new() { Name = "Ent", Health = 30, Level = 1 };
					Functions.BattleEntity(user, ent, inventory);
					Functions.ClearScreen();
					storyStage = 4;
					SaveGame.Save(user, inventory, storyStage);
					goto case 4;

				case 4:
					Console.WriteLine("Congratulations! You finished the game.");
					Functions.ClearScreen();
					break;
			}
		}
	}
}
