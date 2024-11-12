using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdventureGame
{
	public class Inventory
	{
		private List<Item> inventory;
		private readonly object lockObject = new object();

        public Inventory()
        {
			inventory = new List<Item>();
        }

        public Item? IsItemInInventory(string itemName)
		{
			var item = inventory.Find(item => item.Name == itemName);

			if (item != null)
			{
				return item;
			}
			else
			{
				return null;
			}
			
		}
		public void AddItem(string itemName, int itemAmount)
		{
			lock (lockObject)
			{

			}
			var item = inventory.Find(item => item.Name == itemName);

			if (item != null)
			{
				item.Amount += itemAmount;
				
			}
			else
			{
				item = new Item { Name = itemName, Amount = itemAmount };
				inventory.Add(item);
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

		public void UseItem(List<Item> itemList, string itemName, Entity player)
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
	}
}
