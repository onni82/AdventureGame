namespace AdventureGame
{
	// Define the Item class to represent items in the player's inventory
	public class Item : IComparable<Item>
	{
		public string Name { get; set; }  // Name of the item
		public int Amount { get; set; }   // Quantity of the item

		// Implements CompareTo from IComparable interface to enable .Sort()
		public int CompareTo(Item? other)
		{
			// Handle null cases
			if (other == null) return 1;

			// Compare by Name
			return Name.CompareTo(other.Name);
		}

		// Overrides ToString()
		// Prints amount + item name and adds S at the end if plural
		public override string ToString()
		{
			var itemName = Amount < 2 ? Name : Name + "s";
			return $"{Amount} {itemName}";
			
		}

		// Dictionary of all item descriptions
		private static readonly Dictionary<string, string> descriptions = new()
		{
			{ "Potion", "Heals 15 HP per item" },
			{ "Greater Potion", "Heals 25 HP per item" }
		};

		// Try to retreive the item description using previously written Dictionary
		// Set to "no description" if item name not found in Dictionary descriptions
		public string GetItemDescription()
		{
			// Try to get the description from the dictionary
			return descriptions.TryGetValue(Name, out string description)
				? description
				: $"No description for {Name}";
		}
	}
}
