﻿using System;
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
		public int Count => inventory.Count; // Enables the Count() method that is usually just usable on Lists and not custom classes
		public Item this[int index] => inventory[index]; // Enables indexing

		public Inventory()
        {
			inventory = new List<Item>();
        }

		// Checks if item is in inventory and returns item
		// Returns null if not found
        public Item? IsItemInInventory(string itemName)
		{
			return inventory.Find(item => item.Name == itemName);
			
		}

		// Adds item to inventory
		public void AddItem(string itemName, int itemAmount)
		{
			lock (lockObject)
			{
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
		}

		// Uses item and decreases amount in inventory
		public void UseItem(string itemName, Entity player)
		{
			var item = inventory.Find(item => item.Name == itemName);

			if (item != null)
			{
				item.Use(player);
				item.Amount -= 1;
				Console.WriteLine($"Used {itemName} on {player.Name}.");

				if (item.Amount == 0)
				{
					inventory.Remove(item);
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
		public void SortByAmount(bool descending = true)
		{
			lock (lockObject)
			{
				inventory = descending
					? inventory.OrderByDescending(item => item.Amount).ToList()
					: inventory.OrderBy(item => item.Amount).ToList();
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
