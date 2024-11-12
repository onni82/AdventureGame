using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdventureGame
{
	public class Inventory : IEnumerable<Item>
	{
		private List<Item> inventory;
		private readonly object lockObject = new object();
		public int Count => inventory.Count;


		public Inventory()
        {
			inventory = new List<Item>();
        }

		// Checks if item is in inventory and returns item
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

		// Adds item to inventory
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

		// Uses item and decreases amount in inventory
		public void UseItem(string itemName, Entity player)
		{
			var item = inventory.Find(item => item.Name == itemName);

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
					var index = inventory.FindIndex(item => item.Name == itemName);
					inventory.RemoveAt(index);
				}
			}
		}

		// Sorts items by Name
		public void SortByName()
		{
			lock (lockObject)
			{
				inventory = inventory.OrderBy(item => item.Name).ToList();
			}
		}

		// Sorts items by Amount
		public void SortByAmount()
		{
			lock (lockObject)
			{
				inventory = inventory.OrderByDescending(item => item.Amount).ToList();
			}
		}

		// IEnumerable implementation to enable foreach and LINQ support
		public IEnumerator<Item> GetEnumerator()
		{
			return inventory.GetEnumerator();
		}

		IEnumerator IEnumerable.GetEnumerator()
		{
			return GetEnumerator();
		}
	}
}
