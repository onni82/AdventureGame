using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdventureGame
{
	public class Functions
	{
		// Clears screen after reading a key
		public static void ClearScreen()
		{
			Console.WriteLine("Hit a key to proceed.");
			Console.ReadKey();
			Console.Clear();
		}

		// Calls a battle
		// Accepts a player object, enemy object and inventory to be used during battle
		public static void BattleEntity(Entity player, Entity enemy, Inventory inv)
		{
			Console.WriteLine($"Initiating battle with level {enemy.Level + 1} {enemy.Name} who has {enemy.Health} HP.");
			Console.WriteLine($"Level {player.Level + 1} player {player.Name} has {player.Health} HP.");
			ClearScreen();

			bool battleInProgress = true;
			while (battleInProgress) // Makes the battle an infinite loop until battleInProgress = false
			{
				if (player.Health < 1) // Checks if player health is below 1
				{
					Console.WriteLine($"Player {player.Name} died. Running away from battle.");
					battleInProgress = false;
					break;
				}
				if (enemy.Health < 1) // Checks if enemy health is below 1
				{
					Console.WriteLine($"{enemy.Name} died.");
					player.RewardExp((enemy.Level + 1) * 15);
					player.LevelUp();
					battleInProgress = false;
					break;
				}

				// Asks for option in battle menu
				Console.WriteLine("What do you want to do? (A)ttack, (I)tem or (R)un?: ");
				char optionInBattle = Console.ReadKey().KeyChar;
				Console.WriteLine();

				// Checks for user option to run before doing switch case
				if (optionInBattle == 'r' || optionInBattle == 'R')
				{
					Console.WriteLine($"Player {player.Name} ran away from battle.");
					battleInProgress = false;
					break;
				}

				// Switch case that checks user option in battle menu
				switch (optionInBattle)
				{
					case 'a' or 'A':
						Console.WriteLine($"Player {player.Name} attacks {enemy.Name}.");
						enemy.Health -= (player.Level + 1) * 10;
						Console.WriteLine($"{enemy.Name} lost 10 HP.");
						break;

					case 'i' or 'I':
						if (inv.Count == 0)
						{
							Console.WriteLine("You have no items in your inventory.");
							ClearScreen();
							return; // Exit the current case block and go back to the start of the loop
						}

						for (int i = 0; i < inv.Count; i++)
							Console.WriteLine($"[{i}] {inv[i].Amount} {inv[i].Name}. {inv[i].GetItemDescription()}.");

						Console.Write("Your pick: ");
						if (int.TryParse(Console.ReadLine(), out int itemToUse) && itemToUse < inv.Count)
						{
							inv.UseItem(inv[itemToUse].Name, player);
						}
						break;

					default:
                        Console.WriteLine("Invalid optioin! Try again.");
						break;
				}

				if (enemy.Health > 0)
				{
					Console.WriteLine($"{enemy.Name} attacks {player.Name}. {player.Name} lost 10 HP.");
					player.Health -= (enemy.Level + 1) * 10;
				}

				ClearScreen();
			}
		}
	}
}
