namespace AdventureGame
{
	// Define the Entity class to represent a player or enemy character
	public class Entity
	{
		public string Name { get; set; }	// Name of the entity
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

		public int GetRequiredExperience()
		{
			// Try to get the description from the dictionary
			return requiredExperience.TryGetValue(Level, out int experience)
				? experience
				: 0;
		}

		public void RewardExp(int experienceAmount)
		{
			Experience += experienceAmount;
			Console.WriteLine($"Player {Name} gained {experienceAmount} experience.");
			LevelUp();
		}

		public void LevelUp()
		{
			while (Experience >= GetRequiredExperience())
			{
				Level++;
				Console.WriteLine($"{Name} leveled up to level {Level + 1}.");
			}
		}
	}
}
