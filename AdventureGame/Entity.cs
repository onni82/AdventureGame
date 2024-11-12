namespace AdventureGame
{
	// Define the Entity class to represent a player or enemy character
	public class Entity
	{
		public string Name { get; set; }    // Name of the entity
		public int MaxHealth { get; set; }     // Health points of the entity
		public int Health { get; set; }		// Health points of the entity
		public int Level { get; set; }		// Level of the entity
		public int Experience { get; set; }	// Current experience points

		// Amount of experience needed to level up per level
		private static readonly Dictionary<int, int> requiredExperience = new()
		{
			{ 0, 50 },
			{ 1, 100 },
			{ 2, 150 },
			{ 3, 200 },
			{ 4, 250 },
			{ 5, 300 },
			{ 6, 350 },
			{ 7, 400 },
			{ 8, 450 },
			{ 9, 500 },
			{ 10, 550 },
			{ 11, 600 },
			{ 12, 650 },
			{ 13, 700 }
		};

		// Retrieves amount of experince points needed to level up
		public int GetRequiredExperience()
		{
			// Try to get the description from the dictionary
			return requiredExperience.TryGetValue(Level, out int experience)
				? experience
				: 0;
		}

		// Rewards entity with set amount of experience points
		public void RewardExp(int experienceAmount)
		{
			if (experienceAmount > 0)
			{
				Experience += experienceAmount;
				Console.WriteLine($"Player {Name} gained {experienceAmount} experience.");
				LevelUp();
			}
			else
			{
				Console.WriteLine("Invalid experience amount.");
			}
		}

		// Increases entity level if required experience points are met
		public void LevelUp()
		{
			while (Experience >= GetRequiredExperience())
			{
				Level++;
				MaxHealth = 100 + Level * 10; // Example of increasing max health per level
				Health = 100 + Level * 10; // Heals player on level up
				Console.WriteLine($"{Name} leveled up to level {Level + 1}, health and max health is now {MaxHealth}.");
			}
		}

		// Gets a string from Console.ReadLine
		public string GetPlayerName()
		{
			Console.Write("What's your name? ");
			return Console.ReadLine();
		}
	}
}
