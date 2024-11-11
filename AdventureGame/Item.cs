namespace AdventureGame
{
	// Define the Item class to represent items in the player's inventory
	public class Item : IComparable<Item>
	{
		public string Name { get; set; }  // Name of the item
		public int Amount { get; set; }   // Quantity of the item

		public int CompareTo(Item? other)
		{
			// Handle null cases
			if (other == null) return 1;

			// Compare by Name
			return Name.CompareTo(other.Name);
		}

		public override string ToString()
		{
			if (Amount < 2)
			{
				return $"{Amount} {Name}";
			}
			else
			{
				return $"{Amount} {Name}s";
			}
			
		}

		private static readonly Dictionary<string, string> descriptions = new()
		{
			{ "Potion", "Heals 15 HP per item" },
			{ "Greater Potion", "Heals 25 HP per item" }
		};

		public static string GetItemDescription(string itemName)
		{
			// Try to get the description from the dictionary
			return descriptions.TryGetValue(itemName, out string description)
				? description
				: "No description";
		}
	}
}
