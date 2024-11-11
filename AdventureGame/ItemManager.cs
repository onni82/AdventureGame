using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdventureGame
{
	public class ItemManager
	{
		public static Item? IsItemInInventory(List<Item> itemList, string itemName)
		{
			var item = itemList.Find(item => item.Name == itemName);

			if (item != null)
			{
				return item;
			}
			else
			{
				return null;
			}
			
		}
		public static void AddItem(List<Item> itemList, string itemName, int itemAmount)
		{
			var item = itemList.Find(item => item.Name == itemName);

			if (item != null)
			{
				item.Amount += itemAmount;
				
			}
			else
			{
				item = new Item { Name = itemName, Amount = itemAmount };
				itemList.Add(item);
			}

			if (itemAmount > 1)
			{
				Console.WriteLine($"Picked up {itemAmount} {item.Name}s. Now a total of {item.Amount}.");
			}
			else
			{
				Console.WriteLine($"Picked up {itemAmount} {item.Name}. Now a total of {item.Amount}.");
			}
		}

		public static void UseItem(List<Item> itemList, string itemName, Entity player)
		{
			var item = itemList.Find(item => item.Name == itemName);

			if (item != null)
			{
				if (itemName == "Potion")
				{
					player.Health += 15;
				}
				else if (itemName == "Greater Potion")
				{
					player.Health += 25;
				}

				item.Amount -= 1;
				Console.WriteLine($"Used {itemName} on {player.Name}.");

				if (item.Amount == 0)
				{
					var index = itemList.FindIndex(item => item.Name == itemName);
					itemList.RemoveAt(index);
				}
			}
		}

		//public static string GetItemDescription(string itemName)
		//{
		//	return itemName switch
		//	{
		//		"Potion" => "Heals 15 HP per item",
		//		"Greater Potion" => "Heals 25 HP per item",
		//		_ => "No description"
		//	};
		//}
	}
}
