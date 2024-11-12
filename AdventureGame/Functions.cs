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

			while (true)
			{
				if (player.Health < 1)
				{
					Console.WriteLine($"Player {player.Name} died. Running away from battle.");
					break;
				}
				if (enemy.Health < 1)
				{
					Console.WriteLine($"{enemy.Name} died.");
					player.RewardExp((enemy.Level + 1) * 15);
					player.LevelUp();
					break;
				}

				Console.WriteLine("What do you want to do? (A)ttack, (I)tem or (R)un?: ");
				char optionInBattle = Console.ReadKey().KeyChar;
				Console.WriteLine();

				if (optionInBattle == 'r' || optionInBattle == 'R')
				{
					Console.WriteLine($"Player {player.Name} ran away from battle.");
					break;
				}

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
							break;
						}

						for (int i = 0; i < itemList.Count; i++)
							Console.WriteLine($"[{i}] {itemList[i].Amount} {itemList[i].Name}. {itemList[i].GetItemDescription()}.");

						Console.Write("Your pick: ");
						if (int.TryParse(Console.ReadLine(), out int itemToUse) && itemToUse < itemList.Count)
						{
							ItemManager.UseItem(itemList, itemList[itemToUse].Name, player);
						}
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
